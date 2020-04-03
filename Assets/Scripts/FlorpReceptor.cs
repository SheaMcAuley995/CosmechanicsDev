using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlorpReceptor : MonoBehaviour
{
    public float florpTotal;

    float florpMax;
    float florpMin = -0.5f;
    float currentFill;
    float amountDeposited;


    Florp currentContainer;

    Renderer florpRenderer;
    MaterialPropertyBlock propertyBlock;

    private void Awake()
    {
        propertyBlock = new MaterialPropertyBlock();
        //florpRenderer.GetPropertyBlock(propertyBlock);
    }


    private void OnTriggerEnter(Collider other)
    {
        currentContainer = other.GetComponent<Florp>();
        florpRenderer = currentContainer.renderer;
        currentFill = currentContainer.florpFillAmount;
        
        amountDeposited = florpMin;
        florpMax = currentContainer.florpFillAmount;
    }

    private void OnTriggerExit(Collider other)
    {
        currentContainer.florpFillAmount = currentFill;   
    }

    private void OnTriggerStay(Collider other)
    {
        {
        if (other.tag == "Florp")
            StartCoroutine(FlorpEmpty());
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

            currentContainer.amountFilled = ((currentFill - florpMin) / (florpMax) * 50);

            buffer = florpTotal + ((amountDeposited - florpMin) / (florpMax));


            florpTotal = buffer/5;

            Debug.Log(florpTotal + " :FlorpTotal");

        }
        else
        {
            if (currentFill < -0.5f)
            {
                currentFill = -0.5f;

                propertyBlock.SetFloat("_FillAmount", currentFill);
                florpRenderer.SetPropertyBlock(propertyBlock);
            }

            if(florpTotal > 500)
            {
                florpTotal = 500;
            }

            Debug.Log("Hit");
            yield return null;
        }
        yield return new WaitForFixedUpdate();

    }
    
}
