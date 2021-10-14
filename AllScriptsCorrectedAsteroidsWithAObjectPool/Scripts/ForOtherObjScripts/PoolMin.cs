using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMin : MonoBehaviour
{
   public GameObject[] minAsters;
    public GameObject prefab;
    public Vector2 LeftPos;
    public Vector2 RightPos;
    public bool min;
   
    public int poolCound = 40;
    public int poolCurentElementId = 0;
    
    void Start()
    {
        minAsters = new GameObject[poolCound];
        for(int i = 0; i < poolCound; i ++)
        {
            minAsters[i] = Instantiate(prefab, transform.position, transform.rotation, transform);
            minAsters[i].SetActive(false);
        }
    }

    
    void FixedUpdate()
    {
         if(poolCurentElementId >= 20)
        {
            poolCurentElementId = 0;
        }
       if(min == true)
       {
         minAsters[poolCurentElementId].SetActive(true);  
         minAsters[poolCurentElementId].transform.position = LeftPos;
         minAsters[poolCurentElementId].GetComponent<Asteroids>().LeftForce = true;
         poolCurentElementId ++;
         minAsters[poolCurentElementId].SetActive(true);
         minAsters[poolCurentElementId].transform.position = RightPos;
         minAsters[poolCurentElementId].GetComponent<Asteroids>().RightForce = true;
         poolCurentElementId ++;
         min = false;
       }
    }
}
