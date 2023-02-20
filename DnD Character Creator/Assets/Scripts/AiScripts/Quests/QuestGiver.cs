using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest quest;
    
    public Quest GetQuest()
    {
        return quest;
    }
    
    public void StartQuest()
    {
        
    }
}
