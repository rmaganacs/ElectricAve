using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject button;
    ClickScript scr;
    Text label;
    public int value = 0;
    void Start()
    {
        label = this.gameObject.GetComponent<Text>();
        scr = button.GetComponent<ClickScript>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (value) {
            case 1:
               label.text = "Cost : " + scr.wind.getCost() + "\n" + "Owned: " + scr.wind.getAmt();
                break;
            case 2:
                label.text = "Cost : " + scr.solar.getCost() + "\n" + "Owned: " + scr.solar.getAmt();
                break;
            case 3:
                label.text = "Cost : " + scr.hydro.getCost() + "\n" + "Owned: " + scr.hydro.getAmt();
                break;
            case 4:
                label.text = "Cost : " + scr.bio.getCost() + "\n" + "Owned: " + scr.bio.getAmt();
                break;
            case 5:
                label.text = "Cost : " + scr.geo.getCost() + "\n" + "Owned: " + scr.geo.getAmt();
                break;
            case 6:
                label.text = "Cost : " + scr.wind.getUpgradeCost() + "\n" + "Level: " + scr.wind.getLevel();
                break;
            case 7:
                label.text = "Cost : " + scr.solar.getUpgradeCost() + "\n" + "Level: " + scr.solar.getLevel();
                break;
            case 8:
                label.text = "Cost : " + scr.hydro.getUpgradeCost() + "\n" + "Level: " + scr.hydro.getLevel();
                break;
            case 9:
                label.text = "Cost : " + scr.bio.getUpgradeCost() + "\n" + "Level: " + scr.bio.getLevel();
                break;
            case 10:
                label.text = "Cost : " + scr.geo.getUpgradeCost() + "\n" + "Level: " + scr.geo.getLevel();
                break;
        }
    }
}
