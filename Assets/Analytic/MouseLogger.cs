using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class MouseLogger : SimpleLogger
{
    public bool AutoTrack = false;
    // Update is called once per frame
    void Update()
    {
        if (doMouseLogger)
        {
            if (AutoTrack)
            {
                foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(vKey))
                    {
                        if (vKey.ToString().Contains("Mouse"))
                        {
                            string pos = Input.mousePosition.x + ";" + Input.mousePosition.y;
                            MouseClick(vKey.ToString(), pos);
                        }
                    }
                }
            }
        }
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
