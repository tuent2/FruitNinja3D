using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    private int score;


    public void NewGame()
    {
        score = 0;
        scoreText.text = score.ToString();
    }
    public void IncreateScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    // Start is called before the first frame update
    void Start()
    {
        NewGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
