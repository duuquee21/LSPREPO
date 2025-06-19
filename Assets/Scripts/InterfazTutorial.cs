using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InterfazTutorial : MonoBehaviour
{
    public UnityEvent onIPressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            onIPressed.Invoke();
        }
    }
}
