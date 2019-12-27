using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Master : MonoBehaviour
{
    public Text timerText;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timerText.text = (Mathf.Ceil(Mathf.Clamp(timer, 0, 3))).ToString();
            timer -= Time.deltaTime;
        }
        else if (timer > -2)
        {
            timerText.text = "Spot the Weirdo!";
            timer -= Time.deltaTime;
        }
        else
        {
            timerText.text = "";
        }
    }
}
