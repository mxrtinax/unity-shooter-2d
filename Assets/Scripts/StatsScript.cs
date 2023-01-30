using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsScript : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text waveText;

    int score = 0;
    int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        int score = 0;
        int wave = 1;
    }

    // Update is called once per frame
    void Update()
    {
        score = GameManagerScript.GetScore();
        wave = GameManagerScript.GetWave();

        scoreText.text = score.ToString();
        waveText.text = wave.ToString();
    }
}
