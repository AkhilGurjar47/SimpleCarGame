using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawnSpeed : MonoBehaviour
{
    [SerializeField] Transform playerCarTransform;
    [SerializeField] float offSet = -5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 cameraPos = transform.position;
        cameraPos.z = playerCarTransform.position.z + offSet;
        transform.position = cameraPos;
    }
}
