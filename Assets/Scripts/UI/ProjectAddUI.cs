using Octokit;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ProjectAddUI : MonoBehaviour
{
    [SerializeField]
    private GameObject root = null;
    [SerializeField]
    private InputField ownerInput = null;
    [SerializeField]
    private InputField nameInput = null;
    [SerializeField]
    private Text logText = null;

    public async void TryAddProject()
    {
        var repoOwner = ownerInput.text;
        var repoName = nameInput.text;

        await TryAddProject(repoOwner, repoName);
    }

    private async Task TryAddProject(string repoOwner, string repoName)
    {
        if (string.IsNullOrEmpty(repoOwner) || string.IsNullOrEmpty(repoName))
        {
            logText.text = "입력한 텍스트가 공백입니다.";
            return;
        }

        var client = new GitHubClient(new Octokit.ProductHeaderValue("BugEliminatedGame"));
        var commits = await client.Repository.Commit.GetAll(repoOwner, repoName);
        var commitCount = commits.Count;

        if (commitCount == 0)
        {
            logText.text = "해당 프로젝트가 존재하지 않습니다.";
            return;
        }

        ModelHolder.I.Player.AddProject(repoOwner, repoName, commitCount);
        root.SetActive(false);
    }
}
