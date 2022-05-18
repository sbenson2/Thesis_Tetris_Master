using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_controller : MonoBehaviour
{


    [SerializeField] GameObject Insturc_man;
    [SerializeField] GameObject UI_Manager;

    public int ParticipantID;
    public bool isTesting = true;
    public int testingIndex = 0;
    public string SeqInd;
    public string LatinSqInd;

    //stuff to helf save data
    public string ConditionTracker;
    public string Block_type;
    
    //sequence from old game 
    // 1 = I
    // 2 = J
    // 3 = L
    // 4 = O 'square'
    // 5 = S
    // 6 = T 
    // 7 = Z
    //lists for the cube data
    // tetris sequences to fit into the latin square groups

    public List<int> testSeqList = new List<int>() {1, 2 ,3, 4 ,5 ,6 ,7};
    public List<int> seq1 = new List<int>() {1, 6, 1, 4, 5, 4, 1, 6, 7, 5, 7, 2, 1, 3, 5, 6, 4, 2, 2, 6, 5, 2, 6, 7, 2, 1, 6, 5, 6, 4, 3, 2, 1, 3, 2, 4, 2, 1, 3, 7, 5, 6, 2, 7, 6, 7, 4, 7, 4, 6, 2, 4, 3, 4, 5, 4, 7, 3, 5, 1, 7, 1, 3, 7, 3, 1, 3, 5, 3, 5};
    public List<int> seq2 = new List<int>() {1, 5, 6, 2, 3, 4, 6, 7, 3, 2, 3, 6, 5, 4, 6, 3, 7, 1, 4, 1, 4, 3, 7, 3, 2, 1, 3, 4, 3, 4, 1, 7, 2, 7, 4, 1, 7, 5, 3, 1, 5, 1, 7, 3, 5, 2, 4, 2, 6, 7, 4, 5, 2, 6, 7, 1, 4, 1, 5, 7, 6, 2, 6, 2, 5, 6, 5, 2, 5, 6};
    public List<int> seq3 = new List<int>() {1, 6, 4, 7, 2, 1, 7, 2, 6, 2, 5, 1, 2, 7, 1, 3, 4, 5, 7, 2, 3, 4, 5, 7, 3, 1, 3, 6, 5, 4, 2, 6, 2, 6, 2, 3, 6, 1, 2, 4, 3, 5, 4, 1, 2, 7, 3, 4, 1, 3, 1, 5, 6, 7, 4, 5, 1, 7, 4, 6, 7, 3, 3, 6, 7, 4, 5, 6, 5, 5};
    public List<int> seq4s = new List<int>() {2, 5, 1, 6, 4, 1, 5, 1, 2, 7, 6, 3, 1, 5, 3, 7, 4, 7, 6, 3, 4, 7, 3, 4, 2, 3, 1, 2, 7, 5, 2, 6, 7, 2, 6, 5, 1, 2, 5, 2, 4, 3, 7, 5, 1, 3, 5, 6, 1, 5, 7, 4, 2, 1, 6, 1, 4, 7, 3, 6, 5, 6, 2, 4, 3, 6, 7, 4, 3, 4};
    public List<int> seq5 = new List<int>() {6, 7, 2, 3, 1, 4, 1, 6, 3, 5, 6, 3, 5, 2, 3, 5, 6, 5, 1, 4, 7, 1, 3, 5, 2, 5, 7, 2, 3, 5, 7, 3, 4, 6, 3, 1, 6, 4, 5, 3, 4, 7, 6, 1, 7, 6, 1, 4, 6, 2, 4, 2, 7, 4, 2, 5, 7, 5, 2, 4, 2, 1, 4, 1, 6, 7, 3, 7, 2, 1};
    public List<int> seq6 = new List<int>() {5, 6, 5, 1, 4, 2, 5, 6, 4, 2, 4, 2, 2, 1, 3, 7, 1, 3, 6, 5, 1, 5, 4, 5, 7, 1, 3, 2, 6, 2, 6, 3, 2, 1, 4, 4, 3, 1, 2, 7, 4, 5, 4, 7, 7, 6, 5, 4, 6, 4, 7, 6, 7, 6, 7, 1, 3, 2, 6, 2, 5, 3, 1, 3, 1, 7, 5, 3, 7, 3};
    public List<int> seq7 = new List<int>() {3, 1, 5, 1, 2, 5, 7, 4, 6, 1, 5, 7, 1, 7, 6, 5, 7, 2, 6, 1, 7, 4, 7, 6, 3, 4, 2, 3, 4, 1, 6, 1, 7, 6, 3, 1, 3, 4, 1, 7, 1, 7, 3, 2, 6, 7, 4, 3, 6, 4, 6, 4, 3, 5, 6, 2, 4, 3, 2, 3, 4, 2, 5, 5, 2, 5, 2, 5, 2, 5};
    public List<int> seq8 = new List<int>() {5, 6, 5, 7, 6, 4, 2, 5, 7, 4, 5, 7, 4, 3, 5, 7, 3, 1, 6, 7, 5, 3, 6, 6, 5, 2, 3, 2, 6, 7, 5, 6, 5, 2, 3, 4, 3, 6, 5, 4, 1, 4, 2, 4, 7, 7, 3, 6, 4, 1, 3, 7, 2, 1, 4, 2, 3, 6, 3, 1, 4, 7, 1, 2, 1, 2, 1, 1, 2, 1};

    //latin square groups 
    List<int> LSgroup1 = new List<int>() {1, 2, 8, 3, 7, 4, 6, 5};
    List<int> LSgroup1R = new List<int>() {7, 4, 6, 5, 1 , 2 , 8, 3};

    List<int> LSgroup2 = new List<int>() {2, 3, 1, 4, 8, 5, 7, 6};
    List<int> LSgroup2R = new List<int>() {8, 5, 7, 6, 2, 3, 1, 4};

    List<int> LSgroup3 = new List<int>() {3, 4, 2, 5, 1, 6, 8, 7};
    List<int> LSgroup3R = new List<int>() {1, 6, 8, 7, 3, 4, 2, 5};

    List<int> LSgroup4 = new List<int>() {4, 5, 3, 6, 2, 7, 1, 8};
    List<int> LSgroup4R = new List<int>() {2, 7, 1, 8, 4, 5, 3, 6};

    List<int> LSgroup5 = new List<int>() {5, 6, 4, 7, 3, 8, 2, 1};
    List<int> LSgroup5R = new List<int>() {3, 8, 2, 1, 5, 6, 4, 7};

    List<int> LSgroup6 = new List<int>() {6, 7, 5, 8, 4, 1, 3, 2};
    List<int> LSgroup6R = new List<int>() {4, 1, 3, 2, 6, 7, 5, 8};

    List<int> LSgroup7 = new List<int>() {7, 8, 6, 1, 5, 2, 4, 3};
    List<int> LSgroup7R = new List<int>() {5, 2, 4, 3, 7, 8, 6, 1};

    List<int> LSgroup8 = new List<int>() {8, 1, 7, 2, 6, 3, 5, 4};
    List<int> LSgroup8R = new List<int>() {6, 3, 5, 4, 8, 1, 7, 2};

    public List<int> PrimaryList;

    public int whichSeq;

    public int PlayCounter = 1;

    public string firstHalf = "Up";

    [SerializeField] GameObject XRRig;
 
    public Input_manager input_manager;

    public GameObject[] movingCubes;

    public GameObject cubePrefab;

    public Cube_manager cube_manager;

    public Sequence_spawn_new_cubes sequence_spawn_new_cubes;

    public Sequence_move_down_notice sequence_move_down_notice;

    public SequenceMoveDown sequenceMoveDown;

    public CubePosData[] cubePosDataBase;

    public CubePosData currentCubePosData;

    public CubeColorData[] cubeColorDataBase;

    public CubeColorData currentCubeColorData;


    public void Awake()
    {
        

            
        // tetro 1 T
        // Config 1
        CubePosConfig tetro1Config1 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, -1, 1), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        // Config 2
        CubePosConfig tetro1Config2 = new CubePosConfig(new Vector3(0, -1, -1), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        // Config 3
        CubePosConfig tetro1Config3 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 1, -1));
        // Config 4
        CubePosConfig tetro1Config4 = new CubePosConfig(new Vector3(0, 1, 1), new Vector3(0, 1, -1), new Vector3(0, 0, 0), new Vector3(0, -1, 1));
        // Spawn pos
        Vector3[] spawnPosTetro1 = new Vector3[] { new Vector3(0, 19, 4), new Vector3(0, 18, 3), new Vector3(0, 18, 4), new Vector3(0, 18, 5)};

        CubePosData cubePosData1 = new CubePosData(tetro1Config1, tetro1Config2, tetro1Config3, tetro1Config4, spawnPosTetro1);

        CubeColorData cubeColorData1 = new CubeColorData(new Color32(255, 0, 230,0));

        // tetro 2 J
        // Config 1
        CubePosConfig tetro2Config1 = new CubePosConfig(new Vector3(0, 1, 2), new Vector3(0, 1, 2), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        // Config 2
        CubePosConfig tetro2Config2 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 2, -1), new Vector3(0, 2, -1));
        // Config 3
        CubePosConfig tetro2Config3 = new CubePosConfig(new Vector3(0, -1, -2), new Vector3(0, -1, -2), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        // Config 4
        CubePosConfig tetro2Config4 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, -2, 1), new Vector3(0, -2, 1));
        // Spawn pos
        Vector3[] spawnPosTetro2 = new Vector3[] { new Vector3(0, 19, 4), new Vector3(0, 18, 4), new Vector3(0, 18, 5), new Vector3(0, 18, 6) };

        CubePosData cubePosData2 = new CubePosData(tetro2Config1, tetro2Config2, tetro2Config3, tetro2Config4, spawnPosTetro2);

        CubeColorData cubeColorData2 = new CubeColorData(new Color(0f, 0f, 255f));

        // tetro 3 I
        // Config 1
        CubePosConfig tetro3Config1 = new CubePosConfig(new Vector3(0, 1, 1), new Vector3(0, 0, 0), new Vector3(0, -1, -1), new Vector3(0, -2, -2));
        // Config 2
        CubePosConfig tetro3Config2 = new CubePosConfig(new Vector3(0, -1, -1), new Vector3(0, 0, 0), new Vector3(0, 1, 1), new Vector3(0, 2, 2));
        // Config 3
        CubePosConfig tetro3Config3 = new CubePosConfig(new Vector3(0, 1, 1), new Vector3(0, 0, 0), new Vector3(0, -1, -1), new Vector3(0, -2, -2));
        // Config 4
        CubePosConfig tetro3Config4 = new CubePosConfig(new Vector3(0, -1, -1), new Vector3(0, 0, 0), new Vector3(0, 1, 1), new Vector3(0, 2, 2));
        // Spawn pos
        Vector3[] spawnPosTetro3 = new Vector3[] { new Vector3(0, 19, 4), new Vector3(0, 19, 5), new Vector3(0, 19, 6), new Vector3(0, 19, 7) };

        CubePosData cubePosData3 = new CubePosData(tetro3Config1, tetro3Config2, tetro3Config3, tetro3Config4, spawnPosTetro3);

        CubeColorData cubeColorData3 = new CubeColorData(new Color32(0, 255, 217,0));

        // tetro 4 Z
        // Config 1
        CubePosConfig tetro4Config1 = new CubePosConfig(new Vector3(0, 1, 2), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        // Config 2
        CubePosConfig tetro4Config2 = new CubePosConfig(new Vector3(0, 0, -1), new Vector3(0, 0, 0), new Vector3(0, 2, -1), new Vector3(0, 0, 0));
        // Config 3
        CubePosConfig tetro4Config3 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, -1, 0), new Vector3(0, -1, -2));
        // Config 4
        CubePosConfig tetro4Config4 = new CubePosConfig(new Vector3(0, -1, -1), new Vector3(0, 0, 0), new Vector3(0, -1, 1), new Vector3(0, 0, 2));
        // Spawn pos
        Vector3[] spawnPosTetro4 = new Vector3[] { new Vector3(0, 19, 4), new Vector3(0, 19, 5), new Vector3(0, 18, 5), new Vector3(0, 18, 6) };

        CubePosData cubePosData4 = new CubePosData(tetro4Config1, tetro4Config2, tetro4Config3, tetro4Config4, spawnPosTetro4);

        CubeColorData cubeColorData4 = new CubeColorData(new Color32(255, 0, 0,0));


        // tetro 5 O
        // Config 1
        CubePosConfig tetro5Config1 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        // Config 2
        CubePosConfig tetro5Config2 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        // Config 3
        CubePosConfig tetro5Config3 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        // Config 4
        CubePosConfig tetro5Config4 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 0));
        // Spawn pos
        Vector3[] spawnPosTetro5 = new Vector3[] { new Vector3(0, 19, 4), new Vector3(0, 19, 5), new Vector3(0, 18, 4), new Vector3(0, 18, 5) };

        CubePosData cubePosData5 = new CubePosData(tetro5Config1, tetro5Config2, tetro5Config3, tetro5Config4, spawnPosTetro5);

        CubeColorData cubeColorData5 = new CubeColorData(new Color32(255, 242, 0,1));

        // tetro 6 L
        // Config 1
        CubePosConfig tetro6Config1 = new CubePosConfig(new Vector3(0, 0, -1), new Vector3(0, -1, -1), new Vector3(0, 0, 0), new Vector3(0, -1, 2));
        // Config 2
        CubePosConfig tetro6Config2 = new CubePosConfig(new Vector3(0, -1, -1), new Vector3(0, 0, -1), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
        // Config 3
        CubePosConfig tetro6Config3 = new CubePosConfig(new Vector3(0, 1, 0), new Vector3(0, 2, 1), new Vector3(0, 0, 0), new Vector3(0, -1, -1));
        // Config 4
        CubePosConfig tetro6Config4 = new CubePosConfig(new Vector3(0, 0, 2), new Vector3(0, -1, 1), new Vector3(0, 0, 0), new Vector3(0, 1, -1));
        // Spawn pos
        Vector3[] spawnPosTetro6 = new Vector3[] { new Vector3(0, 19, 4), new Vector3(0, 18, 4), new Vector3(0, 18, 3), new Vector3(0, 18, 2) };

        CubePosData cubePosData6 = new CubePosData(tetro6Config1, tetro6Config2, tetro6Config3, tetro6Config4, spawnPosTetro6);

        CubeColorData cubeColorData6 = new CubeColorData(new Color32(255, 93, 0,1));

        // tetro 7 S
        // Config 1
        CubePosConfig tetro7Config1 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(0, 2, 1));
        // Config 2
        CubePosConfig tetro7Config2 = new CubePosConfig(new Vector3(0, 0, -2), new Vector3(0, 0, 0), new Vector3(0, 2, -1), new Vector3(0, 0, 1));
        // Config 3
        CubePosConfig tetro7Config3 = new CubePosConfig(new Vector3(0, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 0, -1), new Vector3(0, -2, -1));
        // Config 4
        CubePosConfig tetro7Config4 = new CubePosConfig(new Vector3(0, 0, 2), new Vector3(0, 0, 0), new Vector3(0, -2, 1), new Vector3(0, 0, -1));
        // Spawn pos
        Vector3[] spawnPosTetro7 = new Vector3[] { new Vector3(0, 19, 4), new Vector3(0, 19, 3), new Vector3(0, 18, 3), new Vector3(0, 18, 2) };

        CubePosData cubePosData7 = new CubePosData(tetro7Config1, tetro7Config2, tetro7Config3, tetro7Config4, spawnPosTetro7);

        CubeColorData cubeColorData7 = new CubeColorData(new Color32(0, 255, 0,1));



        cubePosDataBase = new CubePosData[] { cubePosData3, cubePosData2, cubePosData6, cubePosData5, cubePosData7, cubePosData1, cubePosData4 };

        cubeColorDataBase = new CubeColorData[] { cubeColorData3, cubeColorData2, cubeColorData6, cubeColorData5, cubeColorData7, cubeColorData1, cubeColorData4 };

            //1 T
            //2 J
            //3 I
            //4 Z
            //5 O
            //6 L
            //7 S

            //old 
            //1
            // I
            // J
            // L
            // O 'square'
            // S
            // T 
            // Z
            //7

    }


    public void assignSeq()
    {

        PlayCounter += 1;

        if (PlayCounter == 1)
        {
            whichSeq = PrimaryList[0];
        }
                
        if (PlayCounter == 2)
        {
            whichSeq = PrimaryList[1];
        }

        if (PlayCounter == 3)
        {
            whichSeq = PrimaryList[2];
        }
                
        if (PlayCounter == 4)
        {
            whichSeq = PrimaryList[3];
            if (firstHalf == "Invert")
            {
                firstHalf = "Up";
            }
            else
            {
                firstHalf = "Invert";
            }


            if (ConditionTracker == "A")
            {
                ConditionTracker = "C";
            }
            else if (ConditionTracker == "C")
            {
                ConditionTracker = "A";
            }

            if (ConditionTracker == "B")
            {
                ConditionTracker = "D";
            }
            else if (ConditionTracker == "D")
            {
                ConditionTracker = "B";
            }

        }

        if (PlayCounter == 5)
        {
            whichSeq = PrimaryList[4];

        }
                
        if (PlayCounter == 6)
        {
            whichSeq = PrimaryList[5];
        }

        if (PlayCounter == 7)
        {
            whichSeq = PrimaryList[6];
        }
                
        if (PlayCounter == 8)
        {
            whichSeq = PrimaryList[7];
        }

        if (PlayCounter == 9)
        {
            UI_Manager.GetComponent<UI_manager>().displayEndScreen();
        }
    }

    public void assignGroup()
    {

        //assign the lsgroup depending on the particpant id
        if (ParticipantID == 1)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup4R);
            LatinSqInd = "4R";
        }

        if (ParticipantID == 2)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup3);
            LatinSqInd = "3";
        }

        if (ParticipantID == 3)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup1);
            LatinSqInd = "1";
        }

        if (ParticipantID == 4)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

        if (ParticipantID == 5)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup1R);
            LatinSqInd = "1R";
        }

        if (ParticipantID == 6)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup1);
            LatinSqInd = "1";
        }

        if (ParticipantID == 7)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

        if (ParticipantID == 8)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup7R);
            LatinSqInd = "7R";
        }

        if (ParticipantID == 9)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup6);
            LatinSqInd = "6";
        }

        if (ParticipantID == 10)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup2);
            LatinSqInd = "2";
        }

        if (ParticipantID == 11)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup3);
            LatinSqInd = "3";
        }

        if (ParticipantID == 12)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup6R);
            LatinSqInd = "6R";
        }

        if (ParticipantID == 13)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup8);
            LatinSqInd = "8";
        }

        if (ParticipantID == 14)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

        if (ParticipantID == 15)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup7);
            LatinSqInd = "7";
        }

        if (ParticipantID == 16)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4R);
            LatinSqInd = "4R";
        }

        if (ParticipantID == 17)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup5);
            LatinSqInd = "5";
        }

        if (ParticipantID == 18)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup3R);
            LatinSqInd = "3R";
        }

        if (ParticipantID == 19)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup4R);
            LatinSqInd = "4R";
        }

        if (ParticipantID == 20)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup1);
            LatinSqInd = "1";
        }

        //assign the lsgroup depending on the particpant id
        if (ParticipantID == 21)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup2R);
            LatinSqInd = "2R";
        }

        if (ParticipantID == 22)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4R);
            LatinSqInd = "4R";
        }

        if (ParticipantID == 23)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup5R);
            LatinSqInd = "5R";
        }

        if (ParticipantID == 24)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup5R);
            LatinSqInd = "5R";
        }

        if (ParticipantID == 25)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup6R);
            LatinSqInd = "6R";
        }

        if (ParticipantID == 26)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup6);
            LatinSqInd = "6";
        }

        if (ParticipantID == 27)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup8R);
            LatinSqInd = "8R";
        }

        if (ParticipantID == 28)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

        if (ParticipantID == 29)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup6R);
            LatinSqInd = "6R";
        }

        if (ParticipantID == 30)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup8R);
            LatinSqInd = "8R";
        }

                //assign the lsgroup depending on the particpant id
        if (ParticipantID == 31)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup8R);
            LatinSqInd = "8R";
        }

        if (ParticipantID == 32)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

        if (ParticipantID == 33)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup4R);
            LatinSqInd = "4R";
        }

        if (ParticipantID == 34)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup6);
            LatinSqInd = "6";
        }

        if (ParticipantID == 35)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup5R);
            LatinSqInd = "5R";
        }

        if (ParticipantID == 36)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup7);
            LatinSqInd = "7";
        }

        if (ParticipantID == 37)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup1R);
            LatinSqInd = "1R";
        }

        if (ParticipantID == 38)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup6R);
            LatinSqInd = "6R";
        }

        if (ParticipantID == 39)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup7R);
            LatinSqInd = "7R";
        }

        if (ParticipantID == 40)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup3R);
            LatinSqInd = "3R";
        }

                //assign the lsgroup depending on the particpant id
        if (ParticipantID == 41)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup3);
            LatinSqInd = "3";
        }

        if (ParticipantID == 42)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

        if (ParticipantID == 43)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup1);
            LatinSqInd = "1";
        }

        if (ParticipantID == 44)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup1R);
            LatinSqInd = "1R";
        }

        if (ParticipantID == 45)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup5R);
            LatinSqInd = "5R";
        }

        if (ParticipantID == 46)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4R);
            LatinSqInd = "4R";
        }

        if (ParticipantID == 47)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup5);
            LatinSqInd = "5";
        }

        if (ParticipantID == 48)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

        if (ParticipantID == 49)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup2R);
            LatinSqInd = "2R";
        }

        if (ParticipantID == 50)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup7);
            LatinSqInd = "7";
        }

                //assign the lsgroup depending on the particpant id
        if (ParticipantID == 51)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup7R);
            LatinSqInd = "7R";
        }

        if (ParticipantID == 52)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup8);
            LatinSqInd = "8";
        }

        if (ParticipantID == 53)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup4R);
            LatinSqInd = "4R";
        }

        if (ParticipantID == 54)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup3);
            LatinSqInd = "3";
        }

        if (ParticipantID == 55)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup3R);
            LatinSqInd = "3R";
        }

        if (ParticipantID == 56)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup2);
            LatinSqInd = "2";
        }

        if (ParticipantID == 57)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup2);
            LatinSqInd = "2";
        }

        if (ParticipantID == 58)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup8);
            LatinSqInd = "8";
        }

        if (ParticipantID == 59)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup8);
            LatinSqInd = "8";
        }

        if (ParticipantID == 60)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

                //assign the lsgroup depending on the particpant id
        if (ParticipantID == 61)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup4R);
            LatinSqInd = "4R";
        }

        if (ParticipantID == 62)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup2);
            LatinSqInd = "2";
        }

        if (ParticipantID == 63)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup5);
            LatinSqInd = "5";
        }

        if (ParticipantID == 64)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup7R);
            LatinSqInd = "7R";
        }

        if (ParticipantID == 65)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup2R);
            LatinSqInd = "2R";
        }

        if (ParticipantID == 66)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup6);
            LatinSqInd = "6";
        }

        if (ParticipantID == 67)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup2R);
            LatinSqInd = "2R";
        }

        if (ParticipantID == 68)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup8R);
            LatinSqInd = "8R";
        }

        if (ParticipantID == 69)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup4);
            LatinSqInd = "4";
        }

        if (ParticipantID == 70)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup7);
            LatinSqInd = "7";
        }

        
        if (ParticipantID == 71)
        {
            firstHalf = "Up";
            PrimaryList = new List<int>(LSgroup1R);
            LatinSqInd = "1R";
        }

        if (ParticipantID == 72)
        {
            firstHalf = "Invert";
            PrimaryList = new List<int>(LSgroup3R);
            LatinSqInd = "3R";
        }

        if (PlayCounter == 1)
        {
            whichSeq = PrimaryList[0];
        }
                
        if (PlayCounter == 2)
        {
            whichSeq = PrimaryList[1];
        }

        if (PlayCounter == 3)
        {
            whichSeq = PrimaryList[2];
        }
                
        if (PlayCounter == 4)
        {
            whichSeq = PrimaryList[3];
        }

        if (PlayCounter == 5)
        {
            whichSeq = PrimaryList[4];
        }
                
        if (PlayCounter == 6)
        {
            whichSeq = PrimaryList[5];
        }

        if (PlayCounter == 7)
        {
            whichSeq = PrimaryList[6];
        }
                
        if (PlayCounter == 8)
        {
            whichSeq = PrimaryList[7];
        }

        if (firstHalf == "Up" && Insturc_man.GetComponent<Insturction_manager>().GameRotation == "Not")
        {
            ConditionTracker = "A";
        }

        if (firstHalf == "Up" && Insturc_man.GetComponent<Insturction_manager>().GameRotation == "Rotated")
        {
            ConditionTracker = "B";
        }

        if (firstHalf == "Invert" && Insturc_man.GetComponent<Insturction_manager>().GameRotation == "Not")
        {
            ConditionTracker = "C";
        }

        if (firstHalf == "Invert" && Insturc_man.GetComponent<Insturction_manager>().GameRotation == "Rotated")
        {
            ConditionTracker = "D";
        }

    }


    public void Start()
    {



        input_manager.doInputEvent += moveCube;
        input_manager.rotateInputEvent += rotateCube;
        sequence_move_down_notice.cubesCantGoDownEvent += clearMovingCubeList;



    }


    public void clearMovingCubeList()
    {
        movingCubes = new GameObject[4];
    }


    public void moveCube(string direction)
    {
        if(movingCubes.Length <= 0)
        {
            return;
        }
       

        Vector3 moveVec = new Vector3(0, 0, 0);

        if(direction == "left" && cube_manager.movingCubeCanGoDirection(movingCubes, direction) == true)
        {
            moveVec.z = -1;

            //save the data
            if (GameObject.Find("Game manager").GetComponent<Cube_controller>().isTesting == false)
            {
                GameObject.Find("Game manager").GetComponent<Cube_manager>().LeftMovementCounter += 1;
            }
            
        }

        if (direction == "right" && cube_manager.movingCubeCanGoDirection(movingCubes, direction) == true)
        {
            moveVec.z = 1;

                        //save the data
            if (GameObject.Find("Game manager").GetComponent<Cube_controller>().isTesting == false)
            {
                GameObject.Find("Game manager").GetComponent<Cube_manager>().RightMovementConter += 1;
            }
            
        }

        foreach(GameObject cube in movingCubes)
        {
            cube.GetComponent<Transform>().position += moveVec;
        }
        
    }

    public void rotateCube()
    {
        if(movingCubes.Length == 0)
        {
            return;
        }

        Vector3[] movingCubesPos = new Vector3[4];
        movingCubesPos[0] = movingCubes[0].GetComponent<Transform>().position;
        movingCubesPos[1] = movingCubes[1].GetComponent<Transform>().position;
        movingCubesPos[2] = movingCubes[2].GetComponent<Transform>().position;
        movingCubesPos[3] = movingCubes[3].GetComponent<Transform>().position;

        if (cube_manager.movingCubesCanRotate(movingCubesPos, currentCubePosData) ==  true)
        {

            //save the data
            if (GameObject.Find("Game manager").GetComponent<Cube_controller>().isTesting == false)
            {
                GameObject.Find("Game manager").GetComponent<Cube_manager>().RotationConter += 1;
            }

            for (int i = 0; i < 4; i++)
            {
                movingCubes[i].GetComponent<Transform>().position += currentCubePosData.cubePosConfigs[currentCubePosData.cubePosConfigIndex].cubePositions[i];
            }

            currentCubePosData.cubePosConfigIndex = (currentCubePosData.cubePosConfigIndex + 1) % 4;

            cube_manager.upDateGrid();
        }

        else
        {
            //Debug.Log("Hypothetical position right.");
            Vector3[] hypotheticalNewPosRight = new Vector3[4];

            hypotheticalNewPosRight[0] = movingCubes[0].GetComponent<Transform>().position + new Vector3(0f, 0f, 1f);
            hypotheticalNewPosRight[1] = movingCubes[1].GetComponent<Transform>().position + new Vector3(0f, 0f, 1f);
            hypotheticalNewPosRight[2] = movingCubes[2].GetComponent<Transform>().position + new Vector3(0f, 0f, 1f);
            hypotheticalNewPosRight[3] = movingCubes[3].GetComponent<Transform>().position + new Vector3(0f, 0f, 1f);

            if (cube_manager.movingCubesCanRotate(hypotheticalNewPosRight, currentCubePosData) == true)
            {
                for (int i = 0; i < 4; i++)
                {
                    movingCubes[i].GetComponent<Transform>().position = hypotheticalNewPosRight[i];
                    movingCubes[i].GetComponent<Transform>().position += currentCubePosData.cubePosConfigs[currentCubePosData.cubePosConfigIndex].cubePositions[i];
                }

                currentCubePosData.cubePosConfigIndex = (currentCubePosData.cubePosConfigIndex + 1) % 4;

                cube_manager.upDateGrid();
            }

            else
            {
                //Debug.Log("Hypothetical position left.");
                Vector3[] hypotheticalNewPosLeft = new Vector3[4];

                hypotheticalNewPosLeft[0] = movingCubes[0].GetComponent<Transform>().position + new Vector3(0f, 0f, -1f);
                hypotheticalNewPosLeft[1] = movingCubes[1].GetComponent<Transform>().position + new Vector3(0f, 0f, -1f);
                hypotheticalNewPosLeft[2] = movingCubes[2].GetComponent<Transform>().position + new Vector3(0f, 0f, -1f);
                hypotheticalNewPosLeft[3] = movingCubes[3].GetComponent<Transform>().position + new Vector3(0f, 0f, -1f);

                if (cube_manager.movingCubesCanRotate(hypotheticalNewPosLeft, currentCubePosData) == true)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        movingCubes[i].GetComponent<Transform>().position = hypotheticalNewPosLeft[i];
                        movingCubes[i].GetComponent<Transform>().position += currentCubePosData.cubePosConfigs[currentCubePosData.cubePosConfigIndex].cubePositions[i];
                    }

                    currentCubePosData.cubePosConfigIndex = (currentCubePosData.cubePosConfigIndex + 1) % 4;

                    cube_manager.upDateGrid();
                }
            }

        }
    }

    //labels the blocks for saving
    void blockLabe(int num)
    {

        if (num == 0)
        {
            Block_type = "I";
        }

        if (num == 1)
        {
            Block_type = "J";
        }

        if (num == 2)
        {
            Block_type = "L";
        }

        if (num == 3)
        {
            Block_type = "O";
        }

        if (num == 4)
        {
            Block_type = "S";
        }

        if (num == 5)
        {
            
            Block_type = "T";
        }

        if (num == 6)
        {
            Block_type = "Z";
        }


    }



    //here is where to inject the cube data from an array, depending on the sequence of the array 
    public void setNewCubesData()
    {

        //if the player is currently testing the controls
        if (isTesting == true)
        {
            //inject the desired cube into the 'rand variable', then remove it from the list
            // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
            currentCubePosData = cubePosDataBase[(testSeqList[testingIndex] - 1)];
            currentCubeColorData = cubeColorDataBase[(testSeqList[testingIndex] - 1)];

            currentCubePosData.cubePosConfigIndex = 0;
            testingIndex += 1;
        }
        else
        {
            

            if (whichSeq == 1)
            {
                int rand = seq1[0] - 1; //the original block data is off by 1, so need to minus to get the right tetromino
                
                blockLabe(rand);


                seq1.RemoveAt(0);
                
                // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
                currentCubePosData = cubePosDataBase[rand];
                currentCubeColorData = cubeColorDataBase[rand];

                currentCubePosData.cubePosConfigIndex = 0;
            }

            if (whichSeq == 2)
            {
                int rand = seq2[0] - 1; //the original block data is off by 1, so need to minus to get the right tetromino
                blockLabe(rand);
                seq2.RemoveAt(0);
                
                // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
                currentCubePosData = cubePosDataBase[rand];
                currentCubeColorData = cubeColorDataBase[rand];

                currentCubePosData.cubePosConfigIndex = 0;
            }

            if (whichSeq == 3)
            {
                int rand = seq3[0] - 1; //the original block data is off by 1, so need to minus to get the right tetromino
                blockLabe(rand);
                seq3.RemoveAt(0);
                
                // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
                currentCubePosData = cubePosDataBase[rand];
                currentCubeColorData = cubeColorDataBase[rand];

                currentCubePosData.cubePosConfigIndex = 0;
            }

            if (whichSeq == 4)
            {
                int rand = seq4s[0] - 1; //the original block data is off by 1, so need to minus to get the right tetromino
                blockLabe(rand);
                seq4s.RemoveAt(0);
                
                // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
                currentCubePosData = cubePosDataBase[rand];
                currentCubeColorData = cubeColorDataBase[rand];

                currentCubePosData.cubePosConfigIndex = 0;  
            }

            if (whichSeq == 5)
            {
                int rand = seq5[0] - 1; //the original block data is off by 1, so need to minus to get the right tetromino
                blockLabe(rand);
                seq5.RemoveAt(0);

                
                // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
                currentCubePosData = cubePosDataBase[rand];
                currentCubeColorData = cubeColorDataBase[rand];

                currentCubePosData.cubePosConfigIndex = 0;
            }

            if (whichSeq == 6)
            {
                int rand = seq6[0] - 1; //the original block data is off by 1, so need to minus to get the right tetromino
                blockLabe(rand);
                seq6.RemoveAt(0);

                
                // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
                currentCubePosData = cubePosDataBase[rand];
                currentCubeColorData = cubeColorDataBase[rand];

                currentCubePosData.cubePosConfigIndex = 0;
            }

            if (whichSeq == 7)
            {
                int rand = seq7[0] - 1; //the original block data is off by 1, so need to minus to get the right tetromino
                blockLabe(rand);
                seq7.RemoveAt(0);


                // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
                currentCubePosData = cubePosDataBase[rand];
                currentCubeColorData = cubeColorDataBase[rand];

                currentCubePosData.cubePosConfigIndex = 0;

            }

            if (whichSeq == 8) 
            {
                int rand = seq8[0] - 1; //the original block data is off by 1, so need to minus to get the right tetromino
                blockLabe(rand);
                seq8.RemoveAt(0);

                
                // REMEMBER TO ADD THE DIGIT BACK WHEN RECORDING THE DATA!!!!!
                currentCubePosData = cubePosDataBase[rand];
                currentCubeColorData = cubeColorDataBase[rand];

                currentCubePosData.cubePosConfigIndex = 0;
            }


        }
    }

    public void spawnCubes()
    {

        
        movingCubes = new GameObject[4];

        for (int i = 0; i < 4; i++)
        {
            GameObject go = (GameObject)Instantiate(cubePrefab, currentCubePosData.spawnPos[i], Quaternion.identity);

            go.GetComponent<Renderer>().material.color = currentCubeColorData.color;
            //go.GetComponent<Renderer>().material.SetFloat("_METALLICGLOSSMAP", .8f);

            movingCubes[i] = go;
        }

            
    }


}




public class CubePosData
{
    public CubePosConfig[] cubePosConfigs;

    public Vector3[] spawnPos;

    public int cubePosConfigIndex;

    public CubePosData(CubePosConfig config1, CubePosConfig config2, CubePosConfig config3, CubePosConfig config4, Vector3[] _spawnPos)
    {
        cubePosConfigs = new CubePosConfig[] { config1, config2, config3, config4 };

        spawnPos = _spawnPos;

        cubePosConfigIndex = 0;

    }
}

public class CubeColorData
{
    public Color32 color;

    public CubeColorData(Color32 _color)
    {
        color = _color;
    }
}

public class CubePosConfig
{
    public Vector3[] cubePositions;

    public CubePosConfig(Vector3 pos1, Vector3 pos2, Vector3 pos3, Vector3 pos4)
    {
        cubePositions = new Vector3[] { pos1, pos2, pos3, pos4 };
    }
}
