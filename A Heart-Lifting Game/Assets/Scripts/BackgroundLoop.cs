﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;

    private void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject obj in levels)
        {
            loadChildObjects(obj);
        }
    }

    void loadChildObjects(GameObject obj)
    {
        //Debug.Log(obj.name);
        float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for(int i=0; i<= childsNeeded; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }

    private void LateUpdate()
    {
        foreach(GameObject obj in levels)
        {
            
        }
    }
}


// https://www.youtube.com/watch?v=3UO-1suMbNc