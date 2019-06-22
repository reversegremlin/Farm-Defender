using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseScore : MonoBehaviour
{
    private TMP_Text baseLife;

    void Awake()
    {
        baseLife = GetComponent<TMP_Text>();
    }

    public void SetHealth(int health)
    {
        baseLife.text = health.ToString();
    }
}
