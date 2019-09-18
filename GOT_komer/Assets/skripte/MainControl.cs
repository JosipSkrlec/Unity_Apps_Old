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

        foreach (string a in SeatsSelector.ListaSOP)
        {
            Debug.Log(a);
        }

    }

    public void ZatvoriScreenAddLord()
    {

        AddNewLordPanel.SetActive(false);

        // TODO - dodati ispis tabele




    }

    public void OtvoriScreenAddLord()
    {

        AddNewLordPanel.SetActive(true);

    }

    public void AddLordSAVE()
    {
        string destination = Application.persistentDataPath + "/LORDS.dat";
        //FileStream file;/* = new FileStream("/LORDS.dat", FileMode.Append); */ // FILEMODE za append, da ne brise prijasnje , NE RADI
        Stream stream;

        // temp varijable za provjeru validacije 
        string LordNametemp = LordNameTemp.GetComponent<InputField>().text;
        string TroopTiertemp = TroopTierTemp.GetComponent<InputField>().text;
        string TotalTroopstemp = TotalTroopsTemp.GetComponent<InputField>().text;
        string MarchSizetemp = MarchSizeTemp.GetComponent<InputField>().text;

        // PROVJERA VALIDACIJE
        if (LordNametemp == "" || TroopTiertemp == "" || TotalTroopstemp == "" || MarchSizetemp == "")
        {
            string porukaolosojvalidaciji = " ";

            if (LordNametemp == "")
            {
                porukaolosojvalidaciji += "Name ";
            }
            if (TroopTiertemp == "")
            {
                porukaolosojvalidaciji += "TroopTier  ";
            }
            if (TotalTroopstemp == "")
            {
                porukaolosojvalidaciji += "TotalTroops ";
            }
            if (MarchSizetemp == "")
            {
                porukaolosojvalidaciji += "MarchSize ";
            }
            porukaolosojvalidaciji += "nisu dodani!, Molimo upisite potrebno";

            Debug.Log(porukaolosojvalidaciji);
        }
        else // ako su sva polja popunjena ulazi unutra i zapisuje u file
        {
            if (File.Exists(destination))
            {
                //file = File.OpenWrite(destination); // ne appenda se u file

                stream = new FileStream(destination, FileMode.Append, FileAccess.Write, FileShare.None);

                string VarijablaZaSave = " ";

                VarijablaZaSave = LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp + "/" + System.Environment.NewLine;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, VarijablaZaSave);


                Debug.Log("UPISANO U FILE LORDS - append");

            }
            else
            {
                //file = File.Create(destination);  // ne appenda se u file

                stream = new FileStream(destination, FileMode.Append, FileAccess.Write, FileShare.None);

                string VarijablaZaSave = " ";

                VarijablaZaSave = LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp + "/" + System.Environment.NewLine;

                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(stream, VarijablaZaSave);

                Debug.Log("UPISANO U FILE LORDS - create");
            }

            //file.Close();
            stream.Close();
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

                //var a = bf.Deserialize(file);
                //string b = a.ToString();
                //string[] c = b.Split(':');

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
