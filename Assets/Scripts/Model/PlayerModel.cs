using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public GameProject GameProject;

    public PlayerModel()
    {
    }

    public void AddProject(string repositoryOwner, string repositoryName, int lastCommitCount)
    {
        GameProject = new GameProject(repositoryOwner, repositoryName, lastCommitCount);
        NetworkConnectorHolder.I.AddConnector(new GithubRepositoryConnector(GameProject));

        UIHolder.I.BugCountUI.SetActive(true);
        UIHolder.I.BugCountUI.ApplyBugCount(GameProject.BugCount);
        UIHolder.I.BugView.ApplyBugCount(GameProject.BugCount);
        BugAdder.I.StartAddBug();
    }
}
