using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
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

    private bool mysticAlive = true;
    private bool legacyAlive = true;
    private bool giantAlive = true; 
    private bool coAlive = true;
    private bool medicAlive = true;
    private bool uwaAlive = true;
    private bool sniperAlive = true;
    private bool nerdAlive = true;
    
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
                    if (!mysticAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(211, 162, 219);
                    newCharClip = mysticAud;
                    cName = "Cardinal";
                    if (filepath.Contains("X"))
                    {
                        mysticAlive = !mysticAlive;
                    }
                    break;
                case "uwa":
                    if (!uwaAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(240, 169, 81);
                    newCharClip = uwaAud;
                    cName = "Tomato";
                    if (filepath.Contains("X"))
                    {
                        uwaAlive = !uwaAlive;
                    }
                    break;
                case "oorah":
                    if (!uwaAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(240, 169, 81);
                    newCharClip = uwaAud;
                    cName = "Tomato";
                    if (filepath.Contains("X"))
                    {
                        uwaAlive = !uwaAlive;
                    }
                    break;
                case "uwa~!":
                    if (!uwaAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(240, 169, 81);
                    newCharClip = uwaAud;
                    cName = "Tomato";
                    if (filepath.Contains("X"))
                    {
                        uwaAlive = !uwaAlive;
                    }
                    break;
                case "loveable giant":
                    if (!giantAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(109, 154, 194);
                    newCharClip = giantAud;
                    cName = "Carmine";
                    if (filepath.Contains("X"))
                    {
                        giantAlive = !giantAlive;
                    }
                    break;
                case "the loveable giant":
                    if (!giantAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(109, 154, 194);
                    newCharClip = giantAud;
                    cName = "Carmine";
                    if (filepath.Contains("X"))
                    {
                        giantAlive = !giantAlive;
                    }
                    break;
                case "giant":
                    if (!giantAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(109, 154, 194);
                    newCharClip = giantAud;
                    cName = "Carmine";
                    if (filepath.Contains("X"))
                    {
                        giantAlive = !giantAlive;
                    }
                    break;
                case "loveable":
                    if (!giantAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(109, 154, 194);
                    newCharClip = giantAud;
                    cName = "Carmine";
                    if (filepath.Contains("X"))
                    {
                        giantAlive = !giantAlive;
                    }
                    break;
                case "legacy":
                    if (!legacyAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(90, 95, 120);
                    newCharClip = legacyAud;
                    cName = "Tyrian";
                    if (filepath.Contains("X"))
                    {
                        legacyAlive = !legacyAlive;
                    }
                    break;
                case "legacy soldier":
                    if (!legacyAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(90, 95, 120);
                    newCharClip = legacyAud;
                    cName = "Tyrian";
                    if (filepath.Contains("X"))
                    {
                        legacyAlive = !legacyAlive;
                    }
                    break;
                case "nerd":
                    if (!nerdAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(230, 30, 213);
                    newCharClip = nerdAud;
                    cName = "Turkey";
                    if (filepath.Contains("X"))
                    {
                        nerdAlive = !nerdAlive;
                    }
                    break;
                case "c.o.":
                    if (!coAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(200, 204, 171);
                    newCharClip = coAud;
                    cName = "Crimson";
                    if (filepath.Contains("X"))
                    {
                        coAlive = !coAlive;
                    }
                    break;
                case "sniper":
                    if (!sniperAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(53, 161, 130);
                    newCharClip = sniperAud;
                    cName = "Scarlet";
                    if (filepath.Contains("X"))
                    {
                        sniperAlive = !sniperAlive;
                    }
                    break;
                case "aloof":
                    if (!sniperAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(53, 161, 130);
                    newCharClip = sniperAud;
                    cName = "Scarlet";
                    if (filepath.Contains("X"))
                    {
                        sniperAlive = !sniperAlive;
                    }
                    break;
                case "aloof sniper":
                    if (!sniperAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(53, 161, 130);
                    newCharClip = sniperAud;
                    cName = "Scarlet";
                    if (filepath.Contains("X"))
                    {
                        sniperAlive = !sniperAlive;
                    }
                    break;
                case "medic":
                    if (!medicAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(222, 57, 20);
                    newCharClip = medicAud;
                    cName = "Sanguine";
                    if (filepath.Contains("X"))
                    {
                        medicAlive = !medicAlive;
                    }
                    break;
                case "veteran":
                    if (!sniperAlive)
                    {
                        lineNum++;
                        Invoke(nameof(NewLine), 0.1f);
                        return;
                    }
                    newCol = new Vector3(222, 57, 20);
                    newCharClip = medicAud;
                    cName = "Sanguine";
                    if (filepath.Contains("X"))
                    {
                        sniperAlive = !sniperAlive;
                    }
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
            lineNum++;
            
        }

        if (filepath.Contains("X"))
        {
            Debug.Log(lineNum + ":NUM");
            lineNum = allDialogue.Count-1;
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
            Invoke(nameof(NewLine), 2f);
        }
        
    }

    public void parseNew()
    {
        if (filepath.Contains("E"))
        {
            SceneManager.LoadScene(3);
            return;
        }
        
        if (filepath.Contains("Y"))
        {
            SceneManager.LoadScene(4);
            return;
        }
        
        
        
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

        if (filepath.Contains("X"))
        {
            for (int i = 0; i < allDialogue.Count - 1; i++)
            {
                var CheckLineChar = allDialogue[i].Split('|')[0];
                switch (CheckLineChar)
                {
                    case "mystic":
                    if (!mysticAlive)
                    {
                        allDialogue[i] = "";
                    }
                    break;
                case "uwa":
                    if (!uwaAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "oorah":
                    if (!uwaAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "uwa~!":
                    if (!uwaAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "loveable giant":
                    if (!giantAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "the loveable giant":
                    if (!giantAlive)
                    {

                        allDialogue[i] = "";
                    }
                    break;
                case "giant":
                    if (!giantAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "loveable":
                    if (!giantAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "legacy":
                    if (!legacyAlive)
                    {
                        
                        allDialogue[i] = "";
                    }
                    break;
                case "legacy soldier":
                    if (!legacyAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "nerd":
                    if (!nerdAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "c.o.":
                    if (!coAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "sniper":
                    if (!sniperAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "aloof":
                    if (!sniperAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "aloof sniper":
                    if (!sniperAlive)
                    {
                        
                        allDialogue[i] = "";
                    }
                    break;
                case "medic":
                    if (!medicAlive)
                    {
                       
                        allDialogue[i] = "";
                    }
                    break;
                case "veteran":
                    if (!sniperAlive)
                    {
                        allDialogue[i] = "";
                    }
                    break;
                }
            }

            allDialogue.RemoveAll(string.IsNullOrWhiteSpace);

            var randNum = Random.Range(0, allDialogue.Count - 2);
            lineNum = randNum;
        }
        
        Invoke(nameof(NewLine), 1);
    }
    
}
