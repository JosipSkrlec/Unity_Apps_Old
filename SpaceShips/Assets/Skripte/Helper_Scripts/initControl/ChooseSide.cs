using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseSide : MonoBehaviour
{
    #region Variables
    [Header("AllianceShips")]
    public GameObject AllianceShip01;
    public GameObject AllianceShip02;
    public GameObject AllianceShip03;

    [Header("ResistanceShips")]
    public GameObject ResistanceShip01;
    public GameObject ResistanceShip02;
    public GameObject ResistanceShip03;

    [Header("OtherObjects")]
    public GameObject AlliancePanel;
    public GameObject ResistancePanel;

    public Button AllianceButton;
    public Button ResistanceButton;

    public Text ChooseShipText;
    public Text AllianceText;
    public Text ResistanceText;
    public Text ChoosenSideText;

    private static string ChoosenSide; // STATIC VARIABLE

    #endregion

    public void Switch_To_Alliance()
    {
        ChoosenSide = "Alliance";
        ChoosenSideText.text = "Continue as Alliance";
    }

    public void Switch_To_Resistance()
    {
        ChoosenSide = "Resistance";
        ChoosenSideText.text = "Continue as Resistance";
    }

    public void Continue_Button()
    {

        if (ChoosenSide == "Alliance")
        {
            ChoosenSideText.enabled = false;
            AllianceText.enabled = false;
            ResistanceText.enabled = false;

            ResistancePanel.SetActive(false);
            ChooseShipText.text = "Choose Alliance Ship";

            AlliancePanel.GetComponent<Animator>().enabled = true;
            AllianceShip01.GetComponent<Animator>().enabled = true;
            AllianceShip02.GetComponent<Animator>().enabled = true;
            AllianceShip03.GetComponent<Animator>().enabled = true;

        }
        else if (ChoosenSide == "Resistance")
        {
            ChoosenSideText.enabled = false;
            AllianceText.enabled = false;
            ResistanceText.enabled = false;

            AlliancePanel.SetActive(false);
            ChooseShipText.text = "Choose Resistance Ship";

            ResistancePanel.GetComponent<Animator>().enabled = true;
            ResistanceShip01.GetComponent<Animator>().enabled = true;
            ResistanceShip02.GetComponent<Animator>().enabled = true;
            ResistanceShip03.GetComponent<Animator>().enabled = true;

        }
        else
        {
            Debug.Log("Side is not selected yet");
        }


    }


}// Main class
