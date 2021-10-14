using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapLR : MonoBehaviour
{
    public float posX = 9.07f; // Числовая переменная , отвечает за Vector2 позицию на экране по оси X
    void OnTriggerEnter2D(Collider2D col) // метод в котором условие если коллайдер входит в триггер
    {
       
      col.transform.position = new Vector2(posX , col.transform.position.y); // перемещае вошедший коллайдер на позицию posX по оси X
      
    }
}
