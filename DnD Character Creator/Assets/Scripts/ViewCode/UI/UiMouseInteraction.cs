using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiMouseInteraction : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private AbilityUi myAbility;

    public void OnPointerEnter(PointerEventData eventData)
    {
        myAbility.ActivateDescription();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myAbility.DeactivateDescription();
    }
}
