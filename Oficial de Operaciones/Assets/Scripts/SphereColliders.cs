using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereColliders : MonoBehaviour
{    
    public string ID;
    public bool isActivated;
    public bool hitWithRightHand;
    public float timeForRegiste = 0.2f;

    public float currentTime;
    public bool hasBeenAdded;

    public int timeAdded;

    private Renderer render;
    private GameManager gameManager_Script;

    private void Start()
    {
        render = GetComponent<Renderer>();
        gameManager_Script = FindObjectOfType<GameManager>();
        render.material.SetColor("_Color", Color.red);
    }

    private void Update()
    {
        if (isActivated) AddTime(Time.deltaTime);
    }

    private void AddTime(float _detlatime)
    {
        currentTime += _detlatime;
        if(!hasBeenAdded && currentTime > timeForRegiste)
        {
            //Debug.Log(this.gameObject.name + " Has been Added to list");
            AddToList(hitWithRightHand);
            hasBeenAdded = true;
        }
    }

    private void AddToList(bool _isrighthand)
    {
        if(hitWithRightHand)
        {
            gameManager_Script.RightRegister(ID);
        }
        else
        {
            gameManager_Script.LeftRegister(ID);
        }
    }

    private void ResetTimer()
    {
        currentTime = 0.0f;
        hasBeenAdded = false;
    }

    public void SelectThis(bool _hitwithrighthand)
    {
        hitWithRightHand = _hitwithrighthand;

        isActivated = true;
        render.material.SetColor("_Color", Color.green);

        if (hitWithRightHand)
        {
            gameManager_Script.UpdateRightHandTxt(ID);
        }
        else
        {
            gameManager_Script.UpdateLeftHandTxt(ID);
        }
    }

    public void DeselectThis(bool _hitwithrighthand)
    {
        isActivated = false;
        render.material.SetColor("_Color", Color.red);
        ResetTimer();

        if (_hitwithrighthand)
        {
            gameManager_Script.UpdateRightHandTxt(" ");
        }
        else
        {
            gameManager_Script.UpdateLeftHandTxt(" ");
        }
    }
}
