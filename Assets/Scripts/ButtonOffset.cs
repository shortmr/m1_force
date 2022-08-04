using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOffset : MonoBehaviour
{
    public GameObject robotState;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;
    }

    public void Offset()
    {
        robotState.GetComponent<ActualEffort>().positionOffset = robotState.GetComponent<ActualEffort>().positionEffort;
    }
}
