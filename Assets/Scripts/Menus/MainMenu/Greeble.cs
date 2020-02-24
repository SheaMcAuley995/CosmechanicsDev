using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Greeble : MonoBehaviour
{
    public enum GreebleType
    {
        Spinning,
        Flying
    }
    public GreebleType greebleType = GreebleType.Spinning;

    float speed;
    Vector3 direction;


    void Start()
    {
        speed = Random.Range(15f, 25f);

        if (greebleType == GreebleType.Spinning)
        {            
            direction = new Vector3(Random.Range(-Random.value, Random.value), Random.Range(-Random.value, Random.value), Random.Range(-Random.value, Random.value)).normalized;
            transform.Rotate(direction);
        }
        else
        {
            direction = new Vector3(0f, -110f, 0f);
            transform.Rotate(direction);

            Destroy(this.gameObject, 30f);
        }
    }

    void Update()
    {
        if (greebleType == GreebleType.Spinning)
        {
            transform.Rotate(direction * speed * Time.deltaTime);
        }
        else
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
    }
}
