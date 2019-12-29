using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeaderboardBehaviour : Bolt.EntityEventListener<ILeaderboardState>
{
    public Text text;
    List<string> names = new List<string>();
    private string playerName;
    public Text debugText;
    public string getPlayerName()
    {
        return playerName;
    }
    public override void Attached()
    {
        text = GetComponent<Text>();
        debugText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<Text>();
        state.AddCallback("LeaderboardText", LeaderboardTextCallback);
        state.AddCallback("DebugText", DebugTextCallback);
        var newPlayer = NewPlayerEvent.Create(entity);
        playerName = "Name" + (int)Random.Range(1, 10) + "\n";
        
        newPlayer.Name = playerName;
        newPlayer.Send();
    }

    string formattedLeaderboard()
    {
        string output = "";
        int count = 1;
        foreach (string name in names)
        {
            output += count + ": " + name + "\n";
            count++;
        }
        return output;
    }
    public override void OnEvent(NewPlayerEvent evnt)
    {
        if (entity.IsOwner)
        {
            names.Add(evnt.Name);
            state.LeaderboardText = formattedLeaderboard();
        }
    }
    public override void OnEvent(SelectEvent evnt)
    {
        if (entity.IsOwner)
        {
            state.DebugText = evnt.Selected;
        }
    }
    public void changeDebugText(string txt)
    {
        var selectingEvent = SelectEvent.Create();
        selectingEvent.Selected = txt;
        selectingEvent.Send();
    }

    private void LeaderboardTextCallback()
    {
        text.text = state.LeaderboardText;
    }
    private void DebugTextCallback()
    {
        debugText.text = state.DebugText;
    }

    public override void SimulateOwner()
    {
        //if (timer > 2)
        //{
        //    timer = 0;
        //    state.LeaderboardText = "okay " + (int)Random.Range(1, 10);
        //}
        //timer += Time.deltaTime;
    }
}
