using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class listOfObjectsToChangePositionRotationScale
{
    //public Transform PivotForObjectToPositionChange;
    //public Transform ObjectToPositionChange;
    public Transform ObjectToModify;

    //public bool applyToX;
    //public bool applyToY;
    //public bool applyToZ;

    [Header("Position")]
    [Space(30)]
    public Vector3 PositionOffset;
    [Header("Dynamic Position")]
    //public bool useDynamicPosition;
    public bool NegativeDynamicX; 
    public bool dynamicX;
    public bool dynamicY;
    public bool dynamicZ;
    //
    public bool applyPosToX = true;
    public bool applyPosToY = true;
    public bool applyPosToZ = true;

    [Header("Rotation")]
    //public Vector3 RotationOffset;
    public bool applyRotToX = true;
    public bool applyRotToY = true;
    public bool applyRotToZ = true;

    /*
    [Header("Scale")]
    public Vector3 ScaleOffset;
    public bool applySclToX = false;
    public bool applySclToY = false;
    public bool applySclToZ = false;

    public Vector3 ObjectCurrentPos;
    public Vector3 ObjectCurrentRot;
    public Vector3 ObjectCurrentScl;*/
}
/*
[System.Serializable]
public class listOfRotationToChange
{
    public Transform ListOfObjctsForRotationChange;
    public Vector3 RotationOffset;
    public bool applyToX;
    public bool applyToY;
    public bool applyToZ;
}

[System.Serializable]
public class listOfScaleToChange
{
    public Transform ListOfObjctsForScaleChange;
    public Vector3 ScaleOffset;
    public bool applyToX;
    public bool applyToY;
    public bool applyToZ;
}*/

public class SetPositionRotationScale : MonoBehaviour
{
    [SerializeField] private Transform ObjectToFollow;
    [SerializeField] private float mDesiredRotation;
    [SerializeField] private float RotationSpeed;

    [Space(30)]
    [SerializeField] private List<listOfObjectsToChangePositionRotationScale> ObjectsToModifyTransform;

    //////////////////////////////////////////////////////////////////////////////////////////
    /*
    [Header("Rotation")]
    [SerializeField] private bool ChangeObjctsRotation;
    [SerializeField] private List<listOfRotationToChange> ObjectsToChangeRotation;

    //////////////////////////////////////////////////////////////////////////////////////////

    [Header("Scale")]
    [SerializeField] private bool ChangeObjctsScale;
    [SerializeField] private List<listOfScaleToChange> ObjectsToChangeScale;
    */
    //////////////////////////////////////////////////////////////////////////////////////////

    private  List<Vector3> inicialObjctsToChangePosition;
    private List<Quaternion> inicialObjctsToChangeRotation;
    private List<Vector3> inicialObjctsToChangeScale;

    private void Start()
    {
        inicialObjctsToChangePosition = new List<Vector3>(new Vector3[ObjectsToModifyTransform.Count]);
        inicialObjctsToChangeRotation = new List<Quaternion>(new Quaternion[ObjectsToModifyTransform.Count]);
        inicialObjctsToChangeScale = new List<Vector3>(new Vector3[ObjectsToModifyTransform.Count]);

        if (ObjectsToModifyTransform.Count > 0)
        {
            for (int i = 0; i < ObjectsToModifyTransform.Count; i++)
            {
                inicialObjctsToChangePosition[i] = ObjectsToModifyTransform[i].ObjectToModify.position;
                inicialObjctsToChangeRotation[i] = ObjectsToModifyTransform[i].ObjectToModify.rotation;
                inicialObjctsToChangeScale[i] = ObjectsToModifyTransform[i].ObjectToModify.lossyScale;
            }
        }
    }

    void Update()
    {
        ChangeTransform();
    }

