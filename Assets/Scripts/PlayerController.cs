using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform camTransform;
    private GameObject pauseMenu;
    public GameObject pauseMenuPrefab;

    private void Start(){
        pauseMenu = Instantiate(pauseMenuPrefab, Vector3.zero, Quaternion.identity);
    }

    private void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0)){
            ClientSend.PlayerShoot(camTransform.forward);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1)){
            ClientSend.PlayerThrowItem(camTransform.forward);
        }

        if(Input.GetKeyDown(KeyCode.Escape)){
            TogglePauseMenu();
        }
    }

    private void FixedUpdate(){
        SendInputToServer();
    }

    private void SendInputToServer(){
        bool[] _inputs = new bool[]{
            Input.GetKey(KeyCode.W),
            Input.GetKey(KeyCode.A),
            Input.GetKey(KeyCode.S),
            Input.GetKey(KeyCode.D),
            Input.GetKey(KeyCode.Space)
        };

        ClientSend.PlayerMovement(_inputs);
    }

    private void TogglePauseMenu(){
        pauseMenu.GetComponent<PauseMenuManager>().TogglePauseMenu();
    }
}
