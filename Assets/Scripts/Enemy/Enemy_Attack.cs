using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Attack : MonoBehaviour
{
    [Header("Daño del Enemigo")]
    [SerializeField] private int damageAmount = 10;
    [SerializeField] private float attackcooldown = 2f;

    public float nextDamageTime = 0; // Tiempo hasta que el jugador pueda recibir daño de nuevo

    private void Update()
    {

        nextDamageTime = nextDamageTime + Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Vida_Player vida_Player = collision.gameObject.GetComponent<Vida_Player>();
            
            if (vida_Player != null && nextDamageTime >= attackcooldown)
            {
                Debug.Log("Enemy attack");
                vida_Player.TakeDamage(damageAmount);
                nextDamageTime = 0;
            }
        }
    }
}
