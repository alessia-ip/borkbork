using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    
    //a short script used on all buttons in the project that link to another scene
    public string SceneName;
    
    public void GoToScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
