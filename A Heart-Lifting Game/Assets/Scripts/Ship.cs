using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Vector3 thruster_strength;
    bool moving = false;
    public float max_speed = 10;
    public float acceleration = 1.5f;
    public float rotate_speed = 10;
    float speed = 1.0f;
    Vector2 rotation;
    public void Launch() => moving = true;
    public void Land() => moving = false;

    IEnumerator FlightTimer(float flight_time)
    {
        yield return new WaitForSeconds(flight_time);
    }

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

        if (moving)
        {
            if (Input.GetKey("left"))
            {
                transform.Rotate(Vector3.forward * thruster_strength.x * Time.deltaTime);
            }
            if (Input.GetKey("right"))
            {
                transform.Rotate(-Vector3.forward * thruster_strength.z * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Debug.Log("BOOM!!!");
            Destroy(this.gameObject);
        }
    }
}
