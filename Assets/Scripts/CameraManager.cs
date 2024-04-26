using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float horizObl;
    public float vertObl;

    void Start()
    {
        SetObliqueness();
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    public void SetObliqueness()
    {
        Matrix4x4 mat = GetComponent<Camera>().projectionMatrix;
        mat[0, 2] = horizObl;
        mat[1, 2] = vertObl;
        GetComponent<Camera>().projectionMatrix = mat;
    }
}
