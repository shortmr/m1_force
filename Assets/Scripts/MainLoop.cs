using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MainLoop : MonoBehaviour
{
    public GameObject arrowX;
    public GameObject arrowY;
    public GameObject trialX;
    public GameObject trialY;
    public GameObject restX;
    public GameObject restY;

    public GameObject textX;
    public GameObject textY;
    public string subscriber;
    public int totalTrials;

    private GameObject data;
    private bool upFlag;
    private bool downFlag;
    private bool zeroFlag;
    private bool restFlag;
    private string direction;

    private int stage;
    private int rep;
    private int max_rep;
    private bool passRest;

    private Vector3 arrowPositionUp;
    private Vector3 trialPositionUp;
    private Vector3 arrowPositionDown;
    private Vector3 trialPositionDown;
    private float angleUp = 0f;
    private float angleDown = 180f;

    void Start()
    {
        rep = 0;
        stage = 0;
        max_rep = (int) (totalTrials*2); // default is 3 trials for each direction

        arrowPositionUp = new Vector3(-8f,3.3f,0f);
        arrowPositionDown = new Vector3(-8f,0.7f,0f);
        trialPositionUp = new Vector3(-10.2f,7.46f,0f);
        trialPositionDown = new Vector3(-10.2f,7.43f,0f);

        textX.GetComponent<TextMeshProUGUI>().text = "0";
        textY.GetComponent<TextMeshProUGUI>().text = "0";

        // Initialize pre-trial arrows
        arrowX.SetActive(false);
        arrowY.SetActive(false);
        trialX.SetActive(false);
        trialY.SetActive(false);
        restX.SetActive(false);
        restY.SetActive(false);

        direction = "DF";

        zeroFlag = true;
        upFlag = false;
        downFlag = false;
        restFlag = false;

        data = GameObject.Find(subscriber);
    }

    void Update()
    {
        if (data.GetComponent<JointSubscriber>().q > 100 & !restFlag) {
            restX.SetActive(true);
            restY.SetActive(true);
            restFlag = true;
            zeroFlag = false;
        }
        else if (data.GetComponent<JointSubscriber>().q > 0 & data.GetComponent<JointSubscriber>().q < 100 & !downFlag)
        {
            rep = rep + 1;
            arrowX.SetActive(true);
            arrowY.SetActive(true);
            arrowX.GetComponent<Transform>().localPosition = arrowPositionDown;
            arrowX.GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0f,0f,angleDown));
            arrowY.GetComponent<Transform>().localPosition = arrowPositionDown;
            arrowY.GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0f,0f,angleDown));
            restX.SetActive(false);
            restY.SetActive(false);
            downFlag = true;
            zeroFlag = false;
        }
        else if (data.GetComponent<JointSubscriber>().q < 0 & !upFlag)
        {
            rep = rep + 1;
            arrowX.SetActive(true);
            arrowY.SetActive(true);
            arrowX.GetComponent<Transform>().localPosition = arrowPositionUp;
            arrowX.GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0f,0f,angleUp));
            arrowY.GetComponent<Transform>().localPosition = arrowPositionUp;
            arrowY.GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0f,0f,angleUp));
            restX.SetActive(false);
            restY.SetActive(false);
            upFlag = true;
            zeroFlag = false;
        }
        else if (data.GetComponent<JointSubscriber>().q == 0 & !zeroFlag)
        {
            arrowX.SetActive(false);
            arrowY.SetActive(false);
            restX.SetActive(true); //restX.SetActive(false);
            restY.SetActive(true); //restY.SetActive(false);
            upFlag = false;
            downFlag = false;
            zeroFlag = true;
            if (restFlag) {
                if (rep < max_rep) {
                    if (rep%2 == 0) {
                        stage = stage + 1;
                        direction = "DF";
                        if (stage == 1) {
                            trialX.SetActive(true);
                            trialY.SetActive(true);
                        }
                        trialX.GetComponent<Transform>().localPosition = trialPositionUp;
                        trialX.GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0f,0f,angleUp));
                        trialY.GetComponent<Transform>().localPosition = trialPositionUp;
                        trialY.GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0f,0f,angleUp));
                    }
                    else {
                        direction = "PF";
                        trialX.GetComponent<Transform>().localPosition = trialPositionDown;
                        trialX.GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0f,0f,angleDown));
                        trialY.GetComponent<Transform>().localPosition = trialPositionDown;
                        trialY.GetComponent<Transform>().localRotation = Quaternion.Euler(new Vector3(0f,0f,angleDown));
                    }
                    textX.GetComponent<TextMeshProUGUI>().text = stage.ToString();
                    textY.GetComponent<TextMeshProUGUI>().text = stage.ToString();
                    Debug.Log(direction);
                }
                else {
                    trialX.SetActive(false);
                    trialY.SetActive(false);
                }
            }

        }
    }
}