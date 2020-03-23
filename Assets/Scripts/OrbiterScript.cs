using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbiterScript : MonoBehaviour
{
    public Transform planet;
    public float radius;
    public float radSpeed;

    public Vector3 axis;
    public float rotSpeed;
    Vector3 desiredPos;

    private void Start()
    {
        //planet = transform.parent;
        transform.position = (transform.position - planet.position).normalized * radius + planet.position;
    }

    private void Update()
    {
        transform.RotateAround(planet.position, axis, rotSpeed * Time.deltaTime);
        desiredPos = (transform.position - planet.position).normalized * radius + planet.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPos, Time.deltaTime * radSpeed);
    }

}
