using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBeamControl : MonoBehaviour
{
    [SerializeField] Canvas StartScreen;
    [SerializeField] Canvas InstructionScreen;
    [SerializeField] Canvas InbetweenScreen;
    [SerializeField] Canvas afterPracticeScreen;
   
    [SerializeField] GameObject LeftBeam;
    [SerializeField] GameObject RightBeam;


    // Update is called once per frame
    void Update()
    {
        
        //if any of the screens are up, then the beams should be off
        if (StartScreen.enabled == false && InbetweenScreen.enabled == false && InstructionScreen.enabled == false && afterPracticeScreen == false)
        {
            LeftBeam.SetActive(false);
            RightBeam.SetActive(false);
        }
        else
        {
            LeftBeam.SetActive(true);
            RightBeam.SetActive(true);
        }



    }
}
