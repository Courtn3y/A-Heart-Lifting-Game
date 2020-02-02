using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PieceTypes;

public class PieceMovement : MonoBehaviour
{
    float gravity = 1;
    bool placed = false;
    public Parts part;
    Grid grid;
    Ship ship;
    public GameObject space;
    private Camera cam;
    public bool mouse_over = false;
    bool can_move = true;
    float land_height;
    public float distance;
    GameController controller;
    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Ship").GetComponent<Grid>();
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship>();
        controller = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        cam = Camera.main;
        Invoke("GetParent", 0.1f);
        land_height = Random.Range(GameObject.FindGameObjectWithTag("Floor").transform.position.y - 0.3f, GameObject.FindGameObjectWithTag("Floor").transform.position.y + 0.3f);
    }

    void Update()
    {
        if (space != null)
        {
            distance = Vector3.Distance(this.transform.position, space.transform.position);
            if (distance <= grid.place_distance && !placed && !ship.Moving())
            {
                placed = true;
                transform.parent = null;
                transform.parent = space.transform;
                transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z - 0.1f);
                ship.AttachPiece(part, this.gameObject);
            }
        }

        if (transform.parent != null && transform.parent.tag == "Obstacle")
        {
            transform.position = transform.parent.position;
            if (Input.GetMouseButton(0) && mouse_over && can_move)
            {
                controller.ResetHeld();
                transform.parent = null;
            }
        }


        bool mouse_held = false;
        if (Input.GetMouseButton(0) && !ship.Moving() && (mouse_over || mouse_held) && transform.parent != space.transform && can_move && (controller.PartHeld() == this.gameObject || controller.PartHeld() == null))
        {
            controller.SetHeld(this.gameObject);
            mouse_held = true;
            transform.parent = null;
            Vector2 pos;
            pos.x = Input.mousePosition.x;
            pos.y = Input.mousePosition.y;
            transform.position = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 9.4f));
        }
        else
        {
            controller.ResetHeld();
            if (transform.position.y > land_height && !placed && (transform.parent == null || transform.parent.tag != "Obstacle"))
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - gravity * Time.deltaTime, transform.position.z);
            }
        }
    }

    public void StartObstacleTimer()
    {
        can_move = false;
        StartCoroutine(ObstacleTimer());
    }

    IEnumerator ObstacleTimer()
    {
        yield return new WaitForSeconds(0.5f);
        can_move = true;
    }

    void GetParent() => space = grid.GetParentSpace(this.gameObject);
    void OnMouseOver() => mouse_over = true;
    void OnMouseExit() => mouse_over = false;
}

