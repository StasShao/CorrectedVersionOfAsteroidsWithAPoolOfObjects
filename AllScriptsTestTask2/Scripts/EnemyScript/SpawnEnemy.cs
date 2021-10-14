using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float randomSpwX;
    public float randomSpwY;
    public bool dead;
    Animator anim;
    public Transform enemy;
    public GameObject enemyobj;
    Vector3 pos;
    
    void Start()
    { 
     anim = enemyobj.GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        
        randomSpwX = Random.Range(-40, 40);
        randomSpwY = Random.Range(-40, 40);
        pos = new Vector3(randomSpwX, 0.1f, randomSpwY);
       
    }
     public void SpawnEnemys()
       {
          enemy.position = pos;
          anim.enabled = true;
          GameObject.FindGameObjectWithTag("Enemy").GetComponent<BoxCollider>().enabled = true;
          
       }

}
