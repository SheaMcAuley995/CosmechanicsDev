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

    //public float florpFillMax { 
    //    get; 
    //    private set; }

    public float florpFillMin = -0.5f;
    public float florpFillMax = 0.5f;



    public float florpFillAmount;

    public float amountFilled;
    //public AudioSource fillingAudio;
    //public ParticleSystem particle;

    public LayerMask FlorpFillerLayer;
    public FlorpFiller FlorpFiller;

    public FlorpReceptor florpReceptor;

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
            //fillingAudio.Play();
            propertyBlock.SetFloat("_FillAmount", florpFillAmount);
            renderer.SetPropertyBlock(propertyBlock);
            florpFillAmount += .25f;

        }
    }

    public override void putMeDown()
    {
        base.putMeDown();
        if (florpFillAmount <= florpFillMax)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.TransformPoint(Vector3.zero), 2, FlorpFillerLayer);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                FlorpFiller = hitColliders[i].GetComponent<FlorpFiller>();
                FlorpFiller.curButton.On = true;
                FlorpFiller.curButton.meshRenderer.material = FlorpFiller.buttonOnMat;
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
        else
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.TransformPoint(Vector3.zero), 2, FlorpFillerLayer);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                FlorpReceptor receptor = hitColliders[i].GetComponent<FlorpReceptor>();
                

            }
        }
    }

    public override void pickMeUp(Transform pickUpTransform)
    {

        if(FlorpFiller == null)
        {
            base.pickMeUp(pickUpTransform);
        }
        

        if(FlorpFiller != null)
        {
            FlorpFiller.curButton.meshRenderer.material = FlorpFiller.buttonOffMat;
            FlorpFiller.florp = null;
            FlorpFiller = null;
        }

    }


}




