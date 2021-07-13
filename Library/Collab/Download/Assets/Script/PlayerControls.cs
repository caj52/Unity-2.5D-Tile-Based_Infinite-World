using UnityEngine;
public class PlayerControls : MonoBehaviour
{
    public Transform player;
    public Rigidbody playerrig;
    public float speedlimit;
    public float speed;
    public float jumpspeed;
    public Transform subject;
    public Camera cam;
    // Start is called before the first frame update
    public void Movement()
    {

       if ((playerrig.velocity.x<speedlimit && playerrig.velocity.x > -speedlimit) && (playerrig.velocity.z < speedlimit && playerrig.velocity.z > -speedlimit)) {//movement speed cap
            if (Input.GetKey(KeyCode.W))
            {
                playerrig.AddForce(player.forward * speed);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerrig.AddForce(player.right * -speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerrig.AddForce(player.forward * -speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerrig.AddForce(player.right * speed);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                playerrig.AddForce(player.up * jumpspeed);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
            }
        }
        

    }

}
