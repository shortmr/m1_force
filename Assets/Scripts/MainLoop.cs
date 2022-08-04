using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainLoop : MonoBehaviour
{
    public GameObject upX;
    public GameObject upY;
    public GameObject downX;
    public GameObject downY;
    public string subscriber;

    private GameObject traj;
    private bool upFlag;
    private bool downFlag;
    private bool zeroFlag;

    void Start()
    {
        // Initialize pre-trial cloud
        upX.SetActive(false);
        upY.SetActive(false);
        downX.SetActive(false);
        downY.SetActive(false);

        zeroFlag = true;
        upFlag = false;
        downFlag = false;

        traj = GameObject.Find(subscriber);
    }

    void Update()
    {
        if (traj.GetComponent<JointStateSubscriber>().pos > 0 & !downFlag)
        {
            downX.SetActive(true);
            downY.SetActive(true);
            downFlag = true;
            zeroFlag = false;
        }
        else if (traj.GetComponent<JointStateSubscriber>().pos < 0 & !upFlag)
        {
            upX.SetActive(true);
            upY.SetActive(true);
            upFlag = true;
            zeroFlag = false;
        }
        else if (traj.GetComponent<JointStateSubscriber>().pos == 0 & !zeroFlag)
        {
            upX.SetActive(false);
            upY.SetActive(false);
            downX.SetActive(false);
            downY.SetActive(false);
            upFlag = false;
            downFlag = false;
            zeroFlag = true;
        }
    }
}