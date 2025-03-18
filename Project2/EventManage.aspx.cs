using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project2.Models;

namespace Project2
{
    public partial class EventManage : System.Web.UI.Page
    {
        private Event eventModel;

        protected void Page_Load(object sender, EventArgs e)
        {
            eventModel = new Event();
            if (!IsPostBack)
            {
                LoadEvents();
            }
        }

        private void LoadEvents()
        {
            try
            {
                gvEvents.DataSource = eventModel.Read();
                gvEvents.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error loading events: {ex.Message}');</script>");
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();
            pnlGrid.Visible = false;
            pnlForm.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    bool success;
                    if (ViewState["EventID"] == null)
                    {
                        success = eventModel.Create(
                            txtEventName.Text,
                            txtDescription.Text,
                            DateTime.Parse(txtEventDate.Text),
                            txtLocation.Text,
                            int.Parse(txtPrice.Text),
                            int.Parse(txtCapacity.Text),
                            "Active"
                        );
                    }
                    else
                    {
                        success = eventModel.Update(
                            int.Parse(ViewState["EventID"].ToString()),
                            txtEventName.Text,
                            txtDescription.Text,
                            DateTime.Parse(txtEventDate.Text),
                            txtLocation.Text,
                            int.Parse(txtPrice.Text),
                            int.Parse(txtCapacity.Text)
                        );
                    }

                    if (success)
                    {
                        LoadEvents();
                        pnlForm.Visible = false;
                        pnlGrid.Visible = true;
                    }
                    else
                    {
                        Response.Write("<script>alert('Error saving event.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error saving event: {ex.Message}');</script>");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlForm.Visible = false;
            pnlGrid.Visible = true;
        }

        protected void gvEvents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditEvent")
            {
                int eventId = Convert.ToInt32(e.CommandArgument);
                ViewState["EventID"] = eventId;
                // Load event details and populate form
                LoadEventDetails(eventId);
                pnlGrid.Visible = false;
                pnlForm.Visible = true;
            }
            else if (e.CommandName == "DeleteEvent")
            {
                try
                {
                    int eventId = Convert.ToInt32(e.CommandArgument);
                    if (eventModel.Delete(eventId))
                    {
                        LoadEvents();
                    }
                    else
                    {
                        Response.Write("<script>alert('Error deleting event.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    Response.Write($"<script>alert('Error deleting event: {ex.Message}');</script>");
                }
            }
        }

        private void LoadEventDetails(int eventId)
        {
            var dt = eventModel.Read();
            if (dt != null)
            {
                DataRow[] rows = dt.Select($"EventID = {eventId}");
                if (rows != null && rows.Length > 0)
                {
                    DataRow row = rows[0];
                    txtEventName.Text = row["EventName"].ToString();
                    txtDescription.Text = row["EventDescription"].ToString();
                    txtEventDate.Text = Convert.ToDateTime(row["EventDate"]).ToString("yyyy-MM-dd");
                    txtLocation.Text = row["Location"].ToString();
                    txtCapacity.Text = row["Capacity"].ToString();
                    txtPrice.Text = Convert.ToInt32(row["Price"]).ToString();
                }
            }
        }

        private void ClearForm()
        {
            ViewState["EventID"] = null;
            txtEventName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtEventDate.Text = string.Empty;
            txtLocation.Text = string.Empty;
            txtCapacity.Text = string.Empty;
            txtPrice.Text = string.Empty;
        }
    }
}