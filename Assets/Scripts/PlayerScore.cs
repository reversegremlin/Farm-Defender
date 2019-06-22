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
    }

    public void ScoreHit(int enemyValue)
    {
        score = score + enemyValue;
        scoreText.text = score.ToString();
    }
}
