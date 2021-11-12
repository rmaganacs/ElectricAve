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
    public int upgrade(int Energy)
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
        return Energy;
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

    public EnergySource solar = new EnergySource(7, 1000, 10, .1);
    public EnergySource wind  = new EnergySource(9, 1000, 11, .5);
    public EnergySource hydro = new EnergySource(50, 1000, 12, .2);
    public EnergySource bio = new EnergySource(150, 1000, 13, .4);
    public EnergySource geo   = new EnergySource(250, 1000, 14, .4);
    public Unlock sample;
    public AudioSource buttonPress;
    public AudioSource backgroundMusic;

    bool mute = false;

    private void Start()
    {
        backgroundMusic.Play();
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
    public int getEnergy()
    {
        return Energy;
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

    public void upgradeWind()
    {
        Energy = wind.upgrade(Energy);
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }

    public void upgradeSolar()
    {
        Energy = solar.upgrade(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
    }

    public void upgradeHydro()
    {
        Energy = hydro.upgrade(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void upgradeBio()
    {
        Energy = bio.upgrade(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void upgradeGeo()
    {
        Energy = geo.upgrade(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }
    //funcs for buttons
    public void BuySolarPanel()
    {
        Energy = solar.buyNew(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void BuyWindmill()
    {
        Energy = wind.buyNew(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void BuyHydroplant()
    {
        Energy = hydro.buyNew(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void BuyBio()
    {
        Energy = bio.buyNew(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void BuyGeo()
    {
        Energy = geo.buyNew(Energy);
            if (!buttonPress.isPlaying && !mute)
            {
                buttonPress.Play();
            }
        }

    public void collectWind()
    {
        Energy += wind.getPwr();
        sample.amountCheck();
      if (!buttonPress.isPlaying && !mute)
       {
            buttonPress.Play();
       }

    }

    public void collectHydro()
    {
        Energy += hydro.getPwr();
        sample.amountCheck();
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }

    public void collectSolar()
    {
        Energy += solar.getPwr();
        sample.amountCheck();
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }

    public void collectGeo()
    {
        Energy += geo.getPwr();
        sample.amountCheck();
        if (!buttonPress.isPlaying && !mute)
        {
            buttonPress.Play();
        }
    }
    public void collectBio()
    {
        Energy += bio.getPwr();
        sample.amountCheck();
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
