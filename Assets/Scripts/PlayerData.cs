using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : ScriptableObject
{
    public Vector3 Destination;

    public ObservableVariable<Vector3> Position = new ObservableVariable<Vector3>();

    void Awake()
    {
        Destination = Position.Value = new Vector3(0, 0.5f, 0);
    }

    public bool HasWayToGo()
    {
        return Position.Value != Destination;
    }

    public void Walk()
    {
        Vector3 offset = Destination - Position.Value;
        if (offset.sqrMagnitude > 0.01f)
        {
            Position.Value = Position.Value + offset.normalized * 0.1f;
        } else {
            Position.Value = Destination;
        }
    }
}
