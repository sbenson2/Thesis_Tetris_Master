using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceMoveDown : Sequence
{
    public Cube_manager cube_manager;

    public GameObject[] movingCubes;


    public override void play()
    {
        
        getCubes();

        if (cube_manager.movingCubeCanGoDirection(movingCubes, "down") == true)
        {
            moveCubes();
        }

        // There are no cubes right below the moving cubes, the moving cubes can go down one step
        if (cube_manager.movingCubeCanGoDirection(movingCubes, "down") == true)
        {
            sequence_player.currentSequence = this;
            //Debug.Log("Move Down");
        }

        // There are cubes right below the moving cubes, the moving cubes can't go down any more
       else
        {
            sequence_player.currentSequence = sequence_player.sequence_move_down_notice;
        }

        
    }


    public void getCubes()
    {
        movingCubes = GameObject.FindGameObjectsWithTag("Moving cube");
    }


    public void moveCubes()
    {

        foreach(GameObject cube in movingCubes)
        {
            cube.GetComponent<Transform>().position = cube.GetComponent<Transform>().position + new Vector3(0f, -1f, 0f);
        }
    }



}
