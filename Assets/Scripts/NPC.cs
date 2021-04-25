using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    enum State
    {
        STUDYING,
        CHILLING,
        SOCIAL
    }

    public abstract int npcTag { get; }

    public abstract int currState { get; }

    public abstract void Interact();

    public abstract void TimeChangeEventHandler();

    public abstract void Enter();

    public abstract void Leave();

    public abstract void Introduce();

    public abstract void OnNewHour(object source, int time);
}
