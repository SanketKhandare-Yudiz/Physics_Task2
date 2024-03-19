using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Manager : MonoBehaviour
{
    public Canvas startCanvas;
    public Canvas gameCanvas;
     //public Button StartButton;
    public bool startButtonPressed = false;


    public void Start()
    {
        startCanvas.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(false);

    }
    public void onStartBtnClick()
    {
        startButtonPressed = true;
        startCanvas.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(true);
    }

}
