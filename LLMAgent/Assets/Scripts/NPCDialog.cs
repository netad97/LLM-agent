using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class NPCDialog : MonoBehaviour
{
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject toActivate;
    [SerializeField] private Transform standingPoint;

    private Transform avatar;

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            avatar = other.transform;

            // disable player input

            avatar.GetComponent<PlayerInput>().enabled = false;

            await Task.Delay(50);

            // teleport the avatar to standing point

            avatar.position = standingPoint.position;
            avatar.rotation = standingPoint.rotation;

            // disable main cam, enable dialog cam

            mainCamera.SetActive(false);
            toActivate.SetActive(true);

            // display cursor

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void Recover()
    {
        // disable player input

        avatar.GetComponent<PlayerInput>().enabled = true;

        mainCamera.SetActive(true);
        toActivate.SetActive(false);

        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }
}
