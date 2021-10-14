using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject pl;
    public GameObject button;
    public float camSpeed;
    public bool pause;
    public Vector3 Offset;
   
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
       if(pause)
       {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Resume();
            }
       }

           else

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                Pause();
            }
       
    }
    
    void LateUpdate()
    {
        transform.LookAt(pl.transform);
        transform.position = Vector3.Lerp(transform.position, pl.transform.position, camSpeed) +Offset;
    }
     public void Pause()
    {
      
      button.SetActive(true);
      Cursor.lockState = CursorLockMode.None;
      pause = true;
    }
     public void Resume()
    {
      
       button.SetActive(false);
       Cursor.lockState = CursorLockMode.Locked;
       pause = false;
    }
}
