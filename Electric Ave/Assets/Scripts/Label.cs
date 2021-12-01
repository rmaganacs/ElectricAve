using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Label : MonoBehaviour
{
    double nextTime = 0;
    double interval = 0.25;


    public GameObject button;
    ClickScript scr; 
    Text label;
    // Start is called before the first frame update
    void Start()
    {
        label = this.gameObject.GetComponent<Text>();
        scr = button.GetComponent<ClickScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextTime)
        {
            label.text = scr.UpdateEnergy();
            nextTime += interval;
        }
    }
}
