using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LevisTransitionCamera : MonoBehaviour
{
    public Vector3 offset;

    public Quaternion baseRotation;

    List<GameObject> targets;
    public GameObject target;

    public float transitionSpeed;

    public LevelSelectImput inputAction;

    public List<GameObject> worlds;
    int world;

    public bool worldSelected;

    int currentTarget;

    private Vector2 moveAxis;

    private void Awake()
    {
        inputAction = new LevelSelectImput();
        worldSelected = false;
        
    }

    private void Start()
    {
        currentTarget = 0;

        targets = worlds;

        transform.rotation = baseRotation;

        if (targets != null)
        {
            transform.position = targets[0].transform.position + offset;
            target = targets[0];
        }
    }



    public void NextTarget()
    {
        currentTarget++;

        if(currentTarget >= targets.Count)
        {
            currentTarget = 0;
        }

        target = targets[currentTarget];
        StartCoroutine(ShiftCamera());
    }

    public void PrevTarget()
    {
        if (currentTarget == 0)
        {
            currentTarget = targets.Count - 1;
        }
        else
        {
            currentTarget--;
        }

        target = targets[currentTarget];
        StartCoroutine(ShiftCamera());
    }

    public void WorldSelect()
    {
        worldSelected = true;

        offset = new Vector3(0, 0, 5);

        world = currentTarget;
        currentTarget = 0;

        targets = target.GetComponent<LevelSecion>().levelList;

        SetOrbit(false);

        target = targets[0];


        StartCoroutine(ShiftCamera());
    }

    void SetOrbit(bool state)
    {
        foreach (GameObject level in targets)
        {
            OrbiterScript orbiter = level.GetComponent<OrbiterScript>();

            orbiter.doOrbit = state;

            if (state == true)
            {
                orbiter.moveBack = true;
            }                
        }
    }

    public void BackToWorldSelect()
    {
        worldSelected = false;

        offset = new Vector3(0, 0, 25);

        SetOrbit(true);

        currentTarget = world;
        targets = worlds;
        target = worlds[currentTarget];
      

        StartCoroutine(ShiftCamera());
    }

    Vector3 velocity = Vector3.zero;

    IEnumerator ShiftCamera()
    {
        while(true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targets[currentTarget].transform.position + offset, ref velocity, transitionSpeed);

            yield return new WaitForFixedUpdate();
            //transform.parent = target.transform;
            transform.rotation = baseRotation;
        }
    }

    private void OnEnable()
    {
        inputAction.MenuControls.Select.performed += Select_performed;
        inputAction.MenuControls.Select.Enable();

        inputAction.MenuControls.Move.performed += Move_performed;
        inputAction.MenuControls.Move.Enable();

        inputAction.MenuControls.Back.performed += Back_performed; ;
        inputAction.MenuControls.Back.Enable();
    }


    private void OnDisable()
    {
        inputAction.MenuControls.Select.performed -= Select_performed;
        inputAction.MenuControls.Select.Disable();

        inputAction.MenuControls.Back.performed -= Back_performed;
        inputAction.MenuControls.Back.Disable();
    }

    private void Select_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        Debug.Log("Select");


        if(!worldSelected)
        {
            WorldSelect();
        }
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        moveAxis = obj.ReadValue<Vector2>();
        Debug.Log($"Move Axis {moveAxis}");

        switch (moveAxis.x > moveAxis.y)
        {
            case true  :
                NextTarget();
                break;

            case false :
                PrevTarget();
                break;
        }
    }

    private void Back_performed(InputAction.CallbackContext obj)
    {
        //throw new System.NotImplementedException();
        if(worldSelected)
        {
            BackToWorldSelect();
        }
    }

}
