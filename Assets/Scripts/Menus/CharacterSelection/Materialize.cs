using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Materialize : MonoBehaviour
{
    [Range(0, 1.1f)]
    public float lerpAmount;
    public Material mat;

    private void OnDrawGizmos()
    {
        if (mat == null)
        {
            return;
        }
        mat.SetFloat("_Threshold", lerpAmount);
    }

    void Update()
    {
        if (mat == null)
        {
            mat = GetComponent<Renderer>().material;
            return;
        }
        mat.SetFloat("_Threshold", lerpAmount);

        if (gameObject.tag == "TargetMats")
        {
            lerpAmount = Mathf.Clamp(lerpAmount, 0.3f, 1.1f);
        }
        else
        {
            lerpAmount = Mathf.Clamp(lerpAmount, 0.0f, 1.1f);
        }
    }
}
