using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic
{
    PlayerData data;
    public Action CurrentAction;

    public void Setup(PlayerData _data)
    {
        data = _data;
    }

    public void OnClick(Ray ray)
    {
        float enter = 0.0f;

        if (World.Plane.Raycast(ray, out enter))
        {
            data.Destination = ray.GetPoint(enter) + new Vector3(0, 0.5f, 0);
        }
    }

    public IEnumerator Behaviour()
    {
        while (true)
        {
            makeDecision();
            yield return new WaitUntil(needDecision);
        }
    }

    void makeDecision()
    {
        CurrentAction = () => data.Walk();
    }

    bool needDecision()
    {
        return !data.HasWayToGo();
    }
}
