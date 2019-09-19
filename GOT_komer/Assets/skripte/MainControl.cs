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


    public GameObject paneljedancontent;

    public GameObject ime;
    public GameObject troops;
    public GameObject totaltroops;
    public GameObject marchsize;

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
        //Stream stream;
        StreamWriter sw;

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

                //Pass the filepath and filename to the StreamWriter Constructor
                sw = new StreamWriter(destination, append: true);

                string VarijablaZaSave = " ";

                VarijablaZaSave = LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp + System.Environment.NewLine; //LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp + "/" + System.Environment.NewLine;

                //Write a line of text
                sw.Write(VarijablaZaSave);

                #region Kriptirani podaci
                //stream = new FileStream(destination, FileMode.Append, FileAccess.Write, FileShare.None);

                //string VarijablaZaSave = " ";

                //VarijablaZaSave = LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp + "/" + System.Environment.NewLine;

                //BinaryFormatter bf = new BinaryFormatter();
                //bf.Serialize(stream, VarijablaZaSave);

                #endregion


                Debug.Log("UPISANO U FILE LORDS - append");

            }
            else
            {
                //file = File.Create(destination);  // ne appenda se u file

                sw = new StreamWriter(destination, append: true);

                string VarijablaZaSave = " ";

                VarijablaZaSave = LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp + System.Environment.NewLine; //LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp + "/" + System.Environment.NewLine;

                string prvalinija = "U ovom file-u se nalazi popis svih LORDOVA" + System.Environment.NewLine;

                //Write a line of text
                sw.Write(prvalinija);
                sw.Write(VarijablaZaSave);


                #region Kriptirani podaci

                //stream = new FileStream(destination, FileMode.Append, FileAccess.Write, FileShare.None);

                //string VarijablaZaSave = " ";

                //VarijablaZaSave = LordNametemp + ":" + TroopTiertemp + ":" + TotalTroopstemp + ":" + MarchSizetemp + "/" + System.Environment.NewLine;

                //BinaryFormatter bf = new BinaryFormatter();
                //bf.Serialize(stream, VarijablaZaSave);

                #endregion

                Debug.Log("UPISANO U FILE LORDS - create");


            }

            sw.Close();

            //file.Close();
            //stream.Close(); // Kriptirani podaci
        }



    }

    public void LOADLordsFromFile()
    {
        try
        {
            string destination = Application.persistentDataPath + "/LORDS.dat";
            //FileStream file;
            StreamReader sr;

            if (File.Exists(destination))
            {
                //file = File.OpenRead(destination);

                string line;

                sr = new StreamReader(destination);

                //Read the first line of text
                line = sr.ReadLine();

                //Continue to read until you reach end of file
                while (line != null)
                {

                    line = sr.ReadLine();


                    string[] temp = line.Split(':');

                    string temp1 = temp[0];
                    string temp2 = temp[1];
                    string temp3 = temp[2];
                    string temp4 = temp[3];


                    Debug.Log(line + " " + temp1 + " " + temp2 + " " + temp3 + " " + temp4);







                }

               #region kriptirani podaci
                //BinaryFormatter bf = new BinaryFormatter();

                ////var a = bf.Deserialize(file);
                ////string b = a.ToString();
                ////string[] c = b.Split(':');

                //Debug.Log(bf.Deserialize(file));
                #endregion
            }
            else
            {
                return;                
            }

            //file.Close();
            sr.Close();

        }

        catch(Exception e)
        {
            Debug.Log(e.Message);
        }


    }





}
