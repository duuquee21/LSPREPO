using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class Combinaciones : MonoBehaviour
{
    private List<string> inputSequence = new List<string>();
    private Dictionary<string, System.Action> combinations = new Dictionary<string, System.Action>();
    private float inputTimer = 0.5f; // Tiempo permitido entre entradas
    private float timer;

    [SerializeField] private TextMeshProUGUI feedbackText; // Referencia al texto de la UI
    [SerializeField] private Vida_Player playerHealth; // Referencia al script de vida del jugador

    void Start()
    {
        // Define combinaciones y sus acciones
        combinations.Add("JKL", Attack);
        combinations.Add("JJK", HealPlayer);
        combinations.Add("KKL", Defend);
        UpdateFeedbackText(); // Inicializa el texto en blanco
    }

    void Update()
    {
        DetectInput();
        CheckCombination();
    }

    void DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.J)) AddInput("J");
        if (Input.GetKeyDown(KeyCode.K)) AddInput("K");
        if (Input.GetKeyDown(KeyCode.L)) AddInput("L");
        if (Input.GetKeyDown(KeyCode.H)) ResetCombination();

        // Reduce el tiempo entre entradas
        if (inputSequence.Count > 0)
        {
            timer += Time.deltaTime;
            if (timer > inputTimer)
            {
                ResetCombination();
            }
        }
    }

    void AddInput(string key)
    {
        inputSequence.Add(key);
        timer = 0; // Reinicia el temporizador
        UpdateFeedbackText(); // Actualiza el texto
    }

    void ResetCombination()
    {
        inputSequence.Clear(); // Limpia la secuencia
        timer = 0; // Reinicia el temporizador
        UpdateFeedbackText(); // Actualiza el texto
        Debug.Log("¡Secuencia reiniciada!");
    }

    void CheckCombination()
    {
        string sequence = string.Join("", inputSequence);
        if (combinations.ContainsKey(sequence))
        {
            combinations[sequence].Invoke();
            StartCoroutine(DisplayResult(sequence));
        }
    }

    void UpdateFeedbackText()
    {
        if (feedbackText != null)
        {
            feedbackText.text = string.Join(" ", inputSequence); // Muestra la secuencia actual
        }
    }

    IEnumerator DisplayResult(string sequence)
    {
        string actionName = ""; // Nombre de la acción
        if (sequence == "JKL") actionName = "¡ATAQUE!";
        if (sequence == "JJK") actionName = "¡CURACIÓN!";
        if (sequence == "KKL") actionName = "¡DEFENSA!";

        if (feedbackText != null)
        {
            feedbackText.text = actionName; // Muestra el resultado de la combinación
        }

        yield return new WaitForSeconds(1.5f); // Espera antes de limpiar el texto
        ResetCombination();
    }


    void Attack()
    {
        Debug.Log("Ataque ejecutado!");
    }

    void HealPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.Heal(playerHealth.GetComponent<Vida_Player>().healAmount); // Llama a la curación del jugador
        }
    }

    void Defend()
    {
        Debug.Log("Defensa ejecutada!");
    }
}
