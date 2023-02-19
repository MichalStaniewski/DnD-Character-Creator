using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteractionUi : MonoBehaviour
{
    [SerializeField] private GameObject interactionUI;
    [SerializeField] private PlayerInteractions playerInteractions;
    [SerializeField] private TextMeshProUGUI interactionText;

    private void Start()
    {
        Disable();
    }

    private void Update()
    {
        var _interaction = playerInteractions.PlayerInRangeOfInteractable();

        if (playerInteractions.PlayerInRangeOfInteractable() != null)
        {
            Activate(_interaction);
        }
        else
        {
            Disable();
        }
    }

    public void Activate(NPCInteractable _npcInteractable)
    {
        interactionUI.SetActive(true);
        interactionText.text = "Talk to " + _npcInteractable.gameObject.name;
    }

    public void Disable()
    {
        interactionUI.SetActive(false);
    }
}
