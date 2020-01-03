using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public bool RefreshMoonstones = false;
    public bool CheckIfEndlessModeisPaid = false;
    public bool CheckCampaignLvl = false;

    public Text MoonstoneTextUI;
    public GameObject EndlessPanel;
    public GameObject LockerImage;

    // Start is called before the first frame update
    void Start()
    {
        // this lines are called in update when refreshmoonstones variable is true
        //try
        //{
        //    int MoonstonesCount = PlayerPrefs.GetInt("Moonstones");

        //    MoonstoneTextUI.text = MoonstonesCount.ToString();
        //}
        //catch (System.Exception) { }

        // refresh endless mode to 0(LOCKED)
        if (CheckCampaignLvl == true)
        {
            try
            {
                int CampaignFinished = PlayerPrefs.GetInt("CampaignFinished");

                Debug.Log(CampaignFinished);
                for (int x = 0; x <= CampaignFinished; x++)
                {
                    if (x < CampaignFinished)
                    {
                        Transform currentButtoninCampaign = this.gameObject.transform.GetChild(x);

                        currentButtoninCampaign.GetComponent<Image>().color = Color.green;
                        currentButtoninCampaign.GetComponent<Button>().enabled = false;
                        currentButtoninCampaign.GetComponent<Animator>().enabled = false;

                    }
                    if (x == CampaignFinished)
                    {
                        Transform currentButtoninCampaign = this.gameObject.transform.GetChild(x);

                        currentButtoninCampaign.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                        currentButtoninCampaign.GetComponent<Button>().enabled = true;
                        currentButtoninCampaign.GetComponent<Animator>().enabled = true;

                    }

                }



            }
            catch (System.Exception) { }
        }

        // REFRESH
        // REFRESH

        //PlayerPrefs.SetInt("EndlessMode", 0);
        //PlayerPrefs.SetInt("CampaignFinished", 0);
        //PlayerPrefs.SetInt("Moonstones", 0);

        // REFRESH
        // REFRESH

    }

    // Update is called once per frame
    void Update()
    {
        if (RefreshMoonstones == true)
        {
            try
            {
                int MoonstonesCount = PlayerPrefs.GetInt("Moonstones");

                MoonstoneTextUI.text = MoonstonesCount.ToString();
            }
            catch (System.Exception) { }
        }
        if (CheckIfEndlessModeisPaid == true)
        {
            try
            {
                int EndlessModePaid = PlayerPrefs.GetInt("EndlessMode");

                if (EndlessModePaid == 1)
                {
                    Button button = this.gameObject.GetComponent<Button>();

                    // promjena boje button-a
                    ColorBlock cb = button.colors;
                    cb.normalColor = new Color(cb.normalColor.r, cb.normalColor.g, cb.normalColor.b, 1);
                    cb.highlightedColor = new Color(cb.highlightedColor.r, cb.highlightedColor.g, cb.highlightedColor.b, 1);
                    cb.pressedColor = new Color(cb.pressedColor.r, cb.pressedColor.g, cb.pressedColor.b, 1);
                    cb.selectedColor = new Color(cb.selectedColor.r, cb.selectedColor.g, cb.selectedColor.b, 1);
                    button.colors = cb;

                    // disable locker-a
                    LockerImage.SetActive(false);

                }

            }
            catch (System.Exception) { }


        }

    }//end of update

    public void OpenCampaign()
    {
        SceneManager.LoadScene("CampaignScene");
                             

    }

    public void OpenEndlessModePanel()
    {
        int EndlessMode = PlayerPrefs.GetInt("EndlessMode");

        if (EndlessMode == 1)
        {
            SceneManager.LoadScene("Game");
        }
        else
        {
            EndlessPanel.SetActive(true);
        }

    }
    public void CloseEndlessModePanel()
    {
        EndlessPanel.SetActive(false);

    }

    public void OpenStartingMenu()
    {
        SceneManager.LoadScene("StartingScene");
    }
    public void PayEndlessMode()
    {
        int MoonstonesCount = PlayerPrefs.GetInt("Moonstones");

        if (MoonstonesCount >= 500)
        {
            EndlessPanel.SetActive(false);

            MoonstonesCount -= 500;
            MoonstoneTextUI.text = MoonstonesCount.ToString();
            PlayerPrefs.SetInt("Moonstones", MoonstonesCount);

            PlayerPrefs.SetInt("EndlessMode", 1);
        }


    }

    public void REFRESH()
    {
        PlayerPrefs.SetInt("EndlessMode", 0);
        PlayerPrefs.SetInt("CampaignFinished", 0);
        PlayerPrefs.SetInt("Moonstones", 0);

    }




}
