using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;

    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    // Start is called before the first frame update
    [SerializeField] private float motorForce = 10f;
    [SerializeField] private Transform CarCenterOfMass;
    private Rigidbody Rigidbody;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.centerOfMass = CarCenterOfMass.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
    }
    void MotorForce()
    {
        frontRightWheelCollider.motorTorque = motorForce;
        frontLeftWheelCollider.motorTorque = motorForce;
    }
}
