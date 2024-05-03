using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroscopeRotation : MonoBehaviour
{
    void Start()
    {
        //Screen.orientation = ScreenOrientation.LandscapeLeft;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Input.gyro.enabled = true;
        Input.location.Start();
        Input.compass.enabled = true;
    }

    void Update()
    {
        Vector3 newRotation = Vector3.zero;

        newRotation.x = -2 * Input.gyro.rotationRateUnbiased.x;
        newRotation.y = -2 * Input.gyro.rotationRateUnbiased.y;        
        newRotation.z = 2 * Input.gyro.rotationRateUnbiased.z;

        transform.Rotate(newRotation);
    }
}
