using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    public GameObject[] playerCheck;
   
    public OnOff onOff;
    public float plChk;
    
   
    void Start()
    {
        playerCheck = GameObject.FindGameObjectsWithTag("Player");
        
    }

   
    void Update()
    {
      plChk = playerCheck.Length;
     
   
    }
}
