using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logic
{
    Data data;

    public void Setup(Data _data)
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

    public void Tick()
    {
        if (data.HasWayToGo())
        {
            data.Walk();
        }
    }
}
