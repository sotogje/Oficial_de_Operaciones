using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GestureDatabase gestureList;


    [Header("UI Debug")]
    public TMP_Text rightHandTxt;
    public TMP_Text leftHandTxt;
    public TMP_Text resultTxt;

    public string[] rightRegisterList;
    public string[] leftRegisterList;

    public int rightTimesAdded;
    public int leftTimesAdded;

    public string debugLeftHandTxt;
    public string debugRightHandTxt;
    public string debugResultHandTxt;

    public bool LeftIsFull;
    public bool RightIsFull;

    public InputRegisterList inputRegisterList_Script;
    public LaunchRaycast RightRaycast;
    public LaunchRaycast LeftRaycast;

    public string lastGesture;

    public SphereColliders[] targets;


    private void Start()
    {
        rightRegisterList = new string[2];
        leftRegisterList = new string[2];
        inputRegisterList_Script = GetComponent<InputRegisterList>();
        lastGesture = null;
    }

    private void Update()
    {
        rightHandTxt.text = debugRightHandTxt;
        leftHandTxt.text = debugLeftHandTxt;


        //resultTxt.text = leftHandTxt.text + " + " + rightHandTxt.text;

        CheckStaticPosition();
    }

    private void CheckIfArrayIsFill()
    {
        bool _rightarreyisfull = true;
        bool _leftarreyisfull = true;

        for (int i = 0; i < rightRegisterList.Length; i++)
        {
            if (rightRegisterList[i] == null)
            {
                _rightarreyisfull = false;
                break;
            }
        }

        for (int i = 0; i < leftRegisterList.Length; i++)
        {
            if (leftRegisterList[i] == null)
            {
                _leftarreyisfull = false;
                break;
            }
        }


        if (_leftarreyisfull || _rightarreyisfull)
        {
            Debug.Log("An Arrey is Full");

            CheckRegisterList();
        }
        else
        {
            //Debug.Log("Arreys is NOT Full");
        }
    }

    public void RightRegister(string _id)
    {
        rightRegisterList[rightTimesAdded] = _id;
        rightTimesAdded++;
        if (rightTimesAdded == 2) rightTimesAdded = 0;
    }
    public void LeftRegister(string _id)
    {
        leftRegisterList[leftTimesAdded] = _id;
        leftTimesAdded++;
        if (leftTimesAdded == 2) leftTimesAdded = 0;
    }

    public void CheckRegisterList()
    {
        //Debug.Log("Checking results");
        inputRegisterList_Script.PossibillitiesList(rightRegisterList, leftRegisterList);
        //inputRegisterList_Script.LeftPossibillitiesList1(leftRegisterList);
    }

    public void UpdateRightHandTxt(string _newtext)
    {
        rightHandTxt.text = _newtext;
        debugRightHandTxt = _newtext;
    }
    public void UpdateLeftHandTxt(string _newtext)
    {
        leftHandTxt.text = _newtext;
        debugLeftHandTxt = _newtext;
    }
    public void UpdateResultTxt(string _newtext)
    {

    }

    public void ClearRightArrey()
    {
        for (int i = 0; i < rightRegisterList.Length; i++)
        {
            rightRegisterList[i] = null;
        }
        rightTimesAdded = 0;
        Debug.Log("RIGHT ARRAY HAS BEEN CLEAR!");
        ResetRayCast();
    }

    public void ClearLeftArrey()
    {
        for (int i = 0; i < leftRegisterList.Length; i++)
        {
            leftRegisterList[i] = null;
        }
        leftTimesAdded = 0;
        Debug.Log("LEFT ARRAY HAS BEEN CLEAR!");
        ResetRayCast();
    }

    public void CheckPreviusGesture(string _currentgesture)
    {

        if (lastGesture == null)
        {
            Debug.Log("Gesture Tracking START");
            lastGesture = _currentgesture;
        }
        else if(lastGesture != null)
        {
            if(lastGesture == _currentgesture)
            {
                Debug.Log("Continuing with gesture");
            }
            else
            {
                Debug.Log("Not same gesture as the previous one");
                lastGesture = null;
            }
        }
    }

    public void ResetRayCast()
    {
        RightRaycast.RestartRay();
        LeftRaycast.RestartRay();
    }

    public void SetResult(string _result)
    {
        resultTxt.text = _result;
    }

    public void CheckStaticPosition()
    {
        if (targets[6].isActivated && targets[7].isActivated)
        {
            resultTxt.text = "Standing By";
        }
        else if (targets[8].isActivated && targets[9].isActivated)
        {
            resultTxt.text = "Face Me";
        }
        else
        {
            resultTxt.text = "";
            CheckIfArrayIsFill();
        }
    }
}
