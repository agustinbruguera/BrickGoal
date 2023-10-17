using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Vector2 initialPosition; // Posición inicial de la pelota

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
    public int goles = 0;
    public int golesRecibidos = 0;

    private void Start()
    {
        miRigidbody = GetComponent<Rigidbody2D>();
        initialPosition = transform.position;
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Brick")) {
            Vector2 normal = collision.contacts[0].normal;
            miRigidbody.velocity = Vector2.Reflect(miRigidbody.velocity, normal).normalized * Mathf.Min(miRigidbody.velocity.magnitude + aumentoVelocidad, velocidadMaxima);
        }

        else if (collision.gameObject.CompareTag("Goal")){
            goles++;
            ResetBall();
        }

        else if (collision.gameObject.CompareTag("PlayerGoal")){
            golesRecibidos++;
            ResetBall();
        }
    }

    private void LanzarPelota()
    {
        // Genera una dirección aleatoria
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f); // Ahora la pelota puede lanzarse hacia arriba o hacia abajo

        Vector2 direccionAleatoria = new Vector2(x, y).normalized;
        miRigidbody.velocity = direccionAleatoria * velocidadInicial;
    }



    private void ResetBall()
    {
        transform.position = initialPosition; // Establece la posición de la pelota a su posición inicial
        miRigidbody.velocity = Vector2.zero;           // Detiene cualquier movimiento de la pelota
        // Aquí puedes agregar cualquier otra lógica adicional para reiniciar la pelota, como establecer su rotación a 0, etc.
        pelotaLanzada = false;
    }
}
