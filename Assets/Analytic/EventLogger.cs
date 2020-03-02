using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLogger : SimpleLogger
{
    public void SendEvent(string category, string action)
    {
        string coroutineValues = category + "," + action;
        StartCoroutine(Upload(coroutineValues));
    }

    public void SendEvent(string category, string action, string label)
    {
        string coroutineValues = category + "," + action + "," + label;
        StartCoroutine(Upload(coroutineValues));
    }
    public void SendEvent(string category, string action, string label, string value)
    {
        string coroutineValues = category + "," + action + "," + label + "," + value;
        StartCoroutine(Upload(coroutineValues));
    }
}
