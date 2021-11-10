using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollutionRotation : MonoBehaviour
{   //max rotation: 530
    //min rotation: 617
    //total angle = 87

    public GameObject button; 
    ClickScript scr;
    GameObject needle;
    float changeRate;
    void Start()
    {
        needle = this.gameObject;
        scr = button.GetComponent<ClickScript>();
    }

    // Update is called once per frame
    void Update()
    {
        changeRate = scr.getPollutionProduction() / 10000000.0f;
        if (needle.transform.eulerAngles.z <= 250)
        {   
            needle.transform.Rotate(0, 0, changeRate);
        }
  
    }
}
