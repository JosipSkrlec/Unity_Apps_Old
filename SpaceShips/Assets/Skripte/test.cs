using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        Save_Load SL = new Save_Load(Save_Load.Method_Type.Save,"TEST", "test123");

        Save_Load SL3 = new Save_Load(Save_Load.Method_Type.Save, "TEST", "test12564873");


        Save_Load SL1 = new Save_Load(Save_Load.Method_Type.Load, "TEST", "aa");
    
        Debug.Log(SL1.getOutput());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
