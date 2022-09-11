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

    public void OnMove(float deltaHorizontal, float deltaVertical)
    {
        Vector3 p = data.Position;
        data.Position = new Vector3(p.x + deltaHorizontal, p.y, p.z + deltaVertical);
    }
}
