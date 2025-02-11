using UnityEngine;
using UnityEngine.SceneManagement; // Para cambiar de escena

public class ChangeSceneOnTouch2D : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que toca tiene el tag "Player"
        if (collision.CompareTag("Player"))
        {
            // Carga la escena llamada "puzlle1"
            SceneManager.LoadScene("arquero");
        }
    }
}
