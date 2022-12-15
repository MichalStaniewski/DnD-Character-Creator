using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterMain characterMain;

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
        SetButtonsAndPanels(true);

        raceNameText.text = characterMain.GetRaceName();
        classNameText.text = characterMain.GetClassName();
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
        raceNameText.text = characterMain.GetRaceName();
    }

    public void ClassSelectionButton(int _val)
    {
        characterMain.ChangeClassIndex(_val);
        classNameText.text = characterMain.GetClassName();
    }
    #endregion

    #region LeftPanel
    #endregion
}