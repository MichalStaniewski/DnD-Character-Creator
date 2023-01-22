using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace View
{
    public class UiControl : UiButtonInteractions
    {
        [Header("Text")]
        [SerializeField] private TextMeshProUGUI raceNameText;
        [SerializeField] private TextMeshProUGUI classNameText;
        
        private void Start()
        {            
            CharacterChangeEventSystem.instance.onRaceChange += UpdateNameText;
            CharacterChangeEventSystem.instance.onClassChange += UpdateNameText;

            SetButtonsAndPanels(true);
        }

        public void UpdateNameText(int _val)
        {
            raceNameText.text = CharacterModelData.ModelData.GetCurrentRace().GetName();

            classNameText.text = CharacterModelData.ModelData.GetCurrentClass().GetName();
        }
    }
}