using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sequence_spawn_new_cubes : Sequence
{
    public Cube_manager cube_manager;

    public Cube_controller cubeController;

    [SerializeField] Canvas afterPracticeCanvas;
    [SerializeField] Canvas afterPracticeCanvasR;
    [SerializeField] GameObject XrRig;
    [SerializeField] Canvas ScoreUI;
    [SerializeField] GameObject UI_man;
    public bool SpawnCubeFlag = false;
    public bool onlyFlipOnce = false;

    //used to change the spawn flag outside of this object
    public void SetSpawnFlag()
    {
        SpawnCubeFlag = true;
    }


    public void checkSpawn()
    {
        cube_manager.getAllCubes();
        cube_manager.deleteCubes(cube_manager.allCubestoDelete);
        SpawnCubeFlag = false;

        if (cubeController.PlayCounter == 4 && onlyFlipOnce == false)
        {
            onlyFlipOnce = true;
            Debug.Log("Flipped");
            XrRig.transform.Rotate(0.0f, 0.0f, 180.0f);
            XrRig.transform.Translate(new Vector3(-2f, -1f, 0f));
            ScoreUI.transform.Rotate(0.0f, 0.0f, 180.0f);
            cubeController.isTesting = true;
            cubeController.testingIndex = 0;
            GameObject.Find("UI manager").GetComponent<UI_manager>().displayInstructionHalfSceen();
            //GameObject.Find("Game manager").GetComponent<Input_manager>().InputFlip = true;
                    
        }
        else
        {
            UI_man.GetComponent<UI_manager>().displayGameOverScreen();
        }
    }

    public override void play()
    {


        //if the player is testing the gameplay controlls
        if (cubeController.isTesting == true)
        {
            
            if (cubeController.testingIndex == cubeController.testSeqList.Count)
            {
                cube_manager.getAllCubes();
                cube_manager.deleteCubes(cube_manager.allCubestoDelete);
                SpawnCubeFlag = false;

                //handle flipping the game in the correct direction if neccessary 
                if (GameObject.Find("Game manager").GetComponent<Cube_controller>().firstHalf == "Invert")
                {
                    afterPracticeCanvasR.enabled = true;
                }
                else
                {
                    afterPracticeCanvas.enabled = true;
                }

            }
        }
        
        //use this flag to stop spawning the cubes to control when the player should see them
        if (SpawnCubeFlag == true)
        {

    
            cubeController.setNewCubesData();
            cubeController.spawnCubes();
            sequence_player.currentSequence = sequence_player.moveDownSequence;
            

            //if reach ceiling => game over
            if(cube_manager.cubesSpawnedOnTopOffOtherCubes(cubeController.movingCubes) == true)
            {
               
                checkSpawn();
            }

                        //test if the first seq is out of pieces
            if (cubeController.whichSeq == 1 && cubeController.seq1.Count == 0)
            {
           
                checkSpawn();
            }

            if (cubeController.whichSeq == 2 && cubeController.seq2.Count == 0)
            {
             
                checkSpawn();
            }

            if (cubeController.whichSeq == 3 && cubeController.seq3.Count == 0)
            {
              
                checkSpawn();
            }

            if (cubeController.whichSeq == 4 && cubeController.seq4s.Count == 0)
            {
               
                checkSpawn();
            }
            
            if (cubeController.whichSeq == 5 && cubeController.seq5.Count == 0)
            {
               
                checkSpawn();
            }

            if (cubeController.whichSeq == 6 && cubeController.seq6.Count == 0)
            {
                
                checkSpawn();
            }

            if (cubeController.whichSeq == 7 && cubeController.seq7.Count == 0)
            {
                
                checkSpawn();
            }

            if (cubeController.whichSeq == 8 && cubeController.seq8.Count == 0)
            {
                
                checkSpawn();
            }

        }

        
        
        
    }
}



