using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAdder : MonoBehaviour
{
    private float waitedTime = 0f;

    private static readonly float BUG_ADD_TIME_SECONDS = 5f;

    void Update()
    {
        waitedTime += Time.deltaTime;

        if (waitedTime > BUG_ADD_TIME_SECONDS)
        {
            waitedTime -= BUG_ADD_TIME_SECONDS;
            ModelHolder.I.Player.Project.AddBug(1);
        }
    }
}
