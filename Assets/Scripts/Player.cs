using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerLogic logic;

    void Awake()
    {
        World.Player = ScriptableObject.CreateInstance<PlayerData>();
        World.Player.OnPositionChanged += Move;

        logic = new PlayerLogic();
        logic.Setup(World.Player);

        InputManager inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        inputManager.Setup(logic);
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
        World.Player.OnPositionChanged -= Move;
    }

    void Move(Vector3 previous, Vector3 current)
    {
        transform.position = current;
    }
}
