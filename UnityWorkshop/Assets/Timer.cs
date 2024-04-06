using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float laptime;
    private bool startTimer = false;

    [SerializeField] private TextMeshProUGUI LTime;
    
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
            Debug.Log(laptime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");

        startTimer = true;
    }
}
