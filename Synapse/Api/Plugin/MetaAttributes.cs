﻿using System;
using Synapse.Api.Plugin;
using UnityEngine;

namespace Synapse.Api.Plugin
{
    /// <summary>
    /// A Annotation the marks a class/method as injected.
    /// This Attribute is generally not used for
    /// actual filtering but mostly for code readability
    /// </summary>
    public class Injected : Attribute { }
    
    /// <summary>
    /// A Annotation that marks a class/method as unstable.
    /// This Attribute should generally be applied to something
    /// that can be used from outside but has an incalculable
    /// outcome or might break other plugins and/or the framework
    /// itself in 
    /// </summary>
    public class Unstable : Attribute { }
    
    /// <summary>
    /// A Annotation that marks a class/method of a plugin as
    /// safe to use in another plugins
    /// </summary>
    public class API : Attribute { }
    
}