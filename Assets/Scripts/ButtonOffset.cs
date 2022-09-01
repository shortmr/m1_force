using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOffset : MonoBehaviour
{
    public GameObject actualX;
    public GameObject actualY;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;
    }

    public void Offset()
    {
        actualX.GetComponent<ActualEffort>().positionOffset = actualX.GetComponent<ActualEffort>().positionEffort;
        actualY.GetComponent<ActualEffort>().positionOffset = actualY.GetComponent<ActualEffort>().positionEffort;
    }
}
