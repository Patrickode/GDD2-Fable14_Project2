using System;
using UnityEngine;

[Serializable]
public struct AbilityInstance
{
    [Tooltip("The type of ability this instance holds.")]
    public Ability ability;
    [Tooltip("The amount of times this particular ability can be used.")]
    [Range(1, 20)] public int usages;
}