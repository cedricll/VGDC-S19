﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    public Text wText;
    public Text aText;
    public Text sText;
    public Text dText;

    public string inputs = "";

    public Dialogue dialogue;

    public bool takingInput = false;

    public GameObject menu;

    // Start is called before the first frame update

    void Update()
    {
        if (takingInput && Input.GetKey("w")) {
            this.inputs += "w";
            takingInput = false;
            DisplayNextSentence();
        }
        else if (takingInput && Input.GetKey("a")) {
            this.inputs += "a";
            takingInput = false;
            DisplayNextSentence();
        }
        else if (takingInput && Input.GetKey("s")) {
            this.inputs += "s";
            takingInput = false;
            DisplayNextSentence();
        }
        else if (takingInput && Input.GetKey("d")) {
            this.inputs += "d";
            takingInput = false;
            DisplayNextSentence();
        }
    }

    public void StartDialogue (string name)
    {
        this.dialogue = new Dialogue(name);
        nameText.text = dialogue.name;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (dialogue.endings.Contains(inputs))
        {
            EndDialogue();
            return;
        }
        string sentence = dialogue.sentences[inputs] + "\n";

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) {
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        DisplayChoices();
        takingInput = true;
    }

    public void DisplayChoices()
    {
        wText.text = dialogue.w[inputs];
        aText.text = dialogue.a[inputs];
        sText.text = dialogue.s[inputs];
        dText.text = dialogue.d[inputs];
    }

    void EndDialogue()
    {
        dialogueText.text = "K im out";
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }
}
