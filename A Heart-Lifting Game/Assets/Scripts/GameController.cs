using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    bool ended = false;
    Camera cam;
    GameObject ship_obj;
    GameObject goal_obj;
    public bool game_won = false;
    public float build_timer = 10;
    public float goal_distance;
    public float cam_distance = 10;
    public float game_over_delay = 2;
    Grid grid;
    Ship ship;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        ship_obj = GameObject.FindGameObjectWithTag("Ship");
        goal_obj = GameObject.FindGameObjectWithTag("Goal");
        grid = ship_obj.GetComponent<Grid>();
        ship = ship_obj.GetComponent<Ship>();
        StartCoroutine(Timer());
        Invoke("StartWinCheck", 0.2f);
    }

    private void Update()
    {
        if (ship_obj != null)
        {
            cam.transform.position = new Vector3(ship_obj.transform.position.x, ship_obj.transform.position.y, -cam_distance);
            goal_distance = Vector2.Distance(ship_obj.transform.position, goal_obj.transform.position);
        }
        
        if (goal_distance <= 5 && !ended)
        {
            ended = true;
            ship.Land();
            Debug.Log("REACHED HOME");
            StartCoroutine(WinDelay());
        }
    }

    void StartWinCheck() => StartCoroutine(CheckComplete());

    IEnumerator CheckComplete()
    {
        bool complete = false;
        if (grid != null)
        {
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

    public void GameOver(float delay) => StartCoroutine(GameOverDelay(delay));

    IEnumerator GameOverDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("LoseScene");
    }

    IEnumerator WinDelay()
    {
        yield return new WaitForSeconds(game_over_delay);
        SceneManager.LoadScene("WinScene");
    }
}
