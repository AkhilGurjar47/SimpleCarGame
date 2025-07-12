using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI speedText;
    [SerializeField] TextMeshProUGUI distanceText;
    [SerializeField] TextMeshProUGUI totalScoreText;
    [SerializeField] TextMeshProUGUI totalDistanceText;
    [SerializeField] TextMeshProUGUI maximumSpeedText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] CarController controller;
    [SerializeField] Transform carTransform;
    [SerializeField] GameObject gameOverPanel;

    [SerializeField] GameObject speedIcon;
    [SerializeField] GameObject distanceIcon;
    [SerializeField] GameObject scoreIcon;
    private float speed = 0f;
    private float distance = 0f;
    private float score = 0f;
    private float maximumSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        speedIcon.SetActive(true);
        distanceIcon.SetActive(true);
        scoreIcon.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        DistanceUI();
        SpeedUI();
        ScoreUI();
        MaximumSpeed();
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
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverPanel.SetActive (true);
        speedIcon.SetActive(false);
        distanceIcon.SetActive(false);
        scoreIcon.SetActive(false);
        totalScoreText.text = score.ToString("0"); 
        totalDistanceText.text = distance.ToString("0.00" + "km");
    }
    void MaximumSpeed()
    {
        float currentSpeed = controller.CarSpeed();
        if(currentSpeed > maximumSpeed)
        {
            maximumSpeed = currentSpeed;
        }
        maximumSpeedText.text = maximumSpeed.ToString("0"+"km/h");
    }
    public void TryAgain()
    {
        var currentScene = SceneManager.GetActiveScene();
        Time.timeScale = 1f;
        SceneManager.LoadScene(currentScene.name);
    }
}
