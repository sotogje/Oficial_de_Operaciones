using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReadList))]
public class NewGameManager : MonoBehaviour
{
    private ResultText ResultText_Script;
    private ReadList ListOfTargets;
    public TargetColliders[] TargetColliders_Scrip;

    public TargetCode leftIndependent;
    public TargetCode rightIndependent;

    public LaunchRaycast LeftRaycast;
    public LaunchRaycast RightRaycast;

    public List<GameObject> TargetList = new List<GameObject>();

    private void Start()
    {
        ResultText_Script = FindObjectOfType<ResultText>();
        ListOfTargets = FindObjectOfType<ReadList>();
        foreach(GameObject foundtarget in GameObject.FindGameObjectsWithTag("Target"))
        {
            TargetList.Add(foundtarget);
        }        
    }
    private void Update()
    {
        /*
        if (CheckIfStandingBy())
        {
            ResultText_Script.SetLeftHandText("Target_Y");
            ResultText_Script.SetRightHandText("Target_Z");
            ResultText_Script.SetCommandText("Standing By");
        }
        else
        {
            ResultText_Script.SetRightHandText("");
            ResultText_Script.SetLeftHandText("");
            ResultText_Script.SetCommandText("");
        }*/

        if(leftIndependent != TargetCode.NA && rightIndependent != TargetCode.NA)
        {
            if(leftIndependent == TargetCode.X && rightIndependent == TargetCode.Y)
            {
                ResultText_Script.SetCommandText("Hold Position");
            }
            else
            {
                leftIndependent = TargetCode.NA;
                rightIndependent = TargetCode.NA;
            }
        }
    }

    public bool CheckIfStandingBy()
    {
        bool _y = false;
        bool _z = false;

        for(int i=0; i<TargetColliders_Scrip.Length; i++)
        {
            if (TargetColliders_Scrip[i].GetComponent<TargetColliders>().ID == TargetCode.Y) _y = true;
            if (TargetColliders_Scrip[i].GetComponent<TargetColliders>().ID == TargetCode.Z) _z = true;

        }
        if (_y && _z) return true;
        else return false;
    }

    public void AddToRightList(TargetCode _id)
    {
        ListOfTargets.AddToRightList(_id);
    }

    public void AddToLeftList(TargetCode _id)
    {
        ListOfTargets.AddToLeftList(_id);
    }

    ///////////////////////////////////////////////////////////
    public void AddToIndependenList(TargetCode _id, bool _isrighthand)
    {
        if(_isrighthand)
        {
            rightIndependent = _id;
        }
        else
        {
            leftIndependent = _id;
        }
    }


    private void SowResults(string _result)
    {
        //IF RESULT TEXT SCRIPT IS NOT NULL SEND RESULT TO SHOW TO USER
        if(ResultText_Script) ResultText_Script.SetCommandText(_result);
    }
    public void UpdateRightHandTxt(string _newtext)
    {
        /*rightHandTxt.text = _newtext;
        debugRightHandTxt = _newtext;*/
    }
    public void UpdateLeftHandTxt(string _newtext)
    {
        /*leftHandTxt.text = _newtext;
        debugLeftHandTxt = _newtext;*/
    }

    public void DeactivateTargets()
    {
        for (int i = 0; i < TargetList.Count; i++)
        {
            TargetList[i].GetComponent<BoxCollider>().enabled = false;
        }
        Invoke("ActivateTargets", 0.5f);
    }
    private void ActivateTargets()
    {
        for (int i = 0; i < TargetList.Count; i++)
        {
            TargetList[i].GetComponent<BoxCollider>().enabled = true;
        }
    }
}