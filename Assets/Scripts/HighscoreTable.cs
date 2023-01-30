using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using System;

public class HighscoreTable : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<HighscoreEntry> highscoreEntryList;
    private List<Transform> highscoreEntryTransformList;


    private void Awake() {
        entryContainer = transform.Find("HighscoreEntryContainer");
        entryTemplate = entryContainer.Find("HighscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);


        //AddHighscoreEntry(1000, "ZZZ");
        
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        //Debug.Log(jsonString);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        //Debug.Log(highscores);


        // sort entry list by score
        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++) {
                if (highscores.highscoreEntryList[j].score > highscores.highscoreEntryList[i].score) {
                    // Swap
                    HighscoreEntry tmp = highscores.highscoreEntryList[i];
                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];
                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }



        

        highscoreEntryTransformList = new List<Transform>();
        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList) {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }

    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList) {
        float templateHeight = 25f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            case 1:
                rankString = "1st";
                break;

            case 2:
                rankString = "2nd";
                break;

            case 3:
                rankString = "3rd";
                break;

            default:
                rankString = rank + "th";
                break;
        }

        entryTransform.Find("PosText (TMP)").GetComponent<TMP_Text>().text = rankString;

        int score = highscoreEntry.score;
        entryTransform.Find("ScoreText (TMP)").GetComponent<TMP_Text>().text = score.ToString();

        string name = highscoreEntry.name;
        entryTransform.Find("NameText (TMP)").GetComponent<TMP_Text>().text = name;

        transformList.Add(entryTransform);
    }

    public static void AddHighscoreEntry(int score, string name) {
        // Create HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { score = score, name = name };

        // Load saved Highscores
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        // Add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);
        
        // Save updated Highscores
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

        /*
        highscoreEntryList = new List<HighscoreEntry> {
            new HighscoreEntry{ score = 1, name = "Unknown"}


        };

        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();*/
    }

    private class Highscores {
        public List<HighscoreEntry> highscoreEntryList;
    }

    /*
     * represents a single highscore entry
     * */
    [System.Serializable]
    private class HighscoreEntry {
        public int score;
        public string name;
    }

    public void ResetHighscoreTable() {
        // <<None>> scores
        highscoreEntryList = new List<HighscoreEntry> {
            new HighscoreEntry{ score = 0, name = "None"},
            new HighscoreEntry{ score = 0, name = "None"},
            new HighscoreEntry{ score = 0, name = "None"},
            new HighscoreEntry{ score = 0, name = "None"},
            new HighscoreEntry{ score = 0, name = "None"}
        };

        // rewrite PlayerPrefs highscoreTable with <<None>> scores
        Highscores highscores = new Highscores { highscoreEntryList = highscoreEntryList };
        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

        // destory old scores
        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {
            if (gameObj.name == "HighscoreEntryTemplate(Clone)")
            {
                Destroy(gameObj);
            }
        }

        // display the default <<None>> scores
        Awake();


    }

    public static bool CheckIfHighscore(int newScore) { 
        string jsonString = PlayerPrefs.GetString("highscoreTable");
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);

        int minI = -1;
        int minValue = Int32.MaxValue;

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++) {
            if (highscores.highscoreEntryList[i].score < minValue) {
                minValue = highscores.highscoreEntryList[i].score;
                minI = i;
            }
        }

        string json = JsonUtility.ToJson(highscores);
        PlayerPrefs.SetString("highscoreTable", json);
        PlayerPrefs.Save();

        if (newScore > highscores.highscoreEntryList[minI].score) {
            highscores.highscoreEntryList.RemoveAt(minI);

            return true;
        }

        return false;

        Debug.Log(highscores.highscoreEntryList[minI].score.ToString());
    }

}
