using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold
{
    public Vector3 Position { get => position; }

    Vector3 position;

    public Gold(Vector3 _position)
    {
        position = _position;
    }
}
