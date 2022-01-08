using System.Collections;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using Octokit;

public class GithubRepositoryConnector
{
    private GameProject project;

    public GithubRepositoryConnector(GameProject gameProject)
    {
        this.project = gameProject;
    }

    public async Task GetDataAndUpdate()
    {
        var client = new GitHubClient(new Octokit.ProductHeaderValue("BugEliminatedGame"));
        //var repository = await client.Repository.Get(repositoryOwner, repositoryName);
        var commits = await client.Repository.Commit.GetAll(project.GithubRepositoryOwner, project.GithubRepositoryName);

        var newCommitCount = commits.Count - project.LastCommitCount;
        if (newCommitCount < 0) newCommitCount = 0;

        //Debug.Log($"[Github] {project.GithubRepositoryOwner}/{project.GithubRepositoryName} Changes: {newCommitCount}");

        project.SubtractBugWithChangeCount(newCommitCount, commits.Count);
    }
}