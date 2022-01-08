using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugCountUI : MonoBehaviour
{
    [SerializeField]
    private Text bugText;

    public void ApplyBugCount(int bugCount)
    {
        bugText.text = $"BUG: {bugCount}";
    }
}