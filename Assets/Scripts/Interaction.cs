using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public Queue<string> queue = new Queue<string>();

    public void addInteractionLine(string line)
    {
        queue.Enqueue(line);
    }

    public string getNextLine()
    {
        return queue.Dequeue();
    }

    public bool hasNext()
    {
        return queue.Count != 0;
    }
}
