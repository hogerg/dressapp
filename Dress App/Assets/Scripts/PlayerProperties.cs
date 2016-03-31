using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.IO;

public class PlayerProperties : NetworkBehaviour {

    [SyncVar]
    public int skinPreset, cDress, cTop, cJacket, cPants, cShoes;

    //Sprite fullBody, top;
    
    void Start() { skinPreset = 1; cDress = cTop = cJacket = cPants = cShoes = 0; }

    [Command]
    public void CmdSetSkinPreset(int skin) { skinPreset = skin; }
    [Command]
    public void CmdSetDress(int dress) { cDress = dress; }
    [Command]
    public void CmdSetTop(int top) { cDress = top; }
    [Command]
    public void CmdSetJacket(int jacket) { cDress = jacket; }
    [Command]
    public void CmdSetPants(int pants) { cDress = pants; }
    [Command]
    public void CmdSetShoes(int shoes) { cDress = shoes; }

    public int getSkinPreset() { return skinPreset; }
    public int getDress() { return cDress; }
    public int getTop() { return cTop; }
    public int getJacket() { return cJacket; }
    public int getPants() { return cPants; }
    public int getShoes() { return cShoes; }

    /*void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        int skin = skinPreset, dress = cDress, top = cTop, jacket = cJacket, pants = cPants, shoes = cShoes;
        if (stream.isWriting)
        {
            skin = skinPreset;
            stream.Serialize(ref skin);
            stream.Serialize(ref dress);
            stream.Serialize(ref top);
            stream.Serialize(ref jacket);
            stream.Serialize(ref pants);
            stream.Serialize(ref shoes);
        }
        else
        {
            stream.Serialize(ref skin);
            skinPreset = skin;
            stream.Serialize(ref dress);
            cDress = dress;
            stream.Serialize(ref top);
            cTop = top;
            stream.Serialize(ref jacket);
            cJacket = jacket;
            stream.Serialize(ref pants);
            cPants = pants;
            stream.Serialize(ref shoes);
            cShoes = shoes;
        }
    }*/
}
