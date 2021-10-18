using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{

    //amount of resources
    int solarPanelCnt = 1;
    int windMillCnt = 0;
    int hydroPlantCnt = 0;

    //multiplier of production (based off upgrades)
    double solarMulti = 1.0;
    double windMulti = 1.0;
    double hydroMulti = 1.0;


    //cost base for each energy type
    int solarCost = 500;
    int hydroCost = 700;
    int windCost = 1000;

    int Energy = 0;
    

    //getters to display prices
    public int getSolarCost()
    {
        return solarCost;
    }

    public int getWindCost()
    {
        return windCost;
    }

    public int getHydroCost()
    {
        return hydroCost;
    }

    //funcs for buttons
    public void BuySolarPanel()
    {
        if (Energy >= solarCost)
        {
            Energy =  Energy - solarCost;
            solarPanelCnt++;
            solarCost = (int)(solarCost * 1.3);
        }
        
    }

    public void BuyWindmill()
    {
        if (Energy >= windCost)
        {
            Energy -= windCost;
            windMillCnt++;
            windCost = (int)(windCost * 1.3);
        }

    }

    public void BuyHydroplant()
    {
        if (Energy >= hydroCost)
        {
            Energy -= hydroCost;
            hydroPlantCnt++;
            hydroCost = (int)(hydroCost * 1.3);
        }

    }


    //updates power label
    public string UpdateLabel()
    {
        Energy += (int)(100 * solarMulti * solarPanelCnt);
        Energy += (int)(400 * windMulti * windMillCnt);
        Energy += (int)(150 * hydroMulti * hydroPlantCnt);
        return "Current Energy: " + Energy;
    }
}
