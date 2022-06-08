using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helicopter : Vehicle
{
    // Start is called before the first frame update
    [SerializeField]
    private float rolloverRotation;

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

    private void playerMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        if (Input.GetButton("Jump"))
        {
            playerRb.AddRelativeForce(Vector3.up * m_horsePower);
        }
        if (Input.GetKey("e"))
        {
            transform.Rotate(-Vector3.forward * Time.deltaTime * rolloverRotation);
        }
        else if (Input.GetKey("q"))
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * rolloverRotation);
        }
        transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed * verticalInput);
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
