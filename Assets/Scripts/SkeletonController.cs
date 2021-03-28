using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonController : MonstersScript
{

    
    Rigidbody2D rigidbody2d;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            
        Vector2 position = rigidbody2d.position;
        
        rigidbody2d.MovePosition(position);
    }
}
