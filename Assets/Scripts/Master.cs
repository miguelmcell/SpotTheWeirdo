using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[BoltGlobalBehaviour]
public class Master : Bolt.GlobalEventListener
{
    public Text timerText;
    public Text leaderboardText;
    string players = "";
    
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
        leaderboardText = GameObject.FindGameObjectWithTag("Leaderboard").GetComponent<Text>();
    }
    public override void OnEvent(UpdatePlayersEvent evnt)
    {
        try
        {
            Debug.Log("THIS IS ON SERVER " + evnt.Players);
            players = evnt.Players;
            leaderboardText.text = evnt.Players;
        } catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (timer > 0)
        //{
        //    timerText.text = (Mathf.Ceil(Mathf.Clamp(timer, 0, 3))).ToString();
        //    timer -= Time.deltaTime;
        //}
        //else if (timer > -2)
        //{
        //    timerText.text = "Spot the Weirdo!";
        //    timer -= Time.deltaTime;
        //}
        //else
        //{
        //    timerText.text = "";
        //}
    }
}
