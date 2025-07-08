using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField]private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;

    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;

    [SerializeField] private float motorForce = 100f;
    [SerializeField] private Transform CarCenterOfMass;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private float BreakForce = 1000f;
    [SerializeField] private float SteeringAngle = 30f;

    private Rigidbody Rigidbody;
    private float verticalInput;
    private float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.centerOfMass = CarCenterOfMass.localPosition;
        gameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MotorForce();
        UpdateWheels();
        GetInput();
        Steering();
        ApplyBrakes();
        PowerSteering();
    }
    void GetInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void MotorForce()
    {
        frontRightWheelCollider.motorTorque = motorForce * verticalInput;
        frontLeftWheelCollider.motorTorque = motorForce * verticalInput;
    }
    void Steering()
    {
        frontRightWheelCollider.steerAngle = SteeringAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = SteeringAngle * horizontalInput;
    }
    void PowerSteering()
    {
        if(horizontalInput==0)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(0,0,0),Time.deltaTime);
        }
    }
    void UpdateWheels()
    {
        RotateWheel(frontRightWheelCollider,frontRightWheelTransform);        
        RotateWheel(backRightWheelCollider,backRightWheelTransform);    
        RotateWheel(backLeftWheelCollider,backLeftWheelTransform);
        RotateWheel(frontLeftWheelCollider, frontLeftWheelTransform);
    }
    void RotateWheel(WheelCollider wheelCollider,Transform transform)
    {
        Vector3 Pos;
        Quaternion Rot;
        wheelCollider.GetWorldPose(out Pos, out Rot);
        transform.position = Pos;
        transform.rotation = Rot;
    }
    void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            frontRightWheelCollider.brakeTorque = BreakForce;
            frontLeftWheelCollider.brakeTorque = BreakForce;
            backRightWheelCollider.brakeTorque = BreakForce;
            backLeftWheelCollider.brakeTorque = BreakForce;
            Rigidbody.drag = 1f;
        }
        else
        {
            frontRightWheelCollider.brakeTorque = 0f;
            frontLeftWheelCollider.brakeTorque = 0f;
            backRightWheelCollider.brakeTorque = 0f;
            backLeftWheelCollider.brakeTorque = 0f;
            Rigidbody.drag = 0f;
        }
    }
    public float CarSpeed()
    {
        float speed = Rigidbody.velocity.magnitude * 2.23693629f;
        return speed;
    }
}
