using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun; // ���ǉ�
using Photon.Realtime; // ���ǉ�

public class PhotonSetup : MonoBehaviourPunCallbacks
{
    //player
    public GameObject PhotonObject;

    // Start is called before the first frame update
    void Start()
    {
        //�T�[�o�[�ɐڑ�
        PhotonNetwork.ConnectUsingSettings();
    }

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //�T�[�o�[�ڑ�����
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    //���r�[��������
    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    //�������s
    // �����Ɏ��s�����ꍇ�ɌĂ΂��R�[���o�b�N
    // �P�l�ڂ͕������Ȃ����ߕK�����s����̂ŕ������쐬����
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 4; // �ő�8�l�܂œ����\
        PhotonNetwork.CreateRoom(null, roomOptions); //�������̓��[����
    }


    public override void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(
            PhotonObject.name,
            new Vector3(0f, 1f, 0f),    //�|�W�V����
            Quaternion.identity,    //��]
            0
        );
        GameObject mainCamera = GameObject.FindWithTag("MainCamera");
        mainCamera.GetComponent<UnityChan.ThirdPersonCamera>().enabled = true;
    }
}
