using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletForce : MonoBehaviour
{
    public float timer = 0f;
    public float lifeTime = 5f;
    public float distance; // Числовая переменная float в данном случае будет использоваться в качестве определения расстояния
    public float maxDistance = 9; // Числовая переменная float в данном случае будет использоваться в качестве определения максимального расстояния
    
    Transform player; // Переменная Transform
    
    public float force = 10f; // сила с которой производится выстрел
    Rigidbody2D _rb; // переменная для Rigidbody
    public Vector2 point; // Переменная Vector2 с именем point
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();    // инициализация переменной Rigidbody при старте
       // _rb.AddRelativeForce(Vector2.up * force, ForceMode2D.Impulse); // добавляем усилие по оси Y для компонента  Rigidbody - импульс
       // player = GameObject.FindGameObjectWithTag("Player").transform; // Присваиваем в переменную Transform player найденый GameObject с тегом Player
       // point = new Vector2(transform.position.x, transform.position.y); // Присваиваем значение начальной позиции пули в старте
        
    }
    
    void FixedUpdate()
    {
      timer += 0.1f * Time.deltaTime;
        
        if(timer >= lifeTime)
        {
            timer = 0f;
            _rb.angularVelocity = 0f;
            _rb.velocity = Vector2.zero;
            _rb.rotation = 0f;
            _rb.inertia = 0;
           gameObject.SetActive(false);
        }
      //   if(player) // Если Player есть на сцене
      //  {
           
      //    distance = Vector2.Distance(point, transform.position); // Узнаем расстояние между начальной позицией пули и текущей позиции
     
      //   if(distance >= maxDistance) // Если дистанция от начальной позиции пули больше чем maxDistance
      //     {
      //       _rb.angularVelocity = 0f;
      //       _rb.velocity = Vector2.zero;
      //        _rb.inertia = 0;
      //      gameObject.SetActive(false); // Пуля уничтожается
      //     }
      //  }
    
    }
}
