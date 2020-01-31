using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovement : MonoBehaviour
{
    Grid grid;
    public GameObject parent;
    private Camera cam;
    public bool mouse_over = false;
    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.FindGameObjectWithTag("Grid").GetComponent<Grid>();
        cam = Camera.main;
        Invoke("GetParent", 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && mouse_over)
        {
            Vector2 pos;
            pos.x = Input.mousePosition.x;
            pos.y = Input.mousePosition.y;
            transform.position = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));
        }
    }

    void GetParent()
    {
        parent = grid.GetParentSpace(this.gameObject);
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

