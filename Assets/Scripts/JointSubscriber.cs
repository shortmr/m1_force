using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using JointState = RosMessageTypes.Sensor.JointStateMsg;

public class JointSubscriber : MonoBehaviour
{
    public string topic;
    public float tau_s;
    public float q;

    private bool startup = true;

    void Start() {
        Application.targetFrameRate = 50;
        if (startup) {
            ROSConnection.GetOrCreateInstance().Subscribe<JointState>("/" + topic + "/", StreamData);
            startup = false;
        }
    }

    void StreamData(JointState d) {
        tau_s = (float)d.effort[0]; // interaction torque
        q = (float)d.position[0]; // M1 angle
    }

    private void Update()
    {

    }
}
