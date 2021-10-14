using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TestScore : MonoBehaviour
{
    public Text score, highScore;
    public Score _score;
       void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>();
        highScore = GameObject.FindGameObjectWithTag("BestScore").GetComponent<Text>();
        _score = score.GetComponent<Score>();
    }

   
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "AsterMax")
        {
         _score._curentScore += 20f;
        }
        if(col.gameObject.tag == "AsterM")
        {
         _score._curentScore += 50f;
        }
        if(col.gameObject.tag == "AsterMin")
        {
         _score._curentScore += 100f;
        }
        if(col.gameObject.tag == "Nlo")
        {
         _score._curentScore += 200f;
        }
      
    }
}
