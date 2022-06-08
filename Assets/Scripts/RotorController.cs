using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorController : MonoBehaviour
{
    private GameObject mainRotor;
    private GameObject tailRotor;

    // Start is called before the first frame update
    void Start()
    {
        mainRotor = GameObject.Find("SK_Veh_Small_Heli_Rotor_Main_01");
        tailRotor = GameObject.Find("SK_Veh_Small_Heli_Rotor_Tail_01");
    }

    // Update is called once per frame
    void Update()
    {
        mainRotor.transform.Rotate(Vector3.up * (95760.0f * Time.deltaTime));
        tailRotor.transform.Rotate(Vector3.right * (95760.0f * Time.deltaTime));
    }
}
