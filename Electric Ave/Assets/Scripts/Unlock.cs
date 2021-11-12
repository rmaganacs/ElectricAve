using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unlock : MonoBehaviour
{
    public ClickScript energyValue;
    //Store Unlocks
    public Button SolarButtonStore;
    public Sprite SolarImageUnockedStore;
    public Button HydroButtonStore;
    public Sprite HydroImageUnockedStore;
    public Button BioButtonStore;
    public Sprite BioImageUnockedStore;
    public Button GeoButtonStore;
    public Sprite GeoImageUnockedStore;

    //Upgrade Unlocks
    public Button SolarButtonUpgrade;
    public Sprite SolarImageUnockedUpgrade;
    public Button HydroButtonUpgrade;
    public Sprite HydroImageUnockedUpgrade;
    public Button BioButtonUpgrade;
    public Sprite BioImageUnockedUpgrade;
    public Button GeoButtonUpgrade;
    public Sprite GeoImageUnockedUpgrade;

    //Resource Unlocks
    public Button SolarButtonResource;
    public Sprite SolarImageUnockedResource;
    public Button HydroButtonResource;
    public Sprite HydroImageUnockedResource;
    public Button BioButtonResource;
    public Sprite BioImageUnockedResource;
    public Button GeoButtonResource;
    public Sprite GeoImageUnockedResource;

    //Map Unlocks
    public Button SolarButtonMap;
    public Sprite SolarImageUnockedMap;
    public Button HydroButtonMap;
    public Sprite HydroImageUnockedMap;
    public Button BioButtonMap;
    public Sprite BioImageUnockedMap;
    public Button GeoButtonMap;
    public Sprite GeoImageUnockedMap;

    public bool solarUn = false;
    public bool hydroUn = false;
    public bool bioUn = false;
    public bool geoUn = false;


    public void amountCheck()
    {
        int Energy = energyValue.getEnergy();
        if (Energy >= 100)
        {
            SolarButtonStore.GetComponent<Image>().sprite = SolarImageUnockedStore;
            SolarButtonStore.interactable = true;
            SolarButtonStore.transition = Selectable.Transition.ColorTint;
        }
        if (Energy >= 200){
            HydroButtonStore.GetComponent<Image>().sprite = HydroImageUnockedStore;
            HydroButtonStore.interactable = true;
            HydroButtonStore.transition = Selectable.Transition.ColorTint;
        }
        if (Energy >= 300)
        {
            BioButtonStore.GetComponent<Image>().sprite = BioImageUnockedStore;
            BioButtonStore.interactable = true;
            BioButtonStore.transition = Selectable.Transition.ColorTint;
        }
        if (Energy >= 400)
        {
            GeoButtonStore.GetComponent<Image>().sprite = GeoImageUnockedStore;
            GeoButtonStore.interactable = true;
            GeoButtonStore.transition = Selectable.Transition.ColorTint;
        }
    }

    void Update()
    {
        int solarChecker = energyValue.solar.getAmt();
        int hydroChecker = energyValue.hydro.getAmt();
        int bioChecker = energyValue.bio.getAmt();
        int geoChecker = energyValue.geo.getAmt();
        if (solarChecker >= 1 && solarUn == false)
        {
            SolarButtonUpgrade.GetComponent<Image>().sprite = SolarImageUnockedUpgrade;
            SolarButtonUpgrade.interactable = true;
            SolarButtonUpgrade.transition = Selectable.Transition.ColorTint;

            SolarButtonResource.GetComponent<Image>().sprite = SolarImageUnockedResource;
            SolarButtonResource.interactable = true;
            SolarButtonResource.transition = Selectable.Transition.ColorTint;

            SolarButtonMap.GetComponent<Image>().sprite = SolarImageUnockedMap;
            SolarButtonMap.interactable = true;
            SolarButtonMap.transition = Selectable.Transition.ColorTint;

            solarUn = true;

        }
        if(hydroChecker >= 1 && hydroUn == false)
        {
            HydroButtonUpgrade.GetComponent<Image>().sprite = HydroImageUnockedUpgrade;
            HydroButtonUpgrade.interactable = true;
            HydroButtonUpgrade.transition = Selectable.Transition.ColorTint;

            HydroButtonResource.GetComponent<Image>().sprite = HydroImageUnockedResource;
            HydroButtonResource.interactable = true;
            HydroButtonResource.transition = Selectable.Transition.ColorTint;

            HydroButtonMap.GetComponent<Image>().sprite = HydroImageUnockedMap;
            HydroButtonMap.interactable = true;
            HydroButtonMap.transition = Selectable.Transition.ColorTint;

            hydroUn = true;
        }
        if (bioChecker >= 1 && bioUn == false)
        {
            BioButtonUpgrade.GetComponent<Image>().sprite = BioImageUnockedUpgrade;
            BioButtonUpgrade.interactable = true;
            BioButtonUpgrade.transition = Selectable.Transition.ColorTint;

            BioButtonResource.GetComponent<Image>().sprite = BioImageUnockedResource;
            BioButtonResource.interactable = true;
            BioButtonResource.transition = Selectable.Transition.ColorTint;

            BioButtonMap.GetComponent<Image>().sprite = BioImageUnockedMap;
            BioButtonMap.interactable = true;
            BioButtonMap.transition = Selectable.Transition.ColorTint;

            bioUn = true;
        }
        if (geoChecker >= 1 && geoUn == false)
        {
            GeoButtonUpgrade.GetComponent<Image>().sprite = GeoImageUnockedUpgrade;
            GeoButtonUpgrade.interactable = true;
            GeoButtonUpgrade.transition = Selectable.Transition.ColorTint;

            GeoButtonResource.GetComponent<Image>().sprite = GeoImageUnockedResource;
            GeoButtonResource.interactable = true;
            GeoButtonResource.transition = Selectable.Transition.ColorTint;

            GeoButtonMap.GetComponent<Image>().sprite = GeoImageUnockedMap;
            GeoButtonMap.interactable = true;
            GeoButtonMap.transition = Selectable.Transition.ColorTint;

            geoUn = true;
        }
    }
}
