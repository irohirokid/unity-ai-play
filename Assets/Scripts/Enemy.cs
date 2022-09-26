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
        data = ScriptableObject.CreateInstance<EnemyData>();
        data.Position.OnValueChanged += Move;

        DataRepository dataRepo = DataRepository.Instance;
        dataRepo.Enemy = data;

        logic = new EnemyLogic();
        logic.Setup(dataRepo);
    }

    void Start()
    {
        StartCoroutine(((IIntelligent)logic).Behaviour());
    }

    void Update()
    {
        logic.CurrentAction();
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
