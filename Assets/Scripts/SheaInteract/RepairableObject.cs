﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairableObject : MonoBehaviour, IInteractable, IDamageable<int> {

    public int health = 2;

    public int healthMax = 2;

    public int repairAmount = 1;

    MeshRenderer mesh;
    MeshFilter filter;
    [SerializeField]Mesh[] meshes;
    int currentMesh;
    //public GameObject steamParticlePrefab;
    public GameObject repairEffect;
    public ParticleSystem steamEffect;
    public ParticleSystem steamEffect2;
    public AlertUI alertUI;

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        ShipHealth.instance.shipMaxHealth += healthMax;
        ShipHealth.instance.shipCurrenHealth += health;
        filter = GetComponent<MeshFilter>();
        alertUI.problemMax += healthMax;
        alertUI.problemCurrent += healthMax;
        
        //StartCoroutine("takeDamage");
    }
    public void InteractWith()
    {
        //Todo: Set up a mechanic that take in the currently equiped tool. 
        if (health < healthMax)
        {
            repairObject(repairAmount);
            mesh.material.color -= Color.red;
            GameObject nutsAndBolts = Instantiate(repairEffect, transform.position + new Vector3(0,0.1f),Quaternion.identity);
            Destroy(nutsAndBolts.gameObject, 1);
             
            AudioEventManager.instance.PlaySound("clang", .05f, Random.Range(.9f,1f), 0);    //play clang audio
           //ShipHealth.instance.shipCurrenHealth += repairAmount;
           // Debug.Log("Health Points : " + health);

            if(steamEffect.isPlaying)
            {
                steamEffect.Stop();
                steamEffect2.Stop();
            }

        }
    }





    public void repairObject(int repairAmount)
    {
        currentMesh -= 1;
        filter.mesh = meshes[currentMesh];
        health = health + repairAmount;
        alertUI.problemCurrent += repairAmount;
        ShipHealth.instance.shipCurrenHealth += repairAmount;
        ShipHealth.instance.AdjustUI();
        // health = Mathf.Clamp(health + repairAmount, 0, healthMax);
        
    }



    public void TakeDamage(int damageTaken)
    {
        if (health > 0)
        {
            health -= damageTaken;
            currentMesh += 1;
            filter.mesh = meshes[currentMesh];
            mesh.material.color += Color.red;
            alertUI.problemCurrent -= damageTaken;
            ShipHealth.instance.shipCurrenHealth -= damageTaken;
            ShipHealth.instance.AdjustUI();
            //Debug.Log("Health Points : " + health);
            AudioEventManager.instance.PlaySound("pipebreak",.05f,1,0);
            if(!steamEffect.isPlaying)
            {
                steamEffect.Play();
                steamEffect2.Play();
            }
            
        }

    }
   
   
    private void OnEnable()
    {
        
    }
    private void OnDisable()
    {
        
    }
}
