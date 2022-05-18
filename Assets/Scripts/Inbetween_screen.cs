using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inbetween_screen : MonoBehaviour
{

    [SerializeField] GameObject UIthing;
    [SerializeField] Text timeText;

    [SerializeField] Score_manager Score_Manager;
    [SerializeField] Cube_controller Cubething;

    float Timer = 60;
    bool TimerRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        //TimerRunning = true;
    }

    public void timestart()
    {
        Timer = 60;
        TimerRunning = true;
        GameObject.Find("Game manager").GetComponent<Input_manager>().InputOff();
    }

    // Update is called once per frame
    void Update()
    {


        if (Cubething.PlayCounter == 9 && this.enabled == true)
        {
            this.enabled = false;
            UIthing.GetComponent<UI_manager>().displayEndScreen();
        }


        //show the timer
        DispalyTime(Timer);

        if (TimerRunning)
        {
            if (Timer > 0)
            {
                Timer -= Time.deltaTime;
            }
            else
            {
                Timer = 0;
                TimerRunning = false;
                timeText.text = "00:00";
                
                //hide the 1 minute screens
                UIthing.GetComponent<UI_manager>().disableGameOverScreen();
                Cubething.GetComponent<Cube_controller>().assignSeq();
                GameObject.Find("Game manager").GetComponent<Cube_manager>().GameTimer = 0.0f;
                GameObject.Find("Game manager").GetComponent<Cube_manager>().GameLineCounter = 0;
                GameObject.Find("Game manager").GetComponent<Input_manager>().InputOn();
                Score_Manager.resetScore();



            }
        }



    }


    void DispalyTime(float timeToDisplay)
    {
        if (TimerRunning == true)
        {
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }





}
