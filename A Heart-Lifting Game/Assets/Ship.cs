using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float max_speed = 10;
    public float acceleration = 1.5f;
    public void Launch()
    {
        StartCoroutine(LaunchRoutine());
    }

    IEnumerator LaunchRoutine()
    {
        bool moving = true;
        float speed = 1.0f;
        while (moving)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + (speed * Time.deltaTime), transform.position.z);
            if (speed < max_speed)
            {
                speed += acceleration * Time.deltaTime;
            }
            yield return null;
        }
    }
}
