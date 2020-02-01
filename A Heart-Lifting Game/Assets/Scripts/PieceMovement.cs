using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    Grid grid;
    public GameObject space;
    private Camera cam;
    public bool mouse_over = false;
    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Ship").GetComponent<Grid>();
        cam = Camera.main;
        Invoke("GetParent", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (space != null && Vector3.Distance(this.transform.position, space.transform.position) <= grid.place_distance)
        {
            transform.parent = null;
            transform.parent = space.transform;
            transform.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z - 0.1f);
        }
        if (Input.GetMouseButton(0) && mouse_over && transform.parent != space.transform)
        {
            Vector2 pos;
            pos.x = Input.mousePosition.x;
            pos.y = Input.mousePosition.y;
            transform.position = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));
        }
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

