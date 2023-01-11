using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace View
{
    public class CharacterVisuals : MonoBehaviour
    {
        private GameObject currentRacePrefab;

        private void Awake()
        {
            SetCharacterVisuals(0);
        }

        private void Start()
        {
            CharacterChangeEventSystem.instance.onRaceChange += SetCharacterVisuals;
            CharacterChangeEventSystem.instance.onClassChange += SetCharacterVisuals;
        }

        public void SetCharacterVisuals(int _val)
        {
            if (currentRacePrefab != null)
            {
                Destroy(currentRacePrefab);
            }

            var _modelData = CharacterModelData.ModelData;

            int _raceIndex = _modelData.GetRaceIndex();
            int _classIndex = _modelData.GetClassIndex();

            var _classPrefab = _modelData.GetAvailableRaceList()[_raceIndex].GetRacePrefabList()[_classIndex];

            currentRacePrefab = Instantiate(_classPrefab, transform);
        }
    }
}
