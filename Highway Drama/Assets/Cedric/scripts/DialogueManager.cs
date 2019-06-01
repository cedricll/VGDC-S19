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
        string temp_inputs = inputs;
        if (takingInput && dialogue.w[inputs] != "" && Input.GetKey("w")) {
            if (cycle > 2)
            {
                dialogueText.text = "";
                cycle = 0;
            }
            dialogueText.text += dialogue.w[inputs] + "\n";

            this.inputs = dialogue.wNext[temp_inputs];

            if (temp_inputs == "" || temp_inputs[0] != 'x')
            {
                dialogue.w[temp_inputs] = "";
            }

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

            this.inputs = dialogue.aNext[temp_inputs];

            if (temp_inputs == "" || temp_inputs[0] != 'x')
            {
                dialogue.a[temp_inputs] = "";
            }

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

            this.inputs = dialogue.sNext[temp_inputs];

            if (temp_inputs == "" || temp_inputs[0] != 'x')
            {
                dialogue.s[temp_inputs] = "";
            }

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

            this.inputs = dialogue.dNext[temp_inputs];

            if(temp_inputs == "" || temp_inputs[0] != 'x') {
                dialogue.d[temp_inputs] = "";
            }

            takingInput = false;
            DisplayNextSentence();
        }
    }

    public void StartDialogue (string name)
    {
        this.dialogue = new Dialogue(name);
        nameText.text = dialogue.name_text;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(dialogue.w[inputs] == "RESET") {
            this.inputs = "";
        }

        string sentence = dialogue.sentences[inputs] + "\n";

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
        if (dialogue.w[inputs] == "END")
        {
            this.inputs = "";
            dialogueText.text = "";
            dialogue.End();
        } else if (dialogue.w[inputs] == "SKIP"){
            this.inputs = dialogue.wNext[inputs];
            DisplayNextSentence();
        } else {
            DisplayChoices();
            takingInput = true;
        }
    }

    public void DisplayChoices()
    {
        wText.text = dialogue.w[inputs];
        aText.text = dialogue.a[inputs];
        sText.text = dialogue.s[inputs];
        dText.text = dialogue.d[inputs];
    }

    public void EndDialogue(string sentence)
    {
        dialogueText.text = sentence;
    }

    public void HideMenu()
    {
        menu.SetActive(false);
    }
}
