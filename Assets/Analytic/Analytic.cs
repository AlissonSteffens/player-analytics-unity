using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analytic : MonoBehaviour
{
    [Header("API Settings")]
    public string User;
    public string Game;
    public string ApiURL;
    public string ApiKey;

    [Header("Game Objects")]
    public Animator Character;
    public Animator DialogController;

    [Header("Debbug Settings")]
    public bool IsDebugging;

    [Header("Loggin Settings")]
    public bool TakePictures;
    public bool KeyLogger;
    public bool ScoreLogger;
    public bool MouseLogger;
    public bool StateLogger;
    public bool FlowLogger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
