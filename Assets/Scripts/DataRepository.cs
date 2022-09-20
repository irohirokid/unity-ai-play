using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class DataRepository
{
    private DataRepository()
    {
    }

    private static readonly Lazy<DataRepository> _instance = new Lazy<DataRepository>(() => new DataRepository());

    public static DataRepository Instance
    {
        get
        {
            return _instance.Value;
        }
    }

    public PlayerData Player;
    public EnemyData Enemy;
}
