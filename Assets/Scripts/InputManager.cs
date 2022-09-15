using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Logic logic;

    public void Setup(Logic _logic)
    {
        logic = _logic;
    }

    void Update()
    {
        float dv = Input.GetAxis("Vertical");
        logic.OnMove(0, dv);
    }
}
