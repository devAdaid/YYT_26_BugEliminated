using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugView : MonoBehaviour
{
    [SerializeField]
    private GameObject bugPrefab;

    private List<GameObject> bugs;

    public void ApplyBugCount(int count)
    {
        var addCount = bugs.Count - count;
        while (addCount > 0)
        {
            var bug = Instantiate(bugPrefab, transform);
            bug.transform.position = Vector3.zero;
            bug.GetComponent<Rigidbody2D>().velocity = new Vector2(0.2f, -0.2f);
            bugs.Add(bug);

            addCount -= 1;
        }
    }
}
