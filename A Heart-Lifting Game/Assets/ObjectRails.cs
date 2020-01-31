using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum PlayMode
{
    Linear,
    Catmull,
}

[ExecuteInEditMode]
public class ObjectRails : MonoBehaviour
{

    


    public GameObject obstacle;
    public Transform[] nodes;

    // Start is called before the first frame update
    void Start()
    {
        nodes = GetComponentsInChildren<Transform>();
    }

    
    public Vector2 PositionOnRail(int seg, float ratio, PlayMode mode)
    {
        switch (mode)
        {
            default:
            case PlayMode.Linear:
                return LinearPosition(seg, ratio);
            case PlayMode.Catmull:
                return CatmullPosition(seg, ratio);
        }
    }

    public Vector2 LinearPosition(int seg, float ratio)
    {
        Vector2 p1 = nodes[seg].position;
        Vector2 p2 = nodes[seg + 1].position;

        return Vector2.Lerp(p1, p2, ratio);
    }

    public Vector2 CatmullPosition(int seg, float ratio)
    {
        Vector2 p1, p2, p3, p4;

        if (seg == 0)
        {
            p1 = nodes[seg].position;
            p2 = p1;
            p3 = nodes[seg + 1].position;
            p4 = nodes[seg + 2].position;
        }
        else if (seg == nodes.Length - 2)
        {
            p1 = nodes[seg - 1].position;
            p2 = nodes[seg].position;
            p3 = nodes[seg + 1].position;
            p4 = p3;
        }
        else
        {
            p1 = nodes[seg - 1].position;
            p2 = nodes[seg].position;
            p3 = nodes[seg + 1].position;
            p4 = nodes[seg + 2].position;
        }

        float t2 = ratio * ratio;
        float t3 = t2 * ratio;

        float x =
            0.5f * ((2.0f * p2.x) +
            (-p1.x + p3.x) * ratio +
            (2.0f * p1.x - 5.0f * p2.x + 4 * p3.x - p4.x) * t2 +
            (-p1.x + 3.0f * p2.x - 3.0f * p3.x + p4.x) * t3);

        float y =
           0.5f * ((2.0f * p2.y) +
           (-p1.y + p3.y) * ratio +
           (2.0f * p1.y - 5.0f * p2.y + 4 * p3.y - p4.y) * t2 +
           (-p1.y + 3.0f * p2.y - 3.0f * p3.y + p4.y) * t3);

        return new Vector2(x, y);
    }

    private void OnDrawGizmos()
    {
        for (int i = 0; i < nodes.Length - 1; i++)
        {
            Handles.DrawDottedLine(nodes[i].position, nodes[i + 1].position, 3.0f);
        }
    }
}
