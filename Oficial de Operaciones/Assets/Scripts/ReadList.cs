using System.Collections.Generic;
using UnityEngine;

public class ReadList : MonoBehaviour
{
    public List<TargetCode> leftList;
    public List<TargetCode> rightList;
    public GestureDatabase gestureDatabase;
    public bool rightIsTheSame;
    public string rightGestureName;
    public bool leftIsTheSame;
    public string leftGestureName;

    public bool runTest;

    private NewGameManager NewGameManager_Script;
    private ResultText ResultText_Script;

    private void Start()
    {
        NewGameManager_Script = GetComponent<NewGameManager>();
        ResultText_Script = GetComponent<ResultText>();
    }

    private void Update()
    {
        if (runTest) RunTest();
        /*
        if(leftList[0] == TargetCode.X && rightList[0] == TargetCode.Y)
        {
            Debug.Log("STAND BY");
            ResetList();
        }*/
    }

    public void AddToRightList(TargetCode _id)
    {
        if(rightList[0] == TargetCode.NA)
        {
            //ADD TO POSITION 0 ON LIST
            rightList[0] = _id;
        }
        else
        {
            //ADD TO POSITION 1 ON LIST
            rightList[1] = _id;
            runTest = true;
        }
    }
    public void AddToLeftList(TargetCode _id)
    {
        if(leftList[0] == TargetCode.NA)
        {
            //ADD TO POSITION 0 ON LIST
            leftList[0] = _id;
        }
        else
        {
            //ADD TO POSITION 1 ON LIST
            leftList[1] = _id;
            runTest = true;
        }
    }

    public void RunTest()
    {
        rightIsTheSame = CheckListForward(true, gestureDatabase, rightList);
        if (!rightIsTheSame) Debug.Log("RIGHT list are NOT the same");

        
        leftIsTheSame = CheckListForward(false, gestureDatabase, leftList);
        if (!leftIsTheSame) Debug.Log("LEFT list are NOT the same");

        if (rightIsTheSame && leftIsTheSame && rightGestureName == leftGestureName) Debug.Log("THER IS MOVEMENT");
        else if(rightGestureName != leftGestureName)
        {
            Debug.Log("GESTURE NOT IN THE SAME CATEGORY");
        }

        ResetList();
        NewGameManager_Script.DeactivateTargets();
        runTest = false;
    }

    public void ResetList()
    {
        for(int i=0; i<leftList.Count; i++)
        {
            leftList[i] = TargetCode.NA;
        }

        for(int i=0; i<rightList.Count; i++)
        {
            rightList[i] = TargetCode.NA;
        }
    }

