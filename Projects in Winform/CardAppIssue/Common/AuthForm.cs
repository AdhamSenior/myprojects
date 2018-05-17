using System;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    using Ext;

    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
            Text = Texts.LoginToSystem;

            kwlblTitle.Text = Texts.LoginToSystem;
            klblLogin.Text = Texts.Login;
            klblPass.Text = Texts.Password;
            kbtnEnter.Text = Texts.Enter;

            kbtnEnter.Click += kbtnEnter_Click;
        }
         void kbtnEnter_Click(object sender, EventArgs e)
        {
            var login = ktbLogin.Text.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(login))
            {
                MessageBox.Show(String.Format(ErrorTexts.FieldIsEmpty, Texts.Login));
                return;
            }

            var pass = ktbPassword.Text.ToSafeTrimmedString();
            if (String.IsNullOrEmpty(pass))
            {
                MessageBox.Show(String.Format(ErrorTexts.FieldIsEmpty, Texts.Password));
                return;
            }

            User.Instance.IsDrivingLicense = true;
            User.Instance.Login = login;
            User.Instance.Password = pass;
            Auth();
        }

        async void Auth()
        {
            var wait = new WaitForm { Status = Texts.Authorization, OwnerForm = this };
            wait.Show();
           // var rs = await User.Instance.PostLogin();
            wait.Close();
            wait.Dispose();

            //if (rs.StatusCode != HttpStatusCode.OK)
            //{
            //    var sb = new StringBuilder();
            //    sb.AppendLine(String.Format(ErrorTexts.ServerAuthenticationError, rs.StatusCode));
            //    var error = ApiResponse.ParseError(rs.Content);
            //    if (!String.IsNullOrEmpty(error))
            //        sb.AppendLine(error);
            //    MessageBox.Show(sb.ToString());
            //    return;
            //}

            //var authData = ApiResponse.ParseAuth(rs.Content);
            //if (authData.ContainsKey("token"))
            //{
            //    User.Instance.AuthToken = authData["token"].ToSafeTrimmedString();
            //    await Soato.LoadRegions();
            //}

            //if (Soato.Items.Count == 0)
            //{
            //    MessageBox.Show(String.Format(ErrorTexts.ErrorLoadingEntity, Texts.Regions));
            //    return;
            //}

            //if (authData.ContainsKey("region_id"))
            //{
            //    int depId;
            //    if (int.TryParse(authData["region_id"].ToSafeTrimmedString(), out depId))
            //    {
            //        User.Instance.DepartmentId = depId;
            //        var regions = Soato.Items.Where(wh => wh.Id == depId).ToList();
            //        if (regions.Count == 1)
            //        {
            //            var region = regions.First();
            //            User.Instance.Department = region.NameUz;
            //        }
            //    }
            //}

            //if (authData.ContainsKey("id"))
            //{
            //    int tId;
            //    if (int.TryParse(authData["id"].ToSafeTrimmedString(), out tId))
            //    {
            //        User.Instance.UbddId = tId;
            //    }
            //}

            //if (!User.Instance.IsAuthorized)
            //{
            //    MessageBox.Show(ErrorTexts.FailedToAuthenticateToServer);
            //    return;
            //}

            //if (!User.Instance.IsInitDepartment)
            //{
            //    MessageBox.Show(ErrorTexts.UserHaveUnknownDepartment);
            //    return;
            //}

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
