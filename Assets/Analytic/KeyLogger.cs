using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class KeyLogger : SimpleLogger
{

    // Update is called once per frame
    void Update()
    {
        if (doKeyLogger)
        {
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(vKey))
                {
                    if (!vKey.ToString().Contains("Mouse"))
                    {
                        string coroutineValues = "key," + vKey.ToString();
                        StartCoroutine(Upload(coroutineValues));
                    }

                }
            }
        }
        
    }
}
