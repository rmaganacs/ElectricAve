using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveScript
{
    object[] saveData = new object[11];

    public SaveScript(ClickScript src, Unlock progress)
    {
        saveData[0] = src.getEnergy();
        saveData[1] = src.getPollution();
        for(int i = 2; i < 7; i++)
        {
            saveData[i] = src.getEnergies()[i - 2];
        }
        for (int i = 7; i < 11; i++)
        {
            saveData[i] = progress.getUnlocks()[i - 7];
        }

    }

    public object[] getData()
    {
        return saveData;
    }
}
