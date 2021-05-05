using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public static HUDManager instance;

    public Text health;
    public Text bombs;
    public GameObject player;

    private void Awake(){
        if(instance == null){
            instance = this;
        }
        else if (instance != this){
            Debug.Log("Instance already exists. Destroying object");
            Destroy(this);
        }
    }

    public void Update(){
        if(player != null){
            health.text = "" + player.GetComponent<PlayerManager>().health;
            bombs.text = "" + player.GetComponent<PlayerManager>().itemCount;
        }
    }
}