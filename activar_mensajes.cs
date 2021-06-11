using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activar_mensajes : MonoBehaviour
{
    public GameObject texto_izquierda;
    public GameObject texto_derecha;

    // Start is called before the first frame update
    void Start()
    {
        texto_izquierda.SetActive(false);
        texto_derecha.SetActive(false);
    }
    private void Update()
    {
        activar_mensaje();
    }
    void activar_mensaje()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            texto_izquierda.SetActive(true);
            StartCoroutine("Espera");
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            texto_derecha.SetActive(true);
            StartCoroutine("Espera");
        }
    }
    IEnumerator Espera()
    {
        yield return new WaitForSeconds(2);
        texto_izquierda.SetActive(false);
        texto_derecha.SetActive(false);
    }
}