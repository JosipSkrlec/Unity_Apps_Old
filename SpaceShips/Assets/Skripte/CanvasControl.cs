using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public Text MoonstoneTextUI;

    // Start is called before the first frame update
    void Start()
    {
        try
        {
            int MoonstonesCount = PlayerPrefs.GetInt("Moonstones");

            MoonstoneTextUI.text = MoonstonesCount.ToString();
        }
        catch (System.Exception e) { }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenCampaign()
    {
        SceneManager.LoadScene("CampaignScene");
                             

    }

    public void UnlockEndlessMode()
    {
        

    }




}
