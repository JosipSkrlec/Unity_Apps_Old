using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragFingerOffSet : MonoBehaviour
{
    private Vector3 mousePosition;
    private float deltaX, deltaY;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {

//#if UNITY_EDITOR || UNITY_EDITOR_WIN
        if (Input.GetMouseButtonDown(0))
        {
            float a = 5.0f;
            
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            deltaX = mousePosition.x - transform.position.x;
            deltaY = mousePosition.y - transform.position.y;
        }

        if (Input.GetMouseButton(0))
        {

            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Debug.Log(mousePosition);
            rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));


            //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //direction = (mousePosition - transform.position).normalized;
            //rb.velocity = new Vector2(direction.x * moveSpeed, direction.y * moveSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }

//#elif !UNITY_EDITOR || UNITY_ANDROID
//        if (Input.touchCount > 0)
//        {
//            Touch touch = Input.GetTouch(0);

//            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

//            switch (touch.phase)
//            {

//                case TouchPhase.Began:
//                    deltaX = touchPos.x - transform.position.x;
//                    deltaY = touchPos.y - transform.position.y;

//                    break;

//                case TouchPhase.Moved:
//                    rb.MovePosition(new Vector2(touchPos.x - deltaX, touchPos.y - deltaY));

//                    break;

//                case TouchPhase.Ended:
//                    rb.velocity = Vector2.zero;

//                    break;
//            }


//        }
//#endif

    }



}
