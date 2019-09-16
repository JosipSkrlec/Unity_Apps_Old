using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SAVE : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public class UPGRADES
    {
        /// <summary>
        /// Metoda SpremiTrenutnoStanjeAuta() ukoliko file path ne postoji sprema default vrijednost auta, ukoliko postoji zapise nove vrijednosti koje mjenjaju upgrade-i u GARAGE.
        /// </summary>
        public static void SpremiTrenutnoStanjeAuta()
        {
            string destination = Application.persistentDataPath + "/UPGRADESAUTO.dat";
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);

                //UPGRADEAutaKlasaZaObjekte a = new UPGRADEAutaKlasaZaObjekte();
                //a.Najvecamogucabrzina = GLOBALNE.NajvecaBrzinaAuta;
                //a.UbrzavanjeAuta = GLOBALNE.Ubrzanje;
                //a.UsporavanjeAuta = GLOBALNE.Usporavanje;

                //BinaryFormatter bf = new BinaryFormatter();
                //bf.Serialize(file, a);
            }
            else
            {
                //file = File.Create(destination);
                //UPGRADEAutaKlasaZaObjekte a1 = new UPGRADEAutaKlasaZaObjekte();
                //a1.Najvecamogucabrzina = GLOBALNE.NajvecaBrzinaAuta;
                //a1.UbrzavanjeAuta = GLOBALNE.Ubrzanje;
                //a1.UsporavanjeAuta = GLOBALNE.Usporavanje;

                //BinaryFormatter bf = new BinaryFormatter();
                //bf.Serialize(file, a1);
            }

            //file.Close();
        }

        /// <summary>
        /// Metoda UcitajTrenutnoStanjeAuta() ucita iz datoteke trenutno stanje te ih zapise u varijable GLOBALNE....
        /// </summary>
        public static void UcitajTrenutnoStanjeAuta()
        {
            try
            {
                string destination = Application.persistentDataPath + "/UPGRADESAUTO.dat";
                FileStream file;

                if (File.Exists(destination))
                {
                    //file = File.OpenRead(destination);

                    //BinaryFormatter bf = new BinaryFormatter();
                    //UPGRADEAutaKlasaZaObjekte UcitaniPodaci = (UPGRADEAutaKlasaZaObjekte)bf.Deserialize(file);
                    ////Debug.Log(destination);

                    //GLOBALNE.NajvecaBrzinaAuta = UcitaniPodaci.Najvecamogucabrzina;
                    //GLOBALNE.Ubrzanje = UcitaniPodaci.UbrzavanjeAuta;
                    //GLOBALNE.Usporavanje = UcitaniPodaci.UsporavanjeAuta;
                }
                else
                {
                    //Debug.Log("Problem kod load-a UPGRADE, ili nije spremljeno ili se ucitava prvi puta!");
                    //GLOBALNE.NajvecaBrzinaAuta = 15.0f;
                    //GLOBALNE.Ubrzanje = 1.0f;
                    //GLOBALNE.Usporavanje = 3.0f;

                    //return;
                }


                //file.Close();

            }
            catch (Exception e)
            {
                string a = e.Message;
                //Debug.Log("Problem kod load-a UPGRADE, ili nije spremljeno ili se ucitava prvi puta!" + e.Message);
                //GLOBALNE.NajvecaBrzinaAuta = 15.0f;
                //GLOBALNE.Ubrzanje = 1.0f;
                //GLOBALNE.Usporavanje = 3.0f;
            }
        }
    }
}
