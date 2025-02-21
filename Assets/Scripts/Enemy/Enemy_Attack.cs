using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    [Header("Daño del Enemigo")]
    [SerializeField] private int damageAmount = 10;       // Cantidad de daño infligido al jugador
    [SerializeField] private float attackCooldown = 2f;  // Tiempo entre ataques
    public Animator anim2;                               // Animator del enemigo

    private GameObject player;                           // Referencia al jugador
    private float nextDamageTime = 0f;                   // Tiempo para el próximo ataque

    private void Update()
    {
        nextDamageTime += Time.deltaTime; // Incrementa el temporizador de cooldown
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject; // Almacena la referencia al jugador
            if (nextDamageTime >= attackCooldown)
            {
                anim2.SetBool("isAttacking", true); // Activa la animación
                nextDamageTime = 0; // Reinicia el temporizador
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim2.SetBool("isAttacking", false); // Detiene la animación al salir de la colisión
            player = null; // Limpia la referencia al jugador
        }
    }

    // Método llamado desde el evento de animación
    public void ApplyDamage()
    {
        if (player != null) // Asegúrate de que el jugador aún está en contacto
        {
            Vida_Player vida_Player = player.GetComponent<Vida_Player>();
            if (vida_Player != null)
            {
                Debug.Log("Enemy deals damage");
                vida_Player.TakeDamage(damageAmount); // Aplica daño al jugador
            }
        }
    }
}
