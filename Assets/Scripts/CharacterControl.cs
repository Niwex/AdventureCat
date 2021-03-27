using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    //Stats
    public float speed = 3; 
    public int maxHealth = 5;

    public int getHealth { get { return currentHealth; } }
    int currentHealth;

    //Attack stats
    public Transform Attack1;
    public float Attack1Radius;
    Rigidbody2D rigidbody2d;
    
    float horizontal;
    float vertical;
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();

        currentHealth = 3;
    }

    
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    public void ChangeHealth(int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        
    }

    public void Attack()
    {

    }
}
