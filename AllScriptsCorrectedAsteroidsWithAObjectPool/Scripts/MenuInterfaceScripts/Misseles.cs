using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misseles : MonoBehaviour
{
    public float timer = 0f;
    public float misseleRange = 3;
    public GameObject[] misseles;
    
    public ShipController shipController;
    
    public GameObject player;
   
    void FixedUpdate()
    {
         player = GameObject.FindGameObjectWithTag("Player");
         if(timer >= 0.2f)
         {
             misseleRange = 3f;
             timer = 0f;
         }
         
       
        if(player)
        {
         if(misseleRange == 3)
         {
          foreach(GameObject missele in misseles)
          {
              missele.SetActive(true);
          }
         }  
         if(misseleRange == 2)
         {
          misseles[2].SetActive(false);
         }    
         if(misseleRange == 1)
         {
          misseles[2].SetActive(false);
          misseles[1].SetActive(false);
         }    
        if(misseleRange <= 0)
        {
            timer += 0.1f * Time.deltaTime;
            misseles[2].SetActive(false);
            misseles[1].SetActive(false);
            misseles[0].SetActive(false);
           
        }

      }
    }
    
}
