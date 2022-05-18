using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Input_manager : MonoBehaviour
{
    //Getting the left stick movement
    [SerializeField] private InputActionReference MoveLeft;
    [SerializeField] private InputActionReference MoveRight;
    [SerializeField] private InputActionReference Rotate;

    public delegate void doInputDelegate(string inputName);

    public doInputDelegate doInputEvent;

    public delegate void rotateInputDelegate();

    public rotateInputDelegate rotateInputEvent;

    int InputTrack = 0;
    public bool InputFlip = false;
    public bool InputContol = true;

    void Start()
    {
       MoveLeft.action.performed += OnLeft;
       MoveRight.action.performed += OnRight;
       Rotate.action.performed += OnRotate;
    }

    public void Update()
    {
        getInput();
    }

    private void OnLeft(InputAction.CallbackContext obj)
    {
       InputTrack = 1;
    }

    private void OnRight(InputAction.CallbackContext obj)
    {
       InputTrack = 2;
    }

    private void OnRotate(InputAction.CallbackContext obj)
    {
       InputTrack = 3;
    }


    public void FlipInput()
    {
        if (InputFlip == true)
        {
            InputFlip = false;
        }
        else
        {
            InputFlip = true;
        }
    }

    public void InputOff()
    {
        InputContol = false;
    }

    public void InputOn()
    {
        InputContol = true;
    }

    public void getInput()
    {
       
       if(InputContol == true)
       {
                    //left movement
            if(InputTrack == 1)
            {

                //handle flipping the controls in the correct direction if neccessary 
                if (InputFlip == true)
                {
                    doInputEvent("right");
                }
                else
                {
                    doInputEvent("left");
                }

                InputTrack = 0;
            }

            //right movement
            if(InputTrack == 2)
            {
                //handle flipping the controls in the correct direction if neccessary 
                if (InputFlip == true)
                {
                    doInputEvent("left");
                }
                else
                {
                    doInputEvent("right");
                }

                InputTrack = 0;
            }
    
            //rotation movement
            if(InputTrack == 3)
            {
                rotateInputEvent();
                InputTrack = 0;
                //Debug.Log("rotated");
            }
       }

    }
}
