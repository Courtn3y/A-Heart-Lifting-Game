using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceFromObstacle : MonoBehaviour
{

    private Camera cam;
    public GameObject space;
    public bool mouse_over = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && mouse_over && (transform.parent != space.transform || transform.parent != null ))
        {
            Vector2 pos;
            pos.x = Input.mousePosition.x;
            pos.y = Input.mousePosition.y;
            transform.position = cam.ScreenToWorldPoint(new Vector3(pos.x, pos.y, 10));
        }
    }
}
