using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    // public float velocidadInicial = 1.2f;
    // public float velocidadMaxima = 5f;
    // public float aumentoVelocidad = 0.2f;

    // private Rigidbody2D miRigidbody;
    // private Vector2 direccion;
    // private bool lanzada;

    // private void Start()
    // {
    //     miRigidbody = GetComponent<Rigidbody2D>();
    //     direccion = Vector2.right;
    //     LanzarPelota();
    // }

    // private void FixedUpdate()
    // {
    //     if (lanzada)
    //     {
    //         float velocidadActual = Mathf.Min(velocidadInicial + aumentoVelocidad * Time.time, velocidadMaxima);
    //         miRigidbody.velocity = direccion * velocidadActual;
    //     }
    //     else
    //     {
    //         miRigidbody.velocity = Vector2.zero;
    //     }
    // }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.Space) && !lanzada)
    //     {
    //         LanzarPelota();
    //         lanzada = true;
    //     }
    // }
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
    //     {
    //         direccion = Vector2.Reflect(direccion, collision.contacts[0].normal);
    //         aumentoVelocidad += 0.1f;
    //     }
    // }

    // private void LanzarPelota()
    // {
    //     float x = Random.Range(0, 2) == 0 ? -1 : 1;
    //     float y = Random.Range(-1f, 1f);
    //     direccion = new Vector2(x, y).normalized;
    //     aumentoVelocidad = 0f;
    // }
    // private void LanzarPelota()
    // {
    //     // Aquí puedes definir la dirección inicial de la pelota
    //     Vector2 direccionInicial = new Vector2(1f, 0.5f).normalized;
    //     miRigidbody.velocity = direccionInicial * velocidadInicial;
    // }

    // private float CalcularDireccion(float posicionColision, float alturaPaleta)
    // {
    //     // Calcular una nueva dirección vertical basada en la posición de colisión y la altura de la paleta
    //     float offset = posicionColision - transform.position.y;
    //     float normalizado = offset / (alturaPaleta / 2f);
    //     return normalizado;
    // }
    public float velocidadInicial = 5f;
    public float velocidadMaxima = 10f;
    public float aumentoVelocidad = 1f;

    private Rigidbody2D miRigidbody;
    private bool pelotaLanzada = false;

    private void Start()
    {
        miRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Si la pelota no ha sido lanzada y se detecta un toque en la pantalla, lanzar la pelota
        // if (!pelotaLanzada && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        // {
        //     LanzarPelota();
        //     pelotaLanzada = true;
        // }
        if (!pelotaLanzada && Input.GetKeyDown(KeyCode.Space))
        {
            LanzarPelota();
            pelotaLanzada = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall"))
        {
            print("colision");
            // Calcular la dirección basada en la posición de colisión en la paleta
            float y = CalcularDireccion(collision.transform.position.y, collision.collider.bounds.size.y);

            // Aplicar el aumento de velocidad
            float velocidadActual = Mathf.Min(miRigidbody.velocity.magnitude + aumentoVelocidad, velocidadMaxima);

            // Calcular la nueva dirección de rebote aleatoria
            Vector2 nuevaDireccion = new Vector2(Random.Range(-1f, 1f), y).normalized;
            miRigidbody.velocity = nuevaDireccion * velocidadActual;
        }
    }

    private void LanzarPelota()
    {
        // Aquí puedes definir la dirección inicial de la pelota
        Vector2 direccionInicial = new Vector2(1f, 0.5f).normalized;
        miRigidbody.velocity = direccionInicial * velocidadInicial;
    }

    private float CalcularDireccion(float posicionColision, float alturaPaleta)
    {
        // Calcular una nueva dirección vertical basada en la posición de colisión y la altura de la paleta
        float offset = posicionColision - transform.position.y;
        float normalizado = offset / (alturaPaleta / 2f);
        return normalizado;
    }
}
