using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.UI;

public class TestSpawn : MonoBehaviour
{

    public GameObject canv;
    public GameObject npcPrefab;
    public GameObject playerPrefab;

    public GameObject npcStartPos;
    public GameObject playerStartPos;
    
    public List<GameObject> allDialogue;

    public int spawnTime = 5;

    public GameObject playerBut;
    public int playerLineNum;
    public StringReader _str;
    
    // Start is called before the first frame update

    public void SpawnNew(string newLine, Color bgCol)
    {
        if (allDialogue.Count > 0)
        {
            for(int i = 0; i < allDialogue.Count; i++)
            {
                var newPos = allDialogue[i].GetComponent<RectTransform>().localPosition + new Vector3(0, 110, 0);
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
        newBox.transform.SetParent(canv.transform, false); 
        newBox.GetComponent<RectTransform>().anchoredPosition = npcStartPos.GetComponent<RectTransform>().localPosition;
        allDialogue.Add(newBox);
   
        
       // Invoke(nameof(SpawnNew), spawnTime);
        
    }

    public void SpawnPlayerText()
    {
        
        if (allDialogue.Count > 0)
        {
            for(int i = 0; i < allDialogue.Count; i++)
            {
                var newPos = allDialogue[i].GetComponent<RectTransform>().localPosition + new Vector3(0, 110, 0);
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

        if (playerLineNum != -1)
        {
            _str.lineNum = playerLineNum;
        }

        playerBut.SetActive(false);
    }
    
    public void PlayerButton(string PlayerText)
    {
        playerBut.SetActive(true);
        playerBut.GetComponentInChildren<TMP_Text>().text = PlayerText;
    }
    
}
