using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToDestroy : MonoBehaviour
{
    public float timer = 0f; // Публичная числовая переменная , отвечает за таймер
   
    void FixedUpdate()
    {
        timer += 0.1f * Time.deltaTime; // запускаем таймер
        if(timer >= 0.3f) // условие если таймер больше либо равно 0,3
        {
            timer = 0f; // обнуляем таймер
            Destroy(gameObject); // уничтожаем данный объект
        }
    }
}
