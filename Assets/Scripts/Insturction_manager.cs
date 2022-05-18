using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;

public class Insturction_manager : MonoBehaviour
{

    [SerializeField] Canvas ScoreUI;
    [SerializeField] Canvas StartScreen;
    [SerializeField] Canvas instructionScreen;
    [SerializeField] Canvas instructionScreenR;
    [SerializeField] InputField Participantid;
    [SerializeField] GameObject XrRig;
    public string GameRotation = "Not";

    //which inputs should be rotated or not
    List<int> rotateList = new List<int>() {3, 8, 9, 14, 16, 17, 19, 20, 24, 25, 27, 29, 32, 33, 37, 39, 40, 41, 42, 44, 45, 49, 50,52,53,54,55,56,57,59,60,63,66,67,68,70};



    private List<string[]>rowData = new List<string[]>();

    
    public void SaveData(string Condition, string BlockType, int whichSeqq, string whichLSQ, int Tleft, int Tright, int NumRotations, int CLine, int NCLine, float TimeToComplete)
    {
        string[] rowDataTemp = new string[10];
        // You can add up the values in as many cells as you want.
        
        rowDataTemp[0] = Condition; //Condition
        rowDataTemp[1] = BlockType; //blocktype
        rowDataTemp[2] = whichSeqq.ToString();          //which seq, so grab the first element in array from primary list
        rowDataTemp[3] = whichLSQ;          //which latin sq so grab the name of the primary list
        rowDataTemp[4] = Tleft.ToString(); //number of left translations
        rowDataTemp[5] = Tright.ToString(); //number of right translations
        rowDataTemp[6] = NumRotations.ToString(); //Number of rotations
        rowDataTemp[7] = CLine.ToString(); //number of lines cleared with the block
        rowDataTemp[8] = NCLine.ToString(); //number of line complete during sequences
        rowDataTemp[9] = TimeToComplete.ToString(); //TimeToComplete
        rowData.Add(rowDataTemp);
        
        string[][] output = new string[rowData.Count][];

        for(int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int     length         = output.GetLength(0);
        string     delimiter     = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
        
        
        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }



    void Save(){

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[10];
        rowDataTemp[0] = "Condition";
        rowDataTemp[1] = "BlockType";
        rowDataTemp[2] = "FromSeq";
        rowDataTemp[3] = "LatinBalance";
        rowDataTemp[4] = "TLeft";
        rowDataTemp[5] = "TRight";
        rowDataTemp[6] = "NumRotations";
        rowDataTemp[7] = "CLine";
        rowDataTemp[8] = "NCLine";
        rowDataTemp[9] = "TimeToComplete";
        rowData.Add(rowDataTemp);

        string[][] output = new string[rowData.Count][];

        for(int i = 0; i < output.Length; i++)
        {
            output[i] = rowData[i];
        }

        int     length         = output.GetLength(0);
        string     delimiter     = ",";

        StringBuilder sb = new StringBuilder();
        
        for (int index = 0; index < length; index++)
            sb.AppendLine(string.Join(delimiter, output[index]));
        
        
        string filePath = getPath();

        StreamWriter outStream = System.IO.File.CreateText(filePath);
        outStream.WriteLine(sb);
        outStream.Close();
    }

    // Following method is used to retrive the relative path as device platform
    private string getPath(){

        string dataString = Participantid.text;

        #if UNITY_EDITOR
        return Application.dataPath +"/CSV/"+ dataString +".csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+ dataString +".csv"";
        #elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+ dataString +".csv"";
        #else
        return Application.dataPath +"/"+ dataString +".csv";
        #endif
    }



    public void hideStartScreen()
    {

        //give the participant id to the cube controller so it can know what to play
        GameObject.Find("Game manager").GetComponent<Cube_controller>().ParticipantID = int.Parse(Participantid.text);

        //SaveData();


        //rotate the game if the participant number is a certain digit
        if (rotateList.Contains(int.Parse(Participantid.text)))
        {
            XrRig.transform.Rotate(0.0f, 0.0f, 90.0f);
            GameRotation = "Rotated";
            GameObject.Find("Game manager").GetComponent<Cube_controller>().assignGroup();
            Save();
        }
        else{
                    GameObject.Find("Game manager").GetComponent<Cube_controller>().assignGroup();
        Save();
        }

        //handle flipping the game in the correct direction if neccessary 
        if (GameObject.Find("Game manager").GetComponent<Cube_controller>().firstHalf == "Invert")
        {

            XrRig.transform.Rotate(0.0f, 0.0f, 180.0f);
            XrRig.transform.Translate(new Vector3(-2f, -1f, 0f));
            ScoreUI.transform.Rotate(0.0f, 0.0f, 180.0f);

            StartScreen.enabled = false;
            instructionScreenR.enabled = true;
            GameObject.Find("Game manager").GetComponent<Input_manager>().InputFlip = true;

        }
        else
        {

            StartScreen.enabled = false;
            instructionScreen.enabled = true;
            GameObject.Find("Game manager").GetComponent<Input_manager>().InputFlip = false;
        }





    }

}


