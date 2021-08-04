using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTestMovement : MonoBehaviour
{
    public Transform ObjectToFollow;
    public Transform ParentToSetPossitionAndRotation;

    public float mDesiredRotation;
    public float RotationSpeed;

    public Vector3 movement;
    public Vector3 rotatedMovement;

    public Quaternion currentRotation;
    public Quaternion targetRotation;

    public Vector3 currentRot;
    public Vector3 targetRot;

    private void Update()
    {
        UpdatePosition();
    }
    public void UpdatePosition()
    {
        movement = new Vector3(ObjectToFollow.position.x, ObjectToFollow.position.y, ObjectToFollow.position.z);

        rotatedMovement = Quaternion.Euler(0, ObjectToFollow.rotation.eulerAngles.y, 0) * movement;
        ParentToSetPossitionAndRotation.position = rotatedMovement;

        if(rotatedMovement.magnitude >0)
        {
            mDesiredRotation = Mathf.Atan2(rotatedMovement.x, rotatedMovement.z) * Mathf.Rad2Deg;
        }

        Quaternion rotttt = new Quaternion(ObjectToFollow.rotation.x, ObjectToFollow.rotation.y, ObjectToFollow.rotation.z, ObjectToFollow.rotation.w);

        currentRotation = rotttt;
        currentRot = currentRotation.eulerAngles;

        targetRotation = Quaternion.Euler(0, mDesiredRotation, 0);
        targetRot = targetRotation.eulerAngles;

        ParentToSetPossitionAndRotation.position = movement;
        ParentToSetPossitionAndRotation.rotation = Quaternion.Lerp(currentRotation, targetRotation, RotationSpeed * Time.deltaTime);
    }
}
