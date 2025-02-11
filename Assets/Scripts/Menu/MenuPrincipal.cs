using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public void JugarJuego()
    {
        // Cambiar "NombreDeLaEscena" por el nombre de tu escena del juego
        SceneManager.LoadScene("Tutorial");
    }

    public void AbrirOpciones()
    {
        // Aqu� puedes abrir un men� de opciones
        Debug.Log("Abrir Opciones");
        SceneManager.LoadScene("opciones");
    }

    public void SalirJuego()
    {
        // Cierra la aplicaci�n (solo funciona en la build)
        Debug.Log("Salir del Juego");
        Application.Quit();
    }
}
