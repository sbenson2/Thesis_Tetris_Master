using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLeft : MonoBehaviour
{

    [SerializeField] GameObject LeftHand;


    // Update is called once per frame
    void Update()
    {
        
        this.transform.position = LeftHand.transform.position;
        this.transform.rotation = LeftHand.transform.rotation;

    }
}
