using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetColliders : MonoBehaviour
{
    public TargetCode ID = new TargetCode();
    public bool isActivated;
    public bool hitWithRightHand;
    [Range(0.05f, 1.0f)] public float timeForRegiste = 0.2f;

    public float currentTime;
    public bool hasBeenAdded;


    private Renderer render;
    private NewGameManager newGameManager_Script;
    private ReadList ReadList_Script;
    private ResultText ResultText_Script;

    private void Start()
    {
        render = GetComponent<Renderer>();
        newGameManager_Script = FindObjectOfType<NewGameManager>();
        ReadList_Script = FindObjectOfType<ReadList>();
        ResultText_Script = FindObjectOfType<ResultText>();
        render.material.SetColor("_Color", Color.red);
    }

    private void Update()
    {
        //if (isActivated) AddTime(Time.deltaTime);
    }
    /*
    private void AddTime(float _detlatime)
    {
        currentTime += _detlatime;
        if(!hasBeenAdded && currentTime > timeForRegiste)
        {
            AddToList(hitWithRightHand);
            hasBeenAdded = true;
            SetText(hitWithRightHand, ID.ToString());
            render.material.SetColor("_Color", Color.green);

        }
    }*/

    public void SetRenderColor(Color _changecolorto)
    {
        render.material.SetColor("_Color", _changecolorto);
    }

    public void SetText(bool _isroghthand, string _text)
    {
        if(_isroghthand) ResultText_Script.SetRightHandText(_text);
        else ResultText_Script.SetLeftHandText(_text);
    }

    public void AddToList(bool _isrighthand)
    {
        if(ID == TargetCode.Y || ID == TargetCode.Z)
        {
            Debug.Log(this.gameObject.name + " Has NOT been Added to list");
            if (_isrighthand) ResultText_Script.SetRightHandText(ID.ToString());
            else ResultText_Script.SetLeftHandText(ID.ToString());
            ReadList_Script.ResetList();
        }
        else
        {
            if (_isrighthand)
            {
                newGameManager_Script.AddToRightList(ID);
            }
            else
            {
                newGameManager_Script.AddToLeftList(ID);

            }
            Debug.Log(this.gameObject.name + " Has been Added to list");
        }
    }

    private void ResetTimer()
    {
        currentTime = 0.0f;
        hasBeenAdded = false;
    }
    /*
    public void SelectThis(bool _hitwithrighthand)
    {
        hitWithRightHand = _hitwithrighthand;

        isActivated = true;
        if(hasBeenAdded) SetRenderColor(Color.green);
        else SetRenderColor(Color.yellow);

        if (hitWithRightHand)
        {
            newGameManager_Script.UpdateRightHandTxt(ID.ToString());
        }
        else
        {
            newGameManager_Script.UpdateLeftHandTxt(ID.ToString());
        }
    }*/

    public void DeselectThis(bool _hitwithrighthand)
    {/*
        isActivated = false;
        SetRenderColor(Color.red);
        SetText(hitWithRightHand, " ");
        ResetTimer();

        if (_hitwithrighthand)
        {
            newGameManager_Script.UpdateRightHandTxt(" ");
        }
        else
        {
            newGameManager_Script.UpdateLeftHandTxt(" ");
        }*/
    }
}
