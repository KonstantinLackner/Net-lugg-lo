using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timeValue { get; set; }

    public Text timeText;
    
    private AudioSource source;
    
    public AudioClip ticSound;
        
    // Start is called before the first frame update
    void Start()
    {
        timeValue = 90;
        gameObject.AddComponent<AudioSource>();
        source = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        calculate();
        DisplayTime(timeValue);
    }

    void calculate()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
