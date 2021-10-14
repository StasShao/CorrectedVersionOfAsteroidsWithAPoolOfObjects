using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectorLvls : MonoBehaviour
{
    SpawnerBeginner spwBegin; // Переменная для инициализации скрипта SpawnerBeginner
    public GameObject[] asteroids; // Публичная переменная массива GameObject средние астероиды
    public GameObject[] asteroidsMax; // Публичная переменная массива GameObject большие астероиды
    public GameObject[] asteroidsMin; // Публичная переменная массива GameObject мелкие астероиды
    public float maxObj; // Публичная числовая переменная , отвечает за подсчет всех астероидов на сцене
    
   
    
    void Update()
    {
        asteroids = GameObject.FindGameObjectsWithTag("AsterM"); // присваиваем в переменную массива все найденные объекты с тегом AsterM
        asteroidsMin = GameObject.FindGameObjectsWithTag("AsterMin"); // присваиваем в переменную массива все найденные объекты с тегом AsterMin
        asteroidsMax = GameObject.FindGameObjectsWithTag("AsterMax"); // присваиваем в переменную массива все найденные объекты с тегом AsterMax
        spwBegin = GameObject.FindGameObjectWithTag("SpawnBeginer").GetComponent<SpawnerBeginner>(); // присваиваем в переменную найденный объект с тегом SpawnBeginer
        
        
        maxObj = asteroids.Length + asteroidsMin.Length + asteroidsMax.Length; // запичываем в переменную число  суммы всех найденных астероидов из массивов

        if(maxObj == 0) // условие (если число = 0)
        {
            Plus(); // запускаем метод Plus()
         
        }
       
    }
    
    void Plus() // метод Plus()
    {
        
        spwBegin.howMuchAster = 0f; // обращаемся к найденному скрипту на другом объетке , устанавливаем в найденном скрипте число howMuchAster равное нулю
        spwBegin.maximumSpans += 1f; //обращаемся к найденному скрипту на другом объетке , Прибавляем в найденном скрипте число maximumSpans +1
        spwBegin.poolCurentElementId = 0;
        gameObject.SetActive(false); // выключаем активность данного объекта
       
    }
}
