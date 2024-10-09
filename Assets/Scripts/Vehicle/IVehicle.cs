using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public interface IVehicle
{
    public enum VehicleType
    {
        Standard,
        Sport,
        Family,
        Bus,
        Truck
    }

    public enum CameraMode
    { 
        Side,
        Back
    }

    public float XBound { get; set; }
    public float MaxSpeed { get; set; }
    public float HorsePower { get; set; }
    public float JumpForce { get; set; }
    public float TurnSpeed { get; set; }

    public string VehicleName { get; set; }
    public VehicleType Type { get; set; }
    public Color BodyColor { get; set; }

    public Vector3 CameraOffset { get; set; }
    public Rigidbody Rb { get; set; }

    public float VInput { get; set; }
    public float HInput { get; set; }

    public void Initialize();

    public void Drive();

    public void Jump();

    public void Turn();

    public void SetXBound();
}
