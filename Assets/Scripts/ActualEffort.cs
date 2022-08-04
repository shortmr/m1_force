using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualEffort : MonoBehaviour
{
    public string subscriber;
    public float positionEffort;
    public float gain;
    public float positionOffset;

    private GameObject traj;
    private const float positionSmoothing = 0.5f;
    private const float positionLowpass = 0.1f;
    private float previousEffort = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;
        gain = 0.2f;
        traj = GameObject.Find(subscriber);
    }

    // Update is called once per frame
    void Update()
    {
        positionEffort = -1*traj.GetComponent<EffortSubscriber>().pos;
        positionEffort = (positionEffort * positionLowpass) + (previousEffort * (1.0f - positionLowpass));
        transform.localPosition = new Vector3(0.0f, gain*(Mathf.Lerp(positionEffort,previousEffort,positionSmoothing)-positionOffset)+2, 0.0f);
        //transform.localPosition = new Vector3(0.0f, gain*(positionEffort-positionOffset)+2, 0.0f);
        previousEffort = positionEffort;
    }

}