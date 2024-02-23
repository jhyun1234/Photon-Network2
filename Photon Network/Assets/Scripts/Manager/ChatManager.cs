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

            //  photonView.RPC�� ù��° �Ű����� : �����ų �Լ��� �̸�
            //  photonView.RPC�� �ι�° �Ű����� : ȣ���� �Լ��� ���� �� �ִ� ����� �����Ѵ�.
            //  photonView.RPC�� ����° �Ű����� : ������ �Լ��� �Ű�����

            photonView.RPC("Chatting", RpcTarget.All, chatting);
        }
        
    }
    [PunRPC]
    public void Chatting(string message)
    {
        // ChatPrefab�� �ϳ� ���� text�� ���� �����Ѵ�.
        GameObject content = Instantiate(Resources.Load<GameObject>("String"));

        content.GetComponent<Text>().text = message;
        
        // ��ũ�� �� - content�� �ڽ����� ����Ѵ�.
        content.transform.SetParent(contentTransform);

        // input �ؽ�Ʈ�� �ʱ�ȭ�Ѵ�.
        inputField.text = "";

    }
}
