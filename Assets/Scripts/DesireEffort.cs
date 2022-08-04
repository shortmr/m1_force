using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesireEffort : MonoBehaviour
{
    public string subscriber;
    public float positionEffort;
    public float gain;

    private GameObject traj;

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
        positionEffort = -1*traj.GetComponent<JointStateSubscriber>().pos;
        transform.localPosition = new Vector3(0.0f, gain*positionEffort+2, 0.0f);
    }

}