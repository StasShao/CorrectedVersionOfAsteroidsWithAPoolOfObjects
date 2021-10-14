using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloSpawn : MonoBehaviour
{
   public Transform[] spawnPlace;
   public Transform Nlo;
   public GameObject NloCheck;
   Vector2 posY;
   public float timer = 0f;
   public float randomTime;

    void Start()
    {
        randomTime = Random.Range(1.5f, 3f);
    }

    
    void FixedUpdate()
    {
        posY = new Vector2(transform.position.x, Random.Range(2.57f,-2.57f));
        NloCheck = GameObject.FindGameObjectWithTag("Nlo");
       
        timer += 0.1f * Time.deltaTime;
        if(NloCheck)
        {
            timer = 0;
            randomTime = Random.Range(1.5f, 3f);
            return;
        }
        if(timer >= randomTime)
        {
         Instantiate(Nlo, posY, Quaternion.identity);
        }
    }
}
