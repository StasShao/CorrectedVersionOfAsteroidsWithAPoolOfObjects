using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NloII : MonoBehaviour
{
    public float speed = 10f;
    public float rayDist = 20f;
    public float force = 10f;
    public float timer = 0f;
    public float randomRange;
    public float randomDir;
    LeftDir lDir;
    RightDir rDir;
    public LayerMask mask;
    public AudioSource aSource;
    AudioClip aClip;
    public AudioClip[] clips;
    Rigidbody2D _rb;
    
    public GameObject bullet;
    public GameObject boom;
    public Transform parentPool;
    public Transform poolMid;
    public Transform poolMin;
    GameObject pl;
    Transform player;
    GameObject nloBulletPool;
    NloBulletPool nloPooBullet;
    void Start()
    {
       _rb = GetComponent<Rigidbody2D>();
        parentPool = GameObject.FindGameObjectWithTag("SpawnBeginer").transform;
        poolMid = GameObject.FindGameObjectWithTag("PoolMid").transform;
        poolMin = GameObject.FindGameObjectWithTag("PoolMin").transform;
       aClip = aSource.clip;
       lDir = GetComponent<LeftDir>();
       rDir = GetComponent<RightDir>();
       randomDir = Random.Range(0,10);
       pl = GameObject.FindGameObjectWithTag("Player");
       nloBulletPool = GameObject.FindGameObjectWithTag("NloBulletPool");
       nloPooBullet = nloBulletPool.GetComponent<NloBulletPool>();
      
    }

    
    void Update()
    {

       
       
       if(randomDir >= 0f & randomDir <= 5f)
       {
           rDir.enabled = true;

       }
       if(randomDir >= 5f & randomDir <= 10f)
       {
           lDir.enabled = true;

       }
       if(lDir.enabled && rDir.enabled)
       {
           rDir.enabled = false;
           lDir.enabled = true;
       }
       if(pl)
       {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       }
       if(player)
       {
           pl = GameObject.FindGameObjectWithTag("Player");
       }
    }
    void FixedUpdate()
    {
        pl = GameObject.FindGameObjectWithTag("Player");
        randomRange = Random.Range(0.3f,0.9f);
        timer += 0.1f * Time.deltaTime;
        if(timer >= randomRange)
        {
            aClip = clips[1];
            aSource.PlayOneShot(aClip);
            nloPooBullet.Shot();
           // Instantiate(bullet, transform.position, gameObject.transform.rotation);

            timer = 0f;
        }
        if(player)
        {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
        }
        if(pl)
        {
           Vector2 direction = pl.transform.position - transform.position;
           float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
           _rb.rotation = angle;
        }
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if(col.gameObject.tag == "Bullet") 
        {
            if(gameObject)
            Instantiate(boom, transform.position, Quaternion.identity);
            col.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            col.gameObject.GetComponent<Rigidbody2D>().inertia = 0;
            col.gameObject.GetComponent<Rigidbody2D>().rotation = 0;
            col.gameObject.SetActive(false);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "Player")
        {
            if(gameObject)
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
            Destroy(gameObject);
        }
        if( col.gameObject.tag == "AsterM")
        {
           col.gameObject.transform.parent = poolMid;
           col.gameObject.SetActive(false);
           Instantiate(boom, transform.position, Quaternion.identity);
           Destroy(gameObject);
        }
        if(col.gameObject.tag == "AsterMin")
        {
            col.gameObject.transform.parent = poolMin;
            col.gameObject.SetActive(false);
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if(col.gameObject.tag == "AsterMax")
        {
            col.gameObject.transform.parent = parentPool;
            col.gameObject.SetActive(false);
            Instantiate(boom, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
