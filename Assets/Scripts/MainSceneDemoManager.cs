using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class MainSceneDemoManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI cloutMeter;
    [SerializeField] PlayerStats playerStats;

    public Interaction lowCloutInteraction;
    public Interaction highCloutInteraction;
    public Interaction lowCloutMetInteraction;
    public Interaction highCloutMetInteraction;

    private void Start()
    {
        createLowCloutInteraction();
        createHighCloutInteraction();
        createLowCloutMetInteraction();
    }

    public void increaseClout()
    {
        cloutMeter.SetText("100");
        playerStats.clout = 100;

    }

    public void createLowCloutInteraction()
    {
        lowCloutInteraction = new Interaction();
        lowCloutInteraction.addInteractionLine("...");
        lowCloutInteraction.addInteractionLine("... ...");
        lowCloutInteraction.addInteractionLine("... ... ...");
        lowCloutInteraction.addInteractionLine("Leave me alone you loser.");
        string[] options = { "Sorry I guess.", "You're mean. Smell ya later." };
        lowCloutInteraction.options = options;
    }

    public void createHighCloutInteraction()
    {
        highCloutInteraction = new Interaction();
        highCloutInteraction.addInteractionLine("Hi! I'm Katie. I've heard people around the cafe talk about how cool you are! It's so awesome to finally get to meet you!");
        highCloutInteraction.addInteractionLine("I hope we can be friends!");
        string[] options = { "That sounds awesome!", "Hah, don't make me laugh." };
        highCloutInteraction.options = options;
    }

    public void createLowCloutMetInteraction()
    {
        lowCloutMetInteraction = new Interaction();
        lowCloutMetInteraction.addInteractionLine("I already told you. Go away.");
        string[] options = { "Alright I'm leaving", "You go away." };
        lowCloutMetInteraction.options = options;

    }

    public void createHighCloutMetInteraction()
    {
        highCloutMetInteraction = new Interaction();
        highCloutMetInteraction.addInteractionLine("Yo what's up " + playerStats.characterName + "!");
        highCloutMetInteraction.addInteractionLine("Have you tried the croissants here? They're really good.");
        string[] options = { "Yeah they're great!", "Nah, not yet." };
        highCloutMetInteraction.options = options;
    }

    public void refresh()
    {
        createHighCloutInteraction();
        createLowCloutInteraction();
        createLowCloutMetInteraction();
        createHighCloutMetInteraction();
    }

    public void resetMet()
    {
        playerStats.metKatie = false;
    }
}
