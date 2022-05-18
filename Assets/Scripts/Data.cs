using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.IO;
using System;



public class Data : MonoBehaviour
{

    //variables
    public string file;
    public int FileRowIndex = 0;
    public int fileNum = 1;
    public int PartNum = 0;
    public int Body;
    public float TLeftCon;
    public float TLeftIncon;
    public float TRightCon;
    public float TRightIncon;
    public float NumRotateCon;
    public float NumRotateIncon;
    public float NumClearLineCon;
    public float NumClearLineIncon;
    public float TimeToCompCon;
    public float TimeToComPiecewiseCon;
    public float TimeToCompIncon;
    public float TimetoCompPiecewiseIncon;
    public float OCompLineCon;
    public float OCompLineIncon;
    public float SCompLineCon;
    public float SCompLineIncon;
    public float ZCompLineCon;
    public float ZCompLineIncon;
    public float TCompLineCon;
    public float TCompLineIncon;
    public float LCompLineCon;
    public float LCompLineIncon;
    public float JCompLineCon;
    public float JCompLineIncon;
    public float ICompLineCon;
    public float ICompLineIncon;

    public float congruentCount;
    public float IncongruentCount;

    public int NextFileFlag = 0;

    public string LastFromSeq;
    public float CurrentFromSeq;
    public float TrackLastTime;



    // Start is called before the first frame update
    public void Start()
    {
        StartOUTPUT();
    }

    //to repeat the data stuff
    public void Update()
    {

        if (NextFileFlag == 0)
        {
            ImportData();
        }

        if (NextFileFlag == 1)
        {
            ComputeData();
        }

        if (NextFileFlag == 2)
        {
            SaveData();
        }

        if (NextFileFlag == 3)
        {
            ResetData();
        }
    }

    //returen everything back to 0 for next file 
    public void ResetData()
    {
        TLeftCon = 0f;
        TLeftIncon = 0f;
        TRightCon = 0f;
        TRightIncon = 0f;
        NumRotateCon = 0f;
        NumRotateIncon = 0f;
        NumClearLineCon = 0f;
        NumClearLineIncon = 0f;
        TimeToCompCon = 0f;
        TimeToComPiecewiseCon = 0f;
        TimeToCompIncon = 0f;
        TimetoCompPiecewiseIncon = 0f;
        OCompLineCon = 0f;
        OCompLineIncon = 0f;
        SCompLineCon = 0f;
        SCompLineIncon = 0f;
        ZCompLineCon = 0f;
        ZCompLineIncon = 0f;
        TCompLineCon = 0f;
        TCompLineIncon = 0f;
        LCompLineCon = 0f;
        LCompLineIncon = 0f;
        JCompLineCon = 0f;
        JCompLineIncon = 0f;
        ICompLineCon = 0f;
        ICompLineIncon = 0f;

        congruentCount = 0f;
        IncongruentCount = 0f;

        NextFileFlag = 0;
        CurrentFromSeq = 0.0f;
        LastFromSeq = "";
        
        PartNum += 1; //increase for next participant
        //Debug.Log("Data " + PartNum.ToString() + " Complete!");
    }

    public List<string[]>rowData = new List<string[]>();

    //grab the CSV and rip it apart
    public void ImportData()
    {
        
        //This resets the file string just in case read.ReadToEnd() does not overwrite it. 
        file = "";

        if (File.Exists(getLoadPath()))
        {
            FileStream fileStream = new FileStream(getLoadPath(), FileMode.Open, FileAccess.ReadWrite);
            StreamReader read = new StreamReader(fileStream);
            file = read.ReadToEnd();

           //Debug.Log ("File loadad: " + fileNum.ToString());

            //increase the file num so that everything else can be processed
            if (fileNum <= 72)
            {
                fileNum += 1;
            }
            
            NextFileFlag = 1; //to compute

        }
        else
        {
            NextFileFlag = 69;
            Debug.LogError("File at " + "CSV" + " does not exist, or the Data is done!");
            //Application.Quit();
        }


    
    }

