using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaitTimer : MonoBehaviour
{
    public Button WindButton;
    private bool isEnabled = false;

    void Start()
    {
        StartCoroutine(ButtonCoroutine(isEnabled));
    }

    IEnumerator ButtonCoroutine(bool value)
    {
        yield return new WaitForSeconds(3f);
        // Turn on the button & make it active
        Button btn = WindButton.GetComponent<Button>();
        WindButton.interactable = true;
        isEnabled = !isEnabled;
        btn.onClick.AddListener(isTask);
    }

    void isTask()
    {
        WindButton.interactable = false;
        StartCoroutine(ButtonCoroutine(isEnabled));
    }
    
}
