using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterVisulas characterMain;

    #region RightPanel
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
        //CharacterChangeEventSystem.instance.onChangeCharacterRace += RaceSelectionButton;

        SetButtonsAndPanels(true);

        raceNameText.text = characterMain.GetRace().GetName();
        classNameText.text = characterMain.GetClass().GetName();
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

    public void RaceSelectionButton(int _val)
    {
        characterMain.ChangeRaceIndex(_val);
        raceNameText.text = characterMain.GetRace().GetName();
    }

    public void ClassSelectionButton(int _val)
    {
        characterMain.ChangeClassIndex(_val);
        classNameText.text = characterMain.GetClass().GetName();
    }
    #endregion
}