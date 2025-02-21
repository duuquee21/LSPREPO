using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float speed = 1f;
    public Transform Player;
    public Animator anim3;

    void Start()
    {

    }

    void Update()
    {
       Vector3 displacement = Player.position - transform.position;
        displacement = displacement.normalized;
        
        if (Vector2.Distance(Player.position, transform.position)>1.0f)
        {
            anim3.SetBool("isWalking", true);
            
            transform.position += displacement * speed * Time.deltaTime;
        }
        else
        {
            anim3.SetBool("isWalking", false);

        }
    }
}