    //do all the calculations for data
    public async void ComputeData()
    {


        //key for parts[]
        //Condition,BlockType,FromSeq,LatinBalance,TLeft,TRight,NumRotations,CLine,NCLine,TimeToComplete
        //     0        1       2         3          4      5       6          7    8         9

        //condition A and B are congruent 

        //condition C and D are incongruent

        //This is to get all the rows
        string[] lines = file.Split ("\n" [0]);


        //loop to compute all the data must handle each row at a time and save the data along the way
        for (var i = 0; i < lines.Length; i ++) 
        {
            //This is to get every thing that is comma separated, use parts[] to get a specific colomn variable 
            string[] parts = lines [i].Split ("," [0]);

            float.TryParse(parts[9], out CurrentFromSeq);

            //helps to keep count of the incongruent variables
            if (parts[0] == "A" || parts[0] == "B")
            {
                congruentCount += 1;
            }
            // same but for incongruent
            if (parts[0] == "C" || parts[0] == "D")
            {
                IncongruentCount += 1;
            }

            // P# get the participant number 
            //this is preset and saved somewhere else, go find it muhahahahah *cough*

            // "Body" body orientation 0 for congruent and 1 for incongruent
            //this is done just below so it doesnt run through a bunch of times 

            //lmao i could have but the parts[0] == "A" in a block for all the congruent or incongruent 
            // "TLeftCong" //left movement
            if (parts[0] == "A" || parts[0] == "B")
            {
                float TempTLeft;
                float.TryParse (parts [4], out TempTLeft);
                TLeftCon += TempTLeft;
            }
            
            // "TLeftIncon"
            if (parts[0] == "C" || parts[0] == "D")
            {
                float TempTLeftIn;
                float.TryParse (parts [4], out TempTLeftIn);
                TLeftIncon += TempTLeftIn;
            }

            // "TRightCon"
            if (parts[0] == "A" || parts[0] == "B")
            {

                float TempTRight;
                float.TryParse (parts [5], out TempTRight);
                TRightCon += TempTRight;

            }

            // "TRightIncon"
            if (parts[0] == "C" || parts[0] == "D")
            {
                float TempTRightIn;
                float.TryParse (parts [5], out TempTRightIn);
                TRightIncon += TempTRightIn;
            }

            // "#RotateCon"
            if (parts[0] == "A" || parts[0] == "B")
            {
                float TempRotateCon;
                float.TryParse (parts [6], out TempRotateCon);
                NumRotateCon += TempRotateCon;
            }

            // "#RotateIncon"
            if (parts[0] == "C" || parts[0] == "D")
            {
                float TempRotateIncon;
                float.TryParse (parts [6], out TempRotateIncon);
                NumRotateIncon += TempRotateIncon;
            }

            // "#ClearLineCon"
            if (parts[0] == "A" || parts[0] == "B")
            {
                float TempNumClearCon;
                float.TryParse (parts [7], out TempNumClearCon);
                NumClearLineCon += TempNumClearCon;
            }

            // "#ClearLineIncon"
            if (parts[0] == "C" || parts[0] == "D")
            {
                float TempNumClearINCon;
                float.TryParse (parts [7], out TempNumClearINCon);
                NumClearLineIncon += TempNumClearINCon;
            }

            // these need additional calculations to find the last 'large' number based on the the current 'fromSeq'
            // "TimeToCompCon"
            if (parts[0] == "A" || parts[0] == "B")
            {

                if (CurrentFromSeq < 10.0f && i >= 1) 
                {
                    string[] Nparts = lines [i-1].Split ("," [0]);
                    float TempTimeCon;
                    float.TryParse (Nparts [9], out TempTimeCon);
                    //Debug.Log(TempTimeCon);
                    TimeToCompCon += TempTimeCon;
                }
                else if (i == lines.Length-1) //if at the end of the data file, always grab the last one, because nothing comes after it to trigger data collection
                {
                    float TempTimeCon;
                    float.TryParse (parts [9], out TempTimeCon);
                    //Debug.Log(TempTimeCon);
                    TimeToCompCon += TempTimeCon;
                }
                else
                {
                    float TimpTimePieceCon;
                    float.TryParse(parts[9], out TimpTimePieceCon);
                    TimeToComPiecewiseCon += TimpTimePieceCon;
                }
            }

            // "TimeToCompIncon"
            if (parts[0] == "C" || parts[0] == "D")
            {


                if (CurrentFromSeq < 10.0f && i >= 1)
                {
                    string[] Nparts = lines [i-1].Split ("," [0]);
                    float TempTimeIncon;
                    float.TryParse (Nparts [9], out TempTimeIncon);
                    //Debug.Log(TempTimeIncon);
                    TimeToCompIncon += TempTimeIncon;
                }
                else if (i == lines.Length-1)
                {
                    float TempTimeIncon;
                    float.TryParse (parts [9], out TempTimeIncon);
                    //Debug.Log(TempTimeIncon);
                    TimeToCompIncon += TempTimeIncon;
                }
                else 
                {
                    float TimpTimePieceInCon;
                    float.TryParse(parts[9], out TimpTimePieceInCon);
                    TimetoCompPiecewiseIncon += TimpTimePieceInCon;
                }
            }

            // "OCompLineCon"
            if (parts[1] == "O" &  (parts[0] == "A" || parts[0] == "B")   )
            {
                float TempOCon;
                float.TryParse (parts [7], out TempOCon);
                OCompLineCon += TempOCon;
            }

            // "OCompLineIncon"
            if (parts[1] == "O" & (parts[0] == "C" || parts[0] == "D"))
            {
                float TempOICon;
                float.TryParse (parts [7], out TempOICon);
                OCompLineIncon += TempOICon;
            }

            // "SCompLineCon"
            if (parts[1] == "S" &  (parts[0] == "A" || parts[0] == "B")   )
            {
                float TempSCon;
                float.TryParse (parts [7], out TempSCon);
                SCompLineCon += TempSCon;
            }

            // "SCompLineIncon"
            if (parts[1] == "S" & (parts[0] == "C" || parts[0] == "D"))
            {
                float TempSICon;
                float.TryParse (parts [7], out TempSICon);
                SCompLineIncon += TempSICon;
            }

            // "ZCompLineCon"
            if (parts[1] == "Z" &  (parts[0] == "A" || parts[0] == "B")   )
            {
                float TempZCon;
                float.TryParse (parts [7], out TempZCon);
                ZCompLineCon += TempZCon;
            }

            // "ZCompLineIncon"
            if (parts[1] == "Z" & (parts[0] == "C" || parts[0] == "D"))
            {
                float TempZICon;
                float.TryParse (parts [7], out TempZICon);
                ZCompLineIncon += TempZICon;
            }

            // "TCompLineCon"
            if (parts[1] == "T" &  (parts[0] == "A" || parts[0] == "B")   )
            {
                float TempTCon;
                float.TryParse (parts [7], out TempTCon);
                TCompLineCon += TempTCon;
            }

            // "TCompLineIncon"
            if (parts[1] == "T" & (parts[0] == "C" || parts[0] == "D"))
            {
                float TempTICon;
                float.TryParse (parts [7], out TempTICon);
                TCompLineIncon += TempTICon;
            }

            // "LCompLineCon"
            if (parts[1] == "L" &  (parts[0] == "A" || parts[0] == "B")   )
            {
                float TempLCon;
                float.TryParse (parts [7], out TempLCon);
                LCompLineCon += TempLCon;
            }

            // "LCompLineIncon"
            if (parts[1] == "L" & (parts[0] == "C" || parts[0] == "D"))
            {
                float TempLICon;
                float.TryParse (parts [7], out TempLICon);
                LCompLineIncon += TempLICon;
            }

            // "JCompLineCon"
            if (parts[1] == "J" &  (parts[0] == "A" || parts[0] == "B")   )
            {
                float TempJCon;
                float.TryParse (parts [7], out TempJCon);
                JCompLineCon += TempJCon;
            }

            // "JCompLineIncon"
            if (parts[1] == "J" & (parts[0] == "C" || parts[0] == "D"))
            {
                float TempJInCon;
                float.TryParse (parts [7], out TempJInCon);
                JCompLineIncon += TempJInCon;
            }

            // "ICompLineCon"
            if (parts[1] == "I" &  (parts[0] == "A" || parts[0] == "B")   )
            {
                float TempICon;
                float.TryParse (parts [7], out TempICon);
                ICompLineCon += TempICon;
            }

            //"ICompLineIncon"
            if (parts[1] == "I" & (parts[0] == "C" || parts[0] == "D"))
            {
                float TempIInCon;
                float.TryParse (parts [7], out TempIInCon);
                ICompLineIncon += TempIInCon;
            }
        }

        AssignBody();
        //now we can average the data 

        TLeftCon = TLeftCon/congruentCount;
        TLeftIncon = TLeftIncon/IncongruentCount;

        TRightCon = TRightCon/congruentCount;
        TRightIncon = TRightIncon/IncongruentCount;

        NumRotateCon = NumRotateCon/congruentCount;
        NumRotateIncon = NumRotateIncon/IncongruentCount;

        NumClearLineCon = NumClearLineCon/congruentCount;
        NumClearLineIncon = NumClearLineIncon/IncongruentCount;

        TimeToCompCon = TimeToCompCon/4;
        TimeToCompCon = TimeToCompCon / 60;

        TimeToComPiecewiseCon = TimeToComPiecewiseCon/congruentCount;
        TimeToComPiecewiseCon = TimeToComPiecewiseCon / 60; 

        TimeToCompIncon = TimeToCompIncon/4;
        TimeToCompIncon = TimeToCompIncon / 60;

        TimetoCompPiecewiseIncon = TimetoCompPiecewiseIncon/IncongruentCount;
        TimetoCompPiecewiseIncon = TimetoCompPiecewiseIncon / 60;

        OCompLineCon = OCompLineCon/congruentCount;
        OCompLineIncon = OCompLineIncon/IncongruentCount;

        SCompLineCon = SCompLineCon/congruentCount;
        SCompLineIncon = SCompLineIncon/IncongruentCount;

        ZCompLineCon = ZCompLineCon/congruentCount;
        ZCompLineIncon = ZCompLineIncon/IncongruentCount;

        TCompLineCon = TCompLineCon/congruentCount;
        TCompLineIncon = TCompLineIncon/IncongruentCount;

        LCompLineCon = LCompLineCon/congruentCount;
        LCompLineIncon = LCompLineIncon/IncongruentCount;

        JCompLineCon = JCompLineCon/congruentCount;
        JCompLineIncon = JCompLineIncon/IncongruentCount;

        ICompLineCon = ICompLineCon/congruentCount;
        ICompLineIncon = ICompLineIncon/IncongruentCount;

        NextFileFlag = 2;
    }

