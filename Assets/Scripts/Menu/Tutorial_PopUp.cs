using UnityEngine;
using UnityEngine.UI;

public class TutorialPopup : MonoBehaviour
{
    public GameObject popupPanel; // Referencia al Panel del Pop-up
    public Button understoodButton; // Referencia al botón "Entendido"

    void Start()
    {
        // Asegurarse de que el Pop-up esté activo al inicio
        popupPanel.SetActive(true);

        // Deshabilitar el control del juego al inicio
        Time.timeScale = 0;

        // Asignar la funcionalidad al botón
        understoodButton.onClick.AddListener(ClosePopup);
    }

     public void ClosePopup()
    {
        Debug.Log("Botón pulsado: Ejecutando ClosePopup.");
        // Desactivar el Pop-up
        popupPanel.SetActive(false);

        // Reanudar el juego
        Time.timeScale = 1;
    }

}
