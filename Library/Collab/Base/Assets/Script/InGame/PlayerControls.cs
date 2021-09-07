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
    PlayerAnim pan;
    private void Start()
    {
        pan = player.GetComponent<PlayerAnim>();
    }
    public void Movement()
    {

       if ((playerrig.velocity.x<speedlimit && playerrig.velocity.x > -speedlimit) && (playerrig.velocity.z < speedlimit && playerrig.velocity.z > -speedlimit)) {//movement speed cap
            if (Input.GetKey(KeyCode.W))
            {
                playerrig.AddForce(player.forward * speed);
                pan.playerMove("w",true);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerrig.AddForce(player.right * -speed);
                pan.playerMove("a", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerrig.AddForce(player.forward * -speed);
                pan.playerMove("s", true);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerrig.AddForce(player.right * speed);
                pan.playerMove("d", true);
            }
            //////
            if (!Input.GetKey(KeyCode.W))
            {
                for (int i=0;i<pan.keysheld.Length;i++)
                {
                    if (pan.keysheld[i]=="w")
                    {
                        pan.keysheld.SetValue(null, i);
                    }
                }
            }
            if (!Input.GetKey(KeyCode.A))
            {
                for (int i = 0; i < pan.keysheld.Length; i++)
                {
                    if (pan.keysheld[i] == "a")
                    {
                        pan.keysheld.SetValue(null, i);
                    }
                }
            }
            if (!Input.GetKey(KeyCode.S))
            {
                for (int i = 0; i < pan.keysheld.Length; i++)
                {
                    if (pan.keysheld[i] == "s")
                    {
                        pan.keysheld.SetValue(null, i);
                    }
                }
            }
            if (!Input.GetKey(KeyCode.D))
            {
                for (int i = 0; i < pan.keysheld.Length; i++)
                {
                    if (pan.keysheld[i] == "d")
                    {
                        pan.keysheld.SetValue(null,i);
                    }
                }
            }

            //////
            if (!pan.moving)
            {
                StopMomentum();
            }
            //////


            ////////
            if (!Input.GetKey(KeyCode.W)&& !Input.GetKey(KeyCode.A)&&
                !Input.GetKey(KeyCode.S)&& !Input.GetKey(KeyCode.D))
            {
                pan.playerMove(null, false);
            }
            /////////
            ///
           


        }
        

    }

    public void StopMomentum()
    {
        playerrig.velocity = new Vector3(0, -5, 0);
    }

}
