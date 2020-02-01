using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    bool moving = false;
    public float max_speed = 10;
    public float acceleration = 1.5f;
    public float rotate_speed = 10;
    float speed = 1.0f;
    Vector2 rotation;
    public void Launch() => moving = true;
    public void Land() => moving = false;

    private void Update()
    {
        if (moving)
        {
            transform.position += (transform.up * speed) * Time.deltaTime;
            if (speed < max_speed)
            {
                speed += acceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.forward * rotate_speed * Time.deltaTime);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(-Vector3.forward * rotate_speed * Time.deltaTime);
        }
    }
}
