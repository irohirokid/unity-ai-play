using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour
{
    public List<IIntelligent> Intelligents = new List<IIntelligent>();
    public GameObject goldPrefab;

    public void Init()
    {
        Player player = GameObject.Find("Player").GetComponent<Player>();
        player.Init();
        player.StartAI();
        GameObject.Find("Enemy").GetComponent<Enemy>().Init();
    }

    void Start()
    {
        foreach (IIntelligent i in Intelligents)
        {
            StartCoroutine(i.Behaviour());
        }
    }

    void Update()
    {
        Tick();
    }

    public void Tick()
    {
        foreach (IIntelligent i in Intelligents)
        {
            i.DoAction();
        }
    }

    public void Reset()
    {
        Intelligents.Clear();
        GameObject.Find("Enemy").GetComponent<Enemy>().Reset();
        GameObject.Find("Player").GetComponent<Player>().Reset();
    }

    public void PlaceGold()
    {
        foreach (var gold in GameObject.FindGameObjectsWithTag("Gold"))
        {
            DestroyImmediate(gold);
        }

        for (int i = 0; i < World.goldCount; i++)
        {
            Instantiate(goldPrefab, World.Golds[i].Position, goldPrefab.transform.rotation);
        }
    }
}
