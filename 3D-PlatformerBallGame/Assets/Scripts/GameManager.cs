using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;   
    [SerializeField] private ScoreController scoreController;   
    [SerializeField] GameObject pauseMenuPanel;
    [SerializeField]  TextMeshProUGUI scoreText;

    bool isGameActive=true;
    float respawnDelay = 0.5f;
    private bool isGameEnding;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        scoreController = FindObjectOfType<ScoreController>();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameActive)
            {
                PauseMenu();
            }
            else
            {
                ContinueGame();
            }
            
        }
    }

    public void ViewScore()
    {
        scoreText.text = "Score: " + scoreController.score.ToString();
    }

    public void RespawnPlayer()
    {
        if (isGameEnding == false)
        {
            isGameEnding = true;

            StartCoroutine("RespawnCoroutine");
        }
    }

    public void PauseMenu()
    {
        pauseMenuPanel.gameObject.SetActive(true);
        isGameActive=!isGameActive;
        Time.timeScale = 0;

    }
    public void ContinueGame()
    {
        pauseMenuPanel.gameObject.SetActive(false);
        
        Time.timeScale = 1;
        isGameActive = !isGameActive;
    }

    public IEnumerator RespawnCoroutine()
    {
        playerController.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        isGameEnding = false;
    }
}
