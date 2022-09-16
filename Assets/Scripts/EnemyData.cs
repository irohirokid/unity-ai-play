using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : ScriptableObject
{
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
        Position = new Vector3(6.18f, 0.5f, 0);
    }
}
