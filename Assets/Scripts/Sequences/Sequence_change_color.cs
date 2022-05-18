using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_change_color : Sequence
{
    public List<GameObject> cubesToColor;

    public Cube_manager cube_Manager;

    public Material materialBlue;

    public void colorCubes()
    {
        foreach(GameObject cube in cubesToColor)
        {
            cube.GetComponent<Renderer>().material = materialBlue;
        }
    }

    public override void play()
    {
        //Debug.Log("Change color");
        colorCubes();

        sequence_player.currentSequence = sequence_player.sequence_delete_line;

        // NEXT SEQUENCE => delete lines
        //sequence_player.currentSequence = ;
    }
}
