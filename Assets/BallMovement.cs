using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float velocidadInicial = 1.2f;
    public float velocidadMaxima = 5f;
    public float aumentoVelocidad = 0.2f;

    private Rigidbody2D miRigidbody;
    private Vector2 direccion;

    private void Start()
    {
        miRigidbody = GetComponent<Rigidbody2D>();
        direccion = Vector2.right;
        LanzarPelota();
    }

    private void FixedUpdate()
    {
        float velocidadActual = Mathf.Min(velocidadInicial + aumentoVelocidad * Time.time, velocidadMaxima);
        miRigidbody.velocity = direccion * velocidadActual;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            direccion = Vector2.Reflect(direccion, collision.contacts[0].normal);
            aumentoVelocidad += 0.1f;
        }
    }

    private void LanzarPelota()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(-1f, 1f);
        direccion = new Vector2(x, y).normalized;
        aumentoVelocidad = 0f;
    }
}
