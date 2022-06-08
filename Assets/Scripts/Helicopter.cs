using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : Vehicle
{
    // Start is called before the first frame update
    private float rolloverRotation;
    private bool isLeftRollover;
    private bool isRightRollover;

    new void Start()
    {
        base.Start();
        rolloverRotation = 60.0f;
        setHorsePower(3000.0f);
        setTurnSpeed(90.0f);
    }

    // Update is called once per frame
    void Update()
    {
            playerMovement();
    }

    public virtual void playerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        if (Input.GetButton("Jump"))
        {
            Debug.Log("Spacebar");
            playerRb.AddRelativeForce(Vector3.up * horsePower);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rolloverRotation);
        }
        else if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rolloverRotation);
        }
        //Turning the vehicle
        transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
