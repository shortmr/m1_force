using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesiredEffort : MonoBehaviour
{
    public GameObject jointCommand;
    public float gain;
    public float positionEffort;

    private GameObject data;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;
        gain = 0.2f;
        data = jointCommand;
    }

    // Update is called once per frame
    void Update()
    {
        positionEffort = -1*data.GetComponent<JointSubscriber>().q;
        transform.localPosition = new Vector3(0.0f, gain*positionEffort+2, 0.0f);
    }

}