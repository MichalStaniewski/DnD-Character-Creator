using Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CharacterController : MonoBehaviour
    {
        private void Awake()
        {
            CharacterChangeEventSystem.instance.onRaceChange += ChangeCharacterRaceIndex;
            CharacterChangeEventSystem.instance.onClassChange += ChangeCharacterClassIndex;
        }

        public void ChangeCharacterRaceIndex(int _val)
        {
            CharacterModelData.ModelData.SetRaceIndex(_val);
        }
        
        public void ChangeCharacterClassIndex(int _val)
        {
            CharacterModelData.ModelData.SetClassIndex(_val);
        }
    }
}
