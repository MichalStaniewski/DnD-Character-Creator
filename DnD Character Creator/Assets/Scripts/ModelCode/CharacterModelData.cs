using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class CharacterModelData : MonoBehaviour
    {
        [SerializeField] private List<ClassScriptableObject> availableClasses = new List<ClassScriptableObject>();

        [SerializeField] private List<RaceScriptableObject> availableRaces = new List<RaceScriptableObject>();

        [SerializeField] private List<AbilityBase> currentAbilities = new List<AbilityBase>();

        [SerializeField] private int classIndex = 0;
        [SerializeField] private int raceIndex = 0;

        [SerializeField] private int maxClassIndex = 0;
        [SerializeField] private int maxRaceIndex = 0;

        [SerializeField] private ClassScriptableObject currentClass;
        [SerializeField] private RaceScriptableObject currentRace;

        private static CharacterModelData modelData;
        public static CharacterModelData ModelData
        {
            get
            {
                return modelData;
            }
        }

        private void Awake()
        {
            modelData = this;
        }

        private void Start()
        {
            maxClassIndex = availableClasses.Count - 1;
            maxRaceIndex = availableRaces.Count - 1;

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
        }

        public void SetRaceIndex(int _val)
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

            currentRace = availableRaces[raceIndex];
        }

        public void SetClassIndex(int _val)
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

            currentClass = availableClasses[classIndex];
        }

        public void SetAbilities()
        {
            currentAbilities.Clear();

            currentAbilities.Add(currentRace.GetAbilities()[0]);
                        
            currentAbilities.Add(currentClass.GetAbilities()[0]);
            currentAbilities.Add(currentClass.GetAbilities()[1]);            
        }

        public List<AbilityBase> GetCurrentAbilities()
        {
            return currentAbilities;
        }

        public List<RaceScriptableObject> GetAvailableRaceList()
        {
            return availableRaces;
        }

        public List<ClassScriptableObject> GetAvailableClassList()
        {
            return availableClasses;
        }

        public int GetRaceIndex()
        {
            return raceIndex;
        }

        public int GetClassIndex()
        {
            return classIndex;
        }

        public RaceScriptableObject GetCurrentRace()
        {
            return currentRace;
        }

        public ClassScriptableObject GetCurrentClass()
        {
            return currentClass;
        }
    }
}