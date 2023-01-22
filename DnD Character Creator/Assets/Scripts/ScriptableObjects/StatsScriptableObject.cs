using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScriptableObject : ScriptableObject
{
    [SerializeField] private string thisName;

    [SerializeField] private int strength = 0;
    [SerializeField] private int movement = 0;
    [SerializeField] private int charm = 0;
    [SerializeField] private int intelligence = 0;
    [SerializeField] private int mystic = 0;

    [SerializeField] private List<AbilityBase> abilities = new List<AbilityBase>();

    #region Public Getters

    public void AddAbility(AbilityBase _newAbility)
    {
        abilities.Add(_newAbility);
    }

    public List<AbilityBase> GetAbilities()
    {
        return abilities;    
    }

    public string GetName()
    {
        return thisName;
    }
    public int GetStrength()
    {
        return strength;
    }
    
    public int GetMovement()
    {
        return movement;
    }
    public int GetCharm()
    {
        return charm;
    }
    public int GetIntelligence()
    {
        return intelligence;
    }
    public int GetMystic()
    {
        return mystic;
    }
    #endregion
}
