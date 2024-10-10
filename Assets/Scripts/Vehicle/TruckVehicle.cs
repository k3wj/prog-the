using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckVehicle : AbstractVehicle
{
    public override void Initialize()
    {
        base.Initialize();

        MaxSpeed = 120.0f;
        HorsePower = 8500.0f;
        JumpForce = 3000.0f;
        TurnSpeed = 0.05f;
        VehicleName = "Truck";
    }

    public override void Jump()
    {
        // Truck cannot jump, unfortunatelly ...
    }
}
