using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public float score;
    void Start()
    {

    }


    void Update()
    {

    }
    public void AddScore(float value)
    {
        score = score + value;
        scoreText.text = "Score: " + score.ToString();

    }
    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString();
    }

}
