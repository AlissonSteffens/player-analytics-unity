﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Analytic : MonoBehaviour
{
    [Header("API Settings")]
    public string ApiURL;
    public string User;
    [Header("Debbug Settings")]
    public bool IsDebugging;
    [Header("Loggin Settings")]
    public bool TakePictures;
    public bool KeyLogger;
    public bool MouseLogger;
    public bool StateLogger;


    //public string ApiURL = "http://player-analytics.now.sh/api/input";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}