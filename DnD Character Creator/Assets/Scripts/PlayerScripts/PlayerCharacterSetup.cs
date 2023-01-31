using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSetup : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer skinnedMeshRenderer;

    private GameManager gameManager;    

    private void Start()
    {        
        gameManager = FindObjectOfType<GameManager>();

        SetupCharacterModel();
    }

    private void SetupCharacterModel()
    {
        var _newMesh = gameManager.GetPlayerModelPrefab().sharedMesh;

        skinnedMeshRenderer.sharedMesh = _newMesh;
    }
}
