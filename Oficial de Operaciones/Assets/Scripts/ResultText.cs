using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResultText : MonoBehaviour
{
    public TextMeshProUGUI LeftHand;
    public TextMeshProUGUI RightHand;
    public TextMeshProUGUI Command;
    public bool CountingDown;
    public float TimeToEraseCommand;

    public void SetLeftHandText(string _texttoshow)
    {
        LeftHand.text = _texttoshow;
    }
    public void SetRightHandText(string _texttoshow)
    {
        RightHand.text = _texttoshow;
    }
    public void SetCommandText(string _texttoshow)
    {
        Command.text = _texttoshow;
        CountingDown = true;
        TimeToEraseCommand = 2.2f;
    }
    public void ClearCommandText()
    {
        Command.text = " ";
    }
    private void Update()
    {
        if(CountingDown)
        {
            TimeToEraseCommand -= 1*Time.deltaTime;
            if(TimeToEraseCommand<0)
            {
                Command.text = " ";
                CountingDown = false;
            }
        }
    }
}
