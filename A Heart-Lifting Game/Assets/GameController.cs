using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    GameObject ship_obj;
    public bool game_won = false;
    public float build_timer = 10;
    Grid grid;
    Ship ship;

    // Start is called before the first frame update
    void Start()
    {
        ship_obj = GameObject.FindGameObjectWithTag("Ship");
        grid = ship_obj.GetComponent<Grid>();
        ship = ship_obj.GetComponent<Ship>();
        StartCoroutine(Timer());
        Invoke("StartWinCheck", 0.2f);
    }

    void StartWinCheck() => StartCoroutine(CheckComplete());

    IEnumerator CheckComplete()
    {
        bool complete = false;
        for (int i = 0; i < grid.GetPositions().Count; i++)
        {
            if (grid.GetPositions()[i].transform.childCount == 0)
            {
                complete = false;
                yield return new WaitForSeconds(0.01f);
                StartCoroutine(CheckComplete());
                yield break;
            }
            else
            {
                complete = true;
            }
            yield return null;
        }
        if (complete)
        {
            game_won = true;
            ship.Launch();
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(build_timer);
        ship.Launch();
    }
}
