using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[System.Serializable]
public class Dialogue
{

    public string name;
    public IDictionary<string, string> sentences;
    public IDictionary<string, string> w;
    public IDictionary<string, string> a;
    public IDictionary<string, string> s;
    public IDictionary<string, string> d;
    public List<string> endings = new List<string>();

    public Dialogue(string name)
    {
        this.name = name;
        sentences = new Dictionary<string, string>();
        w = new Dictionary<string, string>();
        a = new Dictionary<string, string>();
        s = new Dictionary<string, string>();
        d = new Dictionary<string, string>();
        MakeDialogue();
    }

    public void MakeOptions(string path, string sentence, string w, string a, string s, string d) {
        this.sentences.Add(path, sentence);
        this.w.Add(path, w);
        this.a.Add(path, a);
        this.s.Add(path, s);
        this.d.Add(path, d);

    }

    public void ClearAll() {
        sentences.Clear();
        w.Clear();
        a.Clear();
        s.Clear();
        d.Clear();
    }

    public void MakeDialogue() {
        switch (this.name)
        {
            case "Test":
                string[] itemEndings = {"ww", "wa", "ws", "wd", "aw", "aa", "as", "ad", "sw", "sa", "ss", "sd", "dw", "da", "ds", "dd"};
                endings.AddRange(itemEndings);
                MakeOptions("", "Hey it's me", "Wassap", "You pickin a fite?", "Yikes", "K");
                MakeOptions("w", "Nice You pressed w", "I sure did", "What's W", "this is a simulation", "Nope");
                MakeOptions("a", "Ya pressed a", "Ayyyyy", "A is for aeiou", "aha!", "Sweet home Alabama");
                MakeOptions("s", "S is my favoritte option too", "Smile", "Sweet", "Sister", "Sadistic");
                MakeOptions("d", "Haha D is my class grade", "Oof", "Same", "Sounds like a you problem", "Dumbass");
                break;  

            //Generics (Car)
            
        }   
    }

}
