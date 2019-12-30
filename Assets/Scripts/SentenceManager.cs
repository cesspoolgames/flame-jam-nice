using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SentenceManager : MonoBehaviour
{

    public TMPro.TMP_Text text;

    private static SentenceManager instance;

    float timeToDisappear = 0f;
    public float appearanceTime = 4f;

    static string[] sentences = new string[]{
"What a lame idea!",
"Who the hell would play this?",
"This game has more bugs than a Columbian motel,",
"I’d recommend this game to my friend, if Hitler was my friend",
"You’ll never make it in time, anyway",
"Your graphics sucksss!",
"Your game will never work, snowflake!",
"What makes you think you can do this?",
"Are you trying to make the user suffer?",
"Quick question: are you a certified idiot?",
"9/11 is a hoax!",
"Epstein didn't kill himself ",
"Rand Paul 2020!",
"N00B coding, bro",
"Some games just aren’t meant to be, you know",
"Them design be weakkk",
"Everyday you learn something new. Today I learned you suck",
"Quit now, while you still have some dignity",
"You have brought shame to your family",
"Your ancestors must be so disappointed",
"Is this the best you got?",
"You work so hard and achieve so little...",
"Time is running out, yo",
"Good. Good. Let the hate flow through you",
"What is this? amateur hour?! Come on",
"I’m here to flame and eat gum and I’m all out of gum",
"This is a terrible use of your time",
"I take it you never heard of Csikszentmihalyi’s flow theory",
"All the other teams are already game-testing",
"I guess you moved fast and broke things, huh?",
"24 more hours left and we’re already all out of pizzas",
"This game is free and I still want my money back",
"Some days I wish you’ve never been born",
"Wow, what a waste of time"

    };


    public static void ShowNewWordIfNeeded()
    {
        if (instance.text.text == "")
        {
            instance.text.text = sentences[Random.Range(0, sentences.Length)];
            instance.timeToDisappear = instance.appearanceTime;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        timeToDisappear -= Time.deltaTime;
        if (timeToDisappear < 0)
        {
            text.text = "";
            timeToDisappear = 0;
        }
    }
}
