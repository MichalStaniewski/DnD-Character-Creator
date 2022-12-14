using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMain : MonoBehaviour
{
    [SerializeField] private List<ClassScriptableObject> availableClasses = new List<ClassScriptableObject>();

    private Dictionary<string, ClassScriptableObject> classDict = new Dictionary<string, ClassScriptableObject>();

    [SerializeField] private List<RaceScriptableObject> availableRaces = new List<RaceScriptableObject>();

    private Dictionary<string, RaceScriptableObject> raceDict = new Dictionary<string, RaceScriptableObject>();

    private int classNum = 5;

    private RaceScriptableObject test;

    [SerializeField] private int classIndex = 0;    
    [SerializeField] private int raceIndex = 0;

    private void Awake()
    {
        foreach (ClassScriptableObject _class in availableClasses)
        {
            classDict.Add(_class.GetClassName(), _class);
        }

        foreach (RaceScriptableObject _race in availableRaces)
        {
            raceDict.Add(_race.GetClassName(), _race);
        }
    }

    private void UpdateClassIndex()
    {
        //change visual
    } 

    private void UpdateRaceIndex()
    {
        
    }

    public void ChangeClassIndex(int _val)
    {
        if ((classIndex += _val) > availableClasses.Count)
        {
            classIndex = 0;
        }
        else if ((classIndex += _val) < 0)
        {
            classIndex = availableClasses.Count;
        }
        else
        {
            classIndex += _val;
        }        
    }
    
    public void ChangeRaceIndex(int _val)
    {
        if ((raceIndex += _val) > availableRaces.Count)
        {
            raceIndex = 0;
        }
        else if ((raceIndex += _val) < 0)
        {
            raceIndex = availableRaces.Count;
        }
        else
        {
            raceIndex += _val;
        }
    }
}