    //manual assignments for participant
    public void AssignBody()
    {
        // 0 is upright
        // 1 is inverted
        if (PartNum == 1) {Body = 0;}
        if (PartNum == 2) {Body = 0;}
        if (PartNum == 3) {Body = 1;}
        if (PartNum == 4) {Body = 0;}
        if (PartNum == 5) {Body = 0;}
        if (PartNum == 6) {Body = 0;}
        if (PartNum == 7) {Body = 0;}
        if (PartNum == 8) {Body = 1;}
        if (PartNum == 9) {Body = 1;}
        if (PartNum == 10) {Body = 0;}
        if (PartNum == 11) {Body = 0;}
        if (PartNum == 12) {Body = 0;}
        if (PartNum == 13) {Body = 0;}
        if (PartNum == 14) {Body = 1;}
        if (PartNum == 15) {Body = 0;}
        if (PartNum == 16) {Body = 1;}
        if (PartNum == 17) {Body = 1;}
        if (PartNum == 18) {Body = 0;}
        if (PartNum == 19) {Body = 1;}
        if (PartNum == 20) {Body = 1;}
        if (PartNum == 21) {Body = 0;}
        if (PartNum == 22) {Body = 0;}
        if (PartNum == 23) {Body = 0;}
        if (PartNum == 24) {Body = 1;}
        if (PartNum == 25) {Body = 1;}
        if (PartNum == 26) {Body = 0;}
        if (PartNum == 27) {Body = 1;}
        if (PartNum == 28) {Body = 0;}
        if (PartNum == 29) {Body = 1;}
        if (PartNum == 30) {Body = 0;}
        if (PartNum == 31) {Body = 0;}
        if (PartNum == 32) {Body = 1;}
        if (PartNum == 33) {Body = 1;}
        if (PartNum == 34) {Body = 0;}
        if (PartNum == 35) {Body = 0;}
        if (PartNum == 36) {Body = 0;}

        //secound half
        if (PartNum == 37) {Body = 1;}
        if (PartNum == 38) {Body = 0;}
        if (PartNum == 39) {Body = 1;}
        if (PartNum == 40) {Body = 1;}
        if (PartNum == 41) {Body = 1;}
        if (PartNum == 42) {Body = 1;}
        if (PartNum == 43) {Body = 0;}
        if (PartNum == 44) {Body = 1;}
        if (PartNum == 45) {Body = 1;}
        if (PartNum == 46) {Body = 0;}
        if (PartNum == 47) {Body = 0;}
        if (PartNum == 48) {Body = 0;}
        if (PartNum == 49) {Body = 1;}
        if (PartNum == 50) {Body = 1;}
        if (PartNum == 51) {Body = 0;}
        if (PartNum == 52) {Body = 1;}
        if (PartNum == 53) {Body = 1;}
        if (PartNum == 54) {Body = 1;}
        if (PartNum == 55) {Body = 1;}
        if (PartNum == 56) {Body = 1;}
        if (PartNum == 57) {Body = 1;}
        if (PartNum == 58) {Body = 0;}
        if (PartNum == 59) {Body = 1;}
        if (PartNum == 60) {Body = 1;}
        if (PartNum == 61) {Body = 0;}
        if (PartNum == 62) {Body = 0;}
        if (PartNum == 63) {Body = 1;}
        if (PartNum == 64) {Body = 0;}
        if (PartNum == 65) {Body = 0;}
        if (PartNum == 66) {Body = 1;}
        if (PartNum == 67) {Body = 1;}
        if (PartNum == 68) {Body = 1;}
        if (PartNum == 69) {Body = 0;} //nice
        if (PartNum == 70) {Body = 1;}
        if (PartNum == 71) {Body = 0;}
        if (PartNum == 72) {Body = 0;}

    }
    
