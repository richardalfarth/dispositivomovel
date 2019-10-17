using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Auth;
using Firebase.Analytics;
using Firebase.Crashlytics;
using Firebase.Database;
using Firebase.DynamicLinks;
using Firebase.Extensions;
using Firebase.Functions;
using Firebase.InstanceId;
using Firebase.Messaging;
using Firebase.RemoteConfig;
using Firebase.Storage;



public class Login : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField login;
    public InputField password;
    void Start()
    { 
        
            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                //   app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }

               DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
            });
        
            
            


    }

    public void ButtonLogin()
    {
        string login = this.login.text;
        string password = this.password.text;
        Debug.Log(name);
    }
    // Update is called once per frame
    void Update()
    {
    
    }
}
