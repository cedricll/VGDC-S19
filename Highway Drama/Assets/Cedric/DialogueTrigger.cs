using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue1()
    {
        FindObjectOfType<DialogueManager>().StartDialogue("Test");
    }

    public void TriggerDialogue2()
    {
        FindObjectOfType<DialogueManager>().StartDialogue("Test");
    }

    public void TriggerDialogue3()
    {
        FindObjectOfType<DialogueManager>().StartDialogue("Test");
    }

    public void TriggerDialogue4()
    {
        FindObjectOfType<DialogueManager>().StartDialogue("Test");
    }
}
