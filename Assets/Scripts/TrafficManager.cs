using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficManager : MonoBehaviour
{
    [SerializeField] Transform[] Lanes;
    [SerializeField] GameObject[] trafficVehicle;
    [SerializeField] CarController carControllers;
    [SerializeField] private float minSpawnTime = 30f;
    [SerializeField] private float maxSpawnTime = 60f;
    private float dynamicTimer = 2f;
    void Start()
    {
        StartCoroutine(TrafficSpawner());
    }

    IEnumerator TrafficSpawner()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            if(carControllers.CarSpeed()>20f)
            {
                dynamicTimer = Random.Range(minSpawnTime, maxSpawnTime) / carControllers.CarSpeed();
                SpawnTrafficVehicle();
            }
            yield return new WaitForSeconds(dynamicTimer);
            
        }
    }
    void SpawnTrafficVehicle()
    {
        Instantiate(trafficVehicle[Random.Range(0, 3)], Lanes[Random.Range(0, Lanes.Length)].position, Quaternion.identity);
    }
}
