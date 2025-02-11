using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;
using UnityEngine.SceneManagement;

public class tp_scene : MonoBehaviour
{
    //public GameObject[] enemigos = new GameObject[10];
    public List<GameObject> enemigos = new List<GameObject>();
    public string siguienteEscena;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < enemigos.Length; i++)
        //{
        //    if (enemigos[i] == null)
        //    {
        //        enemigos.Length -= 1;
        //    }
        //}
        enemigos.RemoveAll(item => item == null);
        if (enemigos.Count == 0)
        {
            Debug.Log("0 eneigos");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (enemigos.Count == 0)
            {
                SceneManager.LoadScene(siguienteEscena);
            }
        }
    }
}