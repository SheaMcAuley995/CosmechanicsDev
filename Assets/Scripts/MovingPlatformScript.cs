using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB;

    Vector3 currentTarget;
    Vector3 startPos;

    public float speed;
    public float pauseTime;

    float distance;

    float startTime;

    bool firstPass;

    bool stop;

    private void Start()
    {
        startTime = Time.time;
        firstPass = true;

        startPos = pointA;

        distance = Vector3.Distance(startPos, currentTarget);

        StartCoroutine(PlatformMovement());
    }

    void ChangeDirection()
    {
        startPos = transform.position;

        if (transform.position == pointA)
        {
            currentTarget = pointB;
        }
        else if(transform.position == pointB)
        {
            currentTarget = pointA;
        }

        startTime = Time.time;
        distance = Vector3.Distance(startPos, currentTarget);

    }

    IEnumerator PlatformMovement()
    {
        while (!stop)
        {
            float distCovered = (Time.time - startTime) * speed;

            float distanceFraction = (distCovered / distance);

            transform.position = Vector3.Lerp(startPos, currentTarget, distanceFraction);

            if (transform.position == pointB || transform.position == pointA)
            {
                yield return new WaitForSeconds(pauseTime);
                ChangeDirection();
            }   

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.collider.transform.parent = transform;        
    }

    private void OnCollisionExit(Collision collision)
    {
        collision.collider.transform.parent = null;
    }
}
