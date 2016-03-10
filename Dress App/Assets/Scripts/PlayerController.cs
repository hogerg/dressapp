using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

    public float speed;
	
	void Update () {
        if (!isLocalPlayer) return;
        speed = 10;
        InputMovement();
	}

    private void InputMovement()
    {
        Vector2 newPos;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos = GetComponent<Rigidbody2D>().position + Vector2.up * speed * Time.deltaTime;
            if (newPos.y < 3f)
                GetComponent<Rigidbody2D>().MovePosition(newPos);
            else
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(newPos.x, 3f));
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPos = GetComponent<Rigidbody2D>().position - Vector2.up * speed * Time.deltaTime;
            if(newPos.y > -3f)
                GetComponent<Rigidbody2D>().MovePosition(newPos);
            else
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(newPos.x, -3f));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPos = GetComponent<Rigidbody2D>().position + Vector2.right * speed * Time.deltaTime;
            if(newPos.x < 5.8f)
                GetComponent<Rigidbody2D>().MovePosition(newPos);
            else
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(5.8f, newPos.y));
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPos = GetComponent<Rigidbody2D>().position - Vector2.right * speed * Time.deltaTime;
            if (newPos.x > -2.5f)
                GetComponent<Rigidbody2D>().MovePosition(newPos);
            else
                GetComponent<Rigidbody2D>().MovePosition(new Vector2(-2.5f, newPos.y));
        }

        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // If the finger is on the screen, move the object smoothly to the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                newPos = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
                //transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime);
                if(newPos.x > -2.5f && newPos.x < 5.8f && newPos.y < 3f && newPos.y > -3f)
                {
                    transform.position = newPos;
                }
            }
        }
    }
}
