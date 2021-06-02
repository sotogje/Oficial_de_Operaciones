using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterAnimator : MonoBehaviour
{
    public Animator LeftHandAnimator;
    public Animator RightHandAnimator;

    public bool TurnLeft;

    public void DoIdel()
    {
        LeftHandAnimator.SetBool("Turn_Left", false);
        RightHandAnimator.SetBool("Turn_Left", false);
        LeftHandAnimator.SetBool("Turn_Right", false);
        RightHandAnimator.SetBool("Turn_Right", false);
        LeftHandAnimator.SetBool("Face_Me", false);
        RightHandAnimator.SetBool("Face_Me", false);
    }
    public void DoTurnLeft()
    {
        DoIdel();
        string _action = "Turn_Left";
        LeftHandAnimator.SetBool(_action, !LeftHandAnimator.GetBool(_action));
        RightHandAnimator.SetBool(_action, !RightHandAnimator.GetBool(_action));
    }
    public void DoTurnRight()
    {
        DoIdel();
        string _action = "Turn_Right";
        LeftHandAnimator.SetBool(_action, !LeftHandAnimator.GetBool(_action));
        RightHandAnimator.SetBool(_action, !RightHandAnimator.GetBool(_action));
    }

    public void DoFaceMe()
    {
        DoIdel();
        string _action = "Face_Me";
        LeftHandAnimator.SetBool(_action, !LeftHandAnimator.GetBool(_action));
        RightHandAnimator.SetBool(_action, !RightHandAnimator.GetBool(_action));
    }

}
