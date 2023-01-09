using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangeEventSystem : MonoBehaviour
{
    public static CharacterChangeEventSystem instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action<int> onChangeCharacterRace;
    public event Action<int> onChangeCharacterClass;

    private Func<int> onRequestClassIndex;
    private Func<int> onRequestRaceIndex;

    public void OnChangeCharacter(int _index)
    {
        if (onChangeCharacterRace != null)
        {
            onChangeCharacterRace(_index);
        }
    }

    public int OnRequestClassIndex()
    {
        if (onRequestClassIndex != null)
        {
            return onRequestClassIndex();
        }

        return -1;
    }

    public int OnRequestRaceIndex()
    {
        if (onRequestRaceIndex != null)
        {
            return onRequestRaceIndex();
        }

        return -1;
    }
}
