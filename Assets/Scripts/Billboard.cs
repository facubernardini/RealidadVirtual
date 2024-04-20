using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject camara;

    void Update()
    {
        transform.rotation = Quaternion.Euler(90f, camara.transform.rotation.eulerAngles.y + 180f, 0f);
    }
}
