using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRaycast : MonoBehaviour
{
    public bool rightHand;
    public LayerMask targetMask;
    [HideInInspector] public TargetColliders targetColliders_Script;
    private float rayDir;

    [SerializeField] private bool GotInfo;
    [SerializeField] private float TimeForRegister;
    [SerializeField] private float CurrentTimer;
    [SerializeField] private bool HasBeenAdded;

    private void Start()
    {
        rayDir = rightHand == true ? 1 : -1;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up) * rayDir, out hit, Mathf.Infinity, targetMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayDir * hit.distance, Color.green);
            targetColliders_Script = hit.transform.gameObject.GetComponent<TargetColliders>();
            if (targetColliders_Script)
            {
                //OnRayHit();
                if (!HasBeenAdded) targetColliders_Script.SetRenderColor(Color.yellow);
                if(!GotInfo) GetTargetInfo(targetColliders_Script);
                RunTimer();
            }
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayDir * 1000, Color.red);
                
            OnRayExit();
        }
    }

    private void OnRayHit()
    {
        //targetColliders_Script.SelectThis(rightHand);
    }
    private void OnRayExit()
    {
        if (targetColliders_Script)
        {
            GotInfo = false;
            CurrentTimer = 0;
            HasBeenAdded = false;
            targetColliders_Script.SetRenderColor(Color.red);
            targetColliders_Script.DeselectThis(rightHand);
            targetColliders_Script = null;
        }
    }
    private void GetTargetInfo(TargetColliders _object)
    {
        TimeForRegister = _object.timeForRegiste;
        GotInfo = true;
    }
    private void RunTimer()
    {
        CurrentTimer += Time.deltaTime;
        if (!HasBeenAdded && CurrentTimer > TimeForRegister)
        {
            targetColliders_Script.AddToList(rightHand);
            HasBeenAdded = true;
            targetColliders_Script.SetText(rightHand, targetColliders_Script.ID.ToString());
            targetColliders_Script.SetRenderColor(Color.green);

        }
    }
}
