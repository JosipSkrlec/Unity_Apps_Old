using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasControl : MonoBehaviour
{
    public bool RefreshMoonstones = false; // postavlja se na pocetnoj sceni na CANVAS-u da refresh-a broj moonstones-a
    public bool CheckIfEndlessModeisPaid = false; // provjera da li je endless placen ili nije
    public bool CheckCampaignLvl = false; // postavlja se true u campaign sceni tako da provjeri koji je lvl gotov koji ne

    [Header("Helpers")]
    public Text MoonstoneTextUI;
    public GameObject EndlessPanelForBuy;
    public GameObject LockerImage;

    void Start()
    {
        // provjera prijedenih levela campaign-a
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
    }// zavrsetak starta

    // Update is called once per frame
    void Update()
    {
        // postavlja se u pocetnoj sceni za refresh moonstones-a
        if (RefreshMoonstones == true)
        {
            try
            {
                int MoonstonesCount = PlayerPrefs.GetInt("Moonstones");

                MoonstoneTextUI.text = MoonstonesCount.ToString();
            }
            catch (System.Exception) { }
        }
        // provjera da li je endless otkljucan ili ne, ako je postavlja se na "ACTIVE" za play
        if (CheckIfEndlessModeisPaid == true)
        {
            try
            {
                int EndlessModePaid = PlayerPrefs.GetInt("EndlessModePaid");

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

    // Otvaranje Campaign Scene
    public void OpenCampaign()
    {
        Time.timeScale = 1.0f;

        SceneManager.LoadScene("CampaignScene");                            

    }

    // Otvaranje starting scene iz win scene, pribrajanje moonstones-a, citanje trenutnih reward-a moonstones-a i refresh istih
    public void OpenStartingSceneFronWinPanel()
    {
        int MoonstonesCount = PlayerPrefs.GetInt("Moonstones");
        int CurrentMoonstonesReward = PlayerPrefs.GetInt("MoonstonesReward");
        MoonstonesCount += CurrentMoonstonesReward;

        PlayerPrefs.SetInt("Moonstones", MoonstonesCount);
        PlayerPrefs.GetInt("MoonstonesReward", 0);

        Time.timeScale = 1.0f;

        SceneManager.LoadScene("StartingScene");
    }

    // otvaranje endless mod-a, ako je placen tada se otvara game
    public void OpenEndlessModePanel()
    {
        int EndlessMode = PlayerPrefs.GetInt("EndlessModePaid");

        // ako je endless placen otvara se game scena sa settings-ima
        if (EndlessMode == 1)
        {
            SceneManager.LoadScene("Game");
            
            PlayerPrefs.SetInt("CurrentCampaignLVL", 0);
            PlayerPrefs.SetInt("NumberOfEnemyWaves", 10);
            PlayerPrefs.SetFloat("EnemyAttackCooldown", 0.1f);
            PlayerPrefs.SetInt("MoonstonesReward", 2500);
            PlayerPrefs.SetString("LEVELCONTROLFORMATION", "3-3-4-5-3-7-4-7-3-7");
            
        }
        // suprotno otvaranje endless panel-a za kupovanje
        else
        {
            EndlessPanelForBuy.SetActive(true);
        }

    }

    // Zatvaranje Endless mode Panel-a za kupovanje
    public void CloseEndlessModePanel()
    {
        EndlessPanelForBuy.SetActive(false);

    }

    // otvaranje starting scene
    public void OpenStartingScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartingScene");
    }

    // Placanje endless mod-a za 500 moonstones-a
    public void PayEndlessMode()
    {
        int MoonstonesCount = PlayerPrefs.GetInt("Moonstones");

        if (MoonstonesCount >= 500)
        {
            EndlessPanelForBuy.SetActive(false);

            MoonstonesCount -= 500;
            MoonstoneTextUI.text = MoonstonesCount.ToString();
            PlayerPrefs.SetInt("Moonstones", MoonstonesCount);

            PlayerPrefs.SetInt("EndlessModePaid", 1);
        }
    }

    // otvaranje Shop-a
    public void OpenShopMenu()
    {
        SceneManager.LoadScene("ShopScene");

    }

    // Helper metoda
    public void REFRESH()
    {

        PlayerPrefs.SetInt("DropChance",10);
        PlayerPrefs.SetFloat("playerShootingCooldown", 0.5f);


        PlayerPrefs.SetInt("EndlessModePaid", 0);
        PlayerPrefs.SetInt("CampaignFinished", 0);
        PlayerPrefs.SetInt("Moonstones", 0);

    }

    
}// zavrsetak main class-e
