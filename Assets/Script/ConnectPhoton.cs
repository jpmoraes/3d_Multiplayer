using UnityEngine;
using Photon.Pun;

public class ConnectPhoton : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab01;
    public GameObject playerPrefab02;// Arraste seu prefab de jogador aqui na Unity Editor

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado ao servidor Photon.");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(playerPrefab01.name, Vector3.zero, Quaternion.identity);
        PhotonNetwork.Instantiate(playerPrefab02.name, Vector3.zero, Quaternion.identity);
    }
}