using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//[System.Serializable]
public class Dialogue : MonoBehaviour
{

    public string name_text;
    public string name_num;
    public IDictionary<string, string> sentences;
    public IDictionary<string, string> w;
    public IDictionary<string, string> a;
    public IDictionary<string, string> s;
    public IDictionary<string, string> d;
    public IDictionary<string, string> wNext;
    public IDictionary<string, string> aNext;
    public IDictionary<string, string> sNext;
    public IDictionary<string, string> dNext;

    public Dialogue(string name)
    {
        Debug.Log("2");
        this.name_num = name;
        this.name_text = name.Substring(0, name.Length - 1);
        sentences = new Dictionary<string, string>();
        w = new Dictionary<string, string>();
        a = new Dictionary<string, string>();
        s = new Dictionary<string, string>();
        d = new Dictionary<string, string>();
        wNext = new Dictionary<string, string>();
        aNext = new Dictionary<string, string>();
        sNext = new Dictionary<string, string>();
        dNext = new Dictionary<string, string>();
        MakeDialogue();
    }

    public void MakeOptions(string path, string wNext, string aNext, string sNext, string dNext, string sentence, string w = "", string a = "", string s = "", string d = "") {
        this.sentences.Add(path, sentence);
        this.w.Add(path, w);
        this.a.Add(path, a);
        this.s.Add(path, s);
        this.d.Add(path, d);
        this.wNext.Add(path, wNext);
        this.aNext.Add(path, aNext);
        this.sNext.Add(path, sNext);
        this.dNext.Add(path, dNext);

    }

    public void ClearAll() {
        sentences.Clear();
        w.Clear();
        a.Clear();
        s.Clear();
        d.Clear();
    }

    public void MakeDialogue() {
        switch (this.name_num)
        {
            case "Dog1":
                MakeDog1();
                break;
            case "Dog2":
                MakeDog2();
                break;
        }   
    }

    public void End() {
        switch (this.name_num)
        {
            case "Dog1":
                FindObjectOfType<DialogueManager>().StartDialogue("Dog2");
                break;
        }
    }

    public void MakeDog1() {
        MakeOptions("", "w", "a", "s", "d", "\"Woof!\"", "Uber for...dog?", "Wait, you're...actually a dog?", "...what?", "No dogs allowed");
        MakeOptions("w", "", "", "", "", "(The dog ignores your confusion and happily jumps in.)", "END");
        MakeOptions("a", "", "", "", "", "(The dog ignores your confusion and happily jumps in.)", "END");
        MakeOptions("s", "", "", "", "", "(The dog ignores your confusion and happily jumps in.)", "END");
        MakeOptions("d", "dw", "da", "", "", "\"Grrrrrr…\"\n(The dog growls about as menacingly as it can. It isn’t very menacing.)", "Oh, okay, fine...", "You heard me. No dogs allowed, punk.", "", "");

        MakeOptions("dw", "", "", "", "", "(The dog jumps in, a little bit grouchy. Dogs can’t give ratings anyways, right?)", "END");
        MakeOptions("da", "daw", "daa", "das", "", "\"GrrRRRRRR\"\n(That was a lot more menacing. I’m not even sure that’s what dogs sound like.)", "Okay, okay, just get in!", "What’s your problem? Scram!", "(Drive away.)");

        MakeOptions("daw", "", "", "", "", "(The dog gets in, and smiles widely at you. Are dogs supposed to smile?)", "END");
        MakeOptions("daa", "1", "1", "1", "1", "\"RRRRRRRRRRRR!!!\"\n(everthing is growling)", "Please get in.", "Please get in.", "Please get in.", "Please get in.");
        MakeOptions("das", "1", "1", "1", "1", "\"RRRRRRRRRRRR!!!\"\n(everthing is growling)", "Please get in.", "Please get in.", "Please get in.", "Please get in.");

        MakeOptions("1", "", "", "", "", "(The dog is inside)\n(When did that happen?)", "END");
    }

