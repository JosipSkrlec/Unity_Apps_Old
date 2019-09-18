using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class MainControl : MonoBehaviour {

    #region public Varijable
    public GameObject PrviPanel;
    public GameObject DrugiPanel;

    public GameObject AddNewLordPanel;

    [SerializeField]
    private GameObject LordNameTemp;
    [SerializeField]
    private GameObject TroopTierTemp;
    [SerializeField]
    private GameObject TotalTroopsTemp;
    [SerializeField]
    private GameObject MarchSizeTemp;

    #endregion

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {



    }

    public void OtvoriDrugiScreen()
    {

        PrviPanel.SetActive(false);
        DrugiPanel.SetActive(true);

    }

    public void ZatvoriScreenAddLord()
    {

        AddNewLordPanel.SetActive(false);

    }

    public void OtvoriScreenAddLord()
    {

        AddNewLordPanel.SetActive(true);

    }

    public void AddLordSAVE()
    {
        string destination = Application.persistentDataPath + "/LORDS.dat";
        FileStream file;

        // temp varijable za provjeru validacije 
        string LordNametemp = LordNameTemp.GetComponent<InputField>().text;
        string TroopTiertemp = TroopTierTemp.GetComponent<InputField>().text;
        string TotalTroopstemp = TotalTroopsTemp.GetComponent<InputField>().text;
        string MarchSizetemp = MarchSizeTemp.GetComponent<InputField>().text;

        // PROVJERA VALIDACIJE
        if (LordNametemp == "" || TotalTroopstemp == "" || TotalTroopstemp == "" || MarchSizetemp == "")
        {
            // TODO - ispisati validaciju kj nije popunjeno
        }
        else // ako su sva polja popunjena ulazi unutra i zapisuje u file
        {
            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);

                string VarijablaZaSave = " ";

                VarijablaZaSave = LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, VarijablaZaSave);
            }
            else
            {
                file = File.Create(destination);

                string VarijablaZaSave = " ";

                VarijablaZaSave = LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(file, VarijablaZaSave);
            }

            file.Close();
        }



    }

    public void LOADLordsFromFile()
    {
        try
        {
            string destination = Application.persistentDataPath + "/LORDS.dat";
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenRead(destination);

                BinaryFormatter bf = new BinaryFormatter();

                Debug.Log(bf.Deserialize(file));

            }
            else
            {

                return;
            }

            file.Close();
        }
        catch(Exception e)
        {
            Debug.Log(e.Message);
        }
    }





}
