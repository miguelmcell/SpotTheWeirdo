using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[BoltGlobalBehaviour(BoltNetworkModes.Server)]
public class ServerCallbacks : Bolt.GlobalEventListener
{
    
    public override void Connected(BoltConnection connection)
    {
        Debug.Log("ADDED NEW PLAYER -> ");
        //var players = UpdatePlayersEvent.Create();
        //players.Players = formattedLeaderboard();
        //players.Send();
    }

 

    public override void Disconnected(BoltConnection connection)
    {
        var log = LogEvent.Create();
        log.Message = connection.RemoteEndPoint.ToString();
        log.Send();
    }
}
