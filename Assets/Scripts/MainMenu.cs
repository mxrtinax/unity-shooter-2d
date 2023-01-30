using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = true;
    }

    public void PlayGame() 
    {
        EnemySpawning.ResetSpawning();
        GameManagerScript.SetScore(0);
        GameManagerScript.SetWave(1);
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
