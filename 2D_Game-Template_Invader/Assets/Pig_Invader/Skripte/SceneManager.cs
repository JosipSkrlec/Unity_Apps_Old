using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IgrajPonovno()
    {
        Application.LoadLevel("GameScena");
    }

    public void GoToPocetna()
    {
        Application.LoadLevel("pocetna");
    }

    public void UgasiIgru()
    {
        Application.Quit();
    }



}
