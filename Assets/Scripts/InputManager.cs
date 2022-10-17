using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    PlayerLogic logic;

    public void Setup(PlayerLogic _logic)
    {
        logic = _logic;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float enter = 0.0f;
            if (World.Plane.Raycast(ray, out enter))
            {
                logic.OnClick(ray.GetPoint(enter));
            }
        }
    }
}
