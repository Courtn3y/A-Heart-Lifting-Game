using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowUV : MonoBehaviour
{
    MeshRenderer mesh;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Material mat = mesh.material;

        Vector2 offset = mat.mainTextureOffset;

        offset.x = transform.position.x / transform.localScale.x;
        offset.y = transform.position.y / transform.localScale.y;

        mat.mainTextureOffset = offset;
    }
}

//https://www.youtube.com/watch?v=nGw_UBJQPDY
