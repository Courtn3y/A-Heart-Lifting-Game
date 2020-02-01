using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSound : MonoBehaviour
{
    AudioSource audio;
    public AudioClip explosion1;
    public AudioClip explosion2;
    public AudioClip explosion3;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        int rand = Random.Range(0, 3);
        if (rand == 0) audio.clip = explosion1;
        if (rand == 1) audio.clip = explosion2;
        if (rand == 2) audio.clip = explosion3;
        audio.Play();
        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(6);
        Destroy(this.gameObject);
    }
}
