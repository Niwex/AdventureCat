using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDestroyer : MonoBehaviour
{
    [SerializeField] float secondsToDestroy;
    void Start()
    {

    }


    void Update()
    {
        Destroy(gameObject, secondsToDestroy);
    }
}
