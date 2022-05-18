using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_move_down_notice : Sequence
{
    public GameObject[] movingCubes;

    public Cube_manager cube_manager;

    public delegate void CubesCantGoDownDelegate();
    public CubesCantGoDownDelegate cubesCantGoDownEvent;

    public override void play()
    {
        //Debug.Log("Move down notice.");

        getCubes();

        if (cube_manager.movingCubeCanGoDirection(movingCubes, "down") == true)
        {
            moveCubes();

            if (cube_manager.movingCubeCanGoDirection(movingCubes, "down") == false)
            {
                cubesCantGoDownEvent();
                cube_manager.turnMovingCubesIntoCubes(movingCubes);
                cube_manager.upDatecubesOfCompleteLines();

                // if lines are completed, color them
                if (cube_manager.cubesOfCompleteLines.Count > 0)
                {
                    sequence_player.changeColorSequence.cubesToColor = cube_manager.cubesOfCompleteLines;

                    sequence_player.currentSequence = sequence_player.changeColorSequence;
                }

                // if no lines are completed, spawn new cubes
                else
                {
                    sequence_player.currentSequence = sequence_player.sequence_spawn_new_cubes;
                }
            }

            else
            {
                sequence_player.currentSequence = sequence_player.moveDownSequence;
            }
        }

        else
        {
            cubesCantGoDownEvent();
            cube_manager.turnMovingCubesIntoCubes(movingCubes);
            cube_manager.upDatecubesOfCompleteLines();

            // if lines are completed, color them
            if (cube_manager.cubesOfCompleteLines.Count > 0)
            {
                sequence_player.changeColorSequence.cubesToColor = cube_manager.cubesOfCompleteLines;

                sequence_player.currentSequence = sequence_player.changeColorSequence;
            }

            // if no lines are completed, spawn new cubes
            else
            {
                sequence_player.currentSequence = sequence_player.sequence_spawn_new_cubes;
            }
        }
    }

    public void getCubes()
    {
        movingCubes = GameObject.FindGameObjectsWithTag("Moving cube");
    }

    public void moveCubes()
    {
        foreach (GameObject cube in movingCubes)
        {
            cube.GetComponent<Transform>().position = cube.GetComponent<Transform>().position + new Vector3(0f, -1f, 0f);
        }
    }
}
