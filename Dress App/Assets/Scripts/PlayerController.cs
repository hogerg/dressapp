using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerController : NetworkBehaviour {

    public float speed;
	
	void Update () {
        if (!isLocalPlayer) return;
        InputMovement();
	}

    private void InputMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + Vector2.up * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position - Vector2.up * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position + Vector2.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            GetComponent<Rigidbody2D>().MovePosition(GetComponent<Rigidbody2D>().position - Vector2.right * speed * Time.deltaTime);
    }
}
