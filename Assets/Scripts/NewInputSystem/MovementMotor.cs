using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMotor : MonoBehaviour
{
    private float moveSpeed = 1f;

    private Rigidbody rb;

    private Vector3 moveDirection = Vector3.zero;
    private Vector2 inputVector = Vector2.zero;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public void SetInputVector(Vector2 vect)
    {
        inputVector = vect;
    }

    private void Update()
    {
        moveDirection = new Vector3(inputVector.x, 0, inputVector.y);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        rb.MovePosition(rb.position + moveDirection);
    }

    //void Move(Vector2 inputDir, bool running)
    //{
    //    if (!onFire)
    //    {
    //        //animators[0].SetBool("OnFire", false);
    //        //animators[1].SetBool("OnFire", false);
    //        if (inputDir != Vector2.zero)
    //        {
    //            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
    //            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
    //        }
    //
    //        float targetSpeed = ((running) ? runSpeed : walkSpeed) * inputDir.magnitude;
    //        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
    //
    //        if (targetSpeed > 0)
    //        {
    //            animators[0].SetBool("Move", true);
    //            animators[1].SetBool("Move", true);
    //        }
    //        else
    //        {
    //            animators[0].SetBool("Move", false);
    //            animators[1].SetBool("Move", false);
    //        }
    //
    //    }
    //
    //    if (onFire)
    //    {
    //        // animators[0].SetBool("OnFire", true);
    //        // animators[1].SetBool("OnFire", true);
    //        onFireEffect.SetActive(true);
    //
    //        if (inputDir != Vector2.zero)
    //        {
    //            float targetRotation = (Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraTrans.eulerAngles.y);
    //            transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
    //        }
    //
    //        float targetSpeed = walkSpeed;
    //        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);
    //    }
    //    else
    //    {
    //        onFireEffect.SetActive(false);
    //    }
    //
    //
    //    rb.velocity = transform.forward * currentSpeed;
    //
    //}

}
