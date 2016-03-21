using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class PlayerProperties : NetworkBehaviour {

    [SyncVar]
    public int skinPreset;

    //Sprite fullBody, top;
    
    void Start()
    {
        skinPreset = 1;
    }

    [Command]
    public void CmdSetSkinPreset(int skin)
    {
        skinPreset = skin;
    }

    public int getSkinPreset()
    {
        return skinPreset;
    }

    void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        int skin = skinPreset;
        if (stream.isWriting)
        {
            skin = skinPreset;
            stream.Serialize(ref skin);
        }
        else
        {
            stream.Serialize(ref skin);
            skinPreset = skin;
        }
    }
}
