using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_manager : MonoBehaviour
{

    public Cube_manager cube_man;

    public Text scoreText;

    public Score_manager scoreManager;

    public Canvas startScreenCanvas;

    public Canvas InstructionScreenCanvas;

    public Canvas InstructionScreenRCanvas;

    public Canvas InBetweenScreenCanvas;

    public GameObject InBetweenScreen;

    public GameObject InBetweenScreenR;

    public Canvas InBetweenScreenCanvasR;

    public Canvas afterPracticeCanvas;

    public Canvas afterPracticeCanvasR;

    public Button startScreenButton;

    public Button gameOverScreenButton;

    public Text finalScoreText;

    public Canvas InstructionHalfScreen;

    public Canvas InstructionHalfScreenR;

    public Canvas gameOverScreenCanvas;

    public Canvas UpEndScreen;
    public Canvas DownEndScreen;

    public Sequence_player sequence_player;

    public Sequence_game_over sequenceGameOver;

    public Game_launcher gameLauncher;

    public Sequence_spawn_new_cubes spawnshit;

    public bool breakswitch = false;

    public void Start()
    {
        scoreManager.updateScoreEvent += updateScoreText;
        sequence_player.startGameEvent += disableStartScreen;
        sequenceGameOver.gameOverEvent += displayGameOverScreen;
        sequenceGameOver.gameOverEvent += upDateFinalScore;
        //startScreenCanvas.enabled = false;
        afterPracticeCanvas.enabled = false;
        afterPracticeCanvasR.enabled = false;
        InBetweenScreenCanvas.enabled = false;
        InBetweenScreenCanvasR.enabled = false;
        InstructionScreenCanvas.enabled = false;
        InstructionScreenRCanvas.enabled = false;
        InstructionHalfScreen.enabled = false;
        InstructionHalfScreenR.enabled = false;
        UpEndScreen.enabled = false;
        DownEndScreen.enabled = false;

    }

    public void updateScoreText(int scoreToDisplay)
    {
        scoreText.text = ""+scoreToDisplay;
    }


    public void displayEndScreen()
    {
        sequence_player.currentSequence = sequence_player.sequence_game_over;
        afterPracticeCanvas.enabled = false;
        afterPracticeCanvasR.enabled = false;
        InBetweenScreenCanvas.enabled = false;
        InBetweenScreenCanvasR.enabled = false;
        InstructionScreenCanvas.enabled = false;
        InstructionScreenRCanvas.enabled = false;
        InstructionHalfScreen.enabled = false;
        InstructionHalfScreenR.enabled = false;
        UpEndScreen.enabled = true;
        DownEndScreen.enabled = true;
        
    }


    public void displayAfterPractice()
    {
        afterPracticeCanvas.enabled = true;
        GameObject.Find("Game manager").GetComponent<Input_manager>().InputOff();
    }

    public void displayAfterPracticeR()
    {
        afterPracticeCanvasR.enabled = true;
        GameObject.Find("Game manager").GetComponent<Input_manager>().InputOff();
    }

    public void displayInstructionHalfSceen()
    {
        if (GameObject.Find("Game manager").GetComponent<Cube_controller>().firstHalf == "Invert")
        {
            InstructionHalfScreenR.enabled = true;
            
        }
        else
        {
            InstructionHalfScreen.enabled = true;
        }
    }


        public void disableInstructionHalfSceen()
    {
        if (GameObject.Find("Game manager").GetComponent<Cube_controller>().firstHalf == "Invert")
        {
            InstructionHalfScreenR.enabled = false;
            
        }
        else
        {
            InstructionHalfScreen.enabled = false;
        }
    }


    //this was hijacked for the screen inbetween tetris games, the 1 minute break screen
    public void displayGameOverScreen()
    {
        if (breakswitch == false)
        {
            breakswitch = true;
            //this is constantly running make sure to turn off the spawning
            if (GameObject.Find("Game manager").GetComponent<Cube_controller>().firstHalf == "Invert")
            {
                InBetweenScreenCanvasR.enabled = true;
                InBetweenScreenR.GetComponent<Inbetween_screen>().timestart();
                
            }
            else
            {
                InBetweenScreenCanvas.enabled = true;
                InBetweenScreen.GetComponent<Inbetween_screen>().timestart();
            }
        }

    }

    public void disableGameOverScreen()
    {
        if (GameObject.Find("Game manager").GetComponent<Cube_controller>().firstHalf == "Invert")
        {
            InBetweenScreenCanvasR.enabled = false;
            breakswitch = false;
            
            sequence_player.currentSequence = sequence_player.sequence_spawn_new_cubes;
            cube_man.getAllCubes();
            cube_man.deleteCubes(cube_man.allCubestoDelete);
            spawnshit.SpawnCubeFlag = true;
        }
        else
        {
            InBetweenScreenCanvas.enabled = false;
            breakswitch = false;
            sequence_player.currentSequence = sequence_player.sequence_spawn_new_cubes;
            
            cube_man.getAllCubes();
            cube_man.deleteCubes(cube_man.allCubestoDelete);
            spawnshit.SpawnCubeFlag = true;

        }
    }

    public void disableStartScreen()
    {
        
        InstructionScreenCanvas.enabled = false;

    }

    public void disableStartRScreen()
    {
        InstructionScreenRCanvas.enabled = false;
    }

    public void upDateFinalScore()
    {
        //finalScoreText.text = scoreManager.score + " points.";
    }

    



}
