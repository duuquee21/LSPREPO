using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuOpciones : MonoBehaviour
{
    [Header("Referencias")]
    public Slider sliderVolumen;
    public Slider sliderBrillo;

    private void Start()
    {
        
        sliderVolumen.value = PlayerPrefs.GetFloat("Volumen", 1f);
        sliderBrillo.value = PlayerPrefs.GetFloat("Brillo", 1f);

        
        AjustarVolumen(sliderVolumen.value);
        AjustarBrillo(sliderBrillo.value);

        
        sliderVolumen.onValueChanged.AddListener(AjustarVolumen);
        sliderBrillo.onValueChanged.AddListener(AjustarBrillo);
    }

    public void AjustarVolumen(float valor)
    {
        
        AudioListener.volume = valor;

        
        PlayerPrefs.SetFloat("Volumen", valor);
    }

    public void AjustarBrillo(float valor)
    {
        
        RenderSettings.ambientLight = Color.white * valor;

        
        PlayerPrefs.SetFloat("Brillo", valor);
    }

    public void GuardarYSalir()
    {
        
        PlayerPrefs.Save();
        gameObject.SetActive(false);
    }
    public void Volver_menu()
    {
        // Cambiar "NombreDeLaEscena" por el nombre de tu escena del juego
        SceneManager.LoadScene("menu_principal");
    }
}
