using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    public static bool hasTriggered;
    
    [SerializeField] GameObject dialogPanel;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private float typingSpeed;
    private bool isReadyToPrint;

    private int index;

    public static DialogueManager Instance;

    public bool HasTriggered
    {
        get => hasTriggered;
        set => hasTriggered = value;
    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(Instance);
    }

    void Start()
    {
        sentences = new Queue<string>();
        hasTriggered = false;
        isReadyToPrint = true;
    }

    IEnumerator TypeDialogue()
    {
        yield return new WaitUntil(() => isReadyToPrint);

        isReadyToPrint = false;
        dialogText.text = "";
        string sentence = sentences.Dequeue();
        
        foreach (var letter in sentence.ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isReadyToPrint = true;
    }

    public void StartDialogue(Dialogue dialogue)
    {
        GameManager.IsPlayerFrozen = true;
        if (!hasTriggered)
        {
            hasTriggered = true;
            dialogPanel.SetActive(true);
            
            headerText.text = dialogue.Header;
            sentences.Clear();
            
            foreach (string sentence in dialogue.Sentences)
            {
                sentences.Enqueue(sentence);
            }
        
        
            StartCoroutine(TypeDialogue());
        }
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        StartCoroutine(TypeDialogue());
    }

    private void EndDialogue()
    {
        headerText.text = "";
        dialogText.text = "";
        hasTriggered = false;
        dialogPanel.SetActive(false);
        GameManager.IsPlayerFrozen = false;
    }
}
