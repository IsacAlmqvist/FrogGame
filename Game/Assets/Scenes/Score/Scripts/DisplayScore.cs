using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayScore : MonoBehaviour
{

    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!PlayerPrefs.HasKey("HighScore")) {
            PlayerPrefs.SetInt("HighScore", 0);
        }
        int currentRecord = PlayerPrefs.GetInt("HighScore", 0);
        int finalScore = PlayerPrefs.GetInt("Score", 0);
        if(finalScore >= currentRecord) {
            currentRecord = finalScore;
            PlayerPrefs.SetInt("HighScore", currentRecord);
        }
        scoreText.text = "Score: " + finalScore + "\nHighscore: " + currentRecord;
        
        Invoke("DoSomething", 3f);
    }

    void DoSomething() {
        SceneManager.LoadScene("Menu");
    }
}
