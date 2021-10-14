using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text score;
    public float _curentScore;
        void Start()
    {
        
    }

    
    void Update()
    {
        score.text = _curentScore.ToString();
    }
}
