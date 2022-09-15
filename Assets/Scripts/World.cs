using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class World
{
    public static readonly Plane Plane;

    static World()
    {
        Plane = new Plane(new Vector3(0, 1, 0), 0);
    }
}
