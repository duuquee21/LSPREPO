using UnityEngine;



public class Arrow2D : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public int damage = 10;   // Daño que inflige al jugador
    public float lifeTime = 5f; // Tiempo antes de destruir el proyectil

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            // Aplica fuerza en la dirección actual del proyectil
            rb.velocity = transform.right * speed;
        }

        Destroy(gameObject, lifeTime); 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Vida_Player vidaPlayer = other.GetComponent<Vida_Player>();
            if (vidaPlayer != null)
            {
                vidaPlayer.TakeDamage(damage); 
                Debug.Log("El jugador recibió daño del proyectil");
            }
            Destroy(gameObject); 
        }
    }
}

