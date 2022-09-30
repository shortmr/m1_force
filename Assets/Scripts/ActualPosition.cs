using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualPosition : MonoBehaviour
{
    public GameObject settings;
    public GameObject jointState;

    private float originz; //  degrees (default: 205f)
    private float gain = 100.0f; // adjusting this value will require additional changes in display
    private Quaternion targetRotation;
    private GameObject data;
    [SerializeField] private float rotateAngle;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;
        data = jointState;
        originz = -1*settings.GetComponent<DisplaySettings>().startRange + 75;
    }

    // Update is called once per frame
    void Update()
    {
        rotateAngle = data.GetComponent<JointSubscriber>().q;
        targetRotation = Quaternion.Euler(0, 0, (rotateAngle*gain) + originz) * Quaternion.identity;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 100);
        if (Quaternion.Angle(targetRotation, transform.rotation) < 1)
        {
            transform.rotation = targetRotation;
        }
    }
}
