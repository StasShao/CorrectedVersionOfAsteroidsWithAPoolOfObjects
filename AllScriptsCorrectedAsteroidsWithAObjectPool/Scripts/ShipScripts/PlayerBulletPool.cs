using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletPool : MonoBehaviour
{
    public GameObject[] bullets;
    public GameObject prefab;
    public Transform poolParent;
    Transform player;
    public int poolCount = 3;
    public int poolCurentElementId = 0;
    public float force = 10f;
    
    void Start()
    {
        
        poolParent = transform;
        bullets = new GameObject[poolCount];
        for(int i = 0; i < poolCount; i++)
        {
            bullets[i] = Instantiate(prefab, transform.position, transform.rotation, poolParent);
            bullets[i].SetActive(false);
        }
    }
    void FixedUpdate()
    {
      if(poolCurentElementId >= poolCount)
      {
          poolCurentElementId = 0;
      }
    }
        public void Shot()
    {
      player = GameObject.FindGameObjectWithTag("Player").transform;
      bullets[poolCurentElementId].transform.position = player.position;
      bullets[poolCurentElementId].transform.rotation = player.rotation;
      bullets[poolCurentElementId].GetComponent<BulletForce>().timer = 0f;
      bullets[poolCurentElementId].SetActive(true);
      bullets[poolCurentElementId].GetComponent<Rigidbody2D>().AddRelativeForce(transform.up * force, ForceMode2D.Impulse);
      
      poolCurentElementId ++;
    }
}
