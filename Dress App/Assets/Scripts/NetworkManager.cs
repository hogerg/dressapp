using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    private const string typeName = "Dress App";
    private const string gameName = "Szoba";
    private HostData[] hostList;
    public GameObject playerPrefab;

	private void StartServer () {
        Network.InitializeServer(4, 25000, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName);
        //MasterServer.ipAddress = "127.0.0.1";
	}

    void OnServerInitialized()
    {
        Debug.Log("Server Initialized");
        SpawnPlayer();
    }

    void OnGUI()
    {
        if(!Network.isClient && !Network.isServer)
        {
            if (GUI.Button(new Rect(200,0,250,40), "Start server"))
            {
                StartServer();
            }

            if (GUI.Button(new Rect(200, 50, 250, 40), "Refresh Hosts"))
            {
                RefreshHostList();
            }

            if (hostList != null)
            {
                for (int i = 0; i < hostList.Length; i++)
                {
                    if (GUI.Button(new Rect(200, 100 + (50 * i), 300, 40), hostList[i].gameName))
                    {
                        JoinServer(hostList[i]);
                    }
                }
            }
        }
    }

    private void RefreshHostList()
    {
        MasterServer.RequestHostList(typeName);
    }

    void OnMasterServerEvent(MasterServerEvent msEvent)
    {
        if(msEvent == MasterServerEvent.HostListReceived)
        {
            hostList = MasterServer.PollHostList();
        }
    }

    private void JoinServer(HostData hostData)
    {
        Network.Connect(hostData);
    }

    void OnConnectedToServer()
    {
        Debug.Log("Server Joined");
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        Network.Instantiate(playerPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
    }

}
