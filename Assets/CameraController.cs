using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0.0f, 45.0f)]
    public float rotationSpeed = 0.5f;
    private string basePath = System.IO.Directory.GetCurrentDirectory()+"/data/" ;

    void Update()
    {
        ScreenCapture.CaptureScreenshot(basePath + "frame"+Time.frameCount+"-"+transform.eulerAngles.ToString()+".png");
        transform.Rotate(rotationSpeed, rotationSpeed, 0.0f, Space.Self);
    }
}
