using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IIntelligent
{
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
