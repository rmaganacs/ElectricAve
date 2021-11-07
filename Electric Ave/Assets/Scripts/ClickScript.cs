using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    double nextTime = 0;
    double interval = 0.25;

    //amount of resources
    int solarPanelCnt = 1;
    int windMillCnt = 0;
    int hydroPlantCnt = 0;
    int geoCnt = 0;
    int bioCnt = 0;

    //accumulators
    int solarPwr = 0;
    int windPwr = 0;
    int hydroPwr = 0;
    int geoPwr = 0;
    int bioPwr = 0;

    //capacities
    public int solarCap = 1000;
    public int windCap = 1000;
    public int hydroCap = 1000;
    public int geoCap = 1000;
    public int bioCap = 1000;

    //multiplier of production (based off upgrades)
    double solarMulti = 1.0;
    double windMulti = 1.0;
    double hydroMulti = 1.0;
    double bioMulti = 1.0;
    double geoMulti = 1.0;

    //base production per item
    public int solarProd = 100;
    public int hydroProd = 300;
    public int windProd = 500;
    public int geoProd = 700;
    public int bioProd = 1000;

    //cost base for each energy type
    public int solarCost = 500;
    public int hydroCost = 700;
    public int windCost = 1000;
    public int geoCost = 1200;
    public int bioCost = 1500;

    //polution dissipation rates
    public double solarPoll = 0.1;
    public double windPoll = 0.5;
    public double hydroPoll = 0.2;
    public double geoPoll = 0.4;
    public double bioPoll = 0.4;

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

    public int getGeoCost()
    {
        return geoCost;
    }

    public int getBioCost()
    {
        return bioCost;
    }

    //upgrade funcs
    public void upgradeSolar()
    {

    }

    public void upgradeHydro()
    {

    }

    public void upgradeWind()
    {

    }

    public void upgradeGeo()
    {

    }

    public void upgradeBio()
    {

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

    public void collectWind()
    {
        Energy += windPwr;
        windPwr = 0;
    }

    public void collectHydro()
    {
        Energy += hydroPwr;
        hydroPwr = 0;
    }

    public void collectSolar()
    {
        Energy += solarPwr;
        solarPwr = 0;
    }

    public void collectGeo()
    {
        Energy += geoPwr;
        geoPwr = 0;
    }

    public void collectBio()
    {
        Energy += bioPwr;
        bioPwr = 0;
    }

    public float getPollutionProduction()
    {
        return (float)(solarPoll + windPoll + hydroPoll + geoPoll + bioPoll);
    }

    //updates power label
    public string UpdateEnergy()
    {

        return "" + Energy;
    }

    

    private void Update()
    {
       
        if (Time.time >= nextTime)
        {
            if (solarPwr + (int)(solarCost * solarMulti * solarPanelCnt) < solarCap){
                solarPwr += (int)(solarCost * solarMulti * solarPanelCnt);
            }
            else solarPwr = solarCap;

            if (windPwr + (int)(windCost * windMulti * windMillCnt) < windCap)
            {
                windPwr += (int)(windCost * windMulti * windMillCnt);
            }
            else windPwr = windCap;

            if (hydroPwr + (int)(hydroCost * hydroMulti * hydroPlantCnt) < hydroCap)
            {
                hydroPwr += (int)(hydroCost * hydroMulti * hydroPlantCnt);
            }
            else hydroPwr = hydroCap;

            if (geoPwr + (int)(geoCost * geoMulti * geoCnt) < geoCap)
            {
                geoPwr += (int)(geoCost * geoMulti * geoCnt);
            }
            else geoPwr = geoCap;

            if (bioPwr + (int)(bioCost * bioMulti * bioCnt) < bioCap)
            {
                bioPwr += (int)(bioCost * bioMulti * bioCnt);
            }
            else bioPwr = bioCap;

        }
    }
}
