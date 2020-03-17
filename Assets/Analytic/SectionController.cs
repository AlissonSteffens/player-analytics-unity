using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SectionController : MonoBehaviour
{
    public string GenerateSectionHash(string user)
    {
        string time = System.DateTime.Now.ToString();
        string hash = user + "#" + time;
        return hash;
    }
}
