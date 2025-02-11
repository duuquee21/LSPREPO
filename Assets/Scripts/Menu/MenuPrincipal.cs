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
        // Aquí puedes abrir un menú de opciones
        Debug.Log("Abrir Opciones");
        SceneManager.LoadScene("opciones");
    }

    public void SalirJuego()
    {
        // Cierra la aplicación (solo funciona en la build)
        Debug.Log("Salir del Juego");
        Application.Quit();
    }
}
