using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRight : MonoBehaviour
{
    [SerializeField] GameObject RightHand;

    // Update is called once per frame
    void Update()
    {
        
        this.transform.position = (RightHand.transform.position += new Vector3(-0.15f, 0f, 0f));
        this.transform.rotation = RightHand.transform.rotation;

    }
}
