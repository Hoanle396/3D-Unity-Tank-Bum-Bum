using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using Photon;
using Photon.Pun;
using Photon.Realtime;
using System;
[System.Serializable]
public class PunManager : MonoBehaviourPunCallbacks {
    [SerializeField]
    private Transform spawnpoint, spawnpoint2;
    [SerializeField]
    private GameObject player;

    public GameObject camera;

    public override void OnConnectedToMaster() {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
    }

    public override void OnJoinedRoom() {
        Vector3 position;
        if (PhotonNetwork.CountOfPlayersInRooms > 1) {
            position = spawnpoint2.position;
        } else { position = spawnpoint.position; }
        GameObject go = PhotonNetwork.Instantiate(player.name, position, Quaternion.identity, 0);
        camera.GetComponentInChildren<CameraFollow>().target = go.transform;
    }

    public override void OnJoinedLobby() {
        base.OnJoinedLobby();
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom("room",roomOptions:roomOptions,typedLobby:TypedLobby.Default);
    }


    void Start() {
        PhotonNetwork.ConnectUsingSettings();
    }

}