using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseLogger : SimpleLogger
{

    // Update is called once per frame
    void Update()
    {
        if (doMouseLogger)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(vKey))
                {
                    if (vKey.ToString().Contains("Mouse"))
                    {
                        string coroutineValues = "mouse," + vKey.ToString() + ",click," + Input.mousePosition.x + ";" + Input.mousePosition.y;
                        StartCoroutine(Upload(coroutineValues));
                    }
                }
            }
        }
    }
}
