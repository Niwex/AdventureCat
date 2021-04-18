using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    [SerializeField] Transform playerTransform;
    float randX;
    //[SerializeField]
    //Vector2 whereToSpawn;
    public float spawnRate = 0f;
    float nextSpawn = 0f;
    public int numOfSpawns = 3;
    public float spawnRadius = 5f;
    bool spawning;
    void Start()
    {
        playerTransform = FindObjectOfType<CharacterControl>().GetComponent<Transform>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfSpawns > 0)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) <= spawnRadius)
            {
                if (Time.time > nextSpawn)
                {
                    Debug.Log("Spawn" + enemy);
                    nextSpawn = Time.time + spawnRate;
                    //randX = Random.Range(-1f , 1f);
                    //whereToSpawn = new Vector2(randX, transform.position.x);
                    Instantiate(enemy, transform.position, Quaternion.identity);
                    numOfSpawns--;
                }
            }
        }
        
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}


