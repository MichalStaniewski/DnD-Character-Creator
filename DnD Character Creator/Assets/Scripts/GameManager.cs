using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Models;

public class GameManager : MonoBehaviour
{
    [SerializeField] private RaceScriptableObject playerRace;
    [SerializeField] private ClassScriptableObject playerClass;

    [SerializeField] private GameObject playerPrefabOld;
    [SerializeField] private SkinnedMeshRenderer playerPrefab;

    [SerializeField] private int classIndex = 0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void CompleteCharacterCreation()
    {
        StoreCharacterData();

        SetPlayerPrefab();

        StartCoroutine(SceneTransition());
    }

    public void StoreCharacterData()
    {
        CharacterModelData _modelData = CharacterModelData.ModelData;

        playerRace = _modelData.GetCurrentRace();
        playerClass = _modelData.GetCurrentClass();

        classIndex = _modelData.GetClassIndex();
    }

    private IEnumerator SceneTransition()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
    
    private void SetPlayerPrefab()
    {
        playerPrefab = playerRace.GetRacePrefabList()[classIndex].GetComponentInChildren<SkinnedMeshRenderer>();
    }

    public RaceScriptableObject GetPlayerRace()
    {
        return playerRace;
    }

    public ClassScriptableObject GetPlayerClass()
    {
        return playerClass;
    }

    public SkinnedMeshRenderer GetPlayerModelPrefab()
    {
        return playerPrefab;
    }
}
