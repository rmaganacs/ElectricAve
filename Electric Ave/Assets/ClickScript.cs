using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public int n;
    int Energy = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyHouse()
    {
        n++;
        

    }

    public string UpdateLabel()
    {
        Energy += n * 100;
        return "Current Energy: " + Energy;
    }
}
