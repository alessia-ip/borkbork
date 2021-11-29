using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StringReader : MonoBehaviour
{
    private string fullPath;
    string filepath = "/Resources/TestSheet.csv";

    public List<string> allDialogue;

    public int lineNum = 0;

    public TestSpawn _TestSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        fullPath = Application.dataPath + filepath;
        string[] final = File.ReadAllLines(fullPath);
        Debug.Log(final[0]);
        for (int i = 1; i < final.Length; i++)
        {
            allDialogue.Add(final[i]);
        }
        
        NewLine();
        
    }

    public void NewLine()
    {
        
        var currentLine = allDialogue[lineNum];
        string[] currentLineSplit = currentLine.Split(',');
        if (currentLineSplit[0].ToUpper() == "PLAYER")
        {
            _TestSpawn.PlayerButton(currentLineSplit[1]);

            _TestSpawn.playerLineNum = int.Parse(currentLineSplit[3]) - 1;
            
            lineNum++;
            
        }
        else
        {

            Vector3 newCol = new Vector3(0, 0, 0);

            switch (currentLineSplit[0])
            {
                case "Mystic":
                    newCol = new Vector3(211, 162, 219);
                    break;
                case "UWA":
                    newCol = new Vector3(240, 169, 81);
                    break;
                case "Loveable":
                    newCol = new Vector3(109, 154, 194);
                    break;
                case "Veteran":
                    newCol = new Vector3(90, 95, 120);
                    break;
                case "Nerd":
                    newCol = new Vector3(230, 30, 213);
                    break;
                case "C.O.":
                    newCol = new Vector3(106, 158, 122);
                    break;
                case "Sniper":
                    newCol = new Vector3(53, 161, 130);
                    break;
                case "Medic":
                    newCol = new Vector3(222, 57, 20);
                    break;
                default:
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

       
        
        Invoke(nameof(NewLine), int.Parse(currentLineSplit[2]));

    }
}
