using UnityEngine;
using UnityEngine.EventSystems;

// CANVAS, lijevo i desno
public class PlayerMovementControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // index strane 0 ili 1, 0 je lijeva 1 je desna
    public int IndexStrane;
    public int getIndexStrane() { return this.IndexStrane; }
    public void setIndexStrane(int value) { this.IndexStrane = value; }

    public GameObject Player;

    public float moveSpeed = 5;

    float xmin;
    float xmax;

    bool temp = false;

    // Start is called before the first frame update
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjelijevo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 krajnjedesno = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = krajnjelijevo.x;
        xmax = krajnjedesno.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (temp == true)
        {
            if (IndexStrane == 0)
            {
                if (Player.transform.transform.position.x < xmin)
                {
                    Player.transform.position = new Vector3(xmin, Player.transform.position.y, Player.transform.position.z);
                    Debug.Log("asdasdads");
                }
                else
                {
                    Player.transform.position = new Vector3(Player.transform.position.x - moveSpeed * Time.deltaTime, Player.transform.position.y, Player.transform.position.z);
                }

            }
            if (IndexStrane == 1)
            {
                if (Player.transform.transform.position.x > xmax)
                {
                    Player.transform.position = new Vector3(xmax, Player.transform.position.y, Player.transform.position.z);
                    Debug.Log("asdasdads");
                }
                else
                {
                    Player.transform.position = new Vector3(Player.transform.position.x + moveSpeed * Time.deltaTime, Player.transform.position.y, Player.transform.position.z);
                }
            }
        }


    }


    public void OnPointerDown(PointerEventData eventData)
    {
        temp = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        temp = false;
    }


}
