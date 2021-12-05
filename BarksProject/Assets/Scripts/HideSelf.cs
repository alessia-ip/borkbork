using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HideSelf : MonoBehaviour
{

    public GameObject manager;

    public Image TimerFill;

    public float amountOfTime;
    public int amountOfTotalTime = 10 ;

    public string nextBlock;

    public GameObject bodyText;
    public GameObject promptText;
    
    private void Start()
    {
        manager = GameObject.Find("GameManager");
        amountOfTime = amountOfTotalTime;
    }

    public void HideMe()
    {
        manager.GetComponent<TestSpawn>().playerBut = this.gameObject;
        manager.GetComponent<TestSpawn>().SpawnPlayerText();

        if (nextBlock != "")
        {
            manager.GetComponent<StringReader>().filepath = nextBlock + ".csv";
            manager.GetComponent<StringReader>().CancelInvoke("NewLine");
            manager.GetComponent<StringReader>().parseNew();
        }
        
    }

    private void Update()
    {
        
        if (amountOfTotalTime != 0)
        {
            amountOfTime = amountOfTime - Time.deltaTime;
            TimerFill.fillAmount = amountOfTime / amountOfTotalTime;
        }

        if (amountOfTime <= 0)
        {
            this.GetComponent<Button>().interactable = false;
            bodyText.GetComponent<TMP_Text>().fontStyle = FontStyles.Strikethrough;
            promptText.GetComponent<TMP_Text>().text = "Message not sent.";
        }
        
    }
}
