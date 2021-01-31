using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueQueue : MonoBehaviour
{
    [SerializeField] private List<Dialogue> dialogues;
    private Queue<DialogueTrigger> dialogueQueue;

    private void Start()
    {
        dialogueQueue = new Queue<DialogueTrigger>();
        foreach (Dialogue dialogue in dialogues)
        {
            DialogueTrigger diagTrigger = new DialogueTrigger(dialogue);
            dialogueQueue.Enqueue(diagTrigger);
        }
    }

    public int DialogueCount
    {
        get => dialogueQueue.Count;
    }

    public void LaunchDialogueTriggers()
    {
        if (!DialogueManager.Instance.HasTriggered && GameManager.EventDialogue)
        {
            DialogueTrigger dialogueTrigger = dialogueQueue.Dequeue();
            dialogueTrigger.TriggerDialogue();
        }
    }
}
