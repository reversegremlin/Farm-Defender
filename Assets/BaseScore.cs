using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseScore : MonoBehaviour
{
    private TMP_Text m_TextComponent;

    void Awake()
    {
        // Get a reference to the text component.
        m_TextComponent = GetComponent<TMP_Text>();

        // Change the text
        m_TextComponent.text = "A simple line of text.";
    }

    public void SetHealth(int health)
    {
        m_TextComponent.text = health.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
