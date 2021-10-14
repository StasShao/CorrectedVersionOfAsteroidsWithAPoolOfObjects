using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerChelnok : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public Transform[] positions;
    public SpawnEnemy enemSpw;
    public bool spawn;
    public bool spawn2;
    void Start()
    {
        enemSpw = GameObject.FindGameObjectWithTag("Spawner").GetComponent<SpawnEnemy>();
    }

    
    void FixedUpdate()
    {
        if(spawn == true)
        {
          transform.position = Vector3.Lerp(transform.position ,positions[1].position, speed * Time.deltaTime);

        }
        if(spawn == false)
        {
            transform.position = Vector3.Lerp(transform.position ,positions[0].position, speed * Time.deltaTime);
        }
    }
    void OnTriggerEnter(Collider col)
    {
       if(col.tag == "Trigger")
       {
         enemSpw.SpawnEnemys();
       }
    }
}
