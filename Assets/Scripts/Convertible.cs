using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convertible : Vehicle //INHERITANCE
{
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Update is called once per frame
    new void Start()
    {
        base.Start(); // POLYMORPHISM
        setHorsePower(20000.0f);
        setTurnSpeed(60.0f);
    }

    void FixedUpdate()
    {
        playerMovement();
    }

    private void playerMovement() // ABSTRACTION
    {
        currentSpeed = GetCurrentSpeed();
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (IsOnGround())
        {
            if (currentSpeed < 0.1f)
            {
                transform.position += new Vector3(0.0f, 0.2f, 0.0f);
            }
            playerRb.AddRelativeForce(Vector3.forward * verticalInput * m_horsePower);
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
