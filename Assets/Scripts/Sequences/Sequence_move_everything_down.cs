using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_move_everything_down : Sequence
{
    public Cube_manager cube_manager;

    public override void play()
    {
        Debug.Log("Move everything down.");
        cube_manager.moveAllCubes(cube_manager.firstEmptyLine());
        sequence_player.currentSequence = sequence_player.sequence_spawn_new_cubes;
    }
}
