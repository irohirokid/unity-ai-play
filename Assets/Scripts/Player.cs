using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerLogic logic;
    PlayerData data;

    void Awake()
    {
        data = ScriptableObject.CreateInstance<PlayerData>();
        data.Position.OnValueChanged += Move;

        DataRepository dataRepo = DataRepository.Instance;
        dataRepo.Player = data;

        logic = new PlayerLogic();
        logic.Setup(dataRepo);

        Application app = GameObject.Find("Application").GetComponent<Application>();
        app.Intelligents.Add((IIntelligent)logic);

        InputManager inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
        inputManager.Setup(logic);
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
