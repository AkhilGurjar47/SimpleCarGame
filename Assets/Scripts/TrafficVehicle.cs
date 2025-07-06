using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrafficVehicle : MonoBehaviour
{
    // Start is called before the first frame update
    const float speed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f,0f,speed*Time.deltaTime);
    }
}
