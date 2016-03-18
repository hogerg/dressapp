using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;

public class PlayerProperties : MonoBehaviour {

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
