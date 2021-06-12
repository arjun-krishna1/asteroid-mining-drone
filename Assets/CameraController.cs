using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Range(0.0f, 45.0f)]
    public float rotationSpeed;
    private string basePath = "~/Desktop/sphere-generate-random/";
    void Update()
    {
        // ScreenCapture.CaptureScreenshot(basePath + "frame"+Time.frameCount+".png");
        // print(transform.eulerAngles.ToString());
        transform.Rotate(0, rotationSpeed, 0.0f, Space.Self);
    }
}
