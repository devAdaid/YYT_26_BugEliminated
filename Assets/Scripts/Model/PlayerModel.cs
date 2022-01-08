using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public GameProject Project;

    public PlayerModel()
    {
    }

    public void AddProject(string repositoryOwner, string repositoryName, int lastCommitCount)
    {
        Project = new GameProject(repositoryOwner, repositoryName, lastCommitCount);
        NetworkConnectorHolder.I.AddConnector(new GithubRepositoryConnector(Project, NetworkConnectorHolder.I.Client));

        UIHolder.I.BugCountUI.SetActive(true);
        UIHolder.I.BugCountUI.ApplyBugCount(Project.BugCount);
        BugAdder.I.StartAddBug();
    }
}
