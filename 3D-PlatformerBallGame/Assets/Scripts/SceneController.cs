using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] GameObject WinnerUI;
    [SerializeField] TextMeshProUGUI winnerScore;
    [SerializeField] ScoreController scoreController;


    void Start()
    {
    }
    void Update()
    {

    }




    public void ReturnMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void LevelUp()
    {
        WinnerUI.SetActive(true);
        winnerScore.text = "Seviye Tamamlandi\r\nPuanýnýz: " + scoreController.score.ToString();
        Invoke("NextLevel", 1f);
    }
    public void NextLevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void AppQuit()
    {
        Application.Quit();

        Debug.Log("çýkýþ yapýldý");
    }

    public void AppMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


}
