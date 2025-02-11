using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    public int damage = 1;
    public double waitingTime = 0;
    public double couldown = 0.5;
    public bool isAttacking = false;
    public GameObject playerrotation;

    public GameObject note;
    private bool _left;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAttacking)
        {
            if (playerrotation.GetComponent<Transform>().localScale==new Vector3(1,1,1))
            {
                _left = true;
            }
            else
            {
                _left = false;
            }
            if (Input.GetKey(KeyCode.J) || Input.GetKey(KeyCode.K) || Input.GetKey(KeyCode.L))
            {
                Debug.Log("ATAQUE");
                GameObject newNote = Instantiate(note, transform.position, Quaternion.identity);
                newNote.GetComponent<Note>().Throw(_left);
                
                isAttacking = true;
            }
        }
        else
        { 
            waitingTime = waitingTime + Time.deltaTime;
            if (waitingTime > couldown)
            {
                isAttacking = false;
                waitingTime = 0;
            }
        }
    }
}
