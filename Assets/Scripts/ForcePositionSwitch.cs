using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ForcePositionSwitch : MonoBehaviour
{
    public GameObject posX;
    public GameObject posY;
    public GameObject forceX;
    public GameObject forceY;

    private int mode;
    private string modeText;
    private TMP_Text text;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 50;

        // Set mode to force on startup
        mode = 1;
        modeText = "Force";
        posX.SetActive(false);
        posY.SetActive(false);
        forceX.SetActive(true);
        forceY.SetActive(true);

        text = GetComponentInChildren<TMP_Text>();
        text.text = modeText;
    }

    public void Switch()
    {
        if (mode == 1) {
            mode = 2;
            modeText = "Position";
            forceX.SetActive(false);
            forceY.SetActive(false);
            posX.SetActive(true);
            posY.SetActive(true);
        }
        else if (mode == 2)  {
            mode = 1;
            modeText = "Force";
            posX.SetActive(false);
            posY.SetActive(false);
            forceX.SetActive(true);
            forceY.SetActive(true);
        }
        text = GetComponentInChildren<TMP_Text>();
        text.text = modeText;
    }
}
