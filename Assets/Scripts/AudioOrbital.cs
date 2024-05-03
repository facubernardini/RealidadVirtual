using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioOrbital : MonoBehaviour
{
    public GameObject camara;


    void Update()
    {
        transform.RotateAround(camara.transform.position, Vector3.up, 50f*Time.deltaTime);
    }
}
