using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAdder : MonoSingleton<BugAdder>
{
    [SerializeField]
    private float waitedTime = 0f;
    [SerializeField]
    private bool canAdd;

    private static readonly float BUG_ADD_TIME_SECONDS = 5f;
    

    public void StartAddBug()
    {
        canAdd = true;
    }

    public void StopAddBug()
    {
        canAdd = false;
        waitedTime = 0f;
    }

    void Update()
    {
        if (!canAdd) return;

        waitedTime += Time.deltaTime;

        if (waitedTime > BUG_ADD_TIME_SECONDS)
        {
            waitedTime -= BUG_ADD_TIME_SECONDS;
            ModelHolder.I.Player.GameProject.AddBug(1);
        }
    }
}
