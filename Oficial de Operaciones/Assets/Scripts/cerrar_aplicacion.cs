using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerrar_aplicacion : MonoBehaviour
{
    public void Cerrar()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
        //Just to make sure its working
    }
}