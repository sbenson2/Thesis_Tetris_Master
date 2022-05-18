using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_delete_line : Sequence
{
    public Cube_manager cubeManager;


    public override void play()
    {

        cubeManager.upDatecubesOfCompleteLines();
        cubeManager.deleteCubes(cubeManager.cubesOfCompleteLines);
        

        sequence_player.currentSequence = sequence_player.sequence_move_everything_down;

    }

    
}
