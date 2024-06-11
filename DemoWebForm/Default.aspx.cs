using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoWebForm
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            lblUserName.Text = "Hello "+ txtUserName.Text.Trim();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}