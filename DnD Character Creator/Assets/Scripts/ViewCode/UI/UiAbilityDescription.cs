using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiAbilityDescription : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI descriptionTextBox;
    [SerializeField] private RectTransform descriptionBG;
    private string descriptionText;

    public void SetDescription(string _description)
    {
        descriptionText = _description;
        descriptionTextBox.text = descriptionText;
    }

    public void Activate(Vector2 _pos)
    {
        descriptionBG.gameObject.SetActive(true);
        descriptionBG.sizeDelta = new Vector2(descriptionBG.sizeDelta.x, descriptionTextBox.preferredHeight > 200 ? 200 : descriptionTextBox.preferredHeight);
        descriptionBG.position = _pos;
    }

    public void Deactivate()
    {
        descriptionBG.gameObject.SetActive(false);
    }
}
