using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NloDuloPosition : MonoBehaviour
{
    public Vector2 pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = pos;
    }
}
