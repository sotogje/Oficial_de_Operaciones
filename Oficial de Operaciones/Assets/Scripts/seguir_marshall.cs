using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class seguir_marshall : MonoBehaviour
{
    #region PUBLIC VARIABELS
    public Transform PlaneDestination;
    public Transform LookDirection;

    public float MoveSpeed = 0.2f;
    public float MaxMoveSpeed;
    public float RotationSpeed;
    #endregion

    public float DebugLineSize;
    public float DebugHorizontal;
    public float DebugVertical;
    public Transform ForwardDir;
    public Transform RightDir;
    public Transform LeftDir;
    public string DirectionMovineg;

    #region PRIVATE VARIABELS
    [SerializeField] private bool HasReachedDestination;
    [SerializeField] private float DistanceToTarget;
    private ResultText ResultText_Script;
    #endregion

    private void Start()
    {
        ResultText_Script = FindObjectOfType<ResultText>();
    }

    void Update()
    {
        CheckForOrders();
        DistanceToTarget = transform.position.z - PlaneDestination.position.z;
        if (!HasReachedDestination) MoveForward();


        Vector3 ForwardDir = transform.TransformDirection(Vector3.forward) * 100;
        Debug.DrawRay(transform.position, ForwardDir, Color.cyan);
    }

    private void MoveForward()
    {
        transform.LookAt(LookDirection);
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;
    }

    private void CheckForOrders()
    {
        //DEBUG
        //JUST TO CHECK IF IT WORKS
        if(MoveSpeed != 0)
        {
            GetDirectionMovemet();
        }
        else DirectionMovineg = "Forward";
        /*
        if (Input.GetKeyUp(KeyCode.W)) MoveSpeed++;
        if (Input.GetKeyUp(KeyCode.S)) MoveSpeed--;*/
        //

        switch (DirectionMovineg)
        {
            case "Turn Right":
                LookDirection.position = RightDir.position;
                break;
            case "Turn Left":
                LookDirection.position = LeftDir.position;
                break;
            case "Forward":
                LookDirection.position = ForwardDir.position;
                break;
            default:
                LookDirection.position = ForwardDir.position;
                break;
        }
    }

    public void GetDirectionMovemet()
    {
        DirectionMovineg = ResultText_Script.Command.text;
    }

    public void Decelerate(float _deceleratespeed)
    {
        Debug.Log("Stop");
        if (MoveSpeed != 0)
        {
            if (MoveSpeed > 0) MoveSpeed--;
            else if (MoveSpeed < 0) MoveSpeed++;

            Invoke("Decelerate", _deceleratespeed);
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "PlaneDestination")
        {
            HasReachedDestination = true;
        }
    }
}