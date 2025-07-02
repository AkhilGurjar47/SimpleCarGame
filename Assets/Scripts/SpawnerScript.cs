using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField] private GameObject[] traffic;
    [SerializeField] private Transform playerTransform;
    private float respawnTime = 5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TrafficSpawner());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator TrafficSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            Spawn();
        }
    }
    void Spawn()
    {
        int value = 80;
        while (value > 50)
        {
            int randomValue = UnityEngine.Random.Range(-5, 5);
            int randomTraffic = UnityEngine.Random.Range(0, traffic.Length);
            Instantiate(traffic[randomTraffic], new Vector3(randomValue, transform.position.y, playerTransform.position.z + value), Quaternion.identity);
            value -= 10;
        }
    }
}
