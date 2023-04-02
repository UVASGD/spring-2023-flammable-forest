using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float currentTime;
    [SerializeField] float startTime;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Mathf.Max(currentTime - Time.deltaTime, 0);
        updateTimerTextUI();
    }

    void updateTimerTextUI(){
        int minutes = Mathf.FloorToInt(currentTime / 60F);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        string formattedTime = string.Format("{0:0}:{1:00}", minutes, seconds);
 
        timerText.text = formattedTime; 
    }

    public bool timerOver(){
        return currentTime == 0;
    }
}
