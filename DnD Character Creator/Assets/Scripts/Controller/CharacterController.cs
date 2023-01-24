using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using View;

namespace Controllers
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private UiControl uiNameControl;
        [SerializeField] private AbilityUiSetup abilityUiSetup;

        private void Start()
        {
            CharacterModelData.ModelData.SetRaceIndex(0);
            CharacterModelData.ModelData.SetClassIndex(0);
            CharacterModelData.ModelData.SetAbilities();

            uiNameControl.UpdateNameText(0);
            abilityUiSetup.SetupAbilityUi(0);
        }

        public void ChangeCharacterRaceIndex(int _changeRaceIndex)
        {
            CharacterModelData.ModelData.SetRaceIndex(_changeRaceIndex);

            CharacterModelData.ModelData.SetAbilities();
            
            CharacterChangeEventSystem.instance.OnRaceChange(_changeRaceIndex);
        }
        
        public void ChangeCharacterClassIndex(int _changeClassIndex)
        {
            CharacterModelData.ModelData.SetClassIndex(_changeClassIndex);

            CharacterModelData.ModelData.SetAbilities();

            CharacterChangeEventSystem.instance.OnClassChange(_changeClassIndex);
        }
    }
}
