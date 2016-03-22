/*
Beallitja a kapcsolatot a Unity matchmakerrel, gombra kattintaskor
frissul a szerverlista. Ha mar van szerver, akkor arra csatlakozik.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.Match;
using UnityEngine.UI;

#if ENABLE_UNET

public class MatchMaking : MonoBehaviour
{
    private NetworkManager manager;
    private float btOffsetX, btOffsetY, btWidth, btHeight, scale;

    Texture2D connectImageNormal, connectImageHover;

    //Inicializalaskor lefut
    void Awake()
    {
        DontDestroyOnLoad(manager);
        scale = Screen.width / 1280f;
        btOffsetX = 920 * scale;
        btOffsetY = 160 * scale;
        btWidth = 280 * scale;
        btHeight = 560 * scale;

        manager = GetComponent<NetworkManager>();
        manager.matchName = "Test";
        manager.matchSize = 4;
        manager.SetMatchHost("mm.unet.unity3d.com", 443, true);

        connectImageNormal = Resources.Load("zart_ajto") as Texture2D;
        connectImageHover = Resources.Load("nyitott_ajto") as Texture2D;
    }

    //Rajzolaskor meghivodik
    void OnGUI()
    {
        //Gomb kepek beallitasa
        GUI.skin.button.normal.background = connectImageNormal;
        GUI.skin.button.hover.background = connectImageHover;
        GUI.skin.button.active.background = connectImageHover;
        //Ha nincs csatlakozva
        if (Application.loadedLevelName == "mainScene" || (!NetworkServer.active && !NetworkClient.active))
        {
            if (manager.matchMaker == null)
                manager.StartMatchMaker();
        }
        else
        {
            if (Application.loadedLevelName == "multiScene")
            {
                GameObject obj = GameObject.Find("Button_Disconnect");
                if (obj != null)
                {
                    Button bt = obj.GetComponent<Button>();
                    if (bt != null)
                    {
                        bt.onClick.RemoveAllListeners();
                        bt.onClick.AddListener(DisconnectFromServer);
                    } 
                }
            }
        }
    }

    public void ListMatches()
    {
        manager.matchMaker.ListMatches(0, 20, "", ConnectToServer);
    }

    private void ConnectToServer(ListMatchResponse matchList)
    {
        manager.OnMatchList(matchList);
        //Ha nincs meg host, semmi
        if (manager.matches == null || manager.matches.Count == 0)
        {
            Debug.Log("Server not started");
        }
        else
        {
            //manager.matchMaker.JoinMatch(manager.matches[0].networkId, "", manager.OnMatchJoined);
            manager.matchMaker.JoinMatch(manager.matches[0].networkId, "", manager.OnMatchJoined);
            Debug.Log("Server joined : " + manager.networkAddress); 
        }
    }

    public void DisconnectFromServer()
    {
        manager.matchMaker.DropConnection(manager.matchInfo.networkId, manager.matchInfo.nodeId, OnMatchmakerDrop);
        
    }

    void OnMatchmakerDrop(UnityEngine.Networking.Match.BasicResponse response)
    {
        manager.OnClientDisconnect(manager.client.connection);
        Debug.Log("Client disconnected; " + response.ToString());
    }

}

#endif