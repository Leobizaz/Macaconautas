using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrapManager : MonoBehaviour
{
    public float scrapTotal = 0;
    public Text textRef;

    void Start()
    {
        textRef = GetComponentInChildren<Text>();
    }

   
    void Update()
    {
        
    }

    public void addScore(float value)
    {
        scrapTotal += value;
        textRef.text = scrapTotal.ToString();

    }

}
