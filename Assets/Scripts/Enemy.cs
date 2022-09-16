using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyData data;
    EnemyLogic logic;

    void Awake()
    {
        data = ScriptableObject.CreateInstance<EnemyData>();
        data.OnPositionChanged += Move;

        logic = new EnemyLogic();
        logic.Setup(data);
    }

    void Start()
    {
        StartCoroutine(logic.Behaviour());
    }

    void Update()
    {
        logic.CurrentAction();
    }

    void OnDestroy()
    {
        data.OnPositionChanged -= Move;
    }

    void Move(Vector3 previous, Vector3 current)
    {
        transform.position = current;
    }
}
