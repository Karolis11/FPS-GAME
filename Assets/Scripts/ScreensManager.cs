using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensManager : MonoBehaviour
{
    [SerializeField] private GameObject startScreen;
    [SerializeField] private GameObject looseScreen;
    [SerializeField] private GameObject winScreen;

    // Start is called before the first frame update
    void Start()
    {
        SetActiveStartScreen(true);
    }

    public void SetActiveStartScreen(bool isActive)
    {
        startScreen.SetActive(isActive);
    }

    public void SetActiveLooseScreen(bool isActive)
    {
        looseScreen.SetActive(isActive);
    }

    public void SetActiveWinScreen(bool isActive)
    {
        winScreen.SetActive(isActive);
    }
}
