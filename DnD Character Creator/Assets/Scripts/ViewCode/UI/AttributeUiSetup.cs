using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttributeUiSetup : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private CharacterVisulas characterRef;

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
        UpdateAttributeValues();
    }

    public void UpdateAttributeValues()
    {
        ResetAttributes();

        #region RaceAttributes
        strengthValue += characterRef.GetRace().GetStrength();
        movementValue += characterRef.GetRace().GetMovement();
        charmValue += characterRef.GetRace().GetCharm();
        intelligenceValue += characterRef.GetRace().GetIntelligence();
        mysticValue += characterRef.GetRace().GetMystic();
        #endregion

        #region ClassAttributes
        strengthValue += characterRef.GetClass().GetStrength();
        movementValue += characterRef.GetClass().GetMovement();
        charmValue += characterRef.GetClass().GetCharm();
        intelligenceValue += characterRef.GetClass().GetIntelligence();
        mysticValue += characterRef.GetClass().GetMystic();
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
