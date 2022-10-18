using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyLogic logic;
    EnemyData data;

    void Awake()
    {
        Init();
    }

    public void Reset()
    {
        transform.position = EnemyData.InitialPosition;
    }

    public void Init()
    {
        data = ScriptableObject.CreateInstance<EnemyData>();
        data.Position.OnValueChanged += Move;

        DataRepository dataRepo = DataRepository.Instance;
        dataRepo.Enemy = data;

        logic = new EnemyLogic();
        logic.Setup(dataRepo);

        GameManager app = GameObject.Find("GameManager").GetComponent<GameManager>();
        app.Intelligents.Add((IIntelligent)logic);
    }

    void OnDestroy()
    {
        data.Position.OnValueChanged -= Move;
    }

    void Move(Vector3 previous, Vector3 current)
    {
        transform.position = current;
    }
}
