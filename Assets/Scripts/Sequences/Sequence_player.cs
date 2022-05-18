using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_player : MonoBehaviour
{
    public Sequence currentSequence;

    public SequenceMoveDown moveDownSequence;

    public Sequence_move_down_notice sequence_move_down_notice;

    public Sequence_change_color changeColorSequence;

    public Sequence_delete_line sequence_delete_line;

    public Sequence_move_everything_down sequence_move_everything_down;

    public Sequence_spawn_new_cubes sequence_spawn_new_cubes;

    public Sequence_game_over sequence_game_over;

    public delegate void StartGameDelegate();

    public StartGameDelegate startGameEvent;


    public void startGameTetris()
    {
        StartCoroutine(playSequenceCoroutine());
        Debug.Log("Start game");
        startGameEvent();
    }

    public void playSequence()
    {
        currentSequence.play();
    }

    public IEnumerator playSequenceCoroutine()
    {
        while(true && currentSequence!= null)
        {
            yield return new WaitForSeconds(.4f);

            playSequence();
        }
    }




}
