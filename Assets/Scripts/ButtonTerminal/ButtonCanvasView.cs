﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCanvasView : MonoBehaviour
{
    public QuickButtonManager buttonManager;

    public Transform mainCam;
    bool isActive = false;


	// Use this for initialization
	void Start ()
    {
		if (mainCam == null)
        {
            mainCam = Camera.main.transform;
        }

        ToggleImages(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isActive)
            LookAtCamera();
	}

    public void ToggleImages(bool isEnabled)
    {
        if (!isEnabled)
        {
            buttonManager.image.enabled = false;
            isActive = false;
        }
        else
        {
            buttonManager.image.enabled = true;
            isActive = true;
        }
    }

    void LookAtCamera()
    {
        transform.rotation = Quaternion.LookRotation(transform.position - mainCam.position);
    }
}
