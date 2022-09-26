using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IIntelligent
{
    void DoAction();
    void makeDecision();
    bool needDecision();

    public IEnumerator Behaviour()
    {
        while (true)
        {
            makeDecision();
            yield return new WaitUntil(needDecision);
        }
    }
}
