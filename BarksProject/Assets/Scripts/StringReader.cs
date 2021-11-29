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
            
            _TestSpawn.SpawnNew(currentLineSplit[1]);
            
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
