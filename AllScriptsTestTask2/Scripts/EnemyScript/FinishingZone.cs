using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishingZone : MonoBehaviour
{
    PlayerController playerController;
    GameObject keelButton;
    

    void Start()
    {
        keelButton = GameObject.FindGameObjectWithTag("FinishZone");
        keelButton.SetActive(false);
    }

    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
          playerController =  col.GetComponent<PlayerController>();
          playerController.inFinishZone = true;
          keelButton.SetActive(true);

        }
        
    }
    void OnTriggerExit(Collider col)
    {
        if(col.tag == "Player")
        {
          playerController =  col.GetComponent<PlayerController>();
          playerController.inFinishZone = false;
          keelButton.SetActive(false);

        }
    }
}
