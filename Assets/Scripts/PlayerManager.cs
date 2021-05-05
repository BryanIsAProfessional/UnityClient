using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int id;
    public string username;
    public int health;
    public int maxHealth;
    public int itemCount = 0;
    
    public MeshRenderer model;

    public void Initialize(int _id, string _username){
        id = _id;
        username = _username;
        health = maxHealth;
    }

    public void SetHealth(int _health){
        health = _health;

        if(health <= 0){
            Die();
        }
    }

    public void Die(){
        model.enabled = false;
    }

    public void Respawn(){
        model.enabled = true;
        SetHealth(maxHealth);
    }
}
