using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

public class ConnectPhoton : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab01;
    public GameObject playerPrefab02;

    void Start()
    {
        if (PhotonNetwork.IsConnected)
        {
            
            int playerN = (int)PhotonNetwork.LocalPlayer.CustomProperties["PlayersN"];

            Debug.Log(playerN);
            if (playerN == 0)//
            {
                Vector3 spawn = new Vector3(0, 10, -10);
                PhotonNetwork.Instantiate(playerPrefab01.name, spawn, Quaternion.Euler(0, 0, 0), 0);
            }
            if (playerN == 1)//
            {
                Vector3 spawn = new Vector3(0, 10, 10);
                PhotonNetwork.Instantiate(playerPrefab02.name, spawn, Quaternion.Euler(0, 180, 0), 0);
            }
            
        }else
        {
            Debug.LogError("Não está conectado ao Photon. Certifique-se de ter configurado a autenticação corretamente.");
        }

    }

}