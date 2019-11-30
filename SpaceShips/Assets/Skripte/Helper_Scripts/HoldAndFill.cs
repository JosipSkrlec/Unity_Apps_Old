using UnityEngine;
using UnityEngine.UI;

public class HoldAndFill : MonoBehaviour
{
    private bool PointerDown;
    private float pointerDownTimer;

    public float RequiredHoldTime;

    [SerializeField]
    private Image FillImage;

    // Update is called once per frame
    void Update()
    {
        if (PointerDown)
        {
            pointerDownTimer += Time.deltaTime;

            if (pointerDownTimer >= RequiredHoldTime)
            {
                Reset();
            }

            if (pointerDownTimer < RequiredHoldTime)
            {

                FillImage.fillAmount = pointerDownTimer / RequiredHoldTime;
            }

        }

    }

    public void OnPointerUp()
    {
        Reset();
        Debug.Log("OnPointerUp");
    }

    public void OnPointerDown()
    {
        PointerDown = true;
        Debug.Log("OnPointerDown");
    }

    private void Reset()
    {
        PointerDown = false;
        pointerDownTimer = 0;
        FillImage.fillAmount = pointerDownTimer / RequiredHoldTime;
    }


}
