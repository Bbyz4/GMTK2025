using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScreen : MonoBehaviour
{
    private bool creditsActive = false;
    [SerializeField] private GameObject creditCanvas;

    void Awake()
    {
        creditsActive = false;

        creditCanvas.SetActive(false);
    }

    public void ShowCredits()
    {
        creditsActive = true;
        creditCanvas.SetActive(true);
    }

    private void HideCredits()
    {
        creditsActive = false;
        creditCanvas.SetActive(false);
    }

    void Update()
    {
        if (Input.anyKeyDown && creditsActive)
        {
            HideCredits();
        }   
    }
}
