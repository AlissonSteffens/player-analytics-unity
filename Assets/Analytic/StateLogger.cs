using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StateLogger : SimpleLogger
{

    private string playerState = "Starting";
    private string lastValidPlayerState = "Starting";
    private string state = "State";
    private string lastState = "State";
    private bool stateChanged = false;


    void Update()
    {
        if (doStateLogger)
        {
            playerState = stateAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
            if(!playerState.Equals(lastValidPlayerState))
            {
                string coroutineValues = "player-state," + playerState;
                StartCoroutine(Upload(coroutineValues));
                lastValidPlayerState = playerState;
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
