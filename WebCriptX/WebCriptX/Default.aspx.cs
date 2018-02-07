using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCriptX
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Btn_Encriptar.Click += new EventHandler(this.Btn_Encriptar_Click);
            Btn_Decriptar.Click += new EventHandler(this.Btn_Decriptar_Click);
        }

        protected void Btn_Encriptar_Click(object sender, EventArgs e)
        {
            string palavraChave = TextBoxPassword.Text.ToUpper();

            string[] fileLines = new string[1];
            fileLines[0] = TextBoxText.Text;

            string[] fileLinesEncriptado = Cifra.encriptar(fileLines, palavraChave);

            TextBoxText.Text = fileLinesEncriptado[0]; 
        }

        protected void Btn_Decriptar_Click(object sender, EventArgs e)
        {
            string palavraChave = TextBoxPassword.Text.ToUpper();

            string[] fileLines = new string[1];
            fileLines[0] = TextBoxText.Text;

            string[] fileLinesDecriptado = Cifra.decriptar(fileLines, palavraChave);

            TextBoxText.Text = fileLinesDecriptado[0];

        }

    }
}