using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[BoltGlobalBehaviour]
public class NetworkCallbacks : Bolt.GlobalEventListener
{
    List<string> logMessages = new List<string>();
    Text debugText;

    public override void SceneLoadLocalDone(string map)
    {
        //var spawnPosition = new Vector3(Random.Range(-8, -8), 0, Random.Range(-8, 8));
        BoltNetwork.Instantiate(BoltPrefabs.Cursor, Vector2.zero, Quaternion.identity);
        debugText = GameObject.FindGameObjectWithTag("DebugText").GetComponent<Text>();
    }

    public override void OnEvent(LogEvent evnt)
    {
        logMessages.Insert(0, evnt.Message);
    }
    //public override void OnEvent(SelectEvent evnt)
    //{
    //    //logMessages.Insert(0, evnt.Selected);
    //    debugText.text = evnt.Selected;
    //}

    void OnGUI()
    {
        //// only display max the 5 latest log messages
        //int maxMessages = Mathf.Min(5, logMessages.Count);

        //GUILayout.BeginArea(new Rect(Screen.width / 2 - 200, Screen.height - 100, 400, 100), GUI.skin.box);

        //for (int i = 0; i < maxMessages; ++i)
        //{
        //    GUILayout.Label(logMessages[i]);
        //}

        //GUILayout.EndArea();
    }
}
