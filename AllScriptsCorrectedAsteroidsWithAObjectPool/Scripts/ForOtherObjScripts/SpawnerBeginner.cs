using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBeginner : MonoBehaviour
{
    float randomSpawn; // Числовая переменная , используется для генерации случайного числа , для использования этого числа в пременной Vector2 positionX
    public GameObject inspector; // публичная переменная GameObject , используется для включения и отключения объекта
    public float howMuchAster; // Числовая переменная , используется для расчета числа астероидов на сцене , импользуется в другом скрипте
    public float maximumSpans = 2f; // Числовая переменная , используется для расчета максимальноколичества генерации астероидов
    public GameObject[] maxAsters; // массив GameObject большие астероиды
    public GameObject[] poolAasteroidsMax;
    public GameObject prefab;
    public Transform poolParent;
    public int poolCurentElementId = 0;
    public int poolCount = 10;
    public float timer = 0f; // Числовая переменная , используется для запуска таймера
    public float timeScaleTimer = 0f;
    public bool StartGame = false;
    Vector2 positionX; // переменная Vector2
    void Start()
    {
        poolParent = transform;
        poolAasteroidsMax = new GameObject[poolCount];
       for(int i = 0; i < poolCount; i ++)
       {
           poolAasteroidsMax[i] = Instantiate(prefab, transform.position, transform.rotation, poolParent);
           poolAasteroidsMax[i].SetActive(false);
       }
    }
    void FixedUpdate()
    {
        randomSpawn = Random.Range(-8.7f,8.7f); // генерируем случайное число от - 8,7 до 8,7 и записываем его в randomSpawn каждый кадр
        positionX = new Vector2(randomSpawn , transform.position.y); // записываем координаты в Vector2 positionX случайно число из randomSpawn каждый кадр
        if(StartGame == false)
        {
         timeScaleTimer += 0.1f * Time.deltaTime;
        }
        timeScaleTimer += 0.1f * Time.deltaTime;
        if(timeScaleTimer >= 0.79f)
        {
            timeScaleTimer = 0f;
            StartGame = true;
        }
        timer += 0.1f * Time.deltaTime; // включаем таймер
        if(timer >= 0.4f) // условие если таймер равен или больше 0,4
        {
        timer = 0f; // обнуляем таймер
        }
        if(maximumSpans >= 10f)
        {
            maximumSpans = 10f;
        }
        if(howMuchAster >= maximumSpans) // условие если число астероидов на сцене больше либо равно числу maximumSpans( максимальное число генераций астероидов)
        {
            
            return; // метод дальше не выполняется при этом условии
        }
        
        if(timer >= 0.39f) // условие если таймер больше или равен 0,3
        {
            
          timer = 0f; // обнуляем таймер
          Instance(); // запускаем метод Instance()
          
        }
    }
    
    void Instance() // метод Instance()
    {
        if(poolCurentElementId < maximumSpans)
        {
        poolAasteroidsMax[poolCurentElementId].SetActive(true);
        poolAasteroidsMax[poolCurentElementId].transform.position = positionX;
        poolCurentElementId ++;
        }
    
        howMuchAster += 1; // прибавляем +1 в числовую переменную howMuchAster
        if(StartGame == true)
        {
        inspector.SetActive(true); // включаем активность GameObject (inspector)
        }
        
    }
}
