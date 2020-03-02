using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StateLogger : SimpleLogger
{

    public string state = "Startting";
    public string LastValidState = "Startting";
    public string demiState = "nothing";
    public string demiStateTime = "nothing";
    bool isDemiStating = false;
    bool stateChanged = false;

    void Update()
    {
        if (doStateLogger)
        {
            if (stateChanged)
            {
                string coroutineValues = "state," + state;
                StartCoroutine(Upload(coroutineValues));
                stateChanged = false;
                LastValidState = state;
            }
        }

    }

  

    public void changeState(string newState)
    {
        if (!state.Equals(newState))
        {
            if (!stateChanged)
            {
                state = newState;
                stateChanged = true;
            }
            
        }
        
    }
}
