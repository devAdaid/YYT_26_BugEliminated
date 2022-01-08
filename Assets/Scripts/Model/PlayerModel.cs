using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    public GameProject Project;

    public PlayerModel()
    {
        Project = new GameProject("devAdaid", "YYT_26_BugEliminated", 0);
        NetworkConnectorHolder.I.AddConnector(new GithubRepositoryConnector(Project));
    }
}
