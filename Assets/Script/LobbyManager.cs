using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public InputField roomNameCreate;
    public InputField roomName;
    public InputField nickname;
    public GameObject OpRoom;
    public GameObject Lobby;
    public Text nomeSalaText; // Adicione uma referência ao objeto de texto para mostrar o nome da sala.
    public List<Text> playerTexts = new List<Text>();
    private bool isUpdatingPlayerList = false;

    void Start()
    {
        OpRoom.SetActive(true);
        Lobby.SetActive(false);
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conectado ao servidor Photon");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Entrou no Lobby");
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4;
        roomOptions.CleanupCacheOnLeave = false;
        PhotonNetwork.CreateRoom(roomNameCreate.text, roomOptions);
        
    }

    public void JoinRoom()
    {
     
        PhotonNetwork.JoinRoom(roomName.text);
        Debug.Log(roomName.text);

    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.NickName = nickname.text;
        Debug.Log("Entrou na sala: " + PhotonNetwork.CurrentRoom.Name);
        OpRoom.SetActive(false);
        Lobby.SetActive(true);
        nomeSalaText.text = "Nome da Sala: " + PhotonNetwork.CurrentRoom.Name;
        UpdatePlayerList();
    }

    public override void OnPlayerLeftRoom(Player player)
    {
        Debug.Log(PhotonNetwork.NickName + " entrou na sala.");
        UpdatePlayerList();
    }

    private void UpdatePlayerList()
    {
        foreach (Text playerText in playerTexts)
        {
            playerText.text = "";
        }

        // Preenche os textos com os nomes dos jogadores na sala.
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            playerTexts[i].text = PhotonNetwork.PlayerList[i].NickName;
        }
    }

    public void VoltarCriarSala()
    {
        //PhotonNetwork.LeaveRoom();
        OpRoom.SetActive(true);
        Lobby.SetActive(false);

        if (!isUpdatingPlayerList)
        {
            StartCoroutine(DelayedUpdatePlayerList(2f)); // Atraso de 2 segundos antes de atualizar a lista.
        }

    }


    private IEnumerator DelayedUpdatePlayerList(float delay)
    {
        isUpdatingPlayerList = true;
        yield return new WaitForSeconds(delay);

        // Atualize a lista de jogadores após o atraso.
        UpdatePlayerList();

        isUpdatingPlayerList = false;
    }

}

