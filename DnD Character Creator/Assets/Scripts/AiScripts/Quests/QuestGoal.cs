using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    [SerializeField] private int requiredAmount;
    [SerializeField] private int currentAmount;    

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ProgressGoal()
    {
        currentAmount++;
    }
}
