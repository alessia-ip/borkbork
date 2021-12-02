using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StringReader : MonoBehaviour
{
    private string fullPath;
    public string filepath = "A1.csv";
    private string folderPath = "/Resources/";

    public List<string> allDialogue;

    public int lineNum = 0;

    public TestSpawn _TestSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        fullPath = Application.dataPath + folderPath + filepath;
        string[] final = File.ReadAllLines(fullPath);
        Debug.Log(final[0]);
        for (int i = 1; i < final.Length; i++)
        {
            if (!final[i].Contains("///"))
            {
                allDialogue.Add(final[i]);
            }
        }
        
        NewLine();
        
    }

    public void NewLine()
    {
        
        var currentLine = allDialogue[lineNum];
        string[] currentLineSplit = currentLine.Split('|');
        if (currentLineSplit[0].ToUpper().Replace(" ", "") == "PLAYER")
        {
            _TestSpawn.PlayerButton(currentLineSplit[1], currentLineSplit[3].Replace(" ",""));

            //_TestSpawn.playerLineNum = int.Parse(currentLineSplit[3]) - 1;
            
            lineNum++;
            
        }
        else
        {

            Vector3 newCol = new Vector3(0, 0, 0);

            switch (currentLineSplit[0].ToLower())
            {
                case "mystic":
                    newCol = new Vector3(211, 162, 219);
                    break;
                case "uwa":
                    newCol = new Vector3(240, 169, 81);
                    break;
                case "oorah":
                    newCol = new Vector3(240, 169, 81);
                    break;
                case "loveable giant":
                    newCol = new Vector3(109, 154, 194);
                    break;
                case "giant":
                    newCol = new Vector3(109, 154, 194);
                    break;
                case "loveable":
                    newCol = new Vector3(109, 154, 194);
                    break;
                case "veteran":
                    newCol = new Vector3(90, 95, 120);
                    break;
                case "legacy":
                    newCol = new Vector3(90, 95, 120);
                    break;
                case "nerd":
                    newCol = new Vector3(230, 30, 213);
                    break;
                case "c.o.":
                    newCol = new Vector3(106, 158, 122);
                    break;
                case "sniper":
                    newCol = new Vector3(53, 161, 130);
                    break;
                case "medic":
                    newCol = new Vector3(222, 57, 20);
                    break;
                case "command":
                    newCol = new Vector3(255, 255, 255);
                    break;
                case "connect":
                    lineNum = 0;
                    filepath = currentLineSplit[3].ToUpper() + ".csv";
                    Debug.Log(filepath);
                    parseNew();
                    return;
                default:
                    newCol = new Vector3(255, 255, 255);
                    break;
            }

            var col = new Color(newCol.x/255.0F,newCol.y/255.0F,newCol.z/255.0F);

            _TestSpawn.SpawnNew(currentLineSplit[1], col);
            
            if (int.TryParse(currentLineSplit[3], out int result))
            {
                Debug.Log("New Line Move!" + result);
                lineNum = result;
            }
            else
            {
                lineNum++;
            }
            
        }


        if (currentLineSplit[2].Replace(" ", "") != "")
        {
            Invoke(nameof(NewLine), int.Parse(currentLineSplit[2].Replace(" ", "")));
        }
        else
        {
            Invoke(nameof(NewLine), 2);
        }
        
    }

    public void parseNew()
    {
        allDialogue.Clear();
        fullPath = Application.dataPath + folderPath + filepath;
        string[] final = File.ReadAllLines(fullPath);
        lineNum = 0; 
        for (int i = 1; i < final.Length; i++)
        {
            if (!final[i].Contains("///"))
            {
                allDialogue.Add(final[i]);
            }
        }
        
        NewLine();
    }
    
}
