using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilityUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI abilityName;
    [SerializeField] private Image abilityIcon;
    [SerializeField] private UiAbilityDescription myDescription;

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

    public void SetDescription(string _description)
    {
        myDescription.SetDescription(_description);
    }

    public void ActivateDescription()
    {
        Vector2 _position = myDescription.gameObject.transform.position;
        myDescription.Activate(_position);
    }

    public void DeactivateDescription()
    {
        myDescription.Deactivate();
    }
}

