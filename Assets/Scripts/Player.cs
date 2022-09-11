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
    }

    void Update()
    {
        float dv = Input.GetAxis("Vertical");
        logic.OnMove(0, dv);
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
