using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseLogger : SimpleLogger
{

    // Update is called once per frame
    void Update()
    {
       
    }

    public void MouseClick(string button)
    {
        MouseClick("menu", button);
    }

    public void MouseClick(string action, string button)
    {
        if (doMouseLogger)
        {
            string coroutineValues = "mouse," + action + ",click," + button;
            StartCoroutine(Upload(coroutineValues));
        }
    }
}
