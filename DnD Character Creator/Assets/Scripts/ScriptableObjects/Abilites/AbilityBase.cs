using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityBase : ScriptableObject
{
    public string abilityName;
    public float cooldownTime;
    public float activeTime;
    public Sprite abilityIcon;
    public string desciption;

    public virtual void Activate() { }
}
