using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    public float posY = 5.18f; // Числовая переменная , отвечает за Vector2 позицию на экране по оси Y
    
    void OnTriggerEnter2D(Collider2D col) // метод в котором условие если коллайдер входит в триггер
    { 
     col.transform.position = new Vector2(col.transform.position.x , posY); // перемещае вошедший коллайдер на позицию posY по оси Y
    }
}
