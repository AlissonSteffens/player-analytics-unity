using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogger : SimpleLogger
{

    string label = "1";

    public void setLabel(string label)
    {
        this.label = label;
    }

    public void setScore(string score)
    {
        if (doScoreLogger)
        {
            string coroutineValues = "score,died,"+ label + ","+ score;
            StartCoroutine(Upload(coroutineValues));

        }

    }

}
