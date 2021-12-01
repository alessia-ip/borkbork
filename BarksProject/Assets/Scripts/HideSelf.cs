using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSelf : MonoBehaviour
{

    public GameObject manager;
    
    private void Start()
    {
        manager = GameObject.Find("GameManager");
    }

    public void HideMe()
    {
        manager.GetComponent<TestSpawn>().SpawnPlayerText();
    }
    
}
