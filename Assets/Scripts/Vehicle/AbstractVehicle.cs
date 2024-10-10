using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using static IVehicle;
using UnityEditor.IMGUI.Controls;

public abstract class AbstractVehicle : MonoBehaviour, IVehicle
{
    private Vector3[,] _camModes =
    {
        {
            new Vector3(13, 9, 9),
            new Vector3(18, -90, 0)
        },
        {
            new Vector3(0, 3, -7),
            new Vector3(0,0,0)
        }
    };

    private CameraMode _camMode;

    [SerializeField]
    private float _xBound;
    public float XBound
    {
        get { return _xBound; }
        set { _xBound = value; }
    }

    [SerializeField]
    private float _maxSpeed;
    public float MaxSpeed
    {
        get { return _maxSpeed; }
        set { _maxSpeed = value; }
    }

    [SerializeField]
    private float _horsePower;
    public float HorsePower
    {
        get { return _horsePower; }
        set { _horsePower = value; }
    }

    [SerializeField]
    private float _jumpForce;
    public float JumpForce
    {
        get { return _jumpForce; }
        set { _jumpForce = value; }
    }

    [SerializeField]
    private float _turnSpeed;
    public float TurnSpeed
    {
        get { return _turnSpeed; }
        set { _turnSpeed = value; }
    }

    [SerializeField]
    private string _vehicleName;
    public string VehicleName
    {
        get { return _vehicleName; }
        set { _vehicleName = value; }
    }

    [SerializeField]
    private VehicleType _type;
    public VehicleType Type
    {
        get { return _type; }
        set { _type = value; }
    }
    public Color BodyColor { get; set; }

    public Vector3 CameraOffset { get; set; }
    public Rigidbody Rb { get; set; }

    public float VInput { get; set; }
    public float HInput { get; set; }

    private void Awake()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        Drive();
        Jump();
        Turn();
        SwitchCameraMode();
    }

    private void LateUpdate()
    {
        UpdateCameraPos();
    }

    public virtual void Initialize()
    {
        XBound = 4.0f;
        MaxSpeed = 100.0f;
        HorsePower = 3000.0f;
        JumpForce = 5000.0f;
        TurnSpeed = 0.02f;
        VehicleName = "New Vehicle";
        Type = VehicleType.Standard;
        BodyColor = Color.white;
        Rb = GetComponent<Rigidbody>();
        UpdateCameraOffset(CameraMode.Side);
    }

    public virtual void Drive()
    {
        VInput = Input.GetAxis("Vertical");
        Rb.AddForce(Vector3.forward * HorsePower * VInput, ForceMode.Force);
    }

    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }

    public virtual void Turn()
    {
        HInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * TurnSpeed * HInput, Space.World);
        SetXBound();
    }

    public void SetXBound()
    {
        if (transform.position.x > XBound)
        {
            transform.position = new Vector3(XBound, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -XBound)
        {
            transform.position = new Vector3(-XBound, transform.position.y, transform.position.z);
        }
    }

    public void UpdateCameraPos()
    {
        Vector3 camPos = Camera.main.transform.position;
        Camera.main.transform.position = new Vector3(camPos.x, camPos.y, transform.position.z + CameraOffset.z);
    }

    public void SwitchCameraMode()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            switch (_camMode)
            {
                case CameraMode.Side:
                    _camMode = CameraMode.Back;
                    break;
                case CameraMode.Back:
                    _camMode = CameraMode.Side;
                    break;
            }

            UpdateCameraOffset();
        }
    }

    private void UpdateCameraOffset()
    {
        CameraOffset = _camModes[(int)_camMode, 0];
        Camera.main.transform.position = _camModes[(int)_camMode, 0];
        Camera.main.transform.rotation = Quaternion.Euler(_camModes[(int)_camMode, 1]);
    }

    private void UpdateCameraOffset(CameraMode camMode)
    {
        _camMode = camMode;
        UpdateCameraOffset();
    }
}
