using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private PlayerInteractionUi uiInteraction;
    [SerializeField] private LayerMask interactableLayer;
    private Quest currentQuest;
    private float interactDistance = 2f;

    private void Start()
    {
        currentQuest = null;
    }

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

        #region New Interface

        foreach (Collider _colliders in _collidersNearPlayer)
        {
            if (_colliders.TryGetComponent<I_Interactable>(out I_Interactable _nPCInteractable))
            {
                _nPCInteractable.Interact();
            }
        }

        #endregion

        /*
        foreach (Collider _colliders in _collidersNearPlayer)
        {
            if (_colliders.TryGetComponent<NPCInteractable>(out NPCInteractable _nPCInteractable))
            {
                _nPCInteractable.Interact();
            }
        }
        */
    }

    public NPCInteractable PlayerInRangeOfInteractable()
    {
        List<NPCInteractable> _npcInteractableList = new List<NPCInteractable>();

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

    public Quest GetCurrentQuest() 
    { 
        return currentQuest;
    }

    public void StartNewQuest(Quest _newQuest)
    {
        if (currentQuest == null || !currentQuest.isActive)
        {
            currentQuest = _newQuest;
            currentQuest.isActive = true;
        }
        else
        {
            Debug.Log("There is already and active quest.");
        }        
    }

    public void CompleteCurrentQuest()
    {

    }

    public void CancelCurrentQuest()
    {

    }
}
