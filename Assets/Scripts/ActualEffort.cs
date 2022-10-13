using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualEffort : MonoBehaviour
{
    public GameObject jointState;
    public float gain;
    public float positionEffort;
    public float positionOffset;

    private GameObject data;
    private const float positionSmoothing = 0.5f;
    private const float positionLowpass = 0.1f;
    private float previousEffort = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;
        data = jointState;
    }

    // Update is called once per frame
    void Update()
    {
        positionEffort = -1*data.GetComponent<JointSubscriber>().tau_s; // flip sign of interaction torque
        positionEffort = (positionEffort * positionLowpass) + (previousEffort * (1.0f - positionLowpass));
        transform.localPosition = new Vector3(0.0f, gain*(Mathf.Lerp(positionEffort,previousEffort,positionSmoothing)-positionOffset)+2, 0.0f);
        previousEffort = positionEffort;
    }

}