using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Expld : MonoBehaviour
{
    GameObject sourceObj;
    AudioSource audioSource;
    AudioClip aClip;
    void Awake()
    {
        sourceObj = GameObject.FindGameObjectWithTag("SpawnBeginer");
        audioSource = sourceObj.GetComponent<AudioSource>();
        aClip = audioSource.clip;
    }

    
    void FixedUpdate()
    {
        sourceObj = GameObject.FindGameObjectWithTag("SpawnBeginer");
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Bullet" || col.gameObject.tag == "AsterM" || col.gameObject.tag == "AsterMin" || col.gameObject.tag == "Player" || col.gameObject.tag == "AsterMax") 
        {
           if(gameObject)
          sourceObj.GetComponent<AudioSource>().PlayOneShot(aClip);
            
        }
    }
}
