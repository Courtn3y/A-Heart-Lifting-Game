using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool game_won = false;
    public int place_distance = 1;
    public float timer = 10;
    public GameObject pieces_parent;
    int num_spaces = 10;
    List<GameObject> positions = new List<GameObject>();
    List<GameObject> pieces = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckWin());
        foreach (Transform child in transform)
        {
            positions.Add(child.gameObject);
        }

        foreach (Transform child in pieces_parent.transform)
        {
            pieces.Add(child.gameObject);
        }
    }

    IEnumerator CheckWin()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            if (positions[i].transform.childCount == 0)
            {
                yield return new WaitForSeconds(0.01f);
                StartCoroutine(CheckWin());
                yield break;
            }
            yield return null;
        }
        game_won = true;
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
