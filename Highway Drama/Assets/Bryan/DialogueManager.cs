using System.Collections;
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

    public int cycle = 0;

    // Start is called before the first frame update

    void Update()
    {
        if (takingInput && dialogue.w[inputs] != "" && Input.GetKey("w")) {
            if (cycle > 2)
            {
                dialogueText.text = "";
                cycle = 0;
            }
            dialogueText.text += dialogue.w[inputs] + "\n";
            this.inputs += "w";
            takingInput = false;
            DisplayNextSentence();
        }
        else if (takingInput && dialogue.a[inputs] != "" && Input.GetKey("a")) {
            if (cycle > 2)
            {
                dialogueText.text = "";
                cycle = 0;
            }
            dialogueText.text += dialogue.a[inputs] + "\n";
            this.inputs += "a";
            takingInput = false;
            DisplayNextSentence();
        }
        else if (takingInput && dialogue.s[inputs] != "" && Input.GetKey("s")) {
            if (cycle > 2)
            {
                dialogueText.text = "";
                cycle = 0;
            }
            dialogueText.text += dialogue.s[inputs] + "\n";
            this.inputs += "s";
            takingInput = false;
            DisplayNextSentence();
        }
        else if (takingInput && dialogue.d[inputs] != "" && Input.GetKey("d")) {
            if (cycle > 2)
            {
                dialogueText.text = "";
                cycle = 0;
            }
            dialogueText.text += dialogue.d[inputs] + "\n";
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
        Debug.Log(inputs);
        string sentence = dialogue.sentences[inputs] + "\n";

        if (dialogue.endings.Contains(inputs))
        {
            EndDialogue(sentence);
            return;
        }

        cycle++;

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

    void EndDialogue(string sentence)
    {
        dialogueText.text = sentence;
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }
}
