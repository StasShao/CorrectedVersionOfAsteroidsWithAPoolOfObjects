using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolMid : MonoBehaviour
{
    public GameObject[] midAsters;
    public GameObject prefab;
    public Vector2 LeftPos;
    public Vector2 RightPos;
    public bool mid;
    public float force = 20f;
    public int poolCound = 20;
    public int poolCurentElementId = 0;
    
    void Start()
    {
        midAsters = new GameObject[poolCound];
        for(int i = 0; i < poolCound; i ++)
        {
            midAsters[i] = Instantiate(prefab, transform.position, transform.rotation, transform);
            midAsters[i].SetActive(false);
        }
    }

    
    void FixedUpdate()
    {
        if(poolCurentElementId >= 20)
        {
            poolCurentElementId = 0;
        }
       if(mid == true)
       {
         midAsters[poolCurentElementId].SetActive(true);  
         midAsters[poolCurentElementId].transform.position = LeftPos;
         midAsters[poolCurentElementId].GetComponent<Asteroids>().LeftForce = true;
         poolCurentElementId ++;
         midAsters[poolCurentElementId].SetActive(true);
         midAsters[poolCurentElementId].transform.position = RightPos;
         midAsters[poolCurentElementId].GetComponent<Asteroids>().RightForce = true;
         poolCurentElementId ++;
         mid = false;
       }
    }
}
