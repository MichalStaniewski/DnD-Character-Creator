using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilityUi : MonoBehaviour
{
    //[SerializeField] private string abilityName;
    [SerializeField] private TextMeshProUGUI abilityName;
    [SerializeField] private Image abilityIcon;

    public Image GetAbilityIcon()
    {
        return abilityIcon;
    }

    public void SetName(string _name)
    {
        abilityName.text = _name;
    }

    public void SetIcon(Sprite _sprite)
    {
        abilityIcon.sprite = _sprite;
    }
}
