using UnityEngine;
using UnityEngine.EventSystems;

// CANVAS, lijevo i desno
public class PlayerMovementControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // index strane 0 ili 1, 0 je lijeva 1 je desna
    public int IndexStrane;
    public int getIndexStrane() { return this.IndexStrane; }
    public void setIndexStrane(int value) { this.IndexStrane = value; }

    // za kranju desnu i lijevu
    float xmin;
    float xmax;

    public float moveSpeed = 5;
    public GameObject character;

    bool temp = false;

    
    void Start()
    {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 krajnjelijevo = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 krajnjedesno = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = krajnjelijevo.x;
        xmax = krajnjedesno.x;
    }

    void Update()
    {
        if(temp == true)
        {
            if (IndexStrane == 0)
            {
                if (character.transform.transform.position.x < xmin)
                {
                    character.transform.position = new Vector3(xmin, character.transform.position.y, character.transform.position.z);
                }
                else
                {
                    character.transform.position = new Vector3(character.transform.position.x - moveSpeed * Time.deltaTime, character.transform.position.y, character.transform.position.z);
                }

            }
            if (IndexStrane == 1)
            {
                if (character.transform.transform.position.x > xmax)
                {
                    character.transform.position = new Vector3(xmax, character.transform.position.y, character.transform.position.z);
                }
                else
                {
                    character.transform.position = new Vector3(character.transform.position.x + moveSpeed * Time.deltaTime, character.transform.position.y, character.transform.position.z);
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
