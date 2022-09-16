using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EnemyLogic logic;

    void Awake()
    {
        World.Enemy = ScriptableObject.CreateInstance<EnemyData>();
        World.Enemy.OnPositionChanged += Move;

        logic = new EnemyLogic();
        logic.Setup(World.Enemy);
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
        World.Enemy.OnPositionChanged -= Move;
    }

    void Move(Vector3 previous, Vector3 current)
    {
        transform.position = current;
    }
}
