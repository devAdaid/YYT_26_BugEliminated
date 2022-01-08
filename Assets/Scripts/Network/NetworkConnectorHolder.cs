using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Octokit;

public class NetworkConnectorHolder : MonoSingleton<NetworkConnectorHolder>
{
    public GitHubClient Client
    {
        get
        {
            if (client == null)
            {
                client = new GitHubClient(new Octokit.ProductHeaderValue("BugEliminatedGame"));
            }
            return client;
        }
    }
    private GitHubClient client;

    private readonly List<GithubRepositoryConnector> repositoryConnectors = new List<GithubRepositoryConnector>();

    private float waitedTimeSeconds;
    private static readonly float UPDATE_SECONDS = 3f;

    private void Update()
    {
        waitedTimeSeconds += Time.deltaTime;
        if (waitedTimeSeconds > UPDATE_SECONDS)
        {
            foreach (var connector in repositoryConnectors)
            {
                var result = connector.GetDataAndUpdate();
            }
            waitedTimeSeconds -= UPDATE_SECONDS;
        }
    }

    public void AddConnector(GithubRepositoryConnector connector)
    {
        repositoryConnectors.Add(connector);
    }

    public void RemoveConnector(GithubRepositoryConnector connector)
    {
        repositoryConnectors.Remove(connector);
    }
}
