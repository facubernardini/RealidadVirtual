using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject camara;

    private float speedH = 1.0f;
    private float speedV = 1.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;
    private float movimientoHorizontal, movimientoVertical;
    private float velocidad = 6.0f;

    void Update()
    {
        // Movimiento del personaje
        movimientoHorizontal = Input.GetAxis("Horizontal");
        movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical);
        movimiento = camara.transform.TransformDirection(movimiento);
        movimiento[1] = 0.0f; //Luego de la transformacion con respecto al mundo, vuelvo a setear el eje Y en 0 para que la camara este siempre al mismo nivel
        camara.transform.position += movimiento * velocidad * Time.deltaTime;
        
        // Rotacion de la camara principal manteniendo el click izquierdo apretado

        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        // Limito el rango de la rotacion vertical
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        camara.transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        
    }
}
