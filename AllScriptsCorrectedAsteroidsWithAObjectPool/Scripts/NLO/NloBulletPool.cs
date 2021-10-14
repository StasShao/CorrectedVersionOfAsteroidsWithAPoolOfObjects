using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloBulletPool : MonoBehaviour
{
    public GameObject[] bullets;
    public GameObject prefab;
    public Transform poolParent;
    Transform Nlo;
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
      
      bullets[poolCurentElementId].SetActive(true);
      Nlo = GameObject.FindGameObjectWithTag("Nlo").transform;
      bullets[poolCurentElementId].transform.position = Nlo.position;
      bullets[poolCurentElementId].transform.rotation = Nlo.rotation;
      bullets[poolCurentElementId].GetComponent<BulletNlo>().timer = 0f;
      bullets[poolCurentElementId].GetComponent<Rigidbody2D>().angularVelocity = 0;
      bullets[poolCurentElementId].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
      bullets[poolCurentElementId].GetComponent<Rigidbody2D>().inertia = 0;
      bullets[poolCurentElementId].GetComponent<Rigidbody2D>().rotation = 0;
      bullets[poolCurentElementId].GetComponent<Rigidbody2D>().AddRelativeForce(Nlo.transform.right * force, ForceMode2D.Impulse);
      
      poolCurentElementId ++;
    }
}
