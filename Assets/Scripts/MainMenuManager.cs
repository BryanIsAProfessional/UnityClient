using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;
    public Button startQueueButton;
    public Text startQueueText;
    public Button cancelQueueButton;
    public Text serverStatusText;

    private static bool keepPingingServer = true;

    private void Start(){
        ConnectToServer();
        cancelQueueButton.gameObject.SetActive(false);
        //StartCoroutine(CheckConnection());
    }

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else if (instance != this){
            Debug.Log("Instance already exists. Destroying object");
            Destroy(this);
        }
    }

    public void FindMatch(){
        PlayerPrefs.SetInt("match_port", -1);
        // disable our queue button and show our cancel queue button
        startQueueButton.interactable = false;
        cancelQueueButton.gameObject.SetActive(true);

        startQueueText.text = "Finding a match..";

        ClientSend.Queue(true);
    }

    public void OpenLevelAfterDelay(int levelId, float time){
        StartCoroutine(OpenLevelCoroutine(levelId, time));
    }

    public IEnumerator OpenLevelCoroutine(int levelId, float time){
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(levelId);
    }

    IEnumerator CheckConnection(){
        while(keepPingingServer){
            if(Client.instance.tcp.socket.Connected){
                serverStatusText.text = "Connected to server";
            }else{
                serverStatusText.text = "Disconnected from server. Retrying connection!";
                ConnectToServer();
            }

            yield return new WaitForSeconds(5f);
        }
    }

    public void StopFindingMatch(){
        // hide our cancel queue button and reenable our queue button
        startQueueButton.interactable = true;
        cancelQueueButton.gameObject.SetActive(false);

        startQueueText.text = "Find a Match";
        
        ClientSend.Queue(false);
    }

    public void ConnectToServer(){
        Client.instance.ConnectToServer(26950);
    }

    public void QuitGame(){
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
