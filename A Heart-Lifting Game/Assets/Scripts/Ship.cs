using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PieceTypes;
public class Ship : MonoBehaviour
{
    public GameObject explosion;
    GameController controller;
    public Vector3 thruster_strength;
    bool moving = false;
    public float max_speed = 10;
    public float acceleration = 1.5f;
    public float rotate_speed = 25;
    float speed = 1.0f;
    Vector2 rotation;

    public GameObject l_thruster;
    public GameObject c_thruster;
    public GameObject r_thruster;
    public GameObject l_tank;
    public GameObject c_tank;
    public GameObject r_tank;

    private void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    public void Launch() => moving = true;
    public void Land() => moving = false;
    public bool Moving()
    {
        return moving;
    }
    IEnumerator FlightTimer(float flight_time)
    {
        yield return new WaitForSeconds(flight_time);
        controller.GameOver();
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

        PartsCheck();
    }

    void PartsCheck()
    {
        if (l_thruster != null) thruster_strength.z = rotate_speed;
        else thruster_strength.x = 0;

        if (c_thruster != null) thruster_strength.y = rotate_speed;
        else thruster_strength.x = 0;

        if (r_thruster != null) thruster_strength.x = rotate_speed;
        else thruster_strength.x = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            Instantiate(explosion, new Vector3(this.transform.position.x, this.transform.position.y, 0), Quaternion.identity);
            controller.GameOver();
            Destroy(this.gameObject);
        }
    }

    public void AttachPiece(Parts part, GameObject obj)
    {
        if (part == Parts.L_thruster) l_thruster = obj;
        if (part == Parts.C_thruster) c_thruster = obj;
        if (part == Parts.R_thruster) r_thruster = obj;
        if (part == Parts.L_tank) l_tank = obj;
        if (part == Parts.C_tank) c_tank = obj;
        if (part == Parts.R_tank) r_tank = obj;
    }
}
