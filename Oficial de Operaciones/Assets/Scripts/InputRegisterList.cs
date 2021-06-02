using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRegisterList : MonoBehaviour
{
    public bool hasFoundRightMatch;
    public bool hasFoundLeftMatch;

    public string[] rightPossibillities1;

    public string[] leftPossibillities1;

    private GameManager GameManager_Script;

    private void Start()
    {
        GameManager_Script = GetComponent<GameManager>();
    }

    public void PossibillitiesList(string[] _rightarrey, string[] _leftarrey)
    {
        hasFoundRightMatch = true;
        hasFoundLeftMatch = true;


        for (int i=0; i< rightPossibillities1.Length; i++)
        {
            //Debug.Log("Seve pattern:  " + rightPossibillities1[i]);
            //Debug.Log("MyPatter:  " + _rightarrey[i]);

            if (rightPossibillities1[i] != _rightarrey[i])
            {
                hasFoundRightMatch = false;
                Debug.Log("Rigth Has No Match");
                break;
            }
        }
        //LeftPossibillitiesList1(_leftarrey);


        for (int i = 0; i < leftPossibillities1.Length; i++)
        {
            //Debug.Log("Seve pattern:  " + leftPossibillities1[i]);
            //Debug.Log("MyPatter: " + _leftarrey[i]);

            if (leftPossibillities1[i] != _leftarrey[i])
            {
                hasFoundLeftMatch = false;
                Debug.Log("Left Has No Match");
                break;
            }
        }
        
        
        if (!hasFoundRightMatch || !hasFoundLeftMatch)
        {
            Debug.Log("No MATCH");
            GameManager_Script.SetResult(" ");
            GameManager_Script.CheckPreviusGesture(null);
            GameManager_Script.ClearRightArrey();
            GameManager_Script.ClearLeftArrey();
        }

        if (hasFoundRightMatch && hasFoundLeftMatch)
        {
            Debug.Log("FOUND A MATCH");
            string _gestuedoing = "Turnign Left";
            GameManager_Script.CheckPreviusGesture(_gestuedoing);
            GameManager_Script.SetResult(_gestuedoing);
        }


        /*
        if (hasFoundRightMatch == false || hasFoundLeftMatch == false)
        {
            Debug.Log("No MATCH");
            GameManager_Script.SetResult(" ");
            GameManager_Script.CheckPreviusGesture(null);
        }*/
    }
    public void LeftPossibillitiesList1(string[] _leftarrey)
    {
        hasFoundLeftMatch = true;

        for (int i = 0; i < leftPossibillities1.Length; i++)
        {
            //Debug.Log("Seve pattern:  " + leftPossibillities1[i]);
            //Debug.Log("MyPatter: " + _leftarrey[i]);

            if (leftPossibillities1[i] != _leftarrey[i])
            {
                hasFoundLeftMatch = false;
                return;
            }
        }
        
        if(hasFoundRightMatch && hasFoundLeftMatch)
        {
            string _gestuedoing = "Turnign Left";
            Debug.Log("FOUND A MATCH");
            GameManager_Script.SetResult(_gestuedoing);
            GameManager_Script.CheckPreviusGesture(_gestuedoing);
        }
        else if(hasFoundRightMatch == false || !hasFoundLeftMatch == false)
        {
            Debug.Log("No MATCH");
            GameManager_Script.SetResult(" ");
            GameManager_Script.CheckPreviusGesture(null);
        }

        if(hasFoundRightMatch)  GameManager_Script.ClearRightArrey();
        if(hasFoundLeftMatch)   GameManager_Script.ClearLeftArrey();
    }
}
