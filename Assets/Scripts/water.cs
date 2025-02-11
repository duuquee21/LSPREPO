using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar la escena

public class WaterDeath : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Comprueba si el jugador toca el agua
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Tocando Agua");
            // Llama a la función Die del jugador (si existe) o reinicia la escena directamente
            Vida_Player vida = collision.gameObject.GetComponent<Vida_Player>();
            if (vida != null)
            {
                vida.Die(); // Llama a la función de morir en el jugador
            }
            else
            {
                // Si no hay una función Die, reinicia la escena
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
}
