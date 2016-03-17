/*
Szerver oldali scriptek: szerver inditas, leallitas
*/

using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

#if ENABLE_UNET

public class ServerScript : MonoBehaviour
{
    private NetworkManager manager;
    private float btOffsetX, btOffsetY, btWidth, btHeight, scaleX, scaleY;

    void Awake()
    {
        manager = GetComponent<NetworkManager>();
        manager.matchName = "Dress App Server";
        manager.matchSize = 4;
        manager.SetMatchHost("mm.unet.unity3d.com", 443, true);

        scaleX = Screen.width / 1280f;
        scaleY = Screen.height / 720f;
        btOffsetX = 30;
        btOffsetY = 620;
        btWidth = 300;
        btHeight = 50;
    }

    void Update()
    {
        scaleX = Screen.width / 1280f;
        scaleY = Screen.height / 720f;
    }

    void OnGUI()
    {
        //Ha nincs csatlakozva
        if(!NetworkServer.localClientActive)
        {
            if (manager.matchMaker == null)
                manager.StartMatchMaker();
            else
            {
                //Gombnyomasra inditja a szerver
                if (GUI.Button(new Rect(btOffsetX * scaleX, btOffsetY * scaleY, btWidth * scaleX, btHeight * scaleY), "Start Server"))
                {
                    manager.matchMaker.ListMatches(0, 20, "", manager.OnMatchList);
                    StartCoroutine(CreateGame());
                }
            }
        }
        //Ha csatlakozva van
        else
        {
            //Gombnyomasra leallitja a szervert
            if (GUI.Button(new Rect(btOffsetX * scaleX, btOffsetY * scaleY, btWidth * scaleX, btHeight * scaleY), "Stop Server"))
            {
                manager.matchMaker.DropConnection(manager.matchInfo.networkId, manager.matchInfo.nodeId, OnMatchmakerDrop);
            }
        }
    }

    //Callback metodus a kapcsolat resetelesre
    void OnMatchmakerDrop(UnityEngine.Networking.Match.BasicResponse response)
    {
        Debug.Log("Server stopped; " + response.ToString());
        NetworkServer.Reset();
        NetworkClient.ShutdownAll();
    }

    //Az aszinkronitas miatt varni kell egy kicsit, hogy frissuljon a host lista
    public IEnumerator CreateGame()
    {
        yield return new WaitForSeconds(3f);
        //Ha nincs meg host, akkor inditja a szervert
        if (manager.matches == null || manager.matches.Count == 0)
        {
            manager.matchMaker.CreateMatch(manager.matchName, manager.matchSize, true, "", manager.OnMatchCreate);
            Debug.Log("Server Started");
        }
        else
        {
            Debug.Log("A server is already running");
        }
    }
}

#endif