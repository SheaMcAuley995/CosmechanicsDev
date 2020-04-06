using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Florp : MonoBehaviour
{
    public bool doFill;

    public float fillSpeed;

    public Renderer renderer;
    private MaterialPropertyBlock propertyBlock;

    Renderer innerRenderer;

    float florpFillMax = 0.5f;
    float florpFillMin = -0.5f;

    public float florpFillAmount;

    public float amountFilled;
    //public ParticleSystem particle;

    public LayerMask interactableLayer;

    private void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(propertyBlock);
        florpFillAmount = -0.5f;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Dispenser")
        {
            doFill = true;
            StartCoroutine(FlorpFill());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Dispenser")
        {
            doFill = false;
        }
    }

    public IEnumerator FlorpFill()
    {
        Debug.Log(propertyBlock.GetFloat("_FillAmount"));
        if (florpFillAmount < florpFillMax && doFill == true)
        {
            propertyBlock.SetFloat("_FillAmount",florpFillAmount);
            renderer.SetPropertyBlock(propertyBlock);
            florpFillAmount += (.01f * fillSpeed);

            amountFilled = (florpFillAmount - florpFillMin) / (florpFillMax) * 50;


            //Debug.Log(propertyBlock.GetFloat("_FillAmount"));
        }
        else
        {
            if(amountFilled > 0.5f)
            {
                florpFillAmount = 0.5f;
                propertyBlock.SetFloat("_FillAmount", florpFillAmount);
                renderer.SetPropertyBlock(propertyBlock);
                yield return null;
            }

            Debug.Log("Hit");
            yield return null;
        }

        yield return new WaitForFixedUpdate();
    }
}