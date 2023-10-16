using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
public class MudarCena : MonoBehaviour
{
    public void Jogar()
    {
        PhotonNetwork.LoadLevel("Jogo");
        SceneManager.LoadScene("Jogo");
    }

}
