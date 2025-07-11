using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI distanceText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] CarController controller;
    [SerializeField] Transform carTransform;
    private float speed = 0f;
    private float distance = 0f;
    private float score = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceUI();
        SpeedUI();
        ScoreUI();
    }
    void DistanceUI()
    {
        distance = carTransform.position.z/1000;
        distanceText.text = distance.ToString("0.00" + "km");
    }
    void SpeedUI()
    {
        speed = controller.CarSpeed();
        speedText.text = speed.ToString("0" + "km/h");
    }
    void ScoreUI()
    {
        score = carTransform.position.z * 6;
        scoreText.text = score.ToString("0");
    }
}
