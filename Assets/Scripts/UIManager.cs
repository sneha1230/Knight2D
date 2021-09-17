using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject optionPanel;
    public GameObject titlePanel, buttonsPanel;
    public void OptionsMenu()
    {
        optionPanel.SetActive(true);
        titlePanel.SetActive(false);
        buttonsPanel.SetActive(false);
    }
    public void Back()
    {
        optionPanel.SetActive(false);
        titlePanel.SetActive(true);
        buttonsPanel.SetActive(true);
    }
}
