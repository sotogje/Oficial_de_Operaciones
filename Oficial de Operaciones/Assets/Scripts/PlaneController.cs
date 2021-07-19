using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{
    [System.Serializable]
    public class Axleinfo
    {
        public string Name;
        public List<WheelCollider> WheelNum;
        public List<GameObject> WheelGeometry;
        /*
        public WheelCollider RightWheel;
        public WheelCollider LeftWheel;
        */

        public bool Motor;
        public bool Steering;
    }

    public List<Axleinfo> AxleInfos = new List<Axleinfo>();
    public float maxSteeringAngles;
    public float TorquePower;
    public float TurnPower;

    public float centerMass;
    private Rigidbody rb;

    public float setSpeed;
    public float speed;


    public string DirectionMovineg;
    private ResultText ResultText_Script;
    [SerializeField] private float ForwardSpeed = 0;
    [SerializeField] private float TurnSpeed = 0;



    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ResultText_Script = FindObjectOfType<ResultText>();
    }
    private void CheckForOrders()
    {
        DirectionMovineg = ResultText_Script.Command.text;
        switch (DirectionMovineg)
        {
            case "Turn Right":
                TurnSpeed = 1;
                break;
            case "Turn Left":
                TurnSpeed = -1;
                break;
            case "Forward":
                TurnSpeed = 0;
                break;
            case "Stop":
                ForwardSpeed = 0;
                TurnSpeed = 0;
                break;
            default:
                ForwardSpeed = 1;
                TurnSpeed = 0;
                break;
        }
    }
    void FixedUpdate()
    {
        CheckForOrders();

        rb.centerOfMass = new Vector3(0, centerMass, 0);
        float _motor = ForwardSpeed;
        float _steering = maxSteeringAngles * TurnSpeed;

        foreach (Axleinfo axleinfo in AxleInfos)
        {
            if(axleinfo.Steering == true)
            {
                for(int i=0; i<axleinfo.WheelNum.Capacity; i++)
                {
                    axleinfo.WheelNum[i].steerAngle = _steering;
                    SetWheelGeometryPos(axleinfo.WheelNum[i], axleinfo.WheelGeometry[i]);
                }
            }
            if(axleinfo.Motor == true)
            {
                for (int i = 0; i < axleinfo.WheelNum.Capacity; i++)
                {
                    axleinfo.WheelNum[i].motorTorque = _motor * TorquePower;
                    SetWheelGeometryPos(axleinfo.WheelNum[i], axleinfo.WheelGeometry[i]);
                }
            }
        }
    }

    public void SetWheelGeometryPos(WheelCollider _wheelcolider, GameObject _wheelgeometry)
    {
        speed = rb.velocity.magnitude;

        if (_wheelcolider != false)
        {
            Vector3 _position = _wheelcolider.transform.position;
            Quaternion _rotaion = _wheelcolider.transform.rotation;

            _wheelcolider.GetWorldPose(out _position, out _rotaion);

            _wheelgeometry.transform.position = _position;
            _wheelgeometry.transform.rotation = _rotaion;
        }
    }
}
