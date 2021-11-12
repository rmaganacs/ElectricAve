using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public ClickScript energyValue;
    public Button SolarButtonStore;
    public Sprite SolarImageUnockedStore;
    public Button HydroButtonStore;
    public Sprite HydroImageUnockedStore;
    public Button BioButtonStore;
    public Sprite BioImageUnockedStore;
    public Button GeoButtonStore;
    public Sprite GeoImageUnockedStore;
    public void amountCheck()
    {
        int Energy = energyValue.getEnergy();
        if (Energy > 2000)
        {
            SolarButtonStore.GetComponent<Image>().sprite = SolarImageUnockedStore;
        }else if (Energy > 65000){
            HydroButtonStore.GetComponent<Image>().sprite = HydroImageUnockedStore;
        }
        else if (Energy > 1250000)
        {
            BioButtonStore.GetComponent<Image>().sprite = BioImageUnockedStore;
        }
        else if (Energy > 1500000)
        {
            GeoButtonStore.GetComponent<Image>().sprite = GeoImageUnockedStore;
        }
    }
}
