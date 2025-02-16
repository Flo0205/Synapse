﻿using Assets._Scripts.Dissonance;
using Synapse.Api.Items;
using System.Collections.Generic;
using UnityEngine;
using InventorySystem.Items.MicroHID;
using Synapse.Api.Enum;
using System;

// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace Synapse.Api.Events.SynapseEventArguments
{
    public class PlayerJoinEventArgs: EventHandler.ISynapseEventArgs
    {
        public Player Player { internal set; get; }
        
        public string Nickname { set; get; }
    }

    public class PlayerLeaveEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }
    }
    
    public class PlayerBanEventArgs : EventHandler.ISynapseEventArgs
    {
        public bool Allow { get; set; } = true;
        
        public Player BannedPlayer { get; internal set; }
        
        public Player Issuer { get; internal set; }
        
        public long BanDuration { get; set; }

        [Obsolete("Use BanDuration",true)]
        public int Duration
        {
            get => (int)BanDuration;
            set => BanDuration = value;
        }
        
        public string Reason { get; set; }
    }

    public class PlayerSpeakEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }
        
        public DissonanceUserSetup DissonanceUserSetup { get; internal set; }

        public bool Scp939Talk { get; set; }
        
        public bool IntercomTalk { get; set; }
        
        public bool RadioTalk { get; set; }
        
        public bool ScpChat { get; set; }
        
        public bool SpectatorChat { get; set; }
        
        public bool Allow { get; set; }
    }

    public class PlayerDeathEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Victim { get; internal set; }
        
        public Player Killer { get; internal set; }
        
        public PlayerStats.HitInfo HitInfo { get; internal set; }
    }

    public class PlayerDamageEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Killer { get; internal set; }
        
        public Player Victim { get; internal set; }
       
        public float DamageAmount
        {
            get => HitInfo.Amount;
            set
            {
                var info = HitInfo;
                info.Amount = value;
                HitInfo = info;
            }
        }

        public PlayerStats.HitInfo HitInfo { get; set; }

        public bool Allow { get; set; } = true;
    }

    public class LoadComponentEventArgs : EventHandler.ISynapseEventArgs
    {
        public GameObject Player { get; internal set; }
    }
    
    public class PlayerItemInteractEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }
        
        public ItemInteractState State { get; internal set; }
        
        public Items.SynapseItem CurrentItem { get; internal set; }
        
        public bool Allow { get; set; }
    }

    public class PlayerThrowGrenadeEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public Items.SynapseItem Item { get; internal set; }

        [Obsolete("Removed Since 11.0.0")]
        public float ForceMultiplier { get; set; }
        
        [Obsolete("Removed since 11.0.0")]
        public float Delay { get; set; }
        
        public bool Allow { get; set; }
    }
    
    public enum ItemInteractState
    {
        Initiating,
        Finalizing,
        Stopping
    }

    public class PlayerHealEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }
        
        public float Amount { get; set; }
        
        public bool Allow { get; set; }
    }

    public class PlayerEscapeEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public int SpawnRole { get; set; }

        public bool Allow { get; set; }

        public bool ChangeTeam { get; set; }

        public bool IsClassD { get; set; }

        public bool IsCuffed => Player.IsCuffed;

        public Player Cuffer => Player.Cuffer;
    }

    public class PlayerSyncDataEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public bool Allow { get; set; } = true;
    }

    public class PlayerReloadEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public bool Allow { get; set; } = true;
        
        public Items.SynapseItem Item { get; internal set; }
    }

    public class PlayerEnterFemurEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public bool Allow { get; set; } = true;
        
        public bool CloseFemur { get; set; }
    }

    public class PlayerGeneratorInteractEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public Generator Generator { get; internal set; }

        public Enum.GeneratorInteraction GeneratorInteraction { get; internal set; }

        public bool Allow { get; set; }
    }

    public class PlayerKeyPressEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public KeyCode KeyCode { get; internal set; }
    }

    public class PlayerDropItemEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public Items.SynapseItem Item { get; internal set; }

        public bool Throw { get; set; }

        public bool Allow { get; set; }
    }

    public class PlayerPickUpItemEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public Items.SynapseItem Item { get; internal set; }

        public bool Allow { get; set; }
    }

    public class PlayerShootEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public Player Target { get; internal set; }

        public Vector3 TargetPosition { get; internal set; }

        public SynapseItem Weapon { get; internal set; }

        public bool Allow { get; set; }
    }

    public class PlayerSetClassEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public RoleType Role { get; set; }

        public List<SynapseItem> Items { get; set; }

        public Dictionary<AmmoType, ushort> Ammo { get; set; }

        public List<SynapseItem> EscapeItems { get; set; }

        public bool IsEscaping => SpawnReason == CharacterClassManager.SpawnReason.Escaped;

        public CharacterClassManager.SpawnReason SpawnReason { get; internal set; }

        public Vector3 Position { get; set; }

        public float Rotation { get; set; }

        public bool Allow { get; set; }

        /// <summary>
        /// This is only for Synapse to know if the object can be deleted by one of the patches
        /// </summary>
        internal bool CanBeDeleted { get; set; } = false;
    }

    public class PlayerStartWorkstationEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public WorkStation WorkStation { get; internal set; }

        public bool Allow { get; set; } = true;
    }

    public class PlayerConnectWorkstationEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        [Obsolete("Workstations no longer needs a Item")]
        public SynapseItem Item { get; internal set; }

        public WorkStation WorkStation { get; internal set; }

        public bool Allow { get; set; } = true;
    }

    public class PlayerUnconnectWorkstationEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public WorkStation WorkStation { get; internal set; }

        public bool Allow { get; set; } = true;
    }

    public class PlayerDropAmmoEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public AmmoType AmmoType { get; set; }

        public uint Amount { get; set; }

        public bool Allow { get; set; } = true;

        [Obsolete("Tablets are no longer required to drop ammo")]
        public SynapseItem Tablet { get; internal set; }
    }

    public class PlayerCuffTargetEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Target { get; internal set; }

        public Player Cuffer { get; internal set; }

        public bool Allow { get; set; } = true;

        [Obsolete("Disarmer are removed from the game")]
        public SynapseItem Disarmer { get; internal set; }
    }

    public class PlayerUseMicroEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public SynapseItem Micro { get; internal set; }

        public float Energy
        {
            get => Micro.Durabillity;
            set => Micro.Durabillity = value;
        }

        public HidState State { get; set; }
    }

    public class PlayerWalkOnSinkholeEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public SinkholeEnvironmentalHazard Sinkhole { get; internal set; }

        public bool Allow { get; set; }
    }

    public class PlayerReportEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Reporter { get; internal set; }

        public Player Target { get; internal set; }

        public string Reason { get; internal set; }

        public bool GlobalReport { get; set; }

        public bool Allow { get; set; } = true;
    }

    public class PlayerDamagePermissionEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Victim { get; internal set; }

        public Player Attacker { get; internal set; }

        public bool AllowDamage { get; set; }
    }

    public class PlayerUnCuffTargetEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public Player Cuffed { get; internal set; }

        public bool Allow { get; set; }

        [Obsolete("Disarmers does no longer exists")]
        public bool FreeWithDisarmer { get; internal set; }
    }

    public class PlayerChangeItemEventArgs : EventHandler.ISynapseEventArgs
    {
        public Player Player { get; internal set; }

        public bool Allow { get; set; } = true;

        public SynapseItem OldItem { get; internal set; }

        public SynapseItem NewItem { get; internal set; }
    }
}