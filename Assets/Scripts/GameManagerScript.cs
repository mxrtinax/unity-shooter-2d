using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public static int score = 0;
    public static int wave = 1;
    public GameObject gameOverUI;

    // Start is called before the first frame update
    void Start()
    {
        int score = 0;
        int wave = 1;
    }

    

    // Update is called once per frame
    void Update()
    {

    }

    public void gameOver()
    {
        Time.timeScale = 0f;
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

    public static int GetWave()
    {
        return wave;
    }
}
