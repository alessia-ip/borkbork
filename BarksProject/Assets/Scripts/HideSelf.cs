using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideSelf : MonoBehaviour
{
    public void HideMe()
    {
        this.gameObject.SetActive(false);
    }
    
}
