using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{

    public ObjectRails rail;
    public PlayMode mode;

    public float speed;
    public float currentSpeed;

    public bool isReversed;
    public bool isLooping;
    public bool pingPong;
    public bool isMoving;
    public bool autoPlay;

    public bool forwards;
    public bool backwards;

    public int currentSeg;
    private float transition;
    public bool isCompleted;
    

    // Start is called before the first frame update
    void Start()
    {
        speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (forwards)
        {
            speed = currentSpeed;
            isReversed = false;
        }
        else if (backwards)
        {
            speed = currentSpeed;
            isReversed = true;
        }
        else if (autoPlay)
        {
            speed = currentSpeed;
        }
        else
        {
            speed = 0;
        }

        if (!rail)
        {
            return;
        }

        if (!isCompleted)
        {
            Play(!isReversed);
        }
    }

    private void Play(bool forward = true)
    {


        float m = (rail.nodes[currentSeg + 1].position - rail.nodes[currentSeg].position).magnitude;
        float s = (Time.deltaTime * 1 / m) * speed;
        transition += (forward) ? s : -s;


        // Checks to see if the current segment has hit the next, and then sets the transition to 0, and carries on
        // with moving forward
        if (transition > 1)
        {
            transition = 0;
            currentSeg++;
            if (currentSeg == rail.nodes.Length - 1)
            {
                if (isLooping)
                {
                    if (pingPong)
                    {
                        transition = 1;
                        currentSeg = rail.nodes.Length - 2;
                        isReversed = !isReversed;
                    }
                    else
                    {
                        currentSeg = 0;
                    }
                }
            }
        }
        // Checks to see if current segment has hit the previous part, and then sets the transition to 1 and scrolls back
        else if (transition < 0)
        {
            transition = 1;
            currentSeg--;

            if (currentSeg == -1)
            {
                if (isLooping)
                {
                    if (pingPong)
                    {
                        transition = 0;
                        currentSeg = 0;
                        isReversed = !isReversed;
                    }
                    else
                    {
                        currentSeg = rail.nodes.Length - 2;
                    }
                }
            }
        }

        // Sends information to the rail and allows the platform to move along the spline 
        transform.position = rail.PositionOnRail(currentSeg, transition, mode);
    }

    private void OnCollisionEnter(Collision other)
    {
        /* Check what is colliding
           if (dragItem)
              Then drag with obstacle
              Or reset item
              or destroy item
         */
    }
}
