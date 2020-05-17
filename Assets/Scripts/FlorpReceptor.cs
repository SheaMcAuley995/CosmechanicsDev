using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorpReceptor : MonoBehaviour
{
    public float florpTotal;

    AudioSource emptySound;

    float florpMax;
    float florpMin = -0.5f;
    float currentFill;
    float amountDeposited;
    float emptyTotal;

    Florp currentContainer;

    Renderer florpRenderer;
    MaterialPropertyBlock propertyBlock;

    private void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
        emptySound = GetComponent<AudioSource>();
        //florpRenderer.GetPropertyBlock(propertyBlock);
    }


    private void OnTriggerEnter(Collider other)
    {
        currentContainer = other.GetComponent<Florp>();
        //florpRenderer = currentContainer.renderer;
        currentFill = currentContainer.florpFillAmount;

        if (currentFill > florpMin)
        {
            emptySound.Play();
        }

        amountDeposited = florpMin;
        florpMax = currentContainer.florpFillAmount;
    }

    private void OnTriggerExit(Collider other)
    {
        currentContainer.florpFillAmount = currentFill;

        emptySound.Stop();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Florp")
        {
            StartCoroutine(FlorpEmpty());
        }

        if (florpTotal > 500)
        {
            florpTotal = 500;
        }

    }

    


    IEnumerator FlorpEmpty()
    {
        float buffer;
        
        if (currentFill > -0.5f )
        {

            propertyBlock.SetFloat("_FillAmount", currentFill);
            florpRenderer.SetPropertyBlock(propertyBlock);

            currentFill -= (.01f * currentContainer.fillSpeed);
            amountDeposited += (.01f * currentContainer.fillSpeed);

            currentContainer.florpFillAmount = propertyBlock.GetFloat("_FillAmount");
            currentContainer.amountFilled = ((currentFill - florpMin) / (florpMax) * 50);

            buffer = -((currentFill + florpMin) / (florpMax) * 50);
            florpTotal += (buffer - (buffer - 1))/4;
        }
        else
        {
            if (currentFill <= -0.5f)
            {
                currentFill = -0.5f;

                propertyBlock.SetFloat("_FillAmount", currentFill);
                florpRenderer.SetPropertyBlock(propertyBlock);

                Debug.Log(propertyBlock.GetFloat("_FillAmount"));
            }
            emptySound.Stop();

            Debug.Log("Hit");
            yield return null;
        }
        yield return new WaitForFixedUpdate();

    }
    
}
