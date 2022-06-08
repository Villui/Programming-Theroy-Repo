using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    protected float m_horsePower;
    public float horsePower // delete semicolon
    {
        get { return m_horsePower; } // getter returns backing field // ENCAPSULATION
        set
        {
            if (value < 0.0f)
            {

                Debug.LogError("You can't set a negative horsepower value!");
            }
            else
            {
                m_horsePower = value; // original setter now in if/else statement
            }
        }
    }
    protected float turnSpeed;
    protected float horizontalInput;
    protected float verticalInput;
    protected float currentSpeed;
    protected Rigidbody playerRb;
    protected Vector3 oldPosition = new Vector3(0.0f, 0.0f, 0.0f);
    [SerializeField] GameObject centerOfMass;

    // Start is called before the first frame update
    protected void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

    }

    protected void setHorsePower(float newSpeed)
    {
        horsePower = newSpeed;
    }

    protected void setTurnSpeed(float newTurnSpeed)
    {
        turnSpeed = newTurnSpeed;
    }

    protected float GetCurrentSpeed()
    {
        currentSpeed = Vector3.Distance(oldPosition, transform.position) / Time.deltaTime;
        oldPosition = transform.position;
        Debug.Log("Speed: " + currentSpeed);
        return currentSpeed;
    }
}
