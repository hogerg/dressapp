using UnityEngine;
using System.Collections;

public class OfflineControls : MonoBehaviour {

    public float speed;

    void Update()
    {
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
