using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    [Header("Da�o del Enemigo")]
    [SerializeField] private int damageAmount = 10;       // Cantidad de da�o infligido al jugador
    [SerializeField] private float attackCooldown = 2f;  // Tiempo entre ataques
    public Animator anim2;                               // Animator del enemigo

    private GameObject player;                           // Referencia al jugador
    private float nextDamageTime = 0f;                   // Tiempo para el pr�ximo ataque

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
                anim2.SetBool("isAttacking", true); // Activa la animaci�n
                nextDamageTime = 0; // Reinicia el temporizador
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim2.SetBool("isAttacking", false); // Detiene la animaci�n al salir de la colisi�n
            player = null; // Limpia la referencia al jugador
        }
    }

    // M�todo llamado desde el evento de animaci�n
    public void ApplyDamage()
    {
        if (player != null) // Aseg�rate de que el jugador a�n est� en contacto
        {
            Vida_Player vida_Player = player.GetComponent<Vida_Player>();
            if (vida_Player != null)
            {
                Debug.Log("Enemy deals damage");
                vida_Player.TakeDamage(damageAmount); // Aplica da�o al jugador
            }
        }
    }
}
