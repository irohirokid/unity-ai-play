using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Data data;
    Logic logic;

    void Awake()
    {
        data = ScriptableObject.CreateInstance<Data>();
        data.OnPositionChanged += Move;

        logic = new Logic();
        logic.Setup(data);

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
        data.OnPositionChanged -= Move;
    }

    void Move(Vector3 previous, Vector3 current)
    {
        transform.position = current;
    }
}
