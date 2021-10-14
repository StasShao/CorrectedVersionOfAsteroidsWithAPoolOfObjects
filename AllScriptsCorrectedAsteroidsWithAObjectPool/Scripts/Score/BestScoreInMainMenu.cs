using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScoreInMainMenu : MonoBehaviour
{
    public Text bestScoreMenu;
    public float sc;
        void Awake()
    {
         if(PlayerPrefs.HasKey("Save"))
       {
         sc =  PlayerPrefs.GetFloat("Save");
       }
    }

    
    void Update()
    {
        bestScoreMenu.text = sc.ToString();
    }
}
