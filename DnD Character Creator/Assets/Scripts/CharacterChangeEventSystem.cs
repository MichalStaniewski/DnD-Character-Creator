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

    public event Action<int> onRaceChange;
    public void OnRaceChange(int _val)
    {
        if (onRaceChange != null)
        {
            onRaceChange(_val);
        }
    }


    public event Action<int> onClassChange;
    public void OnClassChange(int _val)
    {
        if (onClassChange != null)
        {
            onClassChange(_val);
        }
    }
}
