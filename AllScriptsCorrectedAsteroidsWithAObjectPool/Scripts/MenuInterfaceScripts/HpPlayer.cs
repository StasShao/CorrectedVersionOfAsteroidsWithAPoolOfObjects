using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpPlayer : MonoBehaviour
{
    public float hpRange = 5; // Числовая переменная , отвечает за количество объектов в массиве GameObject[] hpObj , синхронизированная с количеством жизней игрока в другом скрипте
    public GameObject[] hpObj; // массив GameObject , в нем находятся Image котые явсяются индикатором жизней персонажа
   
    void FixedUpdate()
    {
        if(hpRange == 4) // условие если hpRange = 4
        {
            hpObj[4].SetActive(false); // выключаем активность GameObject из массива с индексом 4
        }
        if(hpRange == 3) // // условие если hpRange = 3
        {
            hpObj[3].SetActive(false); // выключаем активность GameObject из массива с индексом 3
        }
        if(hpRange == 2) // // условие если hpRange = 2
        {
            hpObj[2].SetActive(false); // выключаем активность GameObject из массива с индексом 2
        }
        if(hpRange == 1) // // условие если hpRange = 1
        {
            hpObj[1].SetActive(false); // выключаем активность GameObject из массива с индексом 1
        }
        if(hpRange == 0) // // условие если hpRange = 0
        {
            hpObj[0].SetActive(false); // выключаем активность GameObject из массива с индексом 0
        }
    }
}
