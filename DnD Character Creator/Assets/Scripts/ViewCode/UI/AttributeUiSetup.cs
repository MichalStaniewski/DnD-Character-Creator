using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace View
{
    public class AttributeUiSetup : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private CharacterVisuals characterRef;

        [Header("Attribute Values")]
        [SerializeField] private TextMeshProUGUI strengthText;
        [SerializeField] private TextMeshProUGUI movementText;
        [SerializeField] private TextMeshProUGUI charmText;
        [SerializeField] private TextMeshProUGUI intelligenceText;
        [SerializeField] private TextMeshProUGUI mysticText;

        [Header("Values")]
        private int strengthValue;
        private int movementValue;
        private int charmValue;
        private int intelligenceValue;
        private int mysticValue;

        private void Start()
        {
            UpdateAttributeValues(0);

            CharacterChangeEventSystem.instance.onRaceChange += UpdateAttributeValues;
            CharacterChangeEventSystem.instance.onClassChange += UpdateAttributeValues;
        }

        public void UpdateAttributeValues(int _val)
        {
            ResetAttributes();

            #region RaceAttributes        
            RaceScriptableObject _raceRef = CharacterModelData.ModelData.GetCurrentRace();

            strengthValue += _raceRef.GetStrength();
            movementValue += _raceRef.GetMovement();
            charmValue += _raceRef.GetCharm();
            intelligenceValue += _raceRef.GetIntelligence();
            mysticValue += _raceRef.GetMystic();
            #endregion

            #region ClassAttributes
            ClassScriptableObject _classRef = CharacterModelData.ModelData.GetCurrentClass();

            strengthValue += _classRef.GetStrength();
            movementValue += _classRef.GetMovement();
            charmValue += _classRef.GetCharm();
            intelligenceValue += _classRef.GetIntelligence();
            mysticValue += _classRef.GetMystic();
            #endregion

            UpdateUI();
        }

        private void UpdateUI()
        {
            strengthText.text = strengthValue.ToString();
            movementText.text = movementValue.ToString();
            charmText.text = charmValue.ToString();
            intelligenceText.text = intelligenceValue.ToString();
            mysticText.text = mysticValue.ToString();
        }

        private void ResetAttributes()
        {
            strengthValue = 10;
            movementValue = 10;
            charmValue = 10;
            intelligenceValue = 10;
            mysticValue = 10;
        }
    }
}
