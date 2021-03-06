﻿using System.Collections.Generic;
using UnityEngine;
public class MeshData
{
    public Vector3 pos;
    public Vector3 scale;
    public Quaternion rot;
    public float speed;
    internal Vector3 angularVelocity;
    public float seed;

    public Matrix4x4 matrix { get { return Matrix4x4.TRS(pos, rot, scale); } }
    public MeshData(Vector3 position,  Quaternion rotation, Vector3 scale, float speed)
    {
        this.pos = position;
        this.scale = scale;
        this.rot = rotation;
        this.speed = speed;
        this.seed = Random.value;
        this.angularVelocity = Random.insideUnitSphere;
    }
}
public class MeshInstancer : MonoBehaviour {

    public Mesh mesh;
    public Material mat;

    [Range(1, 1023)]
    public int maxAsteroids = 300;
    public float radius = 200f;
    public List<MeshData> asteroids = new List<MeshData>();
    private List<Matrix4x4> asteroidsMatricies = new List<Matrix4x4>();
    public Transform spawnpoint;
    public float spawnMax = 10f;
    public float spawnMin = -10f;
    public float scaleValue = .5f;
    public float minSpeed, maxSpeed;
    [Range(-25,25)]
    public float speedMult = 1f;
    float randomness;
    public Transform target;
    // Use this for initialization
    void Start () {

        randomness = Random.Range(spawnMin, spawnMax);
        while (asteroids.Count < maxAsteroids)
        {          
            CreateAsteroid();
        }
       
    }

    private void CreateAsteroid()
    {
        float random1 = Random.Range(spawnMin, spawnMax);
        float random2 = Random.Range(spawnMin, spawnMax);
        float random3 = Random.Range(spawnMin, spawnMax);
        var center = (this.transform.position + new Vector3(random1, random2, random3));
        asteroids.Add(new MeshData(center, this.transform.rotation, this.transform.localScale, speedMult));
        foreach (MeshData matrix in asteroids)
        {
            if (asteroidsMatricies.Count < 1023)
            {
                asteroidsMatricies.Add(matrix.matrix);

            }
            
        }
        
    }

    
    void Update ()
    {
        Vector3 asteroidHeading =(target.transform.position - this.transform.position);
        asteroidHeading.Normalize();
        foreach (var asteroid in asteroids)
        {
            
            var diff = asteroid.pos - this.transform.position;

            asteroid.pos += asteroidHeading * asteroid.speed *  Time.deltaTime * speedMult;
            asteroid.scale = new Vector3(scaleValue,scaleValue,scaleValue);
            
            if ((asteroid.pos - target.position).magnitude > radius)                                                             //
            {                                                                                                                    //
                ReplaceAsteroid(asteroid, asteroidHeading);                                                                      //
            }                                                                                                                    // DO ECS AT SOME POINT 
                                                                                                                                 //
            var angle = Mathf.Atan2(diff.x, diff.y);                                                                             //
            
            asteroid.rot = Quaternion.Euler(asteroid.angularVelocity * Time.time * asteroid.speed);
            Graphics.DrawMeshInstanced(mesh, 0, mat, asteroidsMatricies);
        }                                                                                                                        //       
    }

    private void ReplaceAsteroid(MeshData asteroid, Vector3 asteroidHeading)
    {
        randomness = Random.Range(spawnMin, spawnMax);
        float random2 = Random.Range(spawnMin, spawnMax);
        float random3 = Random.Range(spawnMin, spawnMax);
        asteroid.pos = (this.transform.position + new Vector3(randomness,random2,random3));
        asteroid.speed = Vector3.Distance(asteroid.pos, Camera.main.transform.position) / 10 / speedMult;
       
    }
}
