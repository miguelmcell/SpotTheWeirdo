using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[BoltGlobalBehaviour]
public class Master : Bolt.GlobalEventListener
{
    public Text timerText;
    
    float timer;

    public Text debugText;
    //public override void OnEvent(SelectEvent evnt)
    //{
    //    debugText.text = evnt.Selected + " clicked";
    //}

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
