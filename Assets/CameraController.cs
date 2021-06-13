using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private string basePath = System.IO.Directory.GetCurrentDirectory() + "/data/";

    private int speed = 10;

    private int frame = 0;

    void Update()
    {
        ScreenCapture.CaptureScreenshot(GetImageName());
        transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        print(transform.position.ToString());
    }

    private string GetImageName()
    {
        return basePath + frame + "/frame" + Time.frameCount + "-" + transform.eulerAngles.ToString();
    }
}
