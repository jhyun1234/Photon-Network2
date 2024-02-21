using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using PlayFab.ClientModels;
public class NickName : MonoBehaviourPunCallbacks
{
    
    [SerializeField] TextMeshProUGUI nickName;
    [SerializeField] Camera playerCamera;
    void Start()
    {
       
        Debug.Log("Photon Network ID :"+PhotonNetwork.NickName);

        nickName.text = photonView.Owner.NickName;



    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = playerCamera.transform.forward;
    }
}
