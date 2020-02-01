using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSound : MonoBehaviour
{
    public AudioSource l_turn;
    bool l_turn_playing = false;
    bool l_turn_off = false;
    public AudioSource r_turn;
    bool r_turn_playing = false;
    bool r_turn_off = false;

    public void LTurnOn()
    {
        if (!l_turn_playing)
        {
            l_turn_playing = true;
            l_turn_off = false;
            l_turn.Play();
        }
    }

    public void LTurnOff()
    {
        if (!l_turn_off)
        {
            l_turn_off = true;
            l_turn_playing = false;
            l_turn.Stop();
        }
    }

    public void RTurnOn()
    {
        if (!r_turn_playing)
        {
            r_turn_playing = true;
            r_turn_off = false;
            r_turn.Play();
        }
    }

    public void RTurnOff()
    {
        if (!r_turn_off)
        {
            r_turn_off = true;
            r_turn_playing = false;
            r_turn.Stop();
        }
    }
}