    public void MakeDog2() {
        MakeOptions("", "w", "a", "s", "", "(You look at the completely normal dog riding in your car. It seems very normal.)", "So… how ‘bout this weather lately?", "How does a dog get an Uber anyways?", "I wonder… \"woof woof?\"");
       
        MakeOptions("w", "ww", "wa", "ws", "wd", "\"Ruff!\"", "Like it's been, rough, or...?", "Yeah, it’s sure been crazy.", "I agree, the calm is a nice change of pace.", "... I’m not really sure what I expected you to say.");
        MakeOptions("ww", "w1w", "w1a", "w1s", "w1d", "(You chuckle at your joke. No one else does, though.)\n\"Woof woof!\"", "Yeah man, it’s been raining...wait for it...cats and dogs!", "Did you guys get that hailstorm down here, too?", "Me too, man. Me too.", "...This is stupid.");
        MakeOptions("wa", "w1w", "w1a", "w1s", "w1d", "(You think back to the hailstone that crushed your car last week. Crazy stuff.)\n\"Woof woof!\"", "Yeah man, it’s been raining...wait for it...cats and dogs!", "Did you guys get that hailstorm down here, too?", "Me too, man. Me too.", "...This is stupid.");
        MakeOptions("ws", "w1w", "w1a", "w1s", "w1d", "(Knock on wood)\n\"Woof woof!\"", "Yeah man, it’s been raining...wait for it...cats and dogs!", "Did you guys get that hailstorm down here, too?", "Me too, man. Me too.", "...This is stupid.");
        MakeOptions("wd", "w1w", "w1a", "w1s", "w1d", "(I guess talking to a dog isn’t that weird, is it?)\n\"Woof woof!\"", "Yeah man, it’s been raining...wait for it...cats and dogs!", "Did you guys get that hailstorm down here, too?", "Me too, man. Me too.", "...This is stupid.");

        MakeOptions("w1w", "w11w", "w11a", "", "xpet", "(Comedy is disappointed with you. The dog would be too, if he could talk.)", "Yeah, the weather was just terrierable!", "Those clouds are...really cloudy, huh?", "(Change the topic)", "(Pet the dog)");
        MakeOptions("w1a", "w11w", "w11a", "", "xpet", "\"Woof.\"", "Yeah, the weather was just terrierable!", "Those clouds are...really cloudy, huh?", "(Change the topic)", "(Pet the dog)");
        MakeOptions("w1s", "w11w", "w11a", "", "xpet", "(The dog grunts.)", "Yeah, the weather was just terrierable!", "Those clouds are...really cloudy, huh?", "(Change the topic)", "(Pet the dog)");
        MakeOptions("w1d", "xpet", "", "", "", "(You're pretty sure the dog has no idea what you're saying.)", "(Pet the dog)", "(Change the topic)");

        MakeOptions("w11w", "", "", "", "", "(I felt bad just writing that one...)\n(The dog looks sad.)", "(Change the topic)");
        MakeOptions("w11a", "", "", "", "", "\"Woof.\"\n(The dog is bored.)", "(Change the topic)");
        MakeOptions("xpet", "xpet", "", "", "", "(You pet the dog. It wags its tail exitedly.)", "(Pet the dog again.)", "(Change the topic)");


        MakeOptions("a", "a1", "a1", "as", "ad", "\"Woof!\"\n(The dog shows you the Uber app on its phone.)", "Yeah. That makes sense.", "Neat.", "But how do you push the buttons?", "Wait, what?");
        MakeOptions("a1", "a1w", "a1a", "a1s", "", "(The dog starts showing you its other apps. Apparently its really into mobile games.)", "Is that Minecraft?", "Oh, you have Reddit?", "Mobile games aren't real games");
        MakeOptions("as", "a1", "asa", "ass", "", "(The dog taps the phone with its finger)", "Oh. Silly me.", "Wait, you have fingers?", "What the fuck?");
        MakeOptions("ad", "adw", "ada", "ads", "", "(You look closer at the dog. It's playing Fortnite.)", "Wait, is that a guy up there?", "You really still play Fortnite?", "How the hell can a dog play this?");

        MakeOptions("a1w", "a1ww", "a1wa", "a1ws", "", "(The dog opens up Minecraft, it seems to be in the middle of building a house.)", "Looks pretty good!", "(Give some advice.)", "You suck at building.");
        MakeOptions("a1ww", "a1", "", "", "", "(The dog nods.)", "SKIP");
        MakeOptions("a1wa", "a1", "", "", "", "(You give the dog some constructive criticism. It seems to appreciate it)", "SKIP");
        MakeOptions("a1ws", "", "", "", "", "(You bully the dog. The dog is sad now.)", "(Change the topic)");

        MakeOptions("a1a", "a1aw", "a1aa", "a1as", "a1ad", "(The dog goes on Reddit.)", "Try r/AskReddit!", "Have you seen r/imsorryjon?", "What's on the front page?", "You ever look at r/UCI?");
        MakeOptions("a1aw", "a1", "", "", "", "(The dog scrolls for a bit. It looks bored.)", "SKIP");
        MakeOptions("a1aa", "a1", "", "", "", "(The dog looks horrified, yet intrigued.)", "SKIP");
        MakeOptions("a1as", "a1", "", "", "", "(The dog scrolls through a lot of politics, memes, and cute animals. It seems amused.)", "SKIP");
        MakeOptions("a1ad", "a1adw", "a1ada", "", "", "(The dog pulls up r/UCI. There seems to be a lot of drama about some stickers.)", "Typical UCI drama I guess.", "You know, I think petr.uci has a legitimate business model.");
        MakeOptions("a1adw", "", "", "", "(The dog shrugs.)", "SKIP");
        MakeOptions("a1ada", "", "", "", "(The dog looks disgusted)", "(Awkwardly change the topic)");

        MakeOptions("a1s", "", "", "", "(The dog looks sad and puts down its phone. You feel bad.)", "(Awkwardly change the topic)");

        MakeOptions("asa", "asaw", "asaa", "", "", "(The dog puts its fingers over its lips, shushing you.)", "(Shush)", "(Don't shush)");
        MakeOptions("asaw", "", "", "", "", "(The dog is pleased.)", "SKIP");
        MakeOptions("asaa", "", "", "", "", "(The dog puts its finger over your lips, shushing you.)", "(Shush)");

        MakeOptions("ass", "asa", "assa", "", "", "(The dog looks insulted.)", "Seriously, you have fingers?", "(Apologize)");
        MakeOptions("assa", "", "", "", "", "(The dog accepts your apology.)", "SKIP");

        MakeOptions("adw", "a1", "", "", "", "(The dog also sees the player. It looks grateful.)", "SKIP");
        MakeOptions("ada", "a1", "", "", "", "(The dog looks sad and self concious. Look what you did.)", "SKIP");
        MakeOptions("ads", "a1", "", "", "", "(The dog shrugs. Can dogs shrug?)", "SKIP");

        MakeOptions("s", "sw", "sa", "ss", "", "(The dog looks excited.)\n\"Woof woof!\"\n(It looks like you actually said something.)", "Woof?", "Bark bark!", "Arf!", "(Stop barking at the dog)");
        MakeOptions("sw", "xwoof", "swa", "", "", "\"Woof woooooof!\"", "Woof.", "Woof woof.");
        MakeOptions("xwoof", "xwoof", "", "", "", "\"Woof woof woof!\"", "Woof.", "(Change the topic)");
        MakeOptions("swa", "", "", "", "", "\"Woof?\"\n(The dog looks confused.)", "(Change the topic)");
        MakeOptions("sa", "", "", "", "", "(The dog tilts its head in confusion.)", "(Change the topic)");
        MakeOptions("ss", "", "", "", "", "(The dog looks horribly offended. You're pretty sure that was a racial slur or something.)", "SKIP");


    }

    /*public void DisplayEnding(string input) {
        
    }*/

}
