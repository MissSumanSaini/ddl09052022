using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
namespace ddl09052022
{
    public partial class WebForm1ddl : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source = SUMAN\\SQLEXPRESS; Initial catalog = ddl09052022; integrated Security = true");
        protected void Page_Load(object sender, EventArgs e)
        {
          if(!IsPostBack)  
            {
                BindGrid();
                BindBloodGroup();
                BindCountry();
            }
        }
        void BindBloodGroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblBloodGroup", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblbg.DataValueField = "bgid";
            rblbg.DataTextField = "bgname";
            rblbg.DataSource = dt;
            rblbg.DataBind();

            //grdview.DataSource = dt;
            //grdview.DataBind();
        }

        void BindGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblusers join tblBloodGroup on UserBg=bgid join tblddlCountry on UserCountry=Cid ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
                  
            grdview.DataSource = dt;
            grdview.DataBind();

        }

        void BindCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tblddlCountry", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            DdlCountry.DataValueField = "Cid";
            DdlCountry.DataTextField = "Cname";
            DdlCountry.DataSource = dt;
            DdlCountry.DataBind();
            DdlCountry.Items.Insert(0, new ListItem("--select--", "0"));
        }

        public void Clear()
        {
            txtName.Text = "";
            TxtAge.Text = "";
            rblbg.ClearSelection();
            DdlCountry.SelectedValue = "0";
            btnsave.Text = "Save";

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert into tblusers (UserName,UserAge,UserBg, UserCountry)values ('" + txtName.Text + "', '" + TxtAge.Text + "','" + rblbg.SelectedValue + "','" + DdlCountry.SelectedValue + "')", con);
                cmd.ExecuteNonQuery(); 
                con.Close();
                BindGrid();
                Clear();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Update tblusers set UserName='" + txtName.Text + "', UserAge= '" + TxtAge.Text + "',UserBg='" + rblbg.SelectedValue + "',UserCountry='" + DdlCountry.SelectedValue + "'where Userid= '" + ViewState["id"] +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
                Clear();            }

        }

        protected void grdview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "A")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from tblusers where Userid='" + e.CommandArgument +"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                BindGrid();
            }

            else if (e.CommandName == "B")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select * from tblusers where Userid='" + e.CommandArgument+ "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
               
                txtName.Text = dt.Rows[0]["UserName"].ToString();
                TxtAge.Text = dt.Rows[0]["UserAge"].ToString();
                rblbg.SelectedValue = dt.Rows[0]["UserBg"].ToString();
                DdlCountry.SelectedValue = dt.Rows[0]["UserCountry"].ToString();
                btnsave.Text = "Update";
                ViewState["id"] = e.CommandArgument;
            }
        }
    }
}