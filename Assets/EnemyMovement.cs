using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Transform enemyTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyTransform = transform;
        rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        
    }

    private void FixedUpdate()
    {
        if(enemyTransform.position.x <= -1.75){
            rb.velocity = new Vector2(1 * speed, rb.velocity.y);
        }
        else if(enemyTransform.position.x >= 1.90){
            rb.velocity = new Vector2(-1 * speed, rb.velocity.y);
        }
    }

}
