using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : NetworkBehaviour {

    public Sprite[] skins;
    public Sprite[] dresses;
    public Sprite[] tops;
    public Sprite[] jackets;
    public Sprite[] shoes;
    public int playerSkin;
    public int cDress, cTop, cJacket, cPants, cShoes;

    [SyncVar(hook = "OnPlayerSkinChanged")] public int playerSkinSync;
    [SyncVar(hook = "OnDressChanged")] public int cDressSync;
    [SyncVar(hook = "OnTopChanged")] public int cTopSync;
    [SyncVar(hook = "OnJacketChanged")] public int cJacketSync;
    [SyncVar(hook = "OnShoesChanged")] public int cShoesSync;

    public float speed;

    public override void OnStartLocalPlayer()
    {
        CmdSetPlayerSkin(playerSkin);
        CmdSetDress(cDress);
        CmdSetTop(cTop);
        CmdSetJacket(cJacket);
        CmdSetShoes(cShoes);
    }

    [Command]
    void CmdSetPlayerSkin(int var)
    {
        playerSkinSync = var;
    }

    [Command]
    void CmdSetDress(int var)
    {
        cDressSync = var;
    }

    [Command]
    void CmdSetTop(int var)
    {
        cTopSync = var;
    }

    [Command]
    void CmdSetJacket(int var)
    {
        cJacketSync = var;
    }

    [Command]
    void CmdSetShoes(int var)
    {
        cShoesSync = var;
    }

    public override void OnStartClient()
    {
        OnPlayerSkinChanged(playerSkinSync);
        OnDressChanged(cDressSync);
        OnTopChanged(cTopSync);
        OnJacketChanged(cJacketSync);
        OnShoesChanged(cShoesSync);
    }

    void OnPlayerSkinChanged(int val)
    {
        GetComponent<SpriteRenderer>().sprite = skins[val];
    }

    void OnDressChanged(int val)
    {
        if (val > 0)
            transform.Find("clothes_dress").GetComponent<SpriteRenderer>().sprite = dresses[val - 1];
    }

    void OnTopChanged(int val)
    {
        if (val > 0)
            transform.Find("clothes_top").GetComponent<SpriteRenderer>().sprite = tops[val - 1];
    }

    void OnJacketChanged(int val)
    {
        if (val > 0)
            transform.Find("clothes_jacket").GetComponent<SpriteRenderer>().sprite = jackets[val - 1];
    }

    void OnShoesChanged(int val)
    {
        if (val > 0)
            transform.Find("clothes_shoes").GetComponent<SpriteRenderer>().sprite = shoes[val - 1];
    }

    void Update () {
        if (!isLocalPlayer) return;

        speed = 10;
        InputMovement();
    }

    public void setPlayerSkin(int i) { playerSkin = i; }
    public void setDress(int i) { cDress = i; }
    public void setTop(int i) { cTop = i; }
    public void setJacket(int i) { cJacket = i; }
    public void setPants(int i) { cPants = i; }
    public void setShoes(int i) { cShoes = i; }

    private void InputMovement()
    {
        Vector2 newPos;
        /*if (Input.GetKey(KeyCode.UpArrow))
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
        }*/

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
                touchPosition.y = -0.75f;
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
