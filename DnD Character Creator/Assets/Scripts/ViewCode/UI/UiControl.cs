using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace View
{
    public class UiControl : MonoBehaviour
    {
        [Header("RightPanel")]
        [SerializeField] private GameObject racePanel;
        [SerializeField] private GameObject classPanel;

        [Header("Buttons")]
        [SerializeField] private Button raceButton;
        [SerializeField] private Button classButton;

        [Header("Text")]
        [SerializeField] private TextMeshProUGUI raceNameText;
        [SerializeField] private TextMeshProUGUI classNameText;


        private void Start()
        {
            CharacterChangeEventSystem.instance.onRaceChange += UpdateNameText;
            CharacterChangeEventSystem.instance.onClassChange += UpdateNameText;

            SetButtonsAndPanels(true);

            raceNameText.text = CharacterModelData.ModelData.GetCurrentRace().GetName();

            classNameText.text = CharacterModelData.ModelData.GetCurrentClass().GetName();
        }

        public void UpdateNameText(int _val)
        {
            raceNameText.text = CharacterModelData.ModelData.GetCurrentRace().GetName();

            classNameText.text = CharacterModelData.ModelData.GetCurrentClass().GetName();
        }

        public void RacePanelButton()
        {
            SetButtonsAndPanels(true);
        }

        public void ClassPanelButton()
        {
            SetButtonsAndPanels(false);
        }

        private void SetButtonsAndPanels(bool _val)
        {
            raceButton.gameObject.SetActive(!_val);
            classButton.gameObject.SetActive(_val);

            racePanel.SetActive(_val);
            classPanel.SetActive(!_val);
        }
    }
}