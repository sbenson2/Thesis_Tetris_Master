using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class afterPractice : MonoBehaviour
{

    [SerializeField] Canvas afterPracticeCanvas;
    [SerializeField] Button APCButton;
    [SerializeField] Canvas afterPracticeCanvasR;
    [SerializeField] Button APCRButton;

    [SerializeField] Cube_controller cubeController;

    [SerializeField] Score_manager Score_Manager;


    private int practiceNum = 1;

    public void hidePracticeCanavs()
    {

        //handle flipping the game in the correct direction if neccessary 
        if (GameObject.Find("Game manager").GetComponent<Cube_controller>().firstHalf == "Invert")
        {
            afterPracticeCanvasR.enabled = false;
        }
        else
        {
            afterPracticeCanvas.enabled = false;
        }

        practiceNum = 0;
        APCButton.interactable = true; APCRButton.interactable=true;
        cubeController.isTesting = false;
        cubeController.testingIndex = 0;
        Score_Manager.resetScore();
    }

    public void restartPractice()
    {

        //handle flipping the game in the correct direction if neccessary 
        if (GameObject.Find("Game manager").GetComponent<Cube_controller>().firstHalf == "Invert")
        {
            afterPracticeCanvasR.enabled = false;
        }
        else
        {
            afterPracticeCanvas.enabled = false;
        }

        practiceNum += 1; // increase this score so that the player cannot practice after three trys 


        if (practiceNum > 2) 
        {
            APCButton.interactable = false; 
            APCRButton.interactable = false;
        }

        cubeController.testingIndex = 0;
        Score_Manager.resetScore();
        
    }



}
