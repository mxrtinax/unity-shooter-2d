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
    public string user;
    public GameObject gameOverUI;
    private Transform entryContainer;
    private Transform entryTemplate;

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

        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        //Transform gameOverScore = gameOverUI.transform.Find("GameOverScore");
        gameOverUI.SetActive(true);

        bool isHighscore = HighscoreTable.CheckIfHighscore(score);
        if (isHighscore) {
            gameOverUI.transform.Find("GameOverText").GetComponent<TMP_Text>().text = "YOU'RE HIRED \n (HIGHSCORE)";
            gameOverUI.transform.Find("GameOverScore").GetComponent<TMP_Text>().text = "Take your salary: " + score + " cryptodan";
        }
        else {
            gameOverUI.transform.Find("GameOverScore").GetComponent<TMP_Text>().text = "Crypto wallet: " + score + " cryptodan";
        }

        

    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * represents a single highscore entry
     * */
    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }

    public void ReadUserName(string userName) {
        user = userName;
        HighscoreTable.AddHighscoreEntry(score, user);
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
