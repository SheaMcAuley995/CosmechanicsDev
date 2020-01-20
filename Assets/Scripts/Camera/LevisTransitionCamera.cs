using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevisTransitionCamera : MonoBehaviour
{
    public Vector3 offset;

    public List<GameObject> targets;
    public GameObject target;

    public float transitionSpeed;


    int currentTarget;

    private void Start()
    {
        currentTarget = 0;
        if(targets != null)
        {
            transform.position = targets[0].transform.position + offset;
            target = targets[0];
        }
    }

    public void NextTarget()
    {
        currentTarget++;

        if(currentTarget >= targets.Count)
        {
            currentTarget = 0;
        }

        target = targets[currentTarget];
        StartCoroutine(ShiftCamera());
    }

    public void PrevTarget()
    {
        if (currentTarget == 0)
        {
            currentTarget = targets.Count - 1;
        }
        else
        {
            currentTarget--;
        }

        target = targets[currentTarget];
        StartCoroutine(ShiftCamera());
    }

    IEnumerator ShiftCamera()
    {
        float counter = 0;
        int buffer = 0;

        while(true)
        {
            buffer++;
            counter = buffer / transitionSpeed;

            transform.position = Vector3.Lerp(transform.position, targets[currentTarget].transform.position + offset, counter);

            if(counter >= 1)
            {
                break;
            }
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}
