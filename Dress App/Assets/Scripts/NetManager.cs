using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetManager : NetworkManager {

    public override void OnClientConnect(NetworkConnection conn)
    {
        ClientScene.AddPlayer(conn, 0);
    }

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Debug.Log("ONSERVERADDPLAYER");
        Sprite playerSprite = playerPrefab.GetComponent<PlayerProperties>().getSkinPreset();
        GameObject player = (GameObject)GameObject.Instantiate(playerPrefab, new Vector2(0f, -0.75f), Quaternion.identity);
        player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }

}
