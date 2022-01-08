using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelHolder : MonoSingleton<ModelHolder>
{
    public PlayerModel Player;

    private void Awake()
    {
        Player = new PlayerModel();

        InitializeUI();
    }

    private void InitializeUI()
    {
        UIHolder.I.BugCountUI.SetActive(false);
    }
}