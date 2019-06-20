using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTracker : MonoBehaviour
{
    [SerializeField] Text score;

    int enemiesKilled = 0;

    // Start is called before the first frame update
    void Start()
    {
        score.text = enemiesKilled.ToString();
    }


    public void EnemyKilled()
    {
        ++enemiesKilled;
        score.text = enemiesKilled.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