    public void SaveData()
    {
        string[] rowDataTemp = new string[28];
        // You can add up the values in as many cells as you want.
        
        rowDataTemp[0] = PartNum.ToString(); //Condition
        rowDataTemp[1] = Body.ToString();
        rowDataTemp[2] =  TLeftCon.ToString("F2");
        rowDataTemp[3] =  TLeftIncon.ToString("F2");
        rowDataTemp[4] =  TRightCon.ToString("F2");
        rowDataTemp[5] =  TRightIncon.ToString("F2");
        rowDataTemp[6] =  NumRotateCon.ToString("F2");
        rowDataTemp[7] =  NumRotateIncon.ToString("F2");
        rowDataTemp[8] =  NumClearLineCon.ToString("F2");
        rowDataTemp[9] =  NumClearLineIncon.ToString("F2");
        rowDataTemp[10] = TimeToCompCon.ToString("F2");
        rowDataTemp[11] = TimeToCompIncon.ToString("F2");
        rowDataTemp[12] = TimeToComPiecewiseCon.ToString("F2");
        rowDataTemp[13] = TimetoCompPiecewiseIncon.ToString("F2");
        rowDataTemp[14] =  OCompLineCon.ToString("F2");
        rowDataTemp[15] =  OCompLineIncon.ToString("F2");
        rowDataTemp[16] = SCompLineCon.ToString("F2");
        rowDataTemp[17] =  SCompLineIncon.ToString("F2");
        rowDataTemp[18] =  ZCompLineCon.ToString("F2");
        rowDataTemp[19] =  ZCompLineIncon.ToString("F2");
        rowDataTemp[20] =  TCompLineCon.ToString("F2");
        rowDataTemp[21] =  TCompLineIncon.ToString("F2");
        rowDataTemp[22] =  LCompLineCon.ToString("F2");
        rowDataTemp[23] =  LCompLineIncon.ToString("F2");
        rowDataTemp[24] =  JCompLineCon.ToString("F2");
        rowDataTemp[25] =  JCompLineIncon.ToString("F2");
        rowDataTemp[26] =  ICompLineCon.ToString("F2");
        rowDataTemp[27] =  ICompLineIncon.ToString("F2");

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
        NextFileFlag = 3;
    }

