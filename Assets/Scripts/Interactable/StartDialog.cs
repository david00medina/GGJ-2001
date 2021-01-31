using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialog : MonoBehaviour
{
    private DialogueTrigger startDiagTrigger;

    // Start is called before the first frame update
    void Start()
    {
        startDiagTrigger = gameObject.GetComponent<DialogueTrigger>();
        startDiagTrigger.TriggerDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
