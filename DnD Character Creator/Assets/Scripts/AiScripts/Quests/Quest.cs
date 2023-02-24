using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public string name;
    public string description;
    public int experianceGain;
    public int goldGain;

    public QuestGoal goal;

    public void CheckGoalProgress()
    {
        if (goal.IsReached())
        {
            Complete();
        }
    }

    public void Complete()
    {
        isActive = false;
        Debug.Log(name + " was completed!");
    }
}
