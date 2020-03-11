using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class StateLogger : SimpleLogger
{
    public bool AutoTrackPlayerStates = true;
    public bool AutoTrackDialogController = true;
    private string dialogState = "Starting";
    private string lastValidDialogState = "Starting";
    private string playerState = "Starting";
    private string lastValidPlayerState = "Starting";
    private string state = "State";
    private string lastValidState = "State";
    private bool stateChanged = false;


    void Update()
    {
        if (doStateLogger)
        {
            if (AutoTrackPlayerStates)
            {
                playerState = stateAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
                if (!playerState.Equals(lastValidPlayerState))
                {
                    string coroutineValues = "player-state," + playerState;
                    StartCoroutine(Upload(coroutineValues));
                    lastValidPlayerState = playerState;
                }
            }

            if (AutoTrackDialogController)
            {
                dialogState = dialogController.GetCurrentAnimatorClipInfo(0)[0].clip.name;
                if (!dialogState.Equals(lastValidDialogState))
                {
                    string coroutineValues = "dialog-state," + dialogState;
                    StartCoroutine(Upload(coroutineValues));
                    lastValidDialogState = dialogState;
                }
            }

            if (stateChanged)
            {
                string coroutineValues = "game-state," + state;
                StartCoroutine(Upload(coroutineValues));
                lastValidState = state;
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
