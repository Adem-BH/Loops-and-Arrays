using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Text : MonoBehaviour
{

    public float Timer;
    public TextMeshProUGUI Timee;
    public bool TimeStart = true;
    
    void Start()
    {
        
    }

 
    void Update()
    {
        if (TimeStart == true)
        {

            Timer += Time.deltaTime;

            Timee.text = Mathf.Floor(Timer).ToString();
        }
    }
}
