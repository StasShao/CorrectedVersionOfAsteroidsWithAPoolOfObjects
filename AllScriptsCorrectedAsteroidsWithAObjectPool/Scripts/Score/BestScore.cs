using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public Text bestScore;
    Score _scor;
   public float _bestScore;
   void Awake()
   {
       if(PlayerPrefs.HasKey("Save"))
       {
         _bestScore =  PlayerPrefs.GetFloat("Save");
       }
      
   }
    void Start()
    {
        _scor = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
    }

       void FixedUpdate()
    {
        
        if(_scor._curentScore > _bestScore)
        {
          _bestScore = _scor._curentScore;
          PlayerPrefs.SetFloat("Save", _bestScore);
        }
        bestScore.text = _bestScore.ToString();
        if(Input.GetKeyDown(KeyCode.P))
        {
            _bestScore = 0f;
            PlayerPrefs.SetFloat("Save", _bestScore);
        }
    }
}