    public void StartOUTPUT(){

        // Creating First row of titles manually..
        string[] rowDataTemp = new string[28];
        rowDataTemp[0] = "P#";
        rowDataTemp[1] = "Body";
        rowDataTemp[2] = "TLeftCong";
        rowDataTemp[3] = "TLeftIncon";
        rowDataTemp[4] = "TRightCon";
        rowDataTemp[5] = "TRightIncon";
        rowDataTemp[6] = "#RotateCon";
        rowDataTemp[7] = "#RotateIncon";
        rowDataTemp[8] = "#ClearLineCon";
        rowDataTemp[9] = "#ClearLineIncon";
        rowDataTemp[10] = "TimeToCompCon";
        rowDataTemp[11] = "TimeToCompIncon";
        rowDataTemp[12] = "TimeToCompPiecewiseCon";
        rowDataTemp[13] = "TimeToCompPieceWiseIncon";
        rowDataTemp[14] = "OCompLineCon";
        rowDataTemp[15] = "OCompLineIncon";
        rowDataTemp[16] = "SCompLineCon";
        rowDataTemp[17] = "SCompLineIncon";
        rowDataTemp[18] = "ZCompLineCon";
        rowDataTemp[19] = "ZCompLineIncon";
        rowDataTemp[20] = "TCompLineCon";
        rowDataTemp[21] = "TCompLineIncon";
        rowDataTemp[22] = "LCompLineCon";
        rowDataTemp[23] = "LCompLineIncon";
        rowDataTemp[24] = "JCompLineCon";
        rowDataTemp[25] = "JCompLineIncon";
        rowDataTemp[26] = "ICompLineCon";
        rowDataTemp[27] = "ICompLineIncon";

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
        PartNum += 1;
    }

    // Following method is used to retrive the relative path as device platform
    public string getLoadPath(){
        
        #if UNITY_EDITOR
        return Application.dataPath +"/INPUT/"+ fileNum.ToString() +".csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+ fileNum.ToString() +".csv"";
        #elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+ fileNum.ToString() +".csv"";
        #else
        return Application.dataPath +"/"+ fileNum.ToString() +".csv";
        #endif

    }



    // Following method is used to retrive the relative path as device platform
    public string getPath(){

        string dataString = "OUTPUT";

        #if UNITY_EDITOR
        return Application.dataPath +"/OUTPUT/"+ dataString +".csv";
        #elif UNITY_ANDROID
        return Application.persistentDataPath+ dataString +".csv"";
        #elif UNITY_IPHONE
        return Application.persistentDataPath+"/"+ dataString +".csv"";
        #else
        return Application.dataPath +"/"+ dataString +".csv";
        #endif
    }









}
