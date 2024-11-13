using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    private int score;

    private void Update()
    {
        //À Ã
        /*if (Input.GetMouseButtonDown(0))
            AddScore();*/
    }

    private void AddScore()
    {
        //score = score + 1;
        //score += 1;
        score++;
        scoreText.text = $"Score: {score}";
    }
}
