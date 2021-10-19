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

    //base production per item
    public int solarProd = 100;
    public int hydroProd = 300;
    public int windProd = 500;

    //cost base for each energy type
    public int solarCost = 500;
    public int hydroCost = 700;
    public int windCost = 1000;

    //polution dissipation rates
    public double solarPoll = 0.1;
    public double windPoll = 0.5;
    public double hydroPoll = 0.2;

    int Energy = 0;
    public double Pollution = 5000;
    

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
    public string UpdateEnergy()
    {
        Energy += (int)(100 * solarMulti * solarPanelCnt);
        Energy += (int)(400 * windMulti * windMillCnt);
        Energy += (int)(150 * hydroMulti * hydroPlantCnt);
        return "Current Energy: " + Energy;
    }

    public string UpdatePollution()
    {
        Pollution -= (double)(solarPanelCnt * solarPoll + windMillCnt * windPoll + hydroPlantCnt * hydroPoll);
        return "Current Pollution: " + Pollution;
    }
}
