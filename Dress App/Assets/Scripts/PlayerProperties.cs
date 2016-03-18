using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class PlayerProperties : NetworkBehaviour {

    //[SyncVar]
    public Sprite skinPreset;
    Sprite fullBody, top;
    
    void Start()
    {
        //Debug.Log(skinPreset.name);
    }

    public void setSkinPreset(Image skin)
    {
        skinPreset = skin.sprite;
    }

    public Sprite getSkinPreset()
    {
        return skinPreset;
    }

    public void test()
    {
        Debug.Log("TESTEST");
    }
}
