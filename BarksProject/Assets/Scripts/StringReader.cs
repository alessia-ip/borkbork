using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Serialization;

public class StringReader : MonoBehaviour
{
    private string fullPath;
    public string filepath = "A1.csv";
    private string folderPath = "/Resources/";

    public List<string> allDialogue;

    public int lineNum = 0;

    public TestSpawn _TestSpawn;


    public AudioClip mysticAud;
    [FormerlySerializedAs("veteranAud")] public AudioClip legacyAud;
    public AudioClip giantAud;
    public AudioClip coAud;
    public AudioClip sniperAud;
    public AudioClip medicAud;
    public AudioClip nerdAud;
    public AudioClip uwaAud;
    public AudioClip defaultAud;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
        
        /*fullPath = Application.dataPath + folderPath + filepath;
        string[] final = File.ReadAllLines(fullPath);
        Debug.Log(final[0]);*/
        
        TextAsset txt = Resources.Load<TextAsset>(filepath);
        string[] final = txt.text.Split('\n');

        for (int i = 1; i < final.Length; i++)
        {
            if (!final[i].Contains("///"))
            {
                allDialogue.Add(final[i]);
            }
        }
        
        Invoke(nameof(NewLine), 1.5f);
        
    }

    public void NewLine()
    {
        var currentLine = allDialogue[lineNum];
        string[] currentLineSplit = currentLine.Split('|');
        if (currentLineSplit[0].ToUpper().Replace(" ", "") == "PLAYER")
        {
            int timerVal = 0;
            var timerInt = int.TryParse(currentLineSplit[2], out int result);
            
            if (timerInt)
            {
                timerVal = int.Parse(currentLineSplit[2]);
            }
            else
            {
                timerVal = 10;
            }
            
            _TestSpawn.PlayerButton(currentLineSplit[1], 
                currentLineSplit[3].Replace(" ",""),
                timerVal
            );

            //_TestSpawn.playerLineNum = int.Parse(currentLineSplit[3]) - 1;
            
            lineNum++;
            
        }
        else
        {

            Vector3 newCol = new Vector3(0, 0, 0);
            AudioClip newCharClip = defaultAud;
            var cName = "";

            switch (currentLineSplit[0].ToLower())
            {
                case "mystic":
                    newCol = new Vector3(211, 162, 219);
                    newCharClip = mysticAud;
                    cName = "Cardinal";
                    break;
                case "uwa":
                    newCol = new Vector3(240, 169, 81);
                    newCharClip = uwaAud;
                    cName = "Tomato";
                    break;
                case "oorah":
                    newCol = new Vector3(240, 169, 81);
                    newCharClip = uwaAud;
                    cName = "Tomato";
                    break;
                case "uwa~!":
                    newCol = new Vector3(240, 169, 81);
                    newCharClip = uwaAud;
                    cName = "Tomato";
                    break;
                case "loveable giant":
                    newCol = new Vector3(109, 154, 194);
                    newCharClip = giantAud;
                    cName = "Carmine";
                    break;
                case "the loveable giant":
                    newCol = new Vector3(109, 154, 194);
                    newCharClip = giantAud;
                    cName = "Carmine";
                    break;
                case "giant":
                    newCol = new Vector3(109, 154, 194);
                    newCharClip = giantAud;
                    cName = "Carmine";
                    break;
                case "loveable":
                    newCol = new Vector3(109, 154, 194);
                    newCharClip = giantAud;
                    cName = "Carmine";
                    break;
                case "legacy":
                    newCol = new Vector3(90, 95, 120);
                    newCharClip = legacyAud;
                    cName = "Tyrian";
                    break;
                case "legacy soldier":
                    newCol = new Vector3(90, 95, 120);
                    newCharClip = legacyAud;
                    cName = "Tyrian";
                    break;
                case "nerd":
                    newCol = new Vector3(230, 30, 213);
                    newCharClip = nerdAud;
                    cName = "Turkey";
                    break;
                case "c.o.":
                    newCol = new Vector3(200, 204, 171);
                    newCharClip = coAud;
                    cName = "Crimson";
                    break;
                case "sniper":
                    newCol = new Vector3(53, 161, 130);
                    newCharClip = sniperAud;
                    cName = "Scarlet";
                    break;
                case "aloof":
                    newCol = new Vector3(53, 161, 130);
                    newCharClip = sniperAud;
                    cName = "Scarlet";
                    break;
                case "aloof sniper":
                    newCol = new Vector3(53, 161, 130);
                    newCharClip = sniperAud;
                    cName = "Scarlet";
                    break;
                case "medic":
                    newCol = new Vector3(222, 57, 20);
                    newCharClip = medicAud;
                    cName = "Sanguine";
                    break;
                case "veteran":
                    newCol = new Vector3(222, 57, 20);
                    newCharClip = medicAud;
                    cName = "Sanguine";
                    break;
                case "command":
                    newCol = new Vector3(255, 255, 255);
                    newCharClip = defaultAud;
                    break;
                case "connect":
                    lineNum = 0;
                    filepath = currentLineSplit[3].ToUpper();
                    Debug.Log(filepath);
                    parseNew();
                    return;
                default:
                    newCol = new Vector3(255, 255, 255);
                    break;
            }

            var col = new Color(newCol.x/255.0F,newCol.y/255.0F,newCol.z/255.0F);

            _TestSpawn.SpawnNew(currentLineSplit[1], col, newCharClip, cName);
            
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


        if (currentLineSplit[2].Replace(" ", "") != "" && 
            currentLineSplit[0].ToUpper().Replace(" ", "") != "PLAYER")
        {
            Invoke(nameof(NewLine), int.Parse(currentLineSplit[2].Replace(" ", "")));
        } else if (currentLineSplit[0].ToUpper().Replace(" ", "") == "PLAYER")
        {
            Invoke(nameof(NewLine), 0.4f);
        }
        else
        {
            Invoke(nameof(NewLine), 1.5f);
        }
        
    }

    public void parseNew()
    {
        allDialogue.Clear();
        /*fullPath = Application.dataPath + folderPath + filepath;
        string[] final = File.ReadAllLines(fullPath);*/
        
        TextAsset txt = Resources.Load<TextAsset>(filepath);
        string[] final = txt.text.Split('\n');
        
        lineNum = 0; 
        for (int i = 1; i < final.Length; i++)
        {
            if (!final[i].Contains("///"))
            {
                allDialogue.Add(final[i]);
            }
        }
        
        Invoke(nameof(NewLine), 2);
    }
    
}
