using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScorebBoard : MonoBehaviour
{

    int score = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int enemyValue)
    {
        score = score + enemyValue;
        print(score);
        scoreText.text = score.ToString();
    }
}
