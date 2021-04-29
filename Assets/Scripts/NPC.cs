using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : MonoBehaviour
{
    public Canvas ParentUIComponent;
    public GameObject ChatBoxComponent;
    protected readonly Vector3 ChatBoxPos = new Vector3(1200, 775, 0);


    public abstract string NPCName
    {
        get;
    }

    enum State
    {
        STUDYING,
        CHILLING,
        SOCIAL
    }

    public abstract void Interact();
    public abstract void Introduce();
}
