using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProject
{
    public int BugCount { get; private set; };
    public int LastCommitCount { get; private set; }

    public readonly string GithubRepositoryOwner;
    public readonly string GithubRepositoryName;

    public readonly int MAX_BUG_COUNT = 999999;

    public GameProject(string repositoryOwner, string repositoryName, int lastCommitCount)
    {
        GithubRepositoryOwner = repositoryOwner;
        GithubRepositoryName = repositoryName;
    }

    public void AddBug(int amount)
    {
        BugCount += amount;
        if (BugCount > MAX_BUG_COUNT)
        {
            BugCount = MAX_BUG_COUNT;
        }
        UpdateBugCountUI();
    }

    public void SubtractBugWithChangeCount(int newCommitCount, int currentCommitCount)
    {
        LastCommitCount = currentCommitCount;
        BugCount -= newCommitCount * 100;
        if (BugCount < 0)
        {
            BugCount = 0;
        }
        UpdateBugCountUI();
    }

    private void UpdateBugCountUI()
    {
        // TODO: 이 프로젝트 선택중일때만 갱신
        UIHolder.I.BugCountUI.ApplyBugCount(BugCount);
    }
}
