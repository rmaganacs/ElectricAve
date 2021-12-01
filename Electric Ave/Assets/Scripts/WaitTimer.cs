using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaitTimer : MonoBehaviour
{
    public Button WindButton;
    private bool isEnabled = false;
    Button btn;

    public void Start()
    {
        StartCoroutine(ButtonCoroutine());
    }

    IEnumerator ButtonCoroutine()
    {
        WindButton.interactable = false;
        yield return new WaitForSeconds(3f);
        // Turn on the button & make it active
        WindButton.interactable = true;
    }

    
}
