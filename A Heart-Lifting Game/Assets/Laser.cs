using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    float dur;
    float spd;
    Vector3 dir;
    bool moving = false;
    private void Update()
    {
        if (moving)
        {
            transform.position += (dir * spd) * Time.deltaTime;
        }
    }
    public void StartShot(float duration, float speed, Vector3 direction)
    {
        dur = duration;
        spd = speed;
        dir = direction;
        moving = true;
        StartCoroutine(DespawnTimer());
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(dur);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
