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
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            logic.OnClick(ray);
        }
    }
}
