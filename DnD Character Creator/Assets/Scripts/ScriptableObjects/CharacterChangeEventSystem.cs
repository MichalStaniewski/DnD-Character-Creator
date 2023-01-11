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

    public Action<int> onRaceChange;
    public Action<int> onClassChange;

    public void OnRaceChange(int _val)
    {
        if (onRaceChange != null)
        {
            onRaceChange(_val);
        }
    }
    
    public void OnClassChange(int _val)
    {
        if (onClassChange != null)
        {
            onClassChange(_val);
        }
    }
}
