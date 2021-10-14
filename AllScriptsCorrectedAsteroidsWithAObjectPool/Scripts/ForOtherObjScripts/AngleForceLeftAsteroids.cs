using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleForceLeftAsteroids : MonoBehaviour
{
    float randomGravity; // Числовая переменна , отвечает за случайное число которое будет применятся к гравитации
    public float force = 2f; //Числовая переменная силы отклонения от курса для отколовшегося астероида
    Rigidbody2D _rb; // переменная Rigidbody
    
    
    void Start()
    {
     _rb = GetComponent<Rigidbody2D>(); // Инициализируем Rigidbody
     randomGravity = Random.Range(0.2f,3); // генерируем в старте случайное число которое будет применятся к гравитации от 0,2 до 3
    }

        void Update()
    {
        
       _rb.AddForce(-transform.right * force); //Каждый кадр прилагаем силу по оси Х Rigidbody
       
       _rb.gravityScale = randomGravity; // Каждый кадр устанавливаем гравитацию для Rigidbody , случайно сгенерированным числом
    }
}
