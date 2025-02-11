using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundJ; // Sonido para la tecla J
    public AudioClip soundK; // Sonido para la tecla K
    public AudioClip soundL; // Sonido para la tecla L

    private AudioSource audioSource;

    private bool isOnCooldown = false;
    private float cooldownTime = 0.5f;

    void Start()
    {
        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("No se encontró un componente AudioSource en el objeto.");
        }
    }

    public void PlaySound(string key)
    {
        if (isOnCooldown)
        {
            return;
        }

        AudioClip clipToPlay = null;

        switch (key)
        {
            case "J":
                clipToPlay = soundJ;
                break;
            case "K":
                clipToPlay = soundK;
                break;
            case "L":
                clipToPlay = soundL;
                break;
        }

        if (clipToPlay != null && audioSource != null)
        {
            audioSource.PlayOneShot(clipToPlay);
            StartCoroutine(StartCooldown());
        }
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
    }

    public void SetCooldown(float newCooldown)
    {
        cooldownTime = newCooldown;
    }
}
