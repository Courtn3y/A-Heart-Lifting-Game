using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool game_won = false;
    public int place_distance = 1;
    public float timer = 10;
    public GameObject pieces_parent;
    List<GameObject> positions = new List<GameObject>();
    List<GameObject> pieces = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        Transform grid = transform.GetChild(0);
        foreach (Transform child in grid.transform)
        {
            positions.Add(child.gameObject);
        }

        foreach (Transform child in pieces_parent.transform)
        {
            pieces.Add(child.gameObject);
        }
    }

    public List<GameObject> GetPositions()
    {
        return positions;
    }

    public List<GameObject> GetPieces()
    {
        return pieces;
    }

    public GameObject GetParentSpace(GameObject piece)
    {
        for (int i = 0; i < pieces.Count; i++)
        {
            if (piece == pieces[i])
            {
                return positions[i];
            }
        }
        return null;
    }
}
