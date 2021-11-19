using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;
using UnityEngine.UI;
using System;
using UnityEngine.Profiling;


public class EnergySource
{
    protected int production;
    int temp;
    protected int cap;
    protected int cost;
    protected double poll;
    protected int amt = 0;
    protected int pwr = 0;
    protected int upgradeCost;
    protected int Lvl = 0; //upgrade level
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

    public void accumPwr()
    {
        if (pwr + (int)(production * amt) < cap)
        {
            pwr += (int)(production * amt);
        }
        else pwr = cap;
    }

    public void buyNew(ref int Energy)
    {
        if (Energy > cost)
        {
            Energy = Energy - cost;
            amt++;
            cost = (int)(cost * 1.3);
        }

    }

    public int getPwr()
    {
        temp = pwr;
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
    public void upgrade(ref int Energy)
    {
        if (Energy >= upgradeCost)
        {
            Energy -= upgradeCost;
            cost = (int)(cost * 1.5);
            production = (int)(production * 1.5);
            cap = (int)(cap * 1.5);
            upgradeCost = (int)(upgradeCost * 1.5);
            Lvl++;
        }

    }

    public int getLevel()
    {
        return Lvl;
    }
}
public class ClickScript : MonoBehaviour
{

    double nextTime = 0;
    double interval = 0.5;

    public EnergySource solar;
    public EnergySource wind;
    public EnergySource hydro;
    public EnergySource bio;
    public EnergySource geo;
    public Unlock sample;
    public AudioSource buttonPress;
    public AudioSource backgroundMusic;

    bool mute = false;
    public int Energy = 0;
    public double Pollution = 5000;

    private void Start()
    {
        backgroundMusic.Play();
        SaveScript data = SaveSystem.loadSate();
        if(data != null)
        {
            Energy = (int)data.getData()[0];
            Pollution = (double)data.getData()[1];
            solar = (EnergySource)data.getData()[2];
            hydro = (EnergySource)data.getData()[3];
            wind = (EnergySource)data.getData()[4];
            bio = (EnergySource)data.getData()[5];
            geo = (EnergySource)data.getData()[6];
            sample.solarUn = (bool)data.getData()[7];
            sample.hydroUn = (bool)data.getData()[8];
            sample.geoUn = (bool)data.getData()[9];
            sample.bioUn = (bool)data.getData()[10];
        }
        else
        {
            solar = new EnergySource(50, 1200, 700, .1);
            wind = new EnergySource(20, 1000, 100, .5);
            hydro = new EnergySource(150, 2000, 1500, .2);
            bio = new EnergySource(300, 5000, 20000, .4);
            geo = new EnergySource(450, 8000, 100000, .7);
            Energy = 0;
            Pollution = 5000;
            wind.setAmt(1);
        }
    }

    //amount of resources



    

    //getters to display prices
    public int getSolarCost()
    {
        return solar.getCost();
    }
    public int getEnergy()
    {
        return Energy;
    }
    public double getPollution()
    {
        return Pollution;
    }

    public EnergySource[] getEnergies()
    {
        return new EnergySource[5] { solar, hydro, wind, bio, geo };
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
    public void clickResource()
    {
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
    }
    public void upgradeWind()
    {
        wind.upgrade(ref Energy);
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }

    public void upgradeSolar()
    {
        solar.upgrade(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
    }

    public void upgradeHydro()
    {
        hydro.upgrade(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void upgradeBio()
    {
        bio.upgrade(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void upgradeGeo()
    {
        geo.upgrade(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }
    //funcs for buttons
    public void BuySolarPanel()
    {
        solar.buyNew(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void BuyWindmill()
    {
        wind.buyNew(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void BuyHydroplant()
    {
        hydro.buyNew(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void BuyBio()
    {
        bio.buyNew(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void BuyGeo()
    {
        geo.buyNew(ref Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void collectWind()
    {
       Energy += wind.getPwr();
      if (!buttonPress.isPlaying && !mute)
       {
            buttonPress.Play();
       }

    }

    public void collectHydro()
    {
        Energy += hydro.getPwr();
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }

    public void collectSolar()
    {
        Energy += solar.getPwr();
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }

    public void collectGeo()
    {
        Energy += geo.getPwr();
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }
    public void collectBio()
    {
        Energy += bio.getPwr();
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }

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

    public void Mute()
    {
        mute = !mute;
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
        else
        {
            backgroundMusic.Pause();
        }
    }

    private void Update()
    {

        sample.amountCheck();
        if (Time.time >= nextTime)
        {
            solar.accumPwr();
            hydro.accumPwr();
            wind.accumPwr();
            geo.accumPwr();
            bio.accumPwr();
            nextTime += interval;
        }
        if (Time.time >= 10 *nextTime)
        {
            SaveSystem.saveState(this, sample);
        }
    }
}
