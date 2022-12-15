using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Race", menuName = "Character Race")]
public class RaceScriptableObject : StatsScriptableObject
{
    [SerializeField] private List<GameObject> racePrefabs = new List<GameObject>();

    /// <summary>
    /// Index: Barbarian = 0, Ranger = 1, Sorcerer = 2, Paladin = 3, Rouge = 4
    /// </summary>
    public enum RaceClass
    {
        Barbarian,
        Ranger,
        Sorcerer,
        Paladin,
        Rouge
    }

    /// <summary>
    /// Index: Human = 0, Elf = 1, Ork = 2, Dwarf = 3
    /// </summary>
    public enum Race
    {
        Human,
        Elf,
        Ork,
        Dwarf
    }

    [SerializeField] private RaceClass myClass = RaceClass.Barbarian;
    [SerializeField] private Race myRace = Race.Human;

    public GameObject RaceClassPrefab(RaceClass _raceClass)
    {
        switch (_raceClass)
        {
            case RaceClass.Barbarian:
                return racePrefabs[0];
                
            case RaceClass.Ranger:
                return racePrefabs[1];
                
            case RaceClass.Sorcerer:
                return racePrefabs[2];
                
            case RaceClass.Paladin:
                return racePrefabs[3];
                
            case RaceClass.Rouge:
                return racePrefabs[4];

            default:
                return racePrefabs[0];                
        }
    }

    public RaceClass GetRaceFromIndex(int _index)
    {
        switch (_index)
        {
            case 0:
                return RaceClass.Barbarian;
            case 1:
                return RaceClass.Ranger;
            case 2:
                return RaceClass.Sorcerer;
            case 3:
                return RaceClass.Paladin;
            case 4:
                return RaceClass.Rouge;
            default:
                return RaceClass.Barbarian;
        }
    }

    public List<GameObject> GetRacePrefabList()
    {
        return racePrefabs;
    } 

    public RaceClass GetMyClass()
    {
        return myClass;
    }
}
