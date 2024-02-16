using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class NickName : MonoBehaviourPunCallbacks
{
    [SerializeField] TextMeshProUGUI nickName;
    void Start()
    {
        nickName.text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
