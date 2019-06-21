using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] Text scoreText;

    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score.ToString();
        print("score: " + score);

    }

    public void ScoreHit(int enemyValue)
    {
        score = score + enemyValue;
        print(score);
        scoreText.text = score.ToString();
    }
}
