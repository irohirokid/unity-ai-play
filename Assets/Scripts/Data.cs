using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : ScriptableObject
{
    public Vector3 Destination;

    Vector3 _position;

    public event Action<Vector3, Vector3> OnPositionChanged;

    public Vector3 Position
    {
        get => _position;
        set
        {
            if (value != _position)
            {
                Vector3 previous = _position;
                _position = value;
                OnPositionChanged?.Invoke(previous, _position);
            }
        }
    }

    void Awake()
    {
        Destination = Position = new Vector3(0, 0.5f, 0);
    }

    public bool HasWayToGo()
    {
        return Position != Destination;
    }

    public void Walk()
    {
        Vector3 offset = Destination - Position;
        if (offset.sqrMagnitude > 0.01f)
        {
            Position = Position + offset.normalized * 0.1f;
        } else {
            Position = Destination;
        }
    }
}
