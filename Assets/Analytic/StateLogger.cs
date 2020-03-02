using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StateLogger : SimpleLogger
{

    private string state = "Startting";
    private string LastValidState = "Startting";
    private string demiState = "nothing";
    private string demiStateTime = "nothing";
    private bool isDemiStating = false;
    private bool stateChanged = false;

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
