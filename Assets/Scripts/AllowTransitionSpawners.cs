using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowTransitionSpawners : MonoBehaviour
{
    GameObject[] spawners;
    [SerializeField] SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }
    void Update()
    {
        if (FindObjectOfType<BossAlotOfLegs>() == null)
        {
            if (FindObjectOfType<EnemySpawner>() == null)
            {
                FindObjectOfType<LevelLoader>().allowTransition = true;
            }
            if (FindObjectOfType<LevelLoader>().allowTransition)
            {
                //Debug.Log("Sheep is ready");
                spriteRenderer.enabled = true;
            }
        }
    }
}
