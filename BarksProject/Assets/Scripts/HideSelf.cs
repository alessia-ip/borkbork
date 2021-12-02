using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HideSelf : MonoBehaviour
{

    public GameObject manager;

    public Image TimerFill;

    public float amountOfTime;
    public int amountOfTotalTime;

    public string nextBlock;
    
    private void Start()
    {
        manager = GameObject.Find("GameManager");
    }

    public void HideMe()
    {
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
            //TimerFill.fillAmount = 
        }
        
        
        
    }
}
