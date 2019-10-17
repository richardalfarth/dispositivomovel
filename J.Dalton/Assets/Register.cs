using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Auth;

public class Register : MonoBehaviour
{
    // Start is called before the first frame update
    
    public InputField name;
    public InputField login;
    public InputField password;
    public InputField confirmPassword;

    public Button[] buttons;
    public InputField[] inputFields;

    public Text idLogado, nickLogado, emailLogado;

    private FirebaseAuth auth;
    private FirebaseUser user;

  
    void Start()
    {
        IniciarFirebase();    
    }

    public void IniciarFirebase()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {

            var dependencyStatus = task.Result;

            if (dependencyStatus == DependencyStatus.Available)
            {
                Debug.Log("Verificação concluída, Firebase ativado");
                Debug.Log("Teste");
            
                auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

              

                auth.StateChanged += AuthStateChanged;
                AuthStateChanged(this, null);
            }

            else
            {
                Debug.LogError(System.String.Format("Não foi possível resolver todas as dependências do Firebase: {0}", dependencyStatus));
            }

        });
    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        
        if (auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if (!signedIn && user != null)
            {
                Debug.Log("Usuário foi Desconectado");
            }

            user = auth.CurrentUser;

            if (signedIn)
            {
                Debug.Log("Usuario Conectado");
            }
        }
    }

    void OnDestroy()
    {
        auth.StateChanged -= AuthStateChanged;
        // auth = null;
    }
    public async void ButtonRegister()
    {
        string name = this.name.text;
        string login = this.login.text;
        string passoword = this.password.text;
        string confirm = this.confirmPassword.text;
        if (passoword ==  confirm)
        {
            await auth.CreateUserWithEmailAndPasswordAsync(login, passoword).ContinueWith(task =>
            {
                if (auth.CurrentUser == null)
                {
                    Debug.Log("Ocorreu um erro no cadastro");
                }
                else
                {
                    EnviarEmailVerificacao();

                    Logout();
                }
            });
            
        }
        else
        {
            Debug.Log("Confirmação de senha inválida");
        }
    }
    public async void EnviarEmailVerificacao()
    {
        if (auth.CurrentUser != null)
        {
            await auth.CurrentUser.SendEmailVerificationAsync().ContinueWith(task => {

            });
            Debug.Log("Email enviado com sucesso");
        }
    }

    public void Perfil()
    {
        if (auth.CurrentUser != null)
        {
            Debug.Log(auth.CurrentUser.UserId);
        }
    }
    public void Logout()
    {
        auth.SignOut();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
