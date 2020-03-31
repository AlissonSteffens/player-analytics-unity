using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowLogger : SimpleLogger
{
    private string action = "State";
    public void setAction(string newAction)
    {
        if (doFlowLogger)
        {
            if (takePictures)
            {
                GameObject.FindObjectOfType<PictureTaker>().TakePicture("flowChange");
            }
            action = newAction;
            string coroutineValues = "gameflow," + action;
            StartCoroutine(Upload(coroutineValues));
            
            
        }

    }

    public void testAndSetAction(string newAction)
    {
        if (!action.Equals(newAction) && doFlowLogger)
        {
            action = newAction;
            string coroutineValues = "gameflow," + action;
            StartCoroutine(Upload(coroutineValues));
        }

    }
}
