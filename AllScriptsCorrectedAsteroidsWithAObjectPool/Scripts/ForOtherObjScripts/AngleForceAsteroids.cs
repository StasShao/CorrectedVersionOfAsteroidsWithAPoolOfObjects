using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleForceAsteroids : MonoBehaviour
{
    public float force = 2f; // Числовая переменная силы отклонения от курса для отколовшегося астероида
    Rigidbody2D _rb;// переменная Rigidbody
    
    
    void Start()
    {
     _rb = GetComponent<Rigidbody2D>();// Инициализируем Rigidbody
    }

        void Update()
    {
       _rb.AddForce(transform.right * force);// Каждый кадр прилагаем силу по оси Х Rigidbody
    }
}
