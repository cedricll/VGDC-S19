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
    public IDictionary<string, string> ending_texts;
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

    public void MakeOptions(string path, string sentence, string w = "", string a = "", string s = "", string d = "") {
        this.sentences.Add(path, sentence);
        this.w.Add(path, w);
        this.a.Add(path, a);
        this.s.Add(path, s);
        this.d.Add(path, d);

    }

    public void MakeEnding(string path, string ending) {
        this.ending_texts.Add(path, ending);
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
                MakeTest();
                break;  
            case "Dog1":
                MakeDog1();
                break;
            
        }   
    }

    public void MakeTest() {
        string[] itemEndings = { "ww", "wa", "ws", "wd", "aw", "aa", "as", "ad", "sw", "sa", "ss", "sd", "dw", "da", "ds", "dd" };
        endings.AddRange(itemEndings);
        MakeOptions("", "Hey it's me", "Wassap", "You pickin a fite?", "Yikes", "K");
        MakeOptions("w", "Nice You pressed w", "I sure did", "What's W", "this is a simulation", "Nope");
        MakeOptions("a", "Ya pressed a", "Ayyyyy", "A is for aeiou", "aha!", "Sweet home Alabama");
        MakeOptions("s", "S is my favoritte option too", "Smile", "Sweet", "Sister", "Sadistic");
        MakeOptions("d", "Haha D is my class grade", "Oof", "Same", "Sounds like a you problem", "Dumbass");

    }

    public void MakeDog1() {
        string[] itemEndings = {"w", "a", "s", "ww", "daw", "daww", "dawa", "daws", "dawd"};
        endings.AddRange(itemEndings);
        MakeOptions("", "\"Woof!\"", "Uber for...dog?", "Wait, you're...actually a dog?", "...what?", "No dogs allowed");
        MakeOptions("w", "(The dog ignores your confusion and happily jumps in.)");
        MakeOptions("a", "(The dog ignores your confusion and happily jumps in.)");
        MakeOptions("s", "(The dog ignores your confusion and happily jumps in.)");
        MakeOptions("d", "\"Grrrrrr…\"\n(The dog growls about as menacingly as it can. It isn’t very menacing.)", "Oh, okay, fine...", "You heard me. No dogs allowed, punk.", "", "");

        MakeOptions("dw", "(The dog jumps in, a little bit grouchy. Dogs can’t give ratings anyways, right?)");
        MakeOptions("da", "\"GrrRRRRRR\"\n(That was a lot more menacing. I’m not even sure that’s what dogs sound like.)", "Okay, okay, just get in!", "What’s your problem? Scram!", "Just drive away.");

        MakeOptions("daw", "(The dog gets in, and smiles widely at you. Are dogs supposed to smile?)");
        MakeOptions("daa", "\"RRRRRRRRRRRR!!!\"\n(everthing is growling)", "Please get in.", "Please get in.", "Please get in.", "Please get in.");
        MakeOptions("das", "\"RRRRRRRRRRRR!!!\"\n(everthing is growling)", "Please get in.", "Please get in.", "Please get in.", "Please get in.");

        MakeOptions("daaw", "(The dog is inside)\n(When did that happen?)");
        MakeOptions("daaa", "(The dog is inside)\n(When did that happen?)");
        MakeOptions("daas", "(The dog is inside)\n(When did that happen?)");
        MakeOptions("daad", "(The dog is inside)\n(When did that happen?)");
        MakeOptions("dasw", "(The dog is inside)\n(When did that happen?)");
        MakeOptions("dasa", "(The dog is inside)\n(When did that happen?)");
        MakeOptions("dass", "(The dog is inside)\n(When did that happen?)");
        MakeOptions("dasd", "(The dog is inside)\n(When did that happen?)");
    }

    /*public void DisplayEnding(string input) {
        
    }*/

}
