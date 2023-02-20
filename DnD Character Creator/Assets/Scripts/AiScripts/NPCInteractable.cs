using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteractable : MonoBehaviour
{
    [SerializeField] private Animator npcAnimator;
    [SerializeField] private QuestGiver myQuest;

    public void Interact()
    {
        Debug.Log(this.name + " Interact");
        npcAnimator.SetBool("IsTalking", true);
        myQuest.GetQuest().isActive = true;
    }
}
