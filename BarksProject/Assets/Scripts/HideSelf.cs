using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HideSelf : MonoBehaviour
{

    //this is strictly used on the player input buttons
    
    public GameObject manager;

    public Image TimerFill;

    public float amountOfTime;
    public int amountOfTotalTime = 10 ;

    public string nextBlock;

    public GameObject bodyText;
    public GameObject promptText;
    
    
    private void Start()
    {
        //we grab the game manager in the scene, since this object will always be spawned from a prefab
        manager = GameObject.Find("GameManager");
        //we also set the amount of time this button is active for, as dictated by the excel input OR default time
        amountOfTime = amountOfTotalTime;
    }

    public void HideMe()
    {
        //we execute the spawn text comment
        //this command also gets rid of the button after in another script
        manager.GetComponent<TestSpawn>().playerBut = this.gameObject;
        manager.GetComponent<TestSpawn>().SpawnPlayerText();

        //next block can be assigned when the button is spawned
        //if it's blank, the choice is for the player's benefit
        //if it has text, we jump to a new story block
        if (nextBlock != "")
        {
            manager.GetComponent<StringReader>().filepath = nextBlock;
            manager.GetComponent<StringReader>().CancelInvoke("NewLine");
            manager.GetComponent<StringReader>().parseNew();
        }
        
    }

    private void Update()
    {
        //if the timer runs out of time, we want to turn the button off, and we do all that in update
        
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
