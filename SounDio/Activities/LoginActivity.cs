
namespace SounDio.Activities;

[Activity(Label = "LoginActivity")]
public class LoginActivity : Activity
{
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        SetContentView(Resource.Layout.activity_login);

        Button loginbutton = FindViewById<Button>(Resource.Id.buttonLogin);
        loginbutton.Click += LoginButton_Click;


    }

    private void LoginButton_Click(object? sender, EventArgs e)
    {
        var email = FindViewById<EditText>(Resource.Id.editTextEmail)?.Text;
        var password = FindViewById<EditText>(Resource.Id.editTextPassword)?.Text;
    }
}