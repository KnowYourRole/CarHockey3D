using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;
    

    public float timer;
    private bool canCount = true;
    private bool doOnce = false;
    public Canvas canvasRestart;

    //public ScoreScript scoreScript;
    public UiManager UiManager;


    private void Start()
    {
        timer = mainTimer;
        canvasRestart.enabled = false;
    }

    private void Update()
    {
        // if the timer is bigger than 0 then the timer will go down eg. 4,3,2,1 
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
           
        }
        // if the timer is lower than 0 then the timer will stop counting eg 3,2,1,0 
        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            //uiText.text = "000";
            UiManager.GameOver();
            canvasRestart.enabled = true;
            //enabled = false;
        }
  

    }


    /*
    void CheckForHigherScore()
    {
        
    }
    */

}
