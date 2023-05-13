using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        float newPositionX = rb.position.x + movement * speed * Time.fixedDeltaTime;
        newPositionX = Mathf.Clamp(newPositionX, -1.80f, 1.90f);
        Vector2 newPosition = new Vector2(newPositionX , rb.position.y);
        rb.MovePosition(newPosition);
    }

}
