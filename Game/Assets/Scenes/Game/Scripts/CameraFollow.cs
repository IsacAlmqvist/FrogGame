using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CameraFollow : MonoBehaviour
{

    public Transform player;
    public float offset = 0f;
    public float smoothSpeed = 0.5f;
    private float minY;
    public int score = 0;
    public TMP_Text scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreText.text = "" + score;
        minY = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        if(player == null) {
            Debug.Log("No player :(");
        }

        float targetY = Math.Max(minY, player.position.y + offset);
        Vector3 desiredPos = new Vector3(0, targetY, -10);
        transform.position = Vector3.Lerp(transform.position, desiredPos, smoothSpeed); 

        minY = transform.position.y;

        if(player.position.y < (transform.position.y -5)) {
            PlayerPrefs.SetInt("Score", score);
            SceneManager.LoadScene("Score");
        }

        score = (int) minY * 20;
        scoreText.text = "" + score;
    }
}
