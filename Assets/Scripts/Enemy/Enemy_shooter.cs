using UnityEngine;



public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform firePoint;         // Punto desde el cual se dispara
    public float fireRate = 3f;         // Tiempo entre disparos
    private float fireTimer;
    public Animator anim;

    public Transform player; // Referencia al jugador

    void Start()
    {
        fireTimer = fireRate;
    }

    void Update()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate;
        }
    }

    void Shoot()
    {
        if (projectilePrefab != null && firePoint != null && player != null)
        {
            // Crear el proyectil
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            anim.SetBool("isAttacking", true);
            // Orientar el proyectil hacia el jugador
            Vector2 direction = (player.position - firePoint.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            projectile.transform.rotation = Quaternion.Euler(0f, 0f, angle);

            Debug.Log("Enemigo dispara!");
        }
        else
        {
            anim.SetBool("isAttacking", false);
        }
    }
}





