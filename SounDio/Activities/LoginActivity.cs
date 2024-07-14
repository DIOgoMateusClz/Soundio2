using Android.Accounts;
using Firebase.Database;
using SounDio.BaseClasses;

namespace SounDio.Activities { 

[Activity(Label = "LoginActivity")]
public class LoginActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SetContentView(Resource.Layout.activity_login);

        Button loginbutton = FindViewById<Button>(Resource.Id.buttonLogin);
        //Sobrecarrega o método do CLICK
        loginbutton.Click += LoginButton_Click;


    }

    private async void LoginButton_Click(object? sender, EventArgs e)
    {
        //Captura os valores do campo de texto da tela
        var email = FindViewById<EditText>(Resource.Id.editTextEmail)?.Text;
        var password = FindViewById<EditText>(Resource.Id.editTextPassword)?.Text;

        //Conecta com o Banco de dados Realtime Database do Firebase
        FirebaseClient firebase = new FirebaseClient("https://bancododio-4535e-default-rtdb.firebaseio.com/");

            var usuario = (await firebase
                    .Child("usuarios")
                    .OnceAsync<Usuario>()).Select(item => new Usuario
                    {
                        Email = item.Object.Email,
                        Senha = item.Object.Senha,
                        Nome = item.Object.Nome
                    }).Where(item => item.Email == email).FirstOrDefault();

            if (usuario != null)
            {
                if(usuario.Senha == password)
                {
                    Toast.MakeText(this, "Usuário logado com sucesso!", ToastLength.Short)?.Show();
                }
                else
                {
                    Toast.MakeText(this, "Senha incorreta!", ToastLength.Short)?.Show();
                }
            }else
            {
                Toast.MakeText(this, "Usuário não encontrado!", ToastLength.Short)?.Show();
            }
                

        }   
    }
}