using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMain : MonoBehaviour
{
    [SerializeField] private List<ClassScriptableObject> availableClasses = new List<ClassScriptableObject>();

    private Dictionary<string, ClassScriptableObject> classDict = new Dictionary<string, ClassScriptableObject>();

    [SerializeField] private List<RaceScriptableObject> availableRaces = new List<RaceScriptableObject>();

    private Dictionary<string, RaceScriptableObject> raceDict = new Dictionary<string, RaceScriptableObject>();

    [SerializeField] private List<GameObject> racePrefabs = new List<GameObject>();

    private GameObject currentRacePrefab;

    [SerializeField] private int classIndex = 0;    
    [SerializeField] private int raceIndex = 0;

    [SerializeField] private int maxClassIndex = 0; 
    [SerializeField] private int maxRaceIndex = 0;

    [SerializeField] private ClassScriptableObject currentClass;
    [SerializeField] private RaceScriptableObject currentRace;


    private void Awake()
    {
        foreach (ClassScriptableObject _class in availableClasses)
        {
            classDict.Add(_class.GetName(), _class);
        }

        foreach (RaceScriptableObject _race in availableRaces)
        {
            raceDict.Add(_race.GetName(), _race);
        }

        if (availableClasses.Count == 0 || availableRaces.Count == 0)
        {
            Debug.LogError("AvailableClasses or Available Races have not been populated!");
            return;
        }
        else
        {
            maxRaceIndex = availableRaces.Count - 1;
            maxClassIndex = availableClasses.Count - 1;

            currentRace = availableRaces[0];
            currentClass = availableClasses[0];
        }

        var _classPrefab = currentRace.RaceClassPrefab(RaceScriptableObject.RaceClass.Barbarian);

        currentRacePrefab = Instantiate(_classPrefab, transform);
    }

    private void UpdateRace()
    {
        currentRace = availableRaces[raceIndex];

        Destroy(currentRacePrefab);

        var _classPrefab = currentRace.RaceClassPrefab(currentRace.GetRaceFromIndex(classIndex));

        currentRacePrefab = Instantiate(_classPrefab, transform);

        /*currentRacePrefab.SetActive(false);
        currentRacePrefab = racePrefabs[raceIndex];
        currentRacePrefab.SetActive(true);*/
    }

    private void UpdateClass()
    {
        currentClass = availableClasses[classIndex];

        Destroy(currentRacePrefab);

        var _classPrefab = currentRace.RaceClassPrefab(currentRace.GetRaceFromIndex(classIndex));

        currentRacePrefab = Instantiate(_classPrefab, transform);
    }

    public void ChangeClassIndex(int _val)
    {
        classIndex += _val;

        if (classIndex > maxClassIndex)
        {
            classIndex = 0;
        }

        if (classIndex < 0)
        {
            classIndex = maxClassIndex;
        }
        UpdateClass();
    }
    
    public void ChangeRaceIndex(int _val)
    {
        raceIndex += _val;

        if (raceIndex > maxRaceIndex)
        {
            raceIndex = 0;
        }

        if (raceIndex < 0)
        {
            raceIndex = maxRaceIndex;
        }

        UpdateRace();
    }
    public string GetRaceName()
    {
        return currentRace.GetName();
    }

    public string GetClassName()
    {
        return currentClass.GetName();
    }
}
