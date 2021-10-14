using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroids : MonoBehaviour
{   
    [SerializeField] private float rotateSpeed; // Поле Числовой переменной , отвечает за скорость вращения
   
    float gravity; // числовая переменная , отвечает за гравитацию
    
    
    public AudioSource aSource; // Публичная переменная AudioSource
    public AudioClip[] aClip; // Публичная переменная AudioClip
    public Transform boom; // Публичная переменная Transform используется для добавления эффекта взрыва
    Transform parentPool;
    Vector2 pos1; // Переменная Vector2
    Vector2 pos2; // Переменная Vector2

    // public Transform[] minAsteroids; // Массив Публичная переменная Transform используется для добавления мелких астероидов
    // public Transform[] midAsteroids; // Массив Публичная переменная Transform используется для добавления средних астероидов
   
    Transform poolMid;
     Transform poolMin;
     GameObject poolMidObj;
     GameObject poolMinObj;
     Vector2 LeftPosition;
     Vector2 RightPosition;
   public bool LeftForce;
   public bool RightForce;
   public float force = 30f;

    Rigidbody2D _rb; // Переменная Rigidbody2D
    
    
    void Awake()
    {
      

        rotateSpeed = Random.Range(-3,3); // скорость вращения в старте получает , случайно сгенерированое число от -3 до 3
        gravity = Random.Range(0.5f,2f); // генерируем случайное число для гравитации
       _rb =  GetComponent<Rigidbody2D>(); // инициализируем переменную Rigidbody
       aSource = GameObject.FindGameObjectWithTag("SpawnBeginer").GetComponent<AudioSource>(); // находим объект на сцене с тегом и берем у него компонент AudioSource
       aClip[0] = aSource.clip; // используем AudioClip из массива в AudioSource , найденного объекта
       parentPool = GameObject.FindGameObjectWithTag("SpawnBeginer").transform;
       poolMid = GameObject.FindGameObjectWithTag("PoolMid").transform;
       poolMin = GameObject.FindGameObjectWithTag("PoolMin").transform;
       poolMidObj = GameObject.FindGameObjectWithTag("PoolMid");
       poolMinObj = GameObject.FindGameObjectWithTag("PoolMin");

      
      
    }

    
    void Update()
    {
        
        _rb.AddTorque(1f * rotateSpeed); // прилогаем силу вращения , слугайно сгенерированным числом для Rigidbody
        _rb.gravityScale = gravity; // устанавливаем гравитацию для Rigidbody , можно регулировать из Inspector 
        pos1 = new Vector2(transform.position.x - 0.5f, transform.position.y); // устанавливаем положение по Vector2 слева и справа от данного объекта каждый кадр
        pos2 = new Vector2(transform.position.x + 0.5f, transform.position.y); // устанавливаем положение по Vector2 слева и справа от данного объекта каждый кадр
        
    }
    void FixedUpdate()
    {
      if(LeftForce == true)
      {
         _rb.AddForce(-Vector2.right * force);
      }
       if(RightForce == true)
      {
        _rb.AddForce(Vector2.right * force);
      }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
      if(col.gameObject.tag == "Player") // условие при котором объект соприкосновения имеет тег Player
      {
           aClip[1] = aSource.clip; // используем AudioClip из массива под индексом 1
           aSource.PlayOneShot(aClip[1]); // проигрываем AudioClip 1 раз
      } 
     
        if(col.gameObject.tag == "Bullet" || col.gameObject.tag == "BulletNlo") // условие при котором объект соприкосновения имеет тег Bullet или BulletNlo
        {
              aClip[0] = aSource.clip; // используем AudioClip из массива под индексом 0
              aSource.PlayOneShot(aClip[0]); // проигрываем AudioClip 1 раз
              col.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
              col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
              col.gameObject.GetComponent<Rigidbody2D>().inertia = 0;
              col.gameObject.GetComponent<Rigidbody2D>().rotation = 0;
              col.gameObject.SetActive(false); // уничтожаем объект соприкосновения
              
              Instantiate(boom, transform.position, Quaternion.identity); // Транслируем Transform объекта (взрыв эффект) на место текущего объекта с ориентацией Quaternion.identity
              if(gameObject.tag == "AsterMax") // условие пdри котором объект соприкосновения имеет тег AsterMax
             {
               LeftForce = false;
               RightForce = false;
               poolMidObj.GetComponent<PoolMid>().LeftPos = pos1;
               poolMidObj.GetComponent<PoolMid>().RightPos = pos2;
               poolMidObj.GetComponent<PoolMid>().mid = true;
               gameObject.transform.parent = parentPool;
               gameObject.SetActive(false);
               
            // Instantiate(midAsteroids[0],pos1, Quaternion.identity); // Транслируем Transform объекта (сердний астероид) на место pos1(слева от текущего объекта) с ориентацией Quaternion.identity
            // Instantiate(midAsteroids[1],pos2, Quaternion.identity); // Транслируем Transform объекта (взрыв эффект) на место pos2(справа от текущего объекта) с ориентацией Quaternion.identity
             
             }
            
            if(gameObject.tag == "AsterM") // условие при котором объект соприкосновения имеет тег AsterM
            {
              LeftForce = false;
               RightForce = false;
               poolMinObj.GetComponent<PoolMin>().LeftPos = pos1;
               poolMinObj.GetComponent<PoolMin>().RightPos = pos2;
               poolMinObj.GetComponent<PoolMin>().min = true;
               gameObject.transform.parent = poolMid;
               gameObject.SetActive(false);
            // Instantiate(minAsteroids[0],pos1, Quaternion.identity); // Транслируем Transform объекта (мелкий астероид) на место pos1(слева от текущего объекта) с ориентацией Quaternion.identity
            // Instantiate(minAsteroids[1],pos2, Quaternion.identity); // Транслируем Transform объекта (мелкий астероид) на место pos1(слева от текущего объекта) с ориентацией Quaternion.identity
                                       
            }
              if(gameObject.tag == "AsterMin") // условие при котором объект соприкосновения имеет тег AsterMin
              {
                LeftForce = false;
                RightForce = false;
                gameObject.transform.parent = poolMin;
                gameObject.SetActive(false);
              }
              _rb.velocity = Vector2.zero;
             // _rb.angularVelocity = 0;
              //_rb.inertia = 0;
              gameObject.SetActive(false); // уничтожаем объект соприкосновения

        }
    }
}
