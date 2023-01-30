using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    
    private static int score = 0;
    private static int wave = 1;
    public GameObject gameOverUI;
    
    void Start()
    {
        int score = 0;
        int wave = 1;
    }

    
    void Update()
    {

    }

    public void gameOver()
    {
        Time.timeScale = 0f;
        
        Transform gameOverScore = gameOverUI.transform.Find("GameOverScore");
        gameOverScore.GetComponent<TMP_Text>().text = "Crypto wallet: " + score + " cryptodan";
        gameOverUI.SetActive(true);
    }

    public void playAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public static void AddScore(int newScoreValue)
    {
        score += newScoreValue * wave;
    }

    public static int IncrementWave()
    {
        wave++;
        return wave * 5;
    }

    public static int GetScore() 
    {
        return score;
    }

    public static void SetScore(int newScore)
    {
        score = newScore;
    }

    public static int GetWave()
    {
        return wave;
    }

    public static void SetWave(int newWave)
    {
        wave = newWave;
    }
}
