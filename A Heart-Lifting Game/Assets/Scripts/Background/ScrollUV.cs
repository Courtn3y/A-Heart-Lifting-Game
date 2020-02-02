using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUV : MonoBehaviour
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

        offset.x += Time.deltaTime;

        mat.mainTextureOffset = offset;
    }
}
