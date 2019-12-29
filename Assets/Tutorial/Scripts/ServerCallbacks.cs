using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[BoltGlobalBehaviour(BoltNetworkModes.Server)]
public class ServerCallbacks : Bolt.GlobalEventListener
{
    List<string> leaderboard = new List<string>();
    public override void OnEvent(SelectEvent evnt)
    {
        //logMessages.Insert(0, evnt.Selected);
        BoltLog.Info(evnt.Selected);
    }
    public override void Connected(BoltConnection connection)
    {
        leaderboard.Add(connection.RemoteEndPoint.ToString());
        var players = UpdatePlayersEvent.Create();
        players.Players = formattedLeaderboard();
        players.Send();
    }

    string formattedLeaderboard()
    {
        string output = "";
        foreach (string name in leaderboard)
        {
            output += name + "\n";
        }
        Debug.Log("returning " + output);
        return output;
    }

    public override void Disconnected(BoltConnection connection)
    {
        var log = LogEvent.Create();
        log.Message = connection.RemoteEndPoint.ToString();
        log.Send();
    }
}
