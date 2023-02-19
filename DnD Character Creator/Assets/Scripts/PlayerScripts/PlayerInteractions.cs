using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private PlayerInteractionUi uiInteraction;
    [SerializeField] private LayerMask interactableLayer;
    private float interactDistance = 2f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PlayerInteract();
        }
    }

    private void PlayerInteract() 
    {        
        Collider[] _collidersNearPlayer =  Physics.OverlapSphere(transform.position, interactDistance, interactableLayer);

        foreach (Collider _colliders in _collidersNearPlayer)
        {
            if (_colliders.TryGetComponent<NPCInteractable>(out NPCInteractable _nPCInteractable))
            {
                _nPCInteractable.Interact();
            }
        }
    }

    public NPCInteractable PlayerInRangeOfInteractable()
    {
        Collider[] _collidersNearPlayer = Physics.OverlapSphere(transform.position, interactDistance, interactableLayer);

        foreach (Collider _colliders in _collidersNearPlayer)
        {
            if(_colliders.TryGetComponent<NPCInteractable>(out NPCInteractable _nPCInteractable))
            {
                return _nPCInteractable;
            }
        }
        return null;
    }
}