    public bool CheckListForward(bool _isrighthand, GestureDatabase _gestureList, List<TargetCode> _handlist)
    {
        /*
         * 1- get in gesture list
         * 2- if right handed go to right hand else go to left
         * 3- get hand list
         * 4- check all elements in hand list
         * 5- if the same as current results return true
         * 6- if not the same check ist backwards
         * 7- if the same return true else return false
        */
        if(_isrighthand)
        {
            for (int i = 0; i < _gestureList.Gestures.Length; i++)
            {
                //Debug.Log("Loop: " + i + "   In: " + _gestureList.Gestures[i].name);
                //Debug.Log("CHECKING LIST FROM START TO END");
                for (int j = 0; j < 1; j++)
                {
                    //Debug.Log("Cicles: " + j + " / " + _gestureList.Gestures[i].rightHandList.Count);

                    bool _hasfoundmatch = true;

                    //CHECKS IF LIST IS THE SAME AS DATABASE CHECK LIST FROM START TO FINISH
                    for (int l = 0; l < _handlist.Count; l++)
                    {
                        if (_handlist.Count == _gestureList.Gestures[i].rightHandList.Count)
                        {
                            //Debug.Log("Checking lists:" + " In Hand: " + _handlist[l] + " In database: " + _gestureList.Gestures[i].rightHandList[l]);

                            if (_handlist[l] != _gestureList.Gestures[i].rightHandList[l])
                            {
                                _hasfoundmatch = false;
                            }
                        }
                        else
                        {
                            Debug.Log("RIGHT LIST IS NOT THE SAME SIZE AS DATABASE, LENGTH MUST BE '2'.");
                            ResultText_Script.SetCommandText("No Movement");
                            return false;
                        }

                    }
                    if(!_hasfoundmatch)
                    {
                        _hasfoundmatch = true;
                        _handlist.Reverse();
                        //Debug.Log("NO MATCHES YET, CHECKING LIST FROM END TO START");

                        //CHECKS IF LIST IS THE SAME AS DATABASE CHECK LIST FROM FINISH TO START
                        for (int l = 0; l < _handlist.Count; l++)
                        {

                            if (_handlist.Count == _gestureList.Gestures[i].rightHandList.Count)
                            {
                                //Debug.Log("Checking lists:" + " In Hand: " + _handlist[l] + " In database: " + _gestureList.Gestures[i].rightHandList[l]);

                                if (_handlist[l] != _gestureList.Gestures[i].rightHandList[l])
                                {
                                    _hasfoundmatch = false;
                                }
                            }
                            else
                            {
                                Debug.Log("RIGHT LIST IS NOT THE SAME SIZE AS DATABASE, LENGTH MUST BE '2'.");
                                ResultText_Script.SetCommandText("No Movement");
                                return false;
                            }

                        }
                    }

                    if (_hasfoundmatch)
                    {
                        Debug.Log("MATCH FOUND FOR RIGHT IN LIST: " + _gestureList.Gestures[i].name);
                        ResultText_Script.SetCommandText(_gestureList.Gestures[i].name);
                        rightGestureName = _gestureList.Gestures[i].name;
                        return true;
                    }                    
                }
            }
            ResultText_Script.SetCommandText("No Movement");
            return false;
        }
        else
        {
            for (int i = 0; i < _gestureList.Gestures.Length; i++)
            {
                //Debug.Log("Loop: " + i + "   In: " + _gestureList.Gestures[i].name);
                //Debug.Log("CHECKING LIST FROM START TO END");
                for (int j = 0; j < 1; j++)
                {
                    //Debug.Log("Cicles: " + j + " / " + _gestureList.Gestures[i].leftHandList.Count);

                    bool _hasfoundmatch = true;

                    //CHECKS IF LIST IS THE SAME AS DATABASE CHECK LIST FROM START TO FINISH
                    for (int l = 0; l < _handlist.Count; l++)
                    {
                        if (_handlist.Count == _gestureList.Gestures[i].leftHandList.Count)
                        {
                            //Debug.Log("Checking lists:" + " In Hand: " + _handlist[l] + " In database: " + _gestureList.Gestures[i].leftHandList[l]);

                            if (_handlist[l] != _gestureList.Gestures[i].leftHandList[l])
                            {
                                _hasfoundmatch = false;
                            }
                        }
                        else
                        {
                            Debug.Log("LEFT LIST IS NOT THE SAME SIZE AS DATABASE, LENGTH MUST BE " + _gestureList.Gestures[i].leftHandList.Count);
                            ResultText_Script.SetCommandText("No Movement");
                            return false;
                        }

                    }
                    if (!_hasfoundmatch)
                    {
                        _hasfoundmatch = true;
                        _handlist.Reverse();
                        //Debug.Log("NO MATCHES YET, CHECKING LIST FROM END TO START");

                        //CHECKS IF LIST IS THE SAME AS DATABASE CHECK LIST FROM FINISH TO START
                        for (int l = 0; l < _handlist.Count; l++)
                        {

                            if (_handlist.Count == _gestureList.Gestures[i].leftHandList.Count)
                            {
                                //Debug.Log("Checking lists:" + " In Hand: " + _handlist[l] + " In database: " + _gestureList.Gestures[i].leftHandList[l]);

                                if (_handlist[l] != _gestureList.Gestures[i].leftHandList[l])
                                {
                                    _hasfoundmatch = false;
                                }
                            }
                            else
                            {
                                Debug.Log("LEFT LIST IS NOT THE SAME SIZE AS DATABASE, LENGTH MUST BE " + _gestureList.Gestures[i].leftHandList.Count);
                                ResultText_Script.SetCommandText("No Movement");
                                return false;
                            }

                        }
                    }

                    if (_hasfoundmatch)
                    {
                        Debug.Log("MATCH FOUND LEFT IN LIST: " + _gestureList.Gestures[i].name);
                        ResultText_Script.SetCommandText(_gestureList.Gestures[i].name);
                        leftGestureName = _gestureList.Gestures[i].name;
                        return true;
                    }
                }
            }
            ResultText_Script.SetCommandText("No Movement");
            return false;
        }
    }
}
