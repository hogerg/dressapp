/*
A NetworkManager kiterjesztese a callback fuggvenyek miatt.
*/

namespace UnityEngine.Networking.Match
{
    public class ExtendedNetworkManager : NetworkManager
    {
        //Lista lekerdezes callback
        public override void OnMatchList(ListMatchResponse matchList)
        {
            //Alap eljaras
            base.OnMatchList(matchList);
            /*
            //Ez szebb lenne, ha nem itt lenne, de legalabb jol mukodik

            Debug.Log("Callback list : " + matches.Count);
            //Ha nincs meg szerver
            if (matches == null || matches.Count == 0)
            {
                Debug.Log("Ures");
                //Hozzuk letre
                matchMaker.CreateMatch(matchName, matchSize, true, "", OnMatchCreate);
            }
            //Ha van
            else
            {
                Debug.Log("Van");
                //Akkor csatlakozzunk az elsore (csak egy lehet igy)
                matchMaker.JoinMatch(matches[0].networkId, "", OnMatchJoined);
            }*/
        }

        public override void OnMatchCreate(CreateMatchResponse matchInfo)
        {
            base.OnMatchCreate(matchInfo);
        }
    }
};
