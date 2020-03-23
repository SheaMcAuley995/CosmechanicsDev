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

    private void Awake()
    {
        controls = new PlayerControls();
        
        
        controls.Gameplay.Move.performed += ctx => movementVector = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movementVector = Vector2.zero;
       //controls.Gameplay.Interact.performed += ctx => InteractWithObject();
        controls.Gameplay.Interact.started += ctx => Interaction();
        //controls.Gameplay.Interact.canceled += ctx => endInteraction();
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

        if(cameraTrans == null)
        {
            cameraTrans = Camera.main.transform;
        }

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

        if(Gamepad.current.xButton.wasReleasedThisFrame)
        {
            endInteraction();
        }

        if(controls.Gameplay.Interact.triggered)
        {
            Debug.Log("Pressed");

        }
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
                //Debug.Log("TOOL INTEREACTION");
                interactedObject.GetComponent<PickUp>().myInteraction();
            }
        }
        else
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius, interactableLayer);

            for (int i = 0; i < hitColliders.Length; i++)
            {
                Debug.Log("Interacting with :" + hitColliders[i].name);
                if (hitColliders[i].GetComponent<RepairableObject>() != null)
                {
                    if (hitColliders[i].GetComponent<RepairableObject>().health != hitColliders[i].GetComponent<RepairableObject>().healthMax)
                    {
                        animators[0].SetTrigger("PipeFix");
                        animators[1].SetTrigger("PipeFix");
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
                Debug.Log("TOOL INTEREACTION");
                interactedObject.GetComponent<PickUp>().endMyInteraction();
            }
        }
    }

    public void pickUpObject()
    {
        Debug.Log("CAST");
        Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.forward, radius, interactableLayer);
        Debug.Log(transform.forward);
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

                    //isPuu = true;
                    //puu = Instantiate(puuPrefab, interactedObject.transform.position, interactedObject.transform.rotation, interactedObject.transform);
                    //box.enabled = true;

                    if (hitColliders[i].GetComponent<Interactable>() != false)
                    {
                        interactableObject = hitColliders[i].GetComponent<Interactable>();
                    }
                    break;
                }
            }
        }
        else
        {
            interactedObject.GetComponent<FireExtinguisher>().endMyInteraction();
            if (interactedObject.GetComponent<PickUp>() != null)
            {
                interactedObject.GetComponent<PickUp>().playerController = null;
            }
            interactedObject.GetComponent<PickUp>().putMeDown();
            //isPuu = false;
            //Destroy(puu);
            // box.enabled = false;
            interactedObject = null;
        }
        //if (!isPuu)
        //{
        //    Destroy(puu);
        //}
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
            animators[0].SetBool("OnFire", false);
            animators[1].SetBool("OnFire", false);
            if (inputDir != Vector2.zero)
            {
                float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y;
                transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
            }

            float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
            currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

            if (targetSpeed > 0)
            {
                animators[0].SetBool("Move", true);
                animators[1].SetBool("Move", true);
            }
            else
            {
                animators[0].SetBool("Move", false);
                animators[1].SetBool("Move", false);
            }

        }

        if (onFire)
        {
            animators[0].SetBool("OnFire", true);
            animators[1].SetBool("OnFire", true);
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


        rb.velocity = transform.forward * currentSpeed;

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