    private void ChangeTransform()
    {
        for (int i = 0; i < ObjectsToModifyTransform.Count; i++)
        {
            Vector3 _newpos;
            float _xpos = 0;
            float _ypos = 0;
            float _zpos = 0;

            float _xrot = 0;
            float _yrot = 0;
            float _zrot = 0;

            float _xscl = 0;
            float _yscl = 0;
            float _zscl = 0;

            int _dinamicxdir = 1;

            Transform currentObj = ObjectsToModifyTransform[i].ObjectToModify;

            if (ObjectsToModifyTransform[i].NegativeDynamicX) _dinamicxdir = -1;

           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           /*
           if (ObjectsToChangePosition[i].dynamicX)
           {
               _xpos = ObjectsToChangePosition[i].dynamicX ? (-ObjectToFollow.position.y / 5 * 4) * ObjectsToChangePosition[i].PositionOffset.x + ObjectToFollow.position.x : ObjectToFollow.position.x;
           }
           else
           {
               _xpos = ObjectsToChangePosition[i].applyToX ? inicialObjctsToChangePosition[i].x + ObjectToFollow.position.x : inicialObjctsToChangePosition[i].x;
           }



           if (ObjectsToChangePosition[i].dynamicY)
           {
               _ypos = ObjectsToChangePosition[i].dynamicY ? (ObjectToFollow.position.y - (ObjectToFollow.position.y / 5)) * ObjectsToChangePosition[i].PositionOffset.y : ObjectToFollow.position.y;
           }
           else
           {
               _ypos = ObjectsToChangePosition[i].applyToY ? inicialObjctsToChangePosition[i].y + ObjectToFollow.position.y : inicialObjctsToChangePosition[i].y;
           }



           if (ObjectsToChangePosition[i].dynamicZ)
           {
               _zpos = ObjectsToChangePosition[i].dynamicZ ? ObjectToFollow.position.z + ObjectsToChangePosition[i].PositionOffset.z : ObjectToFollow.position.z;
           }
           else
           {
               _zpos = ObjectsToChangePosition[i].applyToZ ? inicialObjctsToChangePosition[i].z + ObjectToFollow.position.z : inicialObjctsToChangePosition[i].z;
           }
           */
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------


           /*
           if (ObjctsToChangePosition[i].dynamicX) _xpos = ObjctsToChangePosition[i].dynamicX ? (-ObjectToFollow.position.y / 5 * 4) * ObjctsToChangePosition[i].PositionOffset.x + ObjectToFollow.position.x : ObjectToFollow.position.x;
           else _xpos = ObjctsToChangePosition[i].applyToX ? inicialObjctsToChangePosition[i].x + ObjectToFollow.position.x : inicialObjctsToChangePosition[i].x;

           if (ObjctsToChangePosition[i].dynamicY) _ypos = ObjctsToChangePosition[i].dynamicY ? (ObjectToFollow.position.y - (ObjectToFollow.position.y / 5)) * ObjctsToChangePosition[i].PositionOffset.y : ObjectToFollow.position.y;
           else _ypos = ObjctsToChangePosition[i].applyToY ? inicialObjctsToChangePosition[i].y + ObjectToFollow.position.y : inicialObjctsToChangePosition[i].y;

           if (ObjctsToChangePosition[i].dynamicZ) _zpos = ObjctsToChangePosition[i].dynamicZ ? ObjectToFollow.position.z + ObjctsToChangePosition[i].PositionOffset.z : ObjectToFollow.position.z;
           else _zpos = ObjctsToChangePosition[i].applyToZ ? inicialObjctsToChangePosition[i].z + ObjectToFollow.position.z : inicialObjctsToChangePosition[i].z;

           _newpos = new Vector3(_xpos, _ypos, _zpos);


           ObjctsToChangePosition[i].ObjctsToChangeTransform.GetChild(0).position = _newpos;
           */


           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
           //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------



           Vector3 _movemnt;
            Vector3 _rotatedmovemnt;

            //CHECK WHAT POSITION TO INCLUDE 
            if (ObjectsToModifyTransform[i].dynamicX) _xpos =  (ObjectToFollow.position.x + inicialObjctsToChangePosition[i].x) + ((ObjectToFollow.position.y / 5 * 4) * _dinamicxdir);
            else _xpos = ObjectsToModifyTransform[i].applyPosToX ? ObjectToFollow.position.x + inicialObjctsToChangePosition[i].x + ObjectsToModifyTransform[i].PositionOffset.x : inicialObjctsToChangePosition[i].x;



            if (ObjectsToModifyTransform[i].dynamicY) _ypos = (ObjectToFollow.position.y - (ObjectToFollow.position.y / 5)) * ObjectsToModifyTransform[i].PositionOffset.y;
            else _ypos = ObjectsToModifyTransform[i].applyPosToY ? ObjectToFollow.position.y : inicialObjctsToChangePosition[i].y;



            if (ObjectsToModifyTransform[i].dynamicZ) _zpos = ObjectToFollow.position.z + inicialObjctsToChangePosition[i].z;
            else _zpos = ObjectsToModifyTransform[i].applyPosToZ ? ObjectToFollow.position.z + inicialObjctsToChangePosition[i].z : inicialObjctsToChangePosition[i].z;


            //CHECK WHAT ROTAION TO INCLUDE 
            _xrot = ObjectsToModifyTransform[i].applyRotToX ? ObjectToFollow.rotation.x  : inicialObjctsToChangeRotation[i].x;
            _yrot = ObjectsToModifyTransform[i].applyRotToY ? ObjectToFollow.rotation.y  : inicialObjctsToChangeRotation[i].y;
            _zrot = ObjectsToModifyTransform[i].applyRotToZ ? ObjectToFollow.rotation.z  : inicialObjctsToChangeRotation[i].z;

            /*
            _yrot = ObjectsToModifyTransform[i].applyRotToY ? inicialObjctsToChangeRotation[i].y + ObjectToFollow.rotation.y : inicialObjctsToChangeRotation[i].y;

            _zrot = ObjectsToModifyTransform[i].applyRotToZ ? inicialObjctsToChangeRotation[i].y + ObjectToFollow.rotation.z : inicialObjctsToChangeRotation[i].z;
            */
            //position to follow
            _movemnt = new Vector3(_xpos, _ypos, _zpos);
            _rotatedmovemnt = Quaternion.Euler(0, ObjectToFollow.rotation.eulerAngles.y, 0) * _movemnt;
            currentObj.position = _rotatedmovemnt;

            if(_rotatedmovemnt.magnitude > 0)
            {
                mDesiredRotation = Mathf.Atan2(_rotatedmovemnt.x, _rotatedmovemnt.z) * Mathf.Rad2Deg;
            }

            //Rotation to follow to follow
            Quaternion _currentrot = new Quaternion(_xrot, _yrot, _zrot, ObjectToFollow.rotation.w);

            Quaternion _currentRotation = _currentrot;
            Quaternion _targetRotation = Quaternion.Euler(0, mDesiredRotation, 0);

            currentObj.position = _movemnt;
            currentObj.rotation = Quaternion.Lerp(_currentRotation, _targetRotation, RotationSpeed * Time.deltaTime);


            //_xpos = (-ObjectToFollow.position.y / 5 * 4) * ObjectsToChangePosition[i].PositionOffset.x + ObjectToFollow.position.x;


            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

            /*
            _newpos = new Vector3(_xpos, _ypos, _zpos);
            ObjectsToChangePosition[i].ObjectToPositionChange.position = _newpos;
            */


            //ObjectsToChangePosition[i].ListOfObjctsForPositionChange.localPosition = ObjectToFollow.position + ObjectsToChangePosition[i].PositionOffset + _newpos;


            //ObjectsToChangePosition[i].ListOfObjctsForPositionChange.GetChild(0).position = Vector3.zero;
        }
    }
    /*
    private void ChangeRotation()
    {
        for (int i = 0; i < ObjectsToChangeRotation.Count; i++)
        {
            float _xrot = ObjectsToChangeRotation[i].applyToX ? inicialObjctsToChangeRotation[i].x + ObjectToFollow.eulerAngles.x : inicialObjctsToChangeRotation[i].x;
            float _yrot = ObjectsToChangeRotation[i].applyToY ? inicialObjctsToChangeRotation[i].y + ObjectToFollow.eulerAngles.y : inicialObjctsToChangeRotation[i].y;
            float _zrot = ObjectsToChangeRotation[i].applyToZ ? inicialObjctsToChangeRotation[i].z + ObjectToFollow.eulerAngles.z : inicialObjctsToChangeRotation[i].z;
            Vector3 _newrot = new Vector3(_xrot, _yrot, _zrot);
            Vector3 _newnewrot = ObjectsToChangeRotation[i].ListOfObjctsForRotationChange.rotation * ObjectToFollow.forward;

            //ObjctsToChangeRotation[i].ObjctsToChangeRotation.eulerAngles = _newrot;


            ObjectsToChangeRotation[i].ListOfObjctsForRotationChange.eulerAngles = _newrot;
        }
    }
    private void ChangeScale()
    {
        for (int i = 0; i < ObjectsToChangeScale.Count; i++)
        {
            float _xscl = ObjectsToChangeScale[i].applyToX ? ObjectToFollow.lossyScale.x : inicialObjctsToChangeScale[i].x;
            float _yscl = ObjectsToChangeScale[i].applyToY ? ObjectToFollow.lossyScale.y : inicialObjctsToChangeScale[i].y;
            float _zscl = ObjectsToChangeScale[i].applyToZ ? ObjectToFollow.lossyScale.z : inicialObjctsToChangeScale[i].z;
            Vector3 _newscl = new Vector3(_xscl, _yscl, _zscl);

            ObjectsToChangeScale[i].ListOfObjctsForScaleChange.localScale = _newscl;
        }
    }*/
}
