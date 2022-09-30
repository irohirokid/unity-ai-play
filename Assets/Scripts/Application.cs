using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour
{
    public List<IIntelligent> Intelligents = new List<IIntelligent>();
    public GameObject goldPrefab;

    void Start()
    {
        placeGold();

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

    void placeGold()
    {
        World.ResetGold();

        for (int i = 0; i < World.goldCount; i++)
        {
            Instantiate(goldPrefab, World.Golds[i].Position, goldPrefab.transform.rotation);
        }
    }
}
