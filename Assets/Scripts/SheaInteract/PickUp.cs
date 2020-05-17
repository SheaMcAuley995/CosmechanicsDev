using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PickUp : MonoBehaviour {

    public Rigidbody rb;
    public Player playerController;
    public Collider myCollider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        myCollider = GetComponent<Collider>();
    }

    public virtual void pickMeUp(Transform pickUpTransform)
    {
        if(myCollider == null)
        {
            myCollider = GetComponent<Collider>();
        }
        if(playerController != null)
        {
            playerController.interact.interactedObject = null;
            Destroy(playerController.interact.puu);
        }
        myCollider.enabled = false;
        rb.isKinematic = true;
        transform.SetParent(pickUpTransform);
        transform.position = pickUpTransform.position;
        transform.eulerAngles = pickUpTransform.eulerAngles;
    }

    public virtual void myInteraction()
    {
        
    }

    public virtual void endMyInteraction()
    {

    }
   
    public virtual void putMeDown()
    {
        endMyInteraction();
        myCollider.enabled = true;
        transform.SetParent(null);
        rb.isKinematic = false;
    }
}
