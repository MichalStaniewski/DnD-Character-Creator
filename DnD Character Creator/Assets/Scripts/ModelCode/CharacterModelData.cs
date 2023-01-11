using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class CharacterModelData : MonoBehaviour
    {
        [SerializeField] private List<ClassScriptableObject> availableClasses = new List<ClassScriptableObject>();

        [SerializeField] private List<RaceScriptableObject> availableRaces = new List<RaceScriptableObject>();

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
                if (modelData != null)
                {
                    Debug.LogWarning("Singleton instance already exists!");
                }

                return modelData; 
            }
        }

        private void Awake()
        {
            modelData = this;
        }

        private void Start()
        {
            maxClassIndex = availableClasses.Count;
            maxRaceIndex = availableRaces.Count;
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