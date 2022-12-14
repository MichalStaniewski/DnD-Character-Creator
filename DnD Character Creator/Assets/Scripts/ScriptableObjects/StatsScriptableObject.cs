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

    //[SerializeField] private GameObject classPrefab;

    #region Public Getters
    /*public GameObject GetPrefab()
    {
        return classPrefab;
    }*/

    public string GetClassName()
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
