using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
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
            Debug.Log(_colliders.name);
        }
    }
}
