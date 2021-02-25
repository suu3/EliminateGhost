using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Score : MonoBehaviour
{
    public int score;
    public Text textScore;
    
    
    void Update()
    {
        textScore.text = Convert.ToString(score);
    }
}
