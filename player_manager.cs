using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_manager : MonoBehaviour
{
    #region Singleton
    public static player_manager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject jugador;
}