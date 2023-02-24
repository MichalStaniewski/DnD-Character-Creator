using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField] private Quest quest;
    [SerializeField] private PlayerInteractions player;
    
    public Quest GetQuest()
    {
        return quest;
    }
    
    public void StartQuest()
    {
        player.StartNewQuest(quest);
    }
}
