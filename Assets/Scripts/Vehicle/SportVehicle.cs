using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SportVehicle : AbstractVehicle // INHERITANCE
{
    public override void Initialize() // POLYMORPHISM
    {
        base.Initialize();

        MaxSpeed = 300.0f;
        HorsePower = 6000.0f;
        JumpForce = 5800.0f;
        TurnSpeed = 0.04f;
        VehicleName = "Sport Car";
    }
}
