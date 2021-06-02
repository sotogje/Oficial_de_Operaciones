using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchRaycast : MonoBehaviour
{
    public bool rightHand;
    public LayerMask layerMask;
    public SphereColliders sphereColliders_Script;
    private float rayDir;

    public bool canShootRay;

    private void Start()
    {
        rayDir = rightHand == true ? 1 : -1;
        canShootRay = true;
    }

    void FixedUpdate()
    {
        if (canShootRay)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.up) * rayDir, out hit, Mathf.Infinity, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayDir * hit.distance, Color.green);
                sphereColliders_Script = hit.transform.gameObject.GetComponent<SphereColliders>();
                if (sphereColliders_Script)
                {
                    OnRayHit();
                }
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.up) * rayDir * 1000, Color.red);
                OnRayExit();
            }
        }
        else
        {
            OnRayExit(); 
        }
    }

    private void OnRayHit()
    {
        sphereColliders_Script.SelectThis(rightHand);
    }
    private void OnRayExit()
    {
        if (sphereColliders_Script)
        {
            sphereColliders_Script.DeselectThis(rightHand);
            sphereColliders_Script = null;
        }
    }

    public void RestartRay()
    {
        canShootRay = false;
        Invoke("CanShootRayAgain", 0.5f);
    }
    
    private void CanShootRayAgain()
    {
        canShootRay = true;
    }
}
