using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetManager : NetworkManager {

    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        Sprite playerSprite = playerPrefab.GetComponent<PlayerProperties>().getSkinPreset();
        GameObject player = (GameObject)GameObject.Instantiate(playerPrefab, new Vector2(0f,-0.75f), Quaternion.identity);
        Debug.Log(player.GetComponent<SpriteRenderer>().sprite.name);
        player.GetComponent<SpriteRenderer>().sprite = playerSprite;
        Debug.Log(player.GetComponent<SpriteRenderer>().sprite.name);
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }
}
