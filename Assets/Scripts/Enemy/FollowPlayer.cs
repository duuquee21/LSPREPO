using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1f;
    public Transform Player;


    void Start()
    {

    }

    void Update()
    {
       Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        
        if (Vector2.Distance(Player.position, transform.position)>1.0f)
        {
            transform.position += displacement * speed * Time.deltaTime;
        }
    }
}
