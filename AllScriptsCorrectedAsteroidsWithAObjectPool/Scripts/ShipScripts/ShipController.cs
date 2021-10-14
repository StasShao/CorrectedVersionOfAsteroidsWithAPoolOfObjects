using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody2D _rb;
    public float speed = 10f;
    public float rotateSpeed = 0.5f;
    public float Magaz = 3f;
    public float timerReload = 0f;
    public OnOff onOff;
    public bool keyBoard;
    public bool mousekeyBoard;
    
    Camera _camera;
    public Transform boom;
    public Transform bullet;
    public Transform bulletSpw;
    public GameObject plSpaw;
    AudioSource aSource;
    public AudioClip[] clips;
    AudioClip aClip;
    Misseles misseles;
    HpPlayer hp;
    public Transform parentPool;
    public Transform poolMid;
    public Transform poolMin;
    GameObject BulletPool;
    PlayerBulletPool bullPool;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        aSource = GetComponent<AudioSource>();
        aClip = aSource.clip;
        onOff = GameObject.FindGameObjectWithTag("PlayerSpaw").GetComponent<OnOff>();
        plSpaw = GameObject.FindGameObjectWithTag("PlayerSpaw");
        misseles = GameObject.FindGameObjectWithTag("Magaz1").GetComponent<Misseles>();
        hp = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpPlayer>();
        _camera = Camera.main;
        parentPool = GameObject.FindGameObjectWithTag("SpawnBeginer").transform;
        poolMid = GameObject.FindGameObjectWithTag("PoolMid").transform;
        poolMin = GameObject.FindGameObjectWithTag("PoolMin").transform;
        BulletPool = GameObject.FindGameObjectWithTag("BulletPool");
        bullPool = BulletPool.GetComponent<PlayerBulletPool>();
    }

    
    void FixedUpdate()
    {
        if(keyBoard == true)
        {
        float Xmove =  Input.GetAxis("Horizontal");
        float Ymove =  Input.GetAxis("Vertical");

        
        transform.Rotate(0f,0f,-Xmove * rotateSpeed);
        _rb.AddRelativeForce(Vector2.up * Ymove * speed, ForceMode2D.Force);
        
      
         if(hp.hpRange <= 0)
          {
            plSpaw.SetActive(false);
          }
        }
      if(mousekeyBoard == true)
        {
        float Xmove =  Input.GetAxis("Mouse X");
        float YmoveM = Input.GetAxis("Mouse Y");
        float Ymove =  Input.GetAxis("Vertical");
        transform.Rotate(0,0,-Xmove * rotateSpeed);
        transform.Rotate(0,0,-YmoveM* rotateSpeed);
        
        _rb.AddRelativeForce(Vector2.up * Ymove * speed, ForceMode2D.Force);
         Magaz = misseles.misseleRange;
       
        if(hp.hpRange <= 0)
        {
         plSpaw.SetActive(false);
        }
      }
       Magaz = misseles.misseleRange;
      if(Magaz == 0)
          {
              return;
          }
      if(Time.timeScale >= 0.5f)
        {
           if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
          {
           misseles.misseleRange -=1f;
           aClip = clips[0];
           bullPool.Shot();
           aSource.PlayOneShot(aClip);
          }
        
        }
    }
    void Update()
    { 
     Magaz = misseles.misseleRange;
    }
    public void Keyboard()
    {
     keyBoard = true;
     mousekeyBoard = false;
    }
    public void MouseKeyboard()
    {
     mousekeyBoard = true;
     keyBoard = false;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "BulletNlo")
        {
           aClip = clips[1];
           hp = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpPlayer>();
           Instantiate(boom, transform.position, Quaternion.identity);
           aSource.PlayOneShot(aClip);
           hp.hpRange -= 1f;
           onOff.startOn();
           col.gameObject.GetComponent<Rigidbody2D>().inertia = 0;
           col.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
           col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           col.gameObject.GetComponent<Rigidbody2D>().rotation = 0;
           col.gameObject.SetActive(false);
           Destroy(gameObject);
           
        }
        if(col.gameObject.tag == "Nlo")
        {
           aClip = clips[1];
           hp = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpPlayer>();
           Instantiate(boom, transform.position, Quaternion.identity);
           aSource.PlayOneShot(aClip);
           hp.hpRange -= 1f;
           onOff.startOn();
           Destroy(col.gameObject);
           Destroy(gameObject);
        }
        if(col.gameObject.tag == "AsterM")
        {
         aClip = clips[1];
         hp = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpPlayer>();
         Instantiate(boom, transform.position, Quaternion.identity);
         aSource.PlayOneShot(aClip);
         hp.hpRange -= 1f;
         onOff.startOn();
         col.gameObject.transform.parent = poolMid;
         col.gameObject.SetActive(false);
         Destroy(gameObject);
        }
        if(col.gameObject.tag == "AsterMin")
        {
         aClip = clips[1];
         hp = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpPlayer>();
         Instantiate(boom, transform.position, Quaternion.identity);
         aSource.PlayOneShot(aClip);
         hp.hpRange -= 1f;
         onOff.startOn();
         col.gameObject.transform.parent = poolMin;
         col.gameObject.SetActive(false);
         Destroy(gameObject);
        }
        if(col.gameObject.tag == "AsterMax")
        {
         aClip = clips[1];
         hp = GameObject.FindGameObjectWithTag("Hp").GetComponent<HpPlayer>();
         Instantiate(boom, transform.position, Quaternion.identity);
         aSource.PlayOneShot(aClip);
         hp.hpRange -= 1f;
         onOff.startOn();
         col.gameObject.transform.parent = parentPool;
         col.gameObject.SetActive(false);
         Destroy(gameObject);  
        }
    }
}
