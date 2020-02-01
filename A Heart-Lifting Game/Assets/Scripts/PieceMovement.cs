using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PieceTypes;

public class PieceMovement : MonoBehaviour
{
    bool placed = false;
    public Parts part;
    Grid grid;
    Ship ship;
    public GameObject space;
    private Camera cam;
    public bool mouse_over = false;
    bool can_move = true;

    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Ship").GetComponent<Grid>();
        ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<Ship>();
        cam = Camera.main;
        Invoke("GetParent", 0.1f);
    }

    void Update()
    {
        if (space != null && Vector3.Distance(this.transform.position, space.transform.position) <= grid.place_distance && !placed)
        {
            placed = true;
            transform.parent = null;
            transform.parent = space.transform;
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z - 0.1f);
            ship.AttachPiece(part, this.gameObject);
        }

        if (transform.parent != null && transform.parent.tag == "Obstacle")
        {
            transform.position = transform.parent.position;
            if (Input.GetMouseButton(0))
            {
                transform.parent = null;
            }
        }



        if (Input.GetMouseButton(0) && mouse_over)
        {
            if (transform.parent != space.transform && can_move)
            {
                transform.parent = null;
                Vector2 pos;
                pos.x = Input.mousePosition.x;
                pos.y = Input.mousePosition.y;
                transform.position = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));
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

    void GetParent()
    {
        space = grid.GetParentSpace(this.gameObject);
    }

    void OnMouseOver()
    {
        mouse_over = true;
    }

    void OnMouseExit()
    {
        mouse_over = false;
    }
}

