using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class Save_Load
{
    public enum Method_Type
    {
        Save, Load
    }

    // Output Variable
    private string Output;
    public string getOutput(){ return this.Output; }

    public Save_Load(){ }// First Constructor

    /// <summary>
    /// You can use that Constructor for Save And Load, if you use Load Method then Content can be null
    /// </summary>
    public Save_Load(Method_Type Methodtype, string FileName_dat, string Content)
    {
        if (Methodtype == Method_Type.Save)
        {
            string destination = Application.persistentDataPath + "/" + FileName_dat + ".dat";
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);

                BinaryFormatter bf = new BinaryFormatter();
                
                bf.Serialize(file, Content);

                Debug.Log("file exists and i will write inside");

            }
            else
            {
                file = File.Create(destination);                

                BinaryFormatter bf = new BinaryFormatter();

                bf.Serialize(file, Content);

                Debug.Log("file doesnt exists and i will create one");
            }

            file.Close();

        }
        else if (Methodtype == Method_Type.Load)
        {
            try
            {
                string destination = Application.persistentDataPath + "/" + FileName_dat + ".dat";
                FileStream file;

                if (File.Exists(destination))
                {
                    file = File.OpenRead(destination);

                    BinaryFormatter bf = new BinaryFormatter();

                    Output = bf.Deserialize(file).ToString();
                }
                else
                {
                    Debug.Log("Can not load File");

                    return;
                }

                file.Close();

            }
            catch (Exception e)
            {
                string a = e.Message;
            }

        }

    }// Second Constructor

} // Main Class
