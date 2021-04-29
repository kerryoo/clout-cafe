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

    private void Start()
    {
        createLowCloutInteraction();
        createHighCloutInteraction();
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
    }

    public void createHighCloutInteraction()
    {
        highCloutInteraction = new Interaction();
        highCloutInteraction.addInteractionLine("Hi! I'm Katie. I've heard people around the cafe talk about how cool you are! It's so awesome to finally get to meet you!");
        highCloutInteraction.addInteractionLine("I hope we can be friends!");
    }
}
