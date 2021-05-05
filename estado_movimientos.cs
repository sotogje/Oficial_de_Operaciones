using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class estado_movimientos : MonoBehaviour
{
    public float velocidad_adelante;
    public float velocidad_izquierda;
    public float velocidad_derecha;
    public float velocidad_atras;
    public GameObject avion;

    // Update is called once per frame
    void Update()
    {
        adelante();
        atras();
        izquierda();
        derecha();
    }

    void adelante()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = transform.position + avion.transform.forward * velocidad_adelante * Time.deltaTime;
            Debug.Log("w fue presionada");
        }
    }

    void atras()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = transform.position + avion.transform.forward * velocidad_atras * Time.deltaTime;
            Debug.Log("s fue presionada");
        }
    }

    void izquierda()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = transform.position + avion.transform.forward * velocidad_izquierda * Time.deltaTime;
            Debug.Log("A fue presionada");
        }
    }

    void derecha()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = transform.position + avion.transform.forward * velocidad_derecha * Time.deltaTime;
            Debug.Log("d fue presionada");
        }
    }
}