using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestSpawn : MonoBehaviour
{

    //test spawn became the actual spawn file
    //i also added a music tidbit to TW_Multistrings asset so that we got the beeping SFX
    
    
    public GameObject canv;
    public GameObject npcPrefab;
    public GameObject playerPrefab;
    public GameObject playerButtonPrefab;

    public GameObject npcStartPos;
    public GameObject playerStartPos;
    
    public List<GameObject> allDialogue;

    public int spawnTime = 5;

    public GameObject playerBut;
    public int playerLineNum;
    public StringReader _str;
    
   
//This is called to spawn new NPC text
//we get all the info we need when we call the function
    public void SpawnNew(string newLine, Color bgCol, AudioClip clip, string charName)
    {
        
        //we have to bump all the other dialogue up the screen, and delete anything off screen to avoid lag
        if (allDialogue.Count > 0)
        {
            for(int i = 0; i < allDialogue.Count; i++)
            {
                var newPos = allDialogue[i].GetComponent<RectTransform>().localPosition + new Vector3(0, 160, 0);
                allDialogue[i].GetComponent<RectTransform>().localPosition = newPos;
            }

            if (allDialogue.Count > 10)
            {
                var TBD = allDialogue[0];
                allDialogue.RemoveAt(0);
                Destroy(TBD);
            }
        }
        
        //now we instantiate the new text!
        //we also prepend the character's name to the front
        //and we change the text box color
        var newBox = Instantiate(npcPrefab);
        newBox.GetComponent<Image>().color = bgCol;

        var newText = "";
        if (charName.Replace(" ", "") != "")
        {
            //this is just some text formatting. 
            newText = "<b>" + charName + "</b>" + ": " + newLine;
        }
        else
        {
            newText = newLine;
        }
        newBox.GetComponentInChildren<TMP_Text>().text = newText;

        newBox.GetComponentInChildren<TW_MultiStrings_RandomPointer>().audClip = clip;

        /*var child = newBox.transform.GetChild(0);
        child.transform.GetChild(0).GetComponent<TMP_Text>().text = charName;*/
        
        //we do some funny position stuff so it shows up in the right spot
        newBox.transform.SetParent(canv.transform, false); 
        newBox.GetComponent<RectTransform>().anchoredPosition = npcStartPos.GetComponent<RectTransform>().localPosition;
        
        //newBox.GetComponent<AudioSource>().PlayOneShot(clip);
        //old audio input
        allDialogue.Add(newBox);
   
        
       // Invoke(nameof(SpawnNew), spawnTime);
        
    }

    //spawn player text works pretty similar to spawn NPC text - just it happens when pressing the button. 
    public void SpawnPlayerText()
    {
        
        if (allDialogue.Count > 0)
        {
            for(int i = 0; i < allDialogue.Count; i++)
            {
                var newPos = allDialogue[i].GetComponent<RectTransform>().localPosition + new Vector3(0, 160, 0);
                allDialogue[i].GetComponent<RectTransform>().localPosition = newPos;
            }

            if (allDialogue.Count > 10)
            {
                var TBD = allDialogue[0];
                allDialogue.RemoveAt(0);
                Destroy(TBD);
            }
        }
        
        var newBox = Instantiate(playerPrefab);
        newBox.GetComponentInChildren<TMP_Text>().text = "<b>Cinnabar:</b> " + playerBut.GetComponentInChildren<TMP_Text>().text;
        newBox.transform.SetParent(canv.transform, false);
        newBox.GetComponent<RectTransform>().anchoredPosition = playerStartPos.GetComponent<RectTransform>().localPosition;
        allDialogue.Add(newBox);

        ButtonRemoval();
        //playerBut.SetActive(false);
        
    }
    
    public void PlayerButton(string PlayerText, string NewBlock, float timerAmt)
    {
        
        if (allDialogue.Count > 0)
        {
            for(int i = 0; i < allDialogue.Count; i++)
            {
                var newPos = allDialogue[i].GetComponent<RectTransform>().localPosition + new Vector3(0, 160, 0);
                allDialogue[i].GetComponent<RectTransform>().localPosition = newPos;
            }

            if (allDialogue.Count > 10)
            {
                var TBD = allDialogue[0];
                allDialogue.RemoveAt(0);
                Destroy(TBD);
            }
        }
        
        //playerBut.SetActive(true);
        var newButton = Instantiate(playerButtonPrefab);
        newButton.GetComponentInChildren<TMP_Text>().text = PlayerText;
        newButton.GetComponent<HideSelf>().nextBlock = NewBlock;
        newButton.GetComponent<HideSelf>().amountOfTotalTime = (int)timerAmt;
        newButton.GetComponent<HideSelf>().amountOfTime = timerAmt;
        newButton.transform.SetParent(canv.transform, false);
        newButton.GetComponent<RectTransform>().anchoredPosition = playerStartPos.GetComponent<RectTransform>().localPosition;
        allDialogue.Add(newButton);
        playerBut = newButton;
        
    }
    
    public void ButtonRemoval()
    {
        
        int NULLSPOT = 0;
        
        for (int i = 0; i < allDialogue.Count; i++)
        {
            if (allDialogue[i] == playerBut)
            {
                NULLSPOT = i;
                allDialogue.RemoveAt(i);
            }
        }
        
        Destroy(playerBut);
        
        for (int i = 0; i < NULLSPOT; i++)
        { 
            var newPos = allDialogue[i].GetComponent<RectTransform>().localPosition - new Vector3(0, 160, 0);
            allDialogue[i].GetComponent<RectTransform>().localPosition = newPos;
        }

        
        
    }
    
}
