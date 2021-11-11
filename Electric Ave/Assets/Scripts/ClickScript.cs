using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnergySource
{
    protected int production;
    protected int cap;
    protected int cost;
    protected double poll;
    protected int amt = 0;
    protected int pwr = 0;
    protected int upgradeCost;
    public Image energyImage;
    protected bool isLocked = true;

    public EnergySource(int prod, int cap, int cost, double poll)
    {
        this.production = prod;
        this.cap = cap;
        this.cost = cost;
        this.poll = poll;

        upgradeCost = (int)(cost * 3.3);
    }

    public void setAmt(int set)
    {
        amt = set;
    }

    public bool unlock()
    {
        if (isLocked && amt == 0) {
            isLocked = false;
            return true;
        }
        return false;
    }

    public void accumPwr()
    {
        if (pwr + (int)(production * amt) < cap)
        {
            pwr += (int)(production * amt);
        }
        else pwr = cap;
    }

    public int buyNew(int Energy)
    {
        if (Energy > cost)
        {
            Energy = Energy - cost;
            amt++;
        }
        return Energy;
    }

    public int getPwr()
    {
        int temp = pwr;
        pwr = 0;
        return temp;
    }

    public double getPoll()
    {
        return amt * poll;
    }

    public int getCost()
    {
        return cost;
    }
    
    public int getAmt()
    {
        return amt;
    }

    public int getUpgradeCost()
    {
        return upgradeCost;
    }

    public bool getLocked()
    {
        return isLocked;
    }

    public int upgrade(int Energy)
    {
        if(Energy >= upgradeCost)
        {
            Energy -= upgradeCost;
            cost = (int)(cost * 1.5);
            production = (int)(production * 1.5);
            cap = (int)(cap * 1.5);
            upgradeCost = (int)(upgradeCost * 1.5);
        }
        return Energy;
    }
}
public class ClickScript : MonoBehaviour
{

    double nextTime = 0;
    double interval = 0.5;

    public EnergySource solar = new EnergySource(7, 1000, 2000, .1);
    public EnergySource wind  = new EnergySource(9, 1000, 9000, .5);
    public EnergySource hydro = new EnergySource(50, 1000, 65000, .2);
    public EnergySource geo   = new EnergySource(250, 1000, 1250000, .4);
    public EnergySource bio   = new EnergySource(150, 1000, 1500000, .4);

    private void Start()
    {
        wind.setAmt(1);
    }
    //amount of resources


    int Energy = 0;
    public double Pollution = 5000;
    

    //getters to display prices
    public int getSolarCost()
    {
        return solar.getCost();
    }

    public int getWindCost()
    {
        return wind.getCost();
    }

    public int getHydroCost()
    {
        return hydro.getCost();
    }

    public int getGeoCost()
    {
        return geo.getCost();
    }

    public int getBioCost()
    {
        return bio.getCost();
    }

    //upgrade funcs

    public void upgradeSolar()
    {
        Energy = solar.upgrade(Energy);
    }

    public void upgradeWind()
    {
        Energy = wind.upgrade(Energy);
    }

    public void upgradeHydro()
    {
        Energy = hydro.upgrade(Energy);
    }

    public void upgradeGeo()
        {
            Energy = geo.upgrade(Energy);
        }

    public void upgradeBio()
    {
        Energy = bio.upgrade(Energy);
    }

    //funcs for buying
    public void BuySolarPanel()
    {
        Energy = solar.buyNew(Energy);
    }

    public void BuyWindmill()
    {
        Energy = wind.buyNew(Energy);
    }

    public void BuyHydroplant()
    {
        Energy = hydro.buyNew(Energy);
    }

    public void BuyGeo()
    {
        Energy = geo.buyNew(Energy);
    }

    public void BuyBio()
    {
        Energy = bio.buyNew(Energy);
    }

    //funcs for collecting
    public void collectSolar()
    {
        Energy += solar.getPwr();
    }

    public void collectWind()
    {
        Energy += wind.getPwr();
    }

    public void collectHydro()
    {
        Energy += hydro.getPwr();
    }

    public void collectGeo()
    {
        Energy += geo.getPwr();
    }

    public void collectBio()
    {
        Energy += bio.getPwr();
    }

    //funcs for unlocking
    //public void unlockSolar()
    //{
    //    if (solar.unlock())
    //    {
    //        solar.energyImage.sprite = Sprites.Load<Sprite>("locked_solarpanel");
    //    }
    //    else
    //    {
    //        solar.energyImage.sprite = Sprites.Load<Sprite>("solar panel");
    //    }
    //}

    //public void unlockWind()
    //{
    //    if (wind.unlock())
    //    {
    //        wind.energyImage.sprite = Sprites.Load<Sprite>("locked_windturbines");
    //    }
    //    else
    //    {
    //        wind.energyImage.sprite = Sprites.Load<Sprite>("wind turbines");
    //    }
    //}

    //public void unlockHydro()
    //{
    //    if (hydro.unlock())
    //    {
    //        hydro.energyImage.sprite = Sprites.Load<Sprite>("locked_dam");
    //    }
    //    else
    //    {
    //        hydro.energyImage.sprite = Sprites.Load<Sprite>("dam");
    //    }
    //}

    //public void unlockGeo()
    //{
    //    if (geo.unlock())
    //    {
    //        geo.energyImage.sprite = Sprites.Load<Sprite>("locked_geothermal");
    //    }
    //    else
    //    {
    //        geo.energyImage.sprite = Sprites.Load<Sprite>("geothermal");
    //    }
    //}

    //public void unlockBio()
    //{
    //    if (bio.unlock())
    //    {
    //        bio.energyImage.sprite = Sprites.Load<Sprite>("locked_biofuel");
    //    }
    //    else
    //    {
    //        bio.energyImage.sprite = Sprites.Load<Sprite>("biofuel");
    //    }
    //}

    public float getPollutionProduction()
    {
        return (float)(solar.getPoll() +
                       wind.getPoll()  +
                       hydro.getPoll() +
                       geo.getPoll()   +
                       bio.getPoll());
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
            solar.accumPwr();
            hydro.accumPwr();
            wind.accumPwr();
            geo.accumPwr();
            bio.accumPwr();
            nextTime += interval;
        }
    }
}
