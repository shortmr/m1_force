using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesiredPosition : MonoBehaviour
{
    public GameObject settings;

    private float originSine; //  default: -75 (deg)
    private float startRange; // default -130 (deg)
    private float totalRange; // default: 110f (deg)
    private float practiceFreq = 0.2f; // default: 0.2 (Hz)
    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;
        startRange = settings.GetComponent<DisplaySettings>().startRange;
        totalRange = settings.GetComponent<DisplaySettings>().totalRange;
        originSine = startRange + (totalRange/2f);
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time;
        float y = (totalRange/2f - 2f) * Mathf.Sin(2f * Mathf.PI * practiceFreq * t); // amplitude full range minus 2 deg
        targetRotation = Quaternion.Euler(0, 0, y + originSine) * Quaternion.identity;
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 100);
        if (Quaternion.Angle(targetRotation, transform.rotation) < 1)
        {
            transform.rotation = targetRotation;
        }
    }
}


