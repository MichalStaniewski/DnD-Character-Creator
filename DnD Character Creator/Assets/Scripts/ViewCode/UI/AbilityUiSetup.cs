using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;

public class AbilityUiSetup : MonoBehaviour
{
    [SerializeField] private AbilityUi[] abilities = new AbilityUi[3];

    private void Start()
    {
        CharacterChangeEventSystem.instance.onClassChange += SetupAbilityUi;
        CharacterChangeEventSystem.instance.onRaceChange += SetupAbilityUi;
    }

    public void SetupAbilityUi(int _val) 
    {
        var _raceAbilities = CharacterModelData.ModelData.GetCurrentAbilities();
        
        for (int abilityIndex = 0; abilityIndex < abilities.Length; abilityIndex++)
        {
            abilities[abilityIndex].SetIcon(_raceAbilities[abilityIndex].abilityIcon);
            abilities[abilityIndex].SetName(_raceAbilities[abilityIndex].abilityName);
            abilities[abilityIndex].SetDescription(_raceAbilities[abilityIndex].desciption);
        }        
    }
}
