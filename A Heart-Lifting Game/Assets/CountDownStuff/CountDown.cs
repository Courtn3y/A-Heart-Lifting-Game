using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 20f;

    [SerializeField] Text timerNumber;

    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerNumber.text = currentTime.ToString("0");

        if (currentTime <= 5)
        {
            timerNumber.color = Color.red;
        }


        if (currentTime <= 0)
        {
            currentTime = 0;
        }


    }
}
