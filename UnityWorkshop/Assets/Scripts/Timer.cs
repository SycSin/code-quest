using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{

    public float laptime = 0;
    public float besttime = 0;
    private bool startTimer = false;
    [SerializeField] private TextMeshProUGUI LTime;
    [SerializeField] private TextMeshProUGUI BTime;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    private bool checkpoint3 = false;
    private bool checkpoint4 = false;
    private bool checkpoint5 = false;
    private bool checkpoint6 = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            laptime = laptime + Time.deltaTime;

            LTime.text = "Laptime: " + laptime.ToString("F2");
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "FinishLine")
        {
            if (checkpoint1 == true && checkpoint2 == true && checkpoint3 == true && checkpoint4 == true &&
                checkpoint5 == true && checkpoint6 == true)
            {
                startTimer = false;

                if (besttime == 0 || laptime < besttime)
                {
                    besttime = laptime;
                    BTime.text = "Best Time: " + besttime.ToString("F2");
                }
            }
        }

        if (other.gameObject.name == "StartingLine") 
        {
                startTimer = true;
                checkpoint1 = false;
                checkpoint2 = false;
                checkpoint3 = false;
                checkpoint4 = false;
                checkpoint5 = false;
                checkpoint6 = false;
        }
        
        if (other.gameObject.name == "checkpoint1")
        {
            Debug.Log("1");
            checkpoint1 = true;
        }
        
        if (other.gameObject.name == "checkpoint2")
        {
            Debug.Log("2");
            checkpoint2 = true;
        }
        
        if (other.gameObject.name == "checkpoint3")
        {
            Debug.Log("3");
            checkpoint3 = true;
        }
        
        if (other.gameObject.name == "checkpoint4")
        {
            Debug.Log("4");
            checkpoint4 = true;
        }
        
        if (other.gameObject.name == "checkpoint5")
        {
            Debug.Log("5");
            checkpoint5 = true;
        }
        
        if (other.gameObject.name == "checkpoint6")
        {
            Debug.Log("6");
            checkpoint6 = true;
        }
       
    }
}
