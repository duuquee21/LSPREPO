using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vida_Player : MonoBehaviour
{
    [Header("Configuración de Vida")]
    [SerializeField] private int maxHealth = 10; // Vida máxima

    [Header("Curación")]
    [SerializeField] public int healAmount = 3; // Cantidad de vida a curar (editable desde el Inspector)

    [Header("Barra de Vida")]
    [SerializeField] private Slider barraDeVida; // Referencia a la barra de vida en la UI

    private int Health;

    void Start()
    {
        Health = maxHealth;
        ActualizarBarraDeVida();
        Debug.Log("Vida actual del jugador: " + Health);
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Health = Mathf.Clamp(Health, 0, maxHealth); // Asegura que no baje de 0 ni supere maxHealth
        ActualizarBarraDeVida();
        Debug.Log("El jugador ha recibido " + damage + " de daño");

        // Si la vida llega a 0
        if (Health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
        Health = Mathf.Clamp(Health, 0, maxHealth); // Asegura que no supere maxHealth
        ActualizarBarraDeVida();
        Debug.Log("El jugador se ha curado " + amount + " puntos de vida. Vida actual: " + Health);
    }

    public void Die()
    {
        Debug.Log("El jugador ha muerto");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }

    private void ActualizarBarraDeVida()
    {
        if (barraDeVida != null)
        {
            barraDeVida.value = (float)Health / maxHealth;
        }
    }
}
