using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvent : MonoBehaviour
{
    [SerializeField] private DialogueQueue dialogueQueue;
    public static GameEvent instance;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (dialogueQueue.DialogueCount > 0)
        {
            dialogueQueue.LaunchDialogueTriggers();
            GameManager.EventDialogue = true;
        }
        else
        {
            GameManager.EventDialogue = false;
        }
        
        if (DialogueManager.Instance.HasTriggered && Input.GetMouseButtonUp(0))
        {
            DialogueManager.Instance.DisplayNextSentence();
        }
    }

    public DialogueQueue DialogueQueue
    {
        set => dialogueQueue = value;
    }
}
