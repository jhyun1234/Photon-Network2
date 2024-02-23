using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField inputField;
    [SerializeField] Transform contentTransform;
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            if(inputField.text.Length == 0)
            {
                inputField.ActivateInputField();
                return;
            }

            string chatting = PhotonNetwork.NickName + " : " + inputField.text;

            //  photonView.RPC의 첫번째 매개변수 : 실행시킬 함수의 이름
            //  photonView.RPC의 두번째 매개변수 : 호출할 함수를 받을 수 있는 대상을 지정한다.
            //  photonView.RPC의 세번째 매개변수 : 실행할 함수의 매개변수

            photonView.RPC("Chatting", RpcTarget.All, chatting);
        }
        
    }
    [PunRPC]
    public void Chatting(string message)
    {
        // ChatPrefab을 하나 만들어서 text에 값을 설정한다.
        GameObject content = Instantiate(Resources.Load<GameObject>("String"));

        content.GetComponent<Text>().text = message;
        
        // 스크롤 뷰 - content에 자식으로 등록한다.
        content.transform.SetParent(contentTransform);

        // input 텍스트를 초기화한다.
        inputField.text = "";

    }
}
