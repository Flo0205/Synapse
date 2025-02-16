﻿using System;
using HarmonyLib;
using Mirror;
using UnityEngine;
using ev = Synapse.Api.Events.EventHandler;

namespace Synapse.Patches.EventsPatches.ScpPatches.Scp939
{
    [HarmonyPatch(typeof(PlayableScps.Scp939),nameof(PlayableScps.Scp939.ServerAttack))]
    internal static class Scp939AttackPatch
    {
        [HarmonyPrefix]
        private static bool Scp939Attack(PlayableScps.Scp939 __instance, GameObject target, out bool __result)
        {
            __result = false;
            try
            {
                var scp = __instance.GetPlayer();

                if(target.TryGetComponent<BreakableWindow>(out var window))
                {
                    window.Damage(50f, null, new Footprinting.Footprint(scp.Hub), Vector3.zero);
                    __result = true;
                }
                else
                {
                    var targetplayer = target.GetPlayer();

                    if (!SynapseExtensions.GetHarmPermission(scp, targetplayer)) return false;

                    ev.Get.Scp.InvokeScpAttack(scp, targetplayer, Api.Enum.ScpAttackType.Scp939_Bite, out var allow);

                    if (!allow) return false;

                    scp.PlayerStats.HurtPlayer(new PlayerStats.HitInfo(50f, scp.Hub.LoggedNameFromRefHub(),
                      DamageTypes.Scp939, scp.PlayerId, false), target, false, true);
                    scp.ClassManager.RpcPlaceBlood(targetplayer.Position, 0, 2f);

                    targetplayer.PlayerEffectsController.EnableEffect<CustomPlayerEffects.Amnesia>(3f, true);
                    __result = true;
                }

                return false;
            }
            catch(Exception e)
            {
                Synapse.Api.Logger.Get.Error($"Synapse-Event: ScpAttackEvent(Scp939) failed!!\n{e}");
                return true;
            }
        }
    }
}
