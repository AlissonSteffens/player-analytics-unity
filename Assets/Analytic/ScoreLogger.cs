using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLogger : SimpleLogger
{

    string level = "1";

    public void setLevel(string level)
    {
        this.level = level;
    }

    public void setScore(string score)
    {
        if (doScoreLogger)
        {
            string coroutineValues = "score,died,"+level+","+ score;
            StartCoroutine(Upload(coroutineValues));

        }

    }

}
