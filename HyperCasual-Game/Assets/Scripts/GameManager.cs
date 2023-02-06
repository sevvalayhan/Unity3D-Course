using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Device;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using Application = UnityEngine.Device.Application;

public class GameManager : MonoBehaviour
{
    public GameObject LoseUI;
    public GameObject winUI;
    private int score;
    public TextMeshProUGUI scoreText;



    public void LevelEnd()
    {
        LoseUI.SetActive(true);
        scoreText.text = "Toplam Puan: " + score;
    }

    public void WinLevel()
    {
        winUI.SetActive(true);
    }

    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelUp()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int pointValue)
    {
        score += pointValue;
        scoreText.text = "Toplam Puan: " + score;
    }
    public void AppQuit()
    {
        Application.Quit();
    }


}
