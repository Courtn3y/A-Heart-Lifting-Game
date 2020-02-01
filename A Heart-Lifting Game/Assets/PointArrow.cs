using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointArrow : MonoBehaviour
{
    public Transform goal;
    // Start is called before the first frame update
    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Goal").transform;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = goal.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
    }

}
