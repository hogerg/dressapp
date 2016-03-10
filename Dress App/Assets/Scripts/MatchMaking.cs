﻿/*
Beallitja a kapcsolatot a Unity matchmakerrel, gombra kattintaskor
frissul a szerverlista. Ha mar van szerver, akkor arra csatlakozik.
Ennek jobb lenne itt lennie, de az ExtendedNetworkManager scriptben
van megirva, mert a callback fuggveny aszinkron es elobb kerdezodne
le a match lista allapota, minthogy a callback teljesen lefutna.
*/

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

#if ENABLE_UNET

public class MatchMaking : MonoBehaviour
{
    private NetworkManager manager;
    private float btOffsetX;
    private float btOffsetY;
    private float btWidth;
    private float btHeight;

    //Inicializalaskor lefut
    void Awake()
    {
        btOffsetX = (Screen.width / 1280f) * 1200;
        btOffsetY = (Screen.height / 720f) * 210;
        btWidth = (Screen.width / 1200f) * 60;
        btHeight = (Screen.height / 720f) * 300;

        manager = GetComponent<NetworkManager>();
        manager.matchName = "Test";
        manager.matchSize = 10;
        manager.SetMatchHost("mm.unet.unity3d.com", 443, true);
    }

    //Rajzolaskor meghivodik
    void OnGUI()
    {
        //Ha nincs csatlakozva
        if(!NetworkServer.active && !NetworkClient.active){
            if(manager.matchMaker == null)
                manager.StartMatchMaker();
            else
            {
                if (GUI.Button(new Rect(btOffsetX, btOffsetY, btWidth, btHeight), ""))
                {
                    manager.matchMaker.ListMatches(0, 20, "", manager.OnMatchList);
                    StartCoroutine(JoinGame());
                }
            }
        }
    }

    public IEnumerator JoinGame()
    {
        yield return new WaitForSeconds(3f);
        //Ha nincs meg host, semmi
        if (manager.matches == null || manager.matches.Count == 0)
        {
            Debug.Log("Server not started");
        }
        else
        {
            manager.matchMaker.JoinMatch(manager.matches[0].networkId, "", manager.OnMatchJoined);
            Debug.Log("Server joined : " + manager.networkAddress);
        }
    }
}

#endif