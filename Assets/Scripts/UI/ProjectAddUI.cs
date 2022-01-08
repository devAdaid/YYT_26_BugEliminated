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

    public void TryAddProject()
    {
        var repoOwner = ownerInput.text;
        var repoName = nameInput.text;

        var _ = TryAddProject(repoOwner, repoName);
    }

    private async Task TryAddProject(string repoOwner, string repoName)
    {
        if (string.IsNullOrEmpty(repoOwner) || string.IsNullOrEmpty(repoName))
        {
            logText.text = "�Է��� �ؽ�Ʈ�� �����Դϴ�.";
            return;
        }

        var commits = await NetworkConnectorHolder.I.Client.Repository.Commit.GetAll(repoOwner, repoName);
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
