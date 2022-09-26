using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : IIntelligent
{
    public Action CurrentAction;
    DataRepository data;

    public void Setup(DataRepository _data)
    {
        data = _data;
    }

    public void OnClick(Ray ray)
    {
        float enter = 0.0f;

        if (World.Plane.Raycast(ray, out enter))
        {
            data.Player.Destination = ray.GetPoint(enter) + new Vector3(0, 0.5f, 0);
        }
    }

    public void makeDecision()
    {
        CurrentAction = () => data.Player.Walk();
    }

    public bool needDecision()
    {
        return !data.Player.HasWayToGo();
    }
}
