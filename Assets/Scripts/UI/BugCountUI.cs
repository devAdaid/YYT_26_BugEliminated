using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugCountUI : MonoBehaviour
{
    [SerializeField]
    private Text bugText = null;

    public void SetActive(bool active)
    {
        bugText.gameObject.SetActive(active);
    }

    public void ApplyBugCount(int bugCount)
    {
        bugText.text = $"BUG: {bugCount}";
    }
}