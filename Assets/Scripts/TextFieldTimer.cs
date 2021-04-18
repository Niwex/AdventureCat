using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextFieldTimer : MonoBehaviour
{
    public float timeToWait = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, timeToWait);
    }
    
}
