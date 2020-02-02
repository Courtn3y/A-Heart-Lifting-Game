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
    public AudioSource place;
    public AudioSource main_thruster;
    public AudioSource depleted;
    bool depleted_played = false;
    public AudioClip failure1;
    public AudioClip failure2;
    public AudioClip failure3;


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

    public void PlayPartPlace()
    {
        float pitch = place.pitch;
        float new_pitch = Random.Range((pitch - pitch * 0.2f), pitch + (pitch * 0.2f));
        place.pitch = new_pitch;
        place.Play();
    }

    public void PlayDepleted()
    {
        if (!depleted_played)
        {
            main_thruster.Stop();
            depleted_played = true;
            int rand = Random.Range(0, 3);
            if (rand == 0) depleted.clip = failure1;
            if (rand == 1) depleted.clip = failure2;
            if (rand == 2) depleted.clip = failure3;
            depleted.Play();
        }
    }

    public void PlayThruster()
    {
        main_thruster.Play();
    }
}
