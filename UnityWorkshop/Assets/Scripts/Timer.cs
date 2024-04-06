using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{

    public float laptime;
    private bool startTimer = false;
    [SerializeField] private TextMeshProUGUI LTime;
    private bool checkpoint1 = false;
    private bool checkpoint2 = false;
    
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
        if (other.gameObject.name == "StartingLine")
        {
            if (checkpoint1 == true && checkpoint2 == true)
            {
                startTimer = false;    
            }
            else
            {
                startTimer = true;
                checkpoint1 = false;
                checkpoint2 = false;
            }
            
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
    }
}
