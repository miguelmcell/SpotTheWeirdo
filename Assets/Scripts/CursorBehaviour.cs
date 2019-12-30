using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorBehaviour : Bolt.EntityEventListener<ICursorState>
{
    public LeaderboardBehaviour leaderboard;
    public override void Attached()
    {
        leaderboard = GameObject.FindGameObjectWithTag("Leaderboard").GetComponent<LeaderboardBehaviour>();
        state.SetTransforms(state.CursorTransform, transform);
        if (entity.IsOwner)
        {
            GetComponent<Image>().enabled = false;
        }
    }

    public override void SimulateOwner()
    {
        // CHANGE TO DELAY MOUSE POSITION, USE LERP OR SOMETHING
        transform.position = Input.mousePosition;
        //state.SetTransforms(state.CursorTransform, transform);
        if (Input.GetMouseButton(0))
        {
            leaderboard.changeDebugText(leaderboard.getPlayerName() + " clicked" + Random.Range(1, 100));
        }
    }
}
