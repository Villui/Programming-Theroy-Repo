using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convertible : Vehicle
{
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Update is called once per frame
    new void Start()
    {
        base.Start();
        setHorsePower(20000.0f);
        setTurnSpeed(60.0f);
    }

    void FixedUpdate()
    {
        currentSpeed = GetCurrentSpeed();
        playerMovement();
    }

    public virtual void playerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (IsOnGround())
        {
            //Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            if (currentSpeed < 0.1f)
            {
                transform.position += new Vector3(0.0f, 0.2f, 0.0f);
            }
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * horsePower);
            //Turning the vehicle
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
