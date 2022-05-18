using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence_game_over : Sequence
{
    public delegate void GameOverDelegate();

    public GameOverDelegate gameOverEvent;

    public override void play()
    {
        //gameOverEvent();
    }
}
