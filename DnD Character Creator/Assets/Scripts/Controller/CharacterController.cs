using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CharacterController : MonoBehaviour
    {
        private void Start()
        {
            //CharacterChangeEventSystem.instance.onRaceChange += ChangeCharacterRaceIndex;
            //CharacterChangeEventSystem.instance.onClassChange += ChangeCharacterClassIndex;
        }

        public void ChangeCharacterRaceIndex(int _changeRaceIndex)
        {
            CharacterModelData.ModelData.SetRaceIndex(_changeRaceIndex);
            
            CharacterChangeEventSystem.instance.OnRaceChange(_changeRaceIndex);
        }
        
        public void ChangeCharacterClassIndex(int _changeClassIndex)
        {
            CharacterModelData.ModelData.SetClassIndex(_changeClassIndex);

            CharacterChangeEventSystem.instance.OnClassChange(_changeClassIndex);
        }
    }
}
