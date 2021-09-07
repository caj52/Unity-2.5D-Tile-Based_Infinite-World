using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    string lastpressed = "w";
    public Animator playeranim;
    string[] idlesetlist = { "w", "a", "s", "d" };
    public bool moving = false;
    public string[] keysheld = { null, null, null, null };
    string playing;
    bool keyfound;
    public PlayerControls pcon;
    void Update()
    {
        StateCheck();
    }

    void LastPressed()
    {
        playing = directConvert(lastpressed, false);
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
        for (int i = 0; i < keysheld.Length; i++)
        {
            if (keysheld[i] != null)
            {
                held++;
            }
        }
        if (held == 1)
        {
            for (int i = 0; i < keysheld.Length; i++)
            {
                if (keysheld[i] != null)
                {
                    playing = directConvert(keysheld[i], true);
                    lastpressed = keysheld[i];
                    playeranim.Play(playing, 0);
                }
            }
        }
    }



    string directConvert(string direction, bool moving)
    {
        string newdirect = null;
        switch (moving)
        {
            case true:
                switch (direction)
                {
                    case "w":
                        newdirect = "WalkF";
                        break;
                    case "a":
                        newdirect = "WalkL";
                        break;
                    case "s":
                        newdirect = "WalkB";
                        break;
                    case "d":
                        newdirect = "WalkR";
                        break;
                }
                break;
            case false:
                switch (direction)
                {
                    case "w":
                        newdirect = "IdleF";
                        break;
                    case "a":
                        newdirect = "IdleL";
                        break;
                    case "s":
                        newdirect = "IdleB";
                        break;
                    case "d":
                        newdirect = "IdleR";
                        break;
                }
                break;
        }
        return newdirect;
    }


    public void playerMove(string direction,bool run)
    {
        switch(run)
        {
            case true:
            switch (direction)
            {
                case "w":
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
                                pcon.playerrig.velocity = new Vector3(0, -10, 0);
                                keysheld.SetValue(direction, i);
                                done = 1;
                                playing = "WalkF";
                                lastpressed = "w";
                            }
                        }
                    }
                    break;
                case "a":
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
                    break;
                case "s":
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
                    break;
                case "d":
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
                    break;
            }
                break;
            case false:
                for (int i = 0; i < keysheld.Length; i++)
                {
                    keysheld[i] = null;
                }
                moving = false;
                playeranim.StopPlayback();
                LastPressed();
                break;

        }

    }


}
