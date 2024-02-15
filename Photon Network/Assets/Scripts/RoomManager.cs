using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Photon.Pun.Demo.Cockpit; // ��� ������ �������� �� �̺�Ʈ�� ȣ���ϴ� ���̺귯��

public class RoomManager : MonoBehaviourPunCallbacks
{

    public Button roomCreateButton;
    public TMP_InputField roomNameInputField;
    public TMP_InputField roomPersonnelInputFiled;
    public Transform roomParentTransform;

    // �� ����� �����ϱ� ���� �ڷᱸ��

    Dictionary<string, RoomInfo> roomDitionary = new Dictionary<string, RoomInfo>();


    void Update()
    {
        if(roomNameInputField.text.Length > 0 && roomPersonnelInputFiled.text.Length>0)
        {
            roomCreateButton.interactable = true;

        }
        else
        {
            roomCreateButton.interactable = false;
        }
    }

    // �뿡 ������ �� ȣ��Ǵ� �ݹ� �Լ�

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Photon Game");
    }

    public void InstantiateRoom()
    {
        // �� �ɼ��� �����Ѵ�.
        RoomOptions roomOptions = new RoomOptions();

        // �ִ� �������� ���� �����Ѵ�.
        roomOptions.MaxPlayers = byte.Parse(roomNameInputField.text);

        // ���� ���� ���θ� �����Ѵ�.
        roomOptions.IsOpen = true;

        // �κ񿡼� �� ����� �����ų�� �����Ѵ�.
        roomOptions.IsVisible = true;

        // ���� �����ϴ� �Լ�
        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    // �ش� �κ� �� ����� ���� ������ ������ ȣ��(�߰� , ���� ,����) �Ǵ� �ݹ� �Լ�

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // 1. ���� �����Ѵ�.

        // 2. ���� ������Ʈ�Ѵ�.

        // 3. ���� �����Ѵ�.
    }

    public void RemoveRoom()
    {
        foreach(Transform roomTransform in roomParentTransform)
        {
            Destroy(roomTransform.gameObject);
        }
    }

    public void UpdateRoom(List<RoomInfo> roomList)
    {
        for(int i=0; i <roomList.Count; i++)
        {
            // �ش� �̸��� roomDictionary�� key ������ �����Ǿ� �ִٸ�?
            if (roomDitionary.ContainsKey(roomList[i].Name))
            {
                // RemovedFromList : (true) �뿡�� �����Ǿ��� ��
                if (roomList[i].RemovedFromList)
                {
                    roomDitionary.Remove(roomList[i].Name);

                }
                else
                {
                    roomDitionary[roomList[i].Name] = roomList[i];
                }
            }
            else
            {
                roomDitionary[roomList[i].Name] = roomList[i];
            }
        }
    }
}
