using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class World
{
    public const int goldCount = 7;
    public const float FieldRange = 12f;

    public static readonly Plane Plane;
    public static Gold[] Golds { get => golds; }

    private static Gold[] golds = new Gold[goldCount];

    static World()
    {
        Plane = new Plane(new Vector3(0, 1, 0), 0);
    }

    public static void ResetGold()
    {
        for (int i = 0; i < goldCount; i++)
        {
            Vector3 randomPosition = new Vector3(Random.Range(-FieldRange, FieldRange), 0.25f, Random.Range(-FieldRange, FieldRange));
            golds[i] = new Gold(randomPosition);
        }
    }
}
