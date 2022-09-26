using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour
{
    public List<IIntelligent> Intelligents = new List<IIntelligent>();

    void Start()
    {
        foreach (IIntelligent i in Intelligents)
        {
            StartCoroutine(i.Behaviour());
        }
    }

    void Update()
    {
        foreach (IIntelligent i in Intelligents)
        {
            i.DoAction();
        }
    }
}
