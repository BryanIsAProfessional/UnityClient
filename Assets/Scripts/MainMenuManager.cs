using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance;

    // public GameObject mainMenu;
    // public InputField usernameField;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else if (instance != this){
            Debug.Log("Instance already exists. Destroying object");
            Destroy(this);
        }
    }
}
