using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Florp : PickUp
{
    //public bool doFill;

    public float fillSpeed;

    public Renderer renderer;
    private MaterialPropertyBlock propertyBlock;

    Renderer innerRenderer;

    float florpFillMin = -0.5f;
    float florpFillMax = 0.5f;

    public float florpFillAmount;

    public float amountFilled;
    //public ParticleSystem particle;

    public LayerMask FlorpFillerLayer;
    public FlorpFiller FlorpFiller;

    private void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(propertyBlock);
        florpFillAmount = florpFillMin;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void fillFlorp()
    {
        if (florpFillAmount < florpFillMax)
        {
            propertyBlock.SetFloat("_FillAmount", florpFillAmount);
            renderer.SetPropertyBlock(propertyBlock);
            florpFillAmount += .25f;

        }
    }

    public override void putMeDown()
    {
        base.putMeDown();

        Collider[] hitColliders = Physics.OverlapSphere(transform.TransformPoint(Vector3.zero), 2, FlorpFillerLayer);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            FlorpFiller = hitColliders[i].GetComponent<FlorpFiller>();

            if (hitColliders[i] != null)
            {
                FlorpFiller.florp = this;
                rb.isKinematic = true;
                transform.position = FlorpFiller.holdPostion.position;
                transform.rotation = FlorpFiller.holdPostion.rotation;
                break;
            }

        }

    }

    public override void pickMeUp(Transform pickUpTransform)
    {
        base.pickMeUp(pickUpTransform);

        if(FlorpFiller != null)
        {
            FlorpFiller.florp = null;
            FlorpFiller = null;
        }

    }


}




