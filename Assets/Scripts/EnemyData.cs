using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : ScriptableObject
{
    public Vector3 TargetPoint;

    public ObservableVariable<Vector3> Position = new ObservableVariable<Vector3>();

    void Awake()
    {
        Position.Value = new Vector3(6.18f, 0.5f, 0);
    }

    public void Chase()
    {
        Position.Value = Position.Value + (TargetPoint - Position.Value).normalized * 0.12f;
    }

    public bool didFinishAction()
    {
        return (TargetPoint - Position.Value).sqrMagnitude < 1;
    }
}
