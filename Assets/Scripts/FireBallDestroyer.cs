using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDestroyer : MonoBehaviour
{
    [SerializeField] float flyDistance;
    void Start()
    {
        
    }


    void Update()
    {
        if (transform.position.magnitude > flyDistance)
        {
            Destroy(gameObject);
        }
    }

}
