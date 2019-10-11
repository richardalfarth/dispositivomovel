using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Update is called once per frame
    void Update()
    {
    
    }
}
