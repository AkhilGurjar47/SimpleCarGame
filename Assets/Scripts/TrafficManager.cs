using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    [SerializeField] Transform[] Lanes;
    [SerializeField] GameObject[] trafficVehicle;
    void Start()
    {
        StartCoroutine(TrafficSpawner());
    }

    IEnumerator TrafficSpawner()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            Instantiate(trafficVehicle[Random.Range(0, 3)], Lanes[Random.Range(0,Lanes.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2f);
            
        }
    }
}
