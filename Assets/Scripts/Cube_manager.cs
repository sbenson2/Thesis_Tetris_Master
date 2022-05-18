using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_manager : MonoBehaviour
{
    public GameObject[,] cubeGrid;

    public delegate void CubesCantGoDownDelegate();
    public CubesCantGoDownDelegate cubesCantGoDownEvent;

    public List<GameObject> cubesOfCompleteLines;

    public List<GameObject> allCubestoDelete;

    public delegate void DeleteCubeDelegate(int numCubesDeleted);

    public DeleteCubeDelegate deletedCubesEvent;

    [SerializeField] GameObject Instruct_man;

    [SerializeField] GameObject cube_control;

    [SerializeField] Canvas InScreen;

    public int LeftMovementCounter = 0;
    public int RightMovementConter = 0;
    public int RotationConter = 0;
    public int LineCounter = 0;
    public int GameLineCounter = 0;

    public float GameTimer = 0.0f;
 
    void Update()
    {
        //save the data
        if (cube_control.GetComponent<Cube_controller>().isTesting == false)
        {
            GameTimer += Time.deltaTime;
        }

    }

    //tesnh 
    // HELPER FUNCTIONS
    public int numLinesDeleted()
    {
        int count = 0;

        for(int y = 0; y < 20; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                if(cubeGrid[x,y] == null)
                {
                    /*Debug.Log("Count = " + count);
                    Debug.Log("y = " + y);
                    Debug.Log("x = " + x);
                    Debug.Log(cubeGrid[y, x]);
                    */
                    count++;
                }

                else
                {
                    return count / 10;
                }
            }
        }

        return 0;
    }


    public int firstEmptyLine()
    {
        upDateGrid();

        bool emptyLine = true;

        for (int y = 0; y < 20; y++)
        {
            emptyLine = true;

            for (int x = 0; x < 10; x++)
            {
                if (cubeGrid[x, y] != null)
                {
                    emptyLine = false;
                }

            }

            if(emptyLine == true)
            {
                Debug.Log("First empty line index = " + y);
                return y;
            }
        }

        return 0;
    }

    // Complete line

    // current moving cube can't move
    public bool movingCubeCanGoDirection(GameObject[] movingCubes, string direction)
    {
        upDateGrid();

        // If any cube of the current tetro has a block beneath it or one of the block touched the bottom, the whole tretro stops moving
        foreach (GameObject cube in movingCubes)
        {
            int cubeYpos = (int)cube.GetComponent<Transform>().position.y;
            int cubeZpos = (int)cube.GetComponent<Transform>().position.z;

            if(direction == "down")
            {
                // Check if the cube reached the bottom
                if (cubeYpos == 0)
                {
                    return false;
                }

                // Check if there is a cube below the currently moving cube
                else if (cubeGrid[cubeZpos, cubeYpos - 1] != null)
                {
                    return false;
                }
            }

            else if(direction == "left")
            {
                // Check if the cube reached the bottom
                if (cubeZpos == 0)
                {
                    return false;
                }

                // Check if there is a cube below the currently moving cube
                else if (cubeGrid[cubeZpos-1, cubeYpos] != null)
                {
                    return false;
                }
            }

            else if (direction == "right")
            {
                // Check if the cube reached the bottom
                if (cubeZpos == 9)
                {
                    return false;
                }

                // Check if there is a cube below the currently moving cube
                else if (cubeGrid[cubeZpos + 1, cubeYpos] != null)
                {
                    return false;
                }
            }


        }

        return true;
    }

    public bool movingCubesCanRotate(Vector3[] movingCubesPos, CubePosData cubePosData)
    {
        upDateGrid();

        // Get next cube rotation position
        int rotIndex = (cubePosData.cubePosConfigIndex) % 4;

        Vector3[] nextRotPos = new Vector3[4];

        nextRotPos[0] = cubePosData.cubePosConfigs[rotIndex].cubePositions[0];
        nextRotPos[1] = cubePosData.cubePosConfigs[rotIndex].cubePositions[1];
        nextRotPos[2] = cubePosData.cubePosConfigs[rotIndex].cubePositions[2];
        nextRotPos[3] = cubePosData.cubePosConfigs[rotIndex].cubePositions[3];


        // Check if those rotation positions would land on tiles already occupied by other cubes or are out of bounds.

        for (int i = 0; i < 4; i++)
        {
            nextRotPos[i] = movingCubesPos[i] + nextRotPos[i];

            //Debug.Log("nextRotPos[i] = " + nextRotPos[i]);
        }


        foreach(Vector3 rotPos in nextRotPos)
        {
            if((rotPos.z > 19 || rotPos.z < 0 || rotPos.y > 19 || rotPos.y < 0|| cubeGrid[(int)rotPos.z, (int)rotPos.y] != null))
            {
                //Debug.Log("CAN'T ROTATE");
                return false;
            }
        }

        return true;
    }

    // Get complete lines
    public void upDatecubesOfCompleteLines()
    {
        upDateGrid();

        cubesOfCompleteLines = new List<GameObject>();

        bool completeLine = true;
        
        for (int y = 0; y < cubeGrid.Length / 10; y++)
        {
            completeLine = true;

            for (int x = 0; x < (cubeGrid.Length - 100) / 10; x++)
            {
                if(cubeGrid[x,y] == null)
                {
                    completeLine = false;
                }
            }

            if (completeLine == true)
            {
                for (int x = 0; x < (cubeGrid.Length - 100) / 10; x++)
                {
                    cubesOfCompleteLines.Add(cubeGrid[x, y]);

                }
            }
        }
        
        //this will grab the number of lines completed
        LineCounter += (cubesOfCompleteLines.Count);

    }

    //get all the cubes on the play feild to delete
    public void getAllCubes()
    {
        upDateGrid();

        allCubestoDelete = new List<GameObject>();

        for (int y = 0; y < cubeGrid.Length / 10; y++)
        {
            for (int x = 0; x < (cubeGrid.Length - 100) / 10; x++)
            {
             allCubestoDelete.Add(cubeGrid[x, y]);
            }
        }
       

    }


    public void Start()
    {
        cubeGrid = new GameObject[10,20];
    }

    public void upDateGrid()
    {
        // Clear grid
        cubeGrid = new GameObject[10, 20];

        // Get cubes
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("cube");


        // Update Grid
        foreach (GameObject cube in cubes)
        {
            Vector3 cubPos = cube.GetComponent<Transform>().position;

            cubeGrid[(int)cubPos.z, (int)cubPos.y] = cube;
        }

    }



    public void turnMovingCubesIntoCubes(GameObject[] movingCubes)
    {

        //save the data
        if (cube_control.GetComponent<Cube_controller>().isTesting == false)
        {
            Debug.Log("data saved");
            
            LineCounter = LineCounter/20;
            GameLineCounter += LineCounter;
            Instruct_man.GetComponent<Insturction_manager>().SaveData(cube_control.GetComponent<Cube_controller>().ConditionTracker, 
                                                                        cube_control.GetComponent<Cube_controller>().Block_type, 
                                                                        cube_control.GetComponent<Cube_controller>().whichSeq,
                                                                        cube_control.GetComponent<Cube_controller>().LatinSqInd,
                                                                        LeftMovementCounter, 
                                                                        RightMovementConter, 
                                                                        RotationConter, 
                                                                        LineCounter, 
                                                                        GameLineCounter, 
                                                                        GameTimer);
        
            //reset the needed data
            LeftMovementCounter = 0;
            RightMovementConter = 0;
            RotationConter = 0;
            LineCounter = 0;
        
        }
        

        foreach(GameObject cube in movingCubes)
        {
            cube.tag = "cube";
        }


    }

    public void deleteCubes(List<GameObject> cubes)
    {
        foreach(GameObject cube in cubes)
        {
            Destroy(cube);
        }

        deletedCubesEvent(cubes.Count);
    }

    public void moveAllCubes(int YindexLineToStartAt)
    {
        upDateGrid();

        GameObject[] cubesToMoveDown = GameObject.FindGameObjectsWithTag("cube");

        foreach(GameObject cube in cubesToMoveDown)
        {
            if(cube.GetComponent<Transform>().position.y > YindexLineToStartAt)
            {
                //Debug.Log("YindexLineToStartAt =" + YindexLineToStartAt);
                //Debug.Log("cube Y pos =" + cube.GetComponent<Transform>().position.y);

                //Debug.Log("num lines deleted = " + numLinesDeleted());

                cube.GetComponent<Transform>().position += new Vector3(0f, -1f, 0f) * cubesOfCompleteLines.Count/10;
            }
        }
    }



    public bool cubesSpawnedOnTopOffOtherCubes(GameObject[] cubes)
    {
        upDateGrid();

        Vector3[] cubePositions = new Vector3[4];


        
        for(int i = 0; i < 4; i++)
        {
            cubePositions[i] = cubes[i].GetComponent<Transform>().position;
        }

        bool spawnedOnTop = false;

        foreach(Vector3 cubePos in cubePositions)
        {
            if(cubeGrid[(int)cubePos.z,(int)cubePos.y] != null)
            {
                spawnedOnTop = true;
                break;
            }
        }

        return spawnedOnTop;

    }
      




}
