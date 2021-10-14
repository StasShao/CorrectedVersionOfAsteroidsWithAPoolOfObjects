using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDir : MonoBehaviour
{
    public float speed = 0.06f;
    
    
    void Update()
    {
         transform.position = Vector2.Lerp(transform.position, new Vector2(-30f, transform.position.y), speed * Time.deltaTime);
    }
}
