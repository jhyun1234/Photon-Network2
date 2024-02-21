using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Photon.Pun;
using PlayFab.GroupsModels;
public class PhotonPlayer : MonoBehaviourPun
{
    [SerializeField] float speed;
    [SerializeField] float mouseX;
    [SerializeField] float rotateSpeed;

    [SerializeField] Vector3 direction;
    [SerializeField] Camera temporaryCamera;
    void Start()
    {
        // ���� �÷��̾ �� �ڽ��̶��
        if (photonView.IsMine)
        {
            Camera.main.gameObject.SetActive(false);
        }
        else
        {
            temporaryCamera.enabled = false;

            GetComponentInChildren<AudioListener>().enabled = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
         if (PhotonNetwork.IsMasterClient)
         {
                Debug.Log("Master Client");
         }
        if (photonView.IsMine == false) return;

        

        Movement();
    }

    public void Movement()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.x = Input.GetAxisRaw("Vertical");

        direction.Normalize();

        // TransformDirection: �ڱⰡ �ٶ󺸰� �ִ� �������� �̵��ϴ� �Լ��̴�.
        transform.position += transform.TransformDirection(direction) * speed * Time.deltaTime;
    }

    public void Rotation()
    {
        mouseX += Input.GetAxisRaw("Mouse X") * rotateSpeed * Time.deltaTime;

        transform.eulerAngles = new Vector3(0, mouseX, 0);
    }

}     

