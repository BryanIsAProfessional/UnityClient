using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Start(){
        ConnectToServer();
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

    public void ConnectToServer(){
        Client.instance.ConnectToServer(-1);
    }
}
