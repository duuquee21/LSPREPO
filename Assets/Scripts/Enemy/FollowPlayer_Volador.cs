using UnityEngine;

public class FollowPlayer_Volador : MonoBehaviour
{
    public float speed;
    public Transform Player;
    public float stopDistance ;
    public float stopDistance_floor;

    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        if (rb == null) 
        { 
            Debug.LogError("Rigidbody no encontrado!"); 
        } 
          rb.isKinematic = true; 
         transform.position = new Vector4(transform.position.x, transform.position.y, stopDistance_floor, transform.position.z);
    }

    void Update()
    {
        Vector3 displacement = new Vector3( Player.position.x - transform.position.x, Player.position.y - transform.position.y, Player.position.z - transform.position.z );
        displacement = displacement.normalized;

        //Debug.Log("Distancia al jugador: " + Vector3.Distance(new Vector3(Player.position.x, Player.position.y, Player.position.z), new Vector3(transform.position.x, transform.position.y, transform.position.z)));

        if (Vector3.Distance(new Vector3(Player.position.x, Player.position.y, Player.position.z), new Vector3( transform.position.x, transform.position.y, transform.position.z))> stopDistance)
        {
            //Debug.Log("Moviendo enemigo");
            Vector3 move = displacement * speed * Time.deltaTime;
            rb.MovePosition(transform.position + move);
        }
        transform.position = new Vector4(transform.position.x, transform.position.y, stopDistance_floor, transform.position.z);


    }
}
