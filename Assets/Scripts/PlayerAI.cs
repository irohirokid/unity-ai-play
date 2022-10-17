using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAI : IIntelligent
{
    DataRepository data;
    PlayerLogic logic;

    public void Setup(DataRepository _data, PlayerLogic _logic)
    {
        data = _data;
        logic = _logic;
    }

    public void DoAction()
    {
    }

    public void makeDecision()
    {
        int randIndex = Random.Range(0, World.Golds.Length);
        Vector3 randGoldPos = World.Golds[randIndex].Position;
        logic.OnClick(new Vector3(randGoldPos.x, 0, randGoldPos.z));
    }

    public bool needDecision()
    {
        return !data.Player.HasWayToGo();
    }
}
