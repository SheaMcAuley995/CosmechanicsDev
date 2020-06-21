using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerControls controls;


    [HideInInspector] public Vector2 movementVector;
    private Vector2 movementDir;
    [HideInInspector] public bool InteractionBool;
    [HideInInspector] public bool sprint;
    [HideInInspector] public bool bumper;
    [HideInInspector] public bool pauseButton;

    [HideInInspector] public Vector2 selectModel;
    [HideInInspector] public bool Button_Y;
    [HideInInspector] public bool Button_X;
    [HideInInspector] public bool Button_RB;
    [HideInInspector] public bool Button_LB;
    [HideInInspector] public bool Button_A;
    [HideInInspector] public bool Button_B;
    [HideInInspector] public bool start;
    CharacterController cc;

    public bool pickUp = false;
    public Transform pickUpTransform;

    // preReWired scripts
    public float walkSpeed = 2;
    public float runSpeed = 6;
    public float gravity = -12;
    public float jumpheight = 1;

    public float turnSmoothTime = 0.2f;
    float turnSmoothVelocity;

    public float speedSmoothTime = 0.1f;
    float speedSmoothVelocity;
    float currentSpeed;
    float velocityY;

    public Transform cameraTrans;
    GameObject[] players = new GameObject[1];
    Rigidbody rb;
    public InteractWithInterface interact;
    public int maxPossibleCollisions;
    //public LayerMask collisionLayer;
    public LayerMask interactableLayer;
    public float radius;
    Collider[] possibleColliders;
    private Collider thisCollider;
    public Animator[] animators;

    GameObject interactedObject;
    public float onFiretimer;
    public float onFireTimerCur;
    public GameObject onFireEffect;
    private bool onFire;
    public Collider myCollider;
    public Interactable interactableObject;
    public int playerId;
    [HideInInspector] public bool blockMovement = false;

    private void Awake()
    {
        controls = new PlayerControls();

        //CameraMultiTarget.instance.SetTargets(players);

        controls.Gameplay.Move.performed += ctx => movementVector = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movementVector = Vector2.zero;
        //controls.Gameplay.Interact.performed += ctx => InteractWithObject();
        controls.Gameplay.Interact.started += ctx => Interaction();
        controls.Gameplay.Interact.canceled += ctx => endInteraction();
        controls.Gameplay.PickUp.started += ctx => pickUpObject();
        //controls.Gameplay.PickUp.performed += ctx => pickUp;

    }

    private void Start()
    {

        thisCollider = GetComponent<CapsuleCollider>();
        possibleColliders = new Collider[maxPossibleCollisions];
        onFireTimerCur = onFiretimer;
        animators = GetComponentsInChildren<Animator>();
        //player = ReInput.players.GetPlayer(playerId);

        cc = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        interact = GetComponentInChildren<InteractWithInterface>();
        interact.controller = this;
    }

    void Update()
    {

        movementDir = movementVector.normalized;
        ProcessInteraction();
        onFireCheck();
        onFireTimerCur = Mathf.Clamp(onFireTimerCur += Time.time, 0, onFiretimer);
    }


    private void ProcessInteraction()
    {
         Move(movementVector, sprint);
    }

    public void pickUpInteraction()
    {
        interact.interactableObject.pickUpTransform = pickUpTransform;
    }

    public virtual void Interaction()
    {

        if (interactedObject != null)
        {
            if (interactedObject.GetComponent<PickUp>() != null)
            {
                interactedObject.GetComponent<PickUp>().myInteraction();
            }
        }
        else
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, interactableLayer);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                //Debug.Log("Interacting with :" + hitColliders[i].name);
                if (hitColliders[i].GetComponent<RepairableObject>() != null)
                {
                    if (hitColliders[i].GetComponent<RepairableObject>().health != hitColliders[i].GetComponent<RepairableObject>().healthMax)
                    {
                        foreach (Animator animator in animators)
                        {
                            if (animator != null) { animator.SetTrigger("PipeFix"); }
                        }
                        //animators[0].SetTrigger("PipeFix");
                        //animators[1].SetTrigger("PipeFix");
                        hitColliders[i].GetComponent<IInteractable>().InteractWith();
                        break;
                    }
                }
                else
                {
                    if (hitColliders[i].GetComponent<IInteractable>() != null)
                    {
                        hitColliders[i].GetComponent<IInteractable>().InteractWith();
                    }
                    break;
                }

            }
        }
    }

    public void endInteraction()
    {
        if (interactedObject != null)
        {
            if (interactedObject.GetComponent<PickUp>() != null)
            {
                //Debug.Log("TOOL INTEREACTION");
                interactedObject.GetComponent<PickUp>().endMyInteraction();
            }
        }
    }

    public void pickUpObject()
    {
        //Debug.Log("CAST");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward, radius, interactableLayer);
       // Debug.Log(transform.forward);
        if (interactedObject == null)
        {
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].GetComponent<PickUp>() != null)
                {
                    hitColliders[i].GetComponent<PickUp>().pickMeUp(pickUpTransform);
                    hitColliders[i].GetComponent<PickUp>().playerController = this;
                    //hitColliders[i].GetComponent<PickUp>().playerController = controller;
                    interactedObject = hitColliders[i].gameObject;
                    if (hitColliders[i].GetComponent<Interactable>() != false)
                    {
                        interactableObject = hitColliders[i].GetComponent<Interactable>();
                    }
                    if(hitColliders[i].GetComponent<PickUp>().playerController != null)
                    {
                        break;
                    }
                }
            }
        }
        else
        {
            interactedObject.GetComponent<PickUp>().putMeDown();
            interactedObject = null;
        }
    }


    public void callInteract()
    {
        if (interactableObject != null)
        {
            interactableObject.InteractWith();
        }
    }
    public void closeInteract()
    {
        interactableObject = null;
    }

    void Move(Vector2 inputDir, bool running)
    {
        if (!onFire)
        {
            foreach (Animator animator in animators)
            {
                if (animator != null) { animator.SetBool("OnFire", false); }
            }
            //animators[0].SetBool("OnFire", false);
            //animators[1].SetBool("OnFire", false);
            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }

            float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

            if (targetSpeed > 0)
            {
                foreach (Animator animator in animators)
                {
                    if (animator != null) { animator.SetBool("Move", true); }
                }
                //animators[0].SetBool("Move", true);
                //animators[1].SetBool("Move", true);
            }
            else
            {
                foreach (Animator animator in animators)
                {
                    if (animator != null) { animator.SetBool("Move", false); }
                }
                //animators[0].SetBool("Move", false);
                //animators[1].SetBool("Move", false);
            }

        }

        if (onFire)
        {
            foreach (Animator animator in animators)
            {
                if (animator != null) { animator.SetBool("OnFire", true); }
            }
            //animators[0].SetBool("OnFire", true);
            //animators[1].SetBool("OnFire", true);
            onFireEffect.SetActive(true);

            if (inputDir != Vector2.zero)
            {
                float targetRotation = (Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y);
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }

            float targetSpeed = walkSpeed;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
        }
        else
        {
            onFireEffect.SetActive(false);
        }


        if (!blockMovement)
        {
            rb.velocity = transform.forward * currentSpeed;
        }
        else 
        { 
            rb.velocity = transform.forward * Vector2.zero; 
        }

    }

    public void onFireCheck()
    {
        if (onFireTimerCur < onFiretimer / 2)
        {
            onFire = true;
        }
        else
        {
            onFire = false;
        }
    }


    private void OnEnable()
    {
        controls.Gameplay.Enable();
    }
    private void OnDisable()
    {
        controls.Gameplay.Disable();
    }

}
