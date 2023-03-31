using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrudOperationWithStoredProcedureGrid
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindGrid();
            }

        }

        public void BindGrid()
        {
            string cs = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            SqlConnection con;

            try
            {
                using (con = new SqlConnection(cs))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("GetData", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    sda.Fill(ds);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    DropDownList2.Items.Insert(0, new ListItem("----Select Product----"));
                    int totatrow = ds.Tables[0].Rows.Count;
                    int c = 0;
                    while (c < totatrow)
                    {
                        DropDownList2.Items.Add(ds.Tables[0].Rows[c]["ProductName"].ToString());
                        c++;
                    }
                    
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            SqlConnection con;

            string ProductId, ProductName, ProductDescription;
            ProductId = ((TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            ProductName = ((TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
            ProductDescription = ((TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0]).Text;

            
            string s = "Update SP_Update set ProductName = '" + ProductName + "', ProductDescription= '" + ProductDescription + "' where ProductId = '" + ProductId + "'";
            using (con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("SP_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_Update";
                cmd.Parameters.AddWithValue("@ProductId", ProductId);
                cmd.Parameters.AddWithValue("@ProductName", ProductName);
                cmd.Parameters.AddWithValue("@ProductDescription", ProductDescription);
                con.Open();
                cmd.ExecuteNonQuery();
                GridView1.EditIndex = -1;
                BindGrid();
                con.Close();
            }                
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["dbCon"].ConnectionString;
            SqlConnection con;
            string s = "select * from Search_SP where ProductName = " + DropDownList2.SelectedItem.Text;
            using (con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Search_SP", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetData";
                con.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                GridView1.DataSource = ds;
                GridView1.DataBind();
                
                con.Close();
            }         
        }
    }
}
    
