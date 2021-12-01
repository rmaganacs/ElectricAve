using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class BackendLogic
{
    [Test]
    public void EnergyUpdateSimplePasses()
    {
        int Energy = 0;
        double Pollution = 5000;
        double solarMulti = 1.0;
        double windMulti = 1.0;
        double hydroMulti = 1.0;
        int solarPanelCnt = 1;
        int windMillCnt = 0;
        int hydroPlantCnt = 0;
        double solarPoll = 0.1;
        double windPoll = 0.5;
        double hydroPoll = 0.2;
        int solarCost = 500;
        int hydroCost = 700;
        int windCost = 1000;
        // Use the Assert class to test conditions
        Energy += (int)(100 * solarMulti * solarPanelCnt);
        Energy += (int)(400 * windMulti * windMillCnt);
        Energy += (int)(150 * hydroMulti * hydroPlantCnt);
        Assert.AreEqual(100, Energy);
    }
    [Test]
    public void PollutionUpdateSimplePasses()
    {
        int Energy = 0;
        double Pollution = 5000;
        double solarMulti = 1.0;
        double windMulti = 1.0;
        double hydroMulti = 1.0;
        int solarPanelCnt = 1;
        int windMillCnt = 0;
        int hydroPlantCnt = 0;
        double solarPoll = 0.1;
        double windPoll = 0.5;
        double hydroPoll = 0.2;
        int solarCost = 500;
        int hydroCost = 700;
        int windCost = 1000;
        Pollution -= (double)(solarPanelCnt * solarPoll + windMillCnt * windPoll + hydroPlantCnt * hydroPoll);
        Assert.AreEqual(4999.8999999999996, Pollution);
    }
    [Test]
    public void BuyingMechanicSimplePasses()
    {
        double Pollution = 5000;
        double solarMulti = 1.0;
        double windMulti = 1.0;
        double hydroMulti = 1.0;
        int solarPanelCnt = 1;
        int windMillCnt = 0;
        int hydroPlantCnt = 0;
        double solarPoll = 0.1;
        double windPoll = 0.5;
        double hydroPoll = 0.2;
        int solarCost = 500;
        int hydroCost = 700;
        int windCost = 1000;
        int EnergyCount = 2200;
        if (EnergyCount >= windCost)
        {
            EnergyCount -= windCost;
            windMillCnt++;
            windCost = (int)(windCost * 1.3);
        }
        if (EnergyCount >= solarCost)
        {
            EnergyCount = EnergyCount - solarCost;
            solarPanelCnt++;
            solarCost = (int)(solarCost * 1.3);
        }
        if (EnergyCount >= hydroCost)
        {
            EnergyCount -= hydroCost;
            hydroPlantCnt++;
            hydroCost = (int)(hydroCost * 1.3);
        }
        Assert.AreEqual(0, EnergyCount);
    }

}
