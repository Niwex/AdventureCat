using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowTransitionSpawners : MonoBehaviour
{
    GameObject[] spawners;


    void Update()
    {
        if (FindObjectOfType<EnemySpawner>() == null)
        {
            FindObjectOfType<LevelLoader>().allowTransition = true;
        }
    }
}
