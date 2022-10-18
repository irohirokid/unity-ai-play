using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Player : MonoBehaviour
{
    PlayerLogic logic;
    PlayerData data;

    void Awake()
    {
        if (Application.IsPlaying(this))
        {
            Init();

            InputManager inputManager = GameObject.Find("Input Manager").GetComponent<InputManager>();
            inputManager.Setup(logic);
        }
    }

    public void Init()
    {
        data = ScriptableObject.CreateInstance<PlayerData>();
        data.Position.OnValueChanged += Move;

        DataRepository dataRepo = DataRepository.Instance;
        dataRepo.Player = data;

        logic = new PlayerLogic();
        logic.Setup(dataRepo);

        GameManager app = GameObject.Find("GameManager").GetComponent<GameManager>();
        app.Intelligents.Add((IIntelligent)logic);
    }

    public void StartAI()
    {
        GameManager app = GameObject.Find("GameManager").GetComponent<GameManager>();
        DataRepository dataRepo = DataRepository.Instance;

        PlayerAI ai = new PlayerAI();
        ai.Setup(dataRepo, logic);
        app.Intelligents.Add((IIntelligent)ai);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Gold")
        {
            collision.gameObject.SetActive(false);
        }
    }

    void OnDestroy()
    {
        data.Position.OnValueChanged -= Move;
    }

    void Move(Vector3 previous, Vector3 current)
    {
        transform.position = current;
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 0.5f, 0);
    }
}
