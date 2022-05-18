using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_manager : MonoBehaviour
{
    public int score;

    public delegate void UpdateScoreDelegate(int scoreToDisplay);

    public UpdateScoreDelegate updateScoreEvent;

    public UpdateScoreDelegate updateFinalScoreEvent;

    public Cube_manager cubeManager;

    public Sequence_player sequencePlayer;


    public void Start()
    {
        cubeManager.deletedCubesEvent += updateScore;
        sequencePlayer.startGameEvent += resetScore;
    }

    public void updateScore(int numCubes)
    {
        if (GameObject.Find("Sequence spawn cubes").GetComponent<Sequence_spawn_new_cubes>().SpawnCubeFlag == true)
        {
            score += numCubes;
            updateScoreEvent(score);
        }

    }

    public void resetScore()
    {
        score = 0;
        updateScoreEvent(score);
    }

}
