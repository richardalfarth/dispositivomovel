using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    public string username;
    public string email;
    public string password;

    public User()
    {

    }

    public User(string name, string email)
    {
        this.name = name;
        this.email = email;
    }

    public User(string username, string email, string password)
    {
        this.username = username;
        this.email = email;
        this.password = password;   
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
