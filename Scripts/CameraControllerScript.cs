using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{

    public Camera[] cams;
    int camNum = 0;

    void SetCams()
    {
        camNum++;

        if (camNum >= cams.Length)
            camNum = 0;

        foreach (Camera c in cams)
            c.enabled = false;

        cams[camNum].enabled = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.V))
            SetCams();

    }
}
