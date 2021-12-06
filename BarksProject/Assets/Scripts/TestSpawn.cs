using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TestSpawn : MonoBehaviour
{

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
    
    // Start is called before the first frame update

    public void SpawnNew(string newLine, Color bgCol, AudioClip clip, string charName)
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
        
        var newBox = Instantiate(npcPrefab);
        newBox.GetComponent<Image>().color = bgCol;
        newBox.GetComponentInChildren<TMP_Text>().text = newLine;

        var child = newBox.transform.GetChild(0);
        child.transform.GetChild(0).GetComponent<TMP_Text>().text = charName;
        
        newBox.transform.SetParent(canv.transform, false); 
        newBox.GetComponent<RectTransform>().anchoredPosition = npcStartPos.GetComponent<RectTransform>().localPosition;
        newBox.GetComponent<AudioSource>().PlayOneShot(clip);
        allDialogue.Add(newBox);
   
        
       // Invoke(nameof(SpawnNew), spawnTime);
        
    }

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
        newBox.GetComponentInChildren<TMP_Text>().text = playerBut.GetComponentInChildren<TMP_Text>().text;
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
