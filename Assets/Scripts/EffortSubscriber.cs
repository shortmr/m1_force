using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using JointState = RosMessageTypes.Sensor.JointStateMsg;

public class EffortSubscriber : MonoBehaviour
{
    private bool startup = true;
    public string data;
    public float pos;

    void Start() {
        Application.targetFrameRate = 50;
        if (startup) {
            ROSConnection.GetOrCreateInstance().Subscribe<JointState>("/" + data + "/", StreamData);
            startup = false;
        }
    }

    void StreamData(JointState d) {
        pos = (float)d.effort[0];
    }

    private void Update()
    {

    }
}
