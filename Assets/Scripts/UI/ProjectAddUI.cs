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
            logText.text = "�Է��� �ؽ�Ʈ�� �����Դϴ�.";
            return;
        }

        var client = new GitHubClient(new Octokit.ProductHeaderValue("BugEliminatedGame"));
        var commits = await client.Repository.Commit.GetAll(repoOwner, repoName);
        var commitCount = commits.Count;

        if (commitCount == 0)
        {
            logText.text = "�ش� ������Ʈ�� �������� �ʽ��ϴ�.";
            return;
        }

        ModelHolder.I.Player.AddProject(repoOwner, repoName, commitCount);
        root.SetActive(false);
    }
}
