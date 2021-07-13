using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    string lastpressed = "w";
    public Animator playeranim;
    string[] idlesetlist = {"w", "a", "s", "d" };
    public bool moving = false;
    public string[] keysheld= {null,null,null,null };
    string playing;
    bool keyfound;
    public PlayerControls pcon;
    void Update()
    {
        StateCheck();
    }

    void LastPressed()
    {
        playing = directConvert(lastpressed,false);
        playeranim.Play(playing, 0);
      
    }
    public void RotateStateCheck(int direction)
    {
        bool holdcheck = false;
        //direction: -1 is right, 1 is left
        for (int i = 0; i < keysheld.Length; i++)
        {
            if (keysheld[i] != null)
            {
                holdcheck = true;
            }
        }
        if (!holdcheck) {
            for (int i = 0; i < 4; i++)
            {
                if (idlesetlist[i] == lastpressed)
                {
                    if ((i + direction) > 3)
                    {
                        direction -= 4;
                    }
                    else if ((i + direction) < 0)
                    {
                        direction += 4;
                    }
                    lastpressed = idlesetlist[i + direction];
                    break;
                }
            }
            LastPressed();
        }
    }

    void StateCheck()
    {
        int held = 0;
        for (int i=0;i<keysheld.Length;i++)
        {
            if (keysheld[i]!=null)
            {
                held++;
            }
        }
        if (held==1)
        {
            for (int i = 0; i < keysheld.Length; i++)
            {
                if (keysheld[i] != null)
                {
                    playing = directConvert(keysheld[i],true);
                    lastpressed =keysheld[i];
                    playeranim.Play(playing, 0);
                }
            }
        }
    }







    string directConvert(string direction,bool moving)
    {
        string newdirect=null;
        if (moving) {
            if (direction == "w")
            {
                newdirect = "WalkF";
            }
            if (direction == "a")
            {
                newdirect = "WalkL";
            }
            if (direction == "s")
            {
                newdirect = "WalkB";
            }
            if (direction == "d")
            {
                newdirect = "WalkR";
            }
        }
        else if (!moving)
        {
            if (direction == "w")
            {
                newdirect = "IdleF";
            }
            if (direction == "a")
            {
                newdirect = "IdleL";
            }
            if (direction == "s")
            {
                newdirect = "IdleB";
            }
            if (direction == "d")
            {
                newdirect = "IdleR";
            }
        }
        return newdirect;

    }








    public void playerMove(string direction,bool run)
    {
        if (run)
        {
            /////////
            if (direction == "w")
            {
                keyfound = false;
                for (int i = 0; i < keysheld.Length; i++)
                {
                    if (direction == keysheld[i])
                    {
                        keyfound = true;
                    }
                }
                if (!keyfound)
                {
                    for (int i = 0, done = 0; done == 0; i++)
                    {
                        if (keysheld[i] == null)
                        {
                            pcon.playerrig.velocity = new Vector3(0,-10,0);
                            keysheld.SetValue(direction, i);
                            done = 1;
                            playing = "WalkF";
                            lastpressed = "w";
                        }
                    }
                }
            }
            //////////
            else if (direction == "a")
            {
                keyfound = false;
                for (int i = 0; i < keysheld.Length; i++)
                {
                    if (direction == keysheld[i])
                    {
                        keyfound = true;
                    }
                }
                if (!keyfound)
                {
                    for (int i = 0, done = 0; done == 0; i++)
                    {
                        if (keysheld[i] == null)
                        {
                            pcon.StopMomentum();
                            keysheld.SetValue(direction, i);
                            done = 1;
                            playing = "WalkL";
                            lastpressed = "a";
                        }
                    }
                }
            }
            //////////
            else if (direction == "s")
            {
                keyfound = false;
                for (int i = 0; i < keysheld.Length; i++)
                {
                    if (direction == keysheld[i])
                    {
                        keyfound = true;
                    }
                }
                if (!keyfound)
                {
                    for (int i = 0, done = 0; done == 0; i++)
                    {
                        if (keysheld[i] == null)
                        {
                            pcon.StopMomentum();
                            keysheld.SetValue(direction, i);
                            done = 1;
                            playing = "WalkB";
                            lastpressed = "s";
                        }
                    }
                }
            }
            //////////
            else if (direction == "d")
            {
                keyfound = false;
                for (int i = 0; i < keysheld.Length; i++)
                {
                    if (direction == keysheld[i])
                    {
                        keyfound = true;
                    }
                }
                if (!keyfound)
                {
                    for (int i = 0, done = 0; done == 0; i++)
                    {
                        if (keysheld[i] == null)
                        {
                            pcon.StopMomentum();
                            keysheld.SetValue(direction, i);
                            done = 1;
                            playing = "WalkR";
                            lastpressed = "d";
                        }
                    }
                }
            }
            /////////
            moving = true;
            playeranim.Play(playing, 0);
        }

        else if(!run)
        {
            for (int i=0;i<keysheld.Length;i++)
            {
                keysheld[i] = null;
            }
            moving = false;
            playeranim.StopPlayback();              
            LastPressed();
        }

    }






}
