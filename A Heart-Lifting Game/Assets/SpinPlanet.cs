using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlanet : MonoBehaviour
{
    public float spin_speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, spin_speed * Time.deltaTime);
    }
}
