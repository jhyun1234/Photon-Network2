using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
using Photon.Pun.Demo.Cockpit; // 어느 서버에 접속했을 때 이벤트를 호출하는 라이브러리

public class RoomManager : MonoBehaviourPunCallbacks
{

    public Button roomCreateButton;
    public TMP_InputField roomNameInputField;
    public TMP_InputField roomPersonnelInputFiled;
    public Transform roomParentTransform;

    // 룸 목록을 저장하기 위한 자료구조

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

    // 룸에 입장한 후 호출되는 콜백 함수

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Photon Game");
    }

    public void InstantiateRoom()
    {
        // 룸 옵션을 설정한다.
        RoomOptions roomOptions = new RoomOptions();

        // 최대 접속자의 수를 설정한다.
        roomOptions.MaxPlayers = byte.Parse(roomNameInputField.text);

        // 룸의 오픈 여부를 설정한다.
        roomOptions.IsOpen = true;

        // 로비에서 룸 목록을 노출시킬지 설정한다.
        roomOptions.IsVisible = true;

        // 룸을 생성하는 함수
        PhotonNetwork.CreateRoom(roomNameInputField.text, roomOptions);
    }

    // 해당 로비에 방 목록의 변경 사항이 있으면 호출(추가 , 삭제 ,참가) 되는 콜백 함수

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // 1. 룸을 삭제한다.

        // 2. 룸을 업데이트한다.

        // 3. 룸을 생성한다.
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
            // 해당 이름이 roomDictionary의 key 값으로 설정되어 있다면?
            if (roomDitionary.ContainsKey(roomList[i].Name))
            {
                // RemovedFromList : (true) 룸에서 삭제되었을 때
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
