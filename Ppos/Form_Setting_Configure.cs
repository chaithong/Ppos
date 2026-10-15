using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Setting_Configure : Form
    {
        private Form_Main _main;
        public Form_Setting_Configure(Form_Main form_Main)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _main = form_Main;

            if (!Class_Parameter.login_program)
            {
                login_program.Image = Ppos.Properties.Resources.uncheck;
            }
            /*if (!Class_Parameter.hide_menu)
            {
                hide_menu.Image = Ppos.Properties.Resources.uncheck;
            }*/
            if (!Class_Parameter.use_item_medium_large)
            {
                use_item_medium_large.Image = Ppos.Properties.Resources.uncheck;
            }
            if (!Class_Parameter.custom_cost_adjust)
            {
                custom_cost_adjust.Image = Ppos.Properties.Resources.uncheck;
            }
        }

        private void Click_Status(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection con_sqlite = new SQLiteConnection(Form_Login.sqlite_path))
                {
                    con_sqlite.Open();
                    using (SQLiteCommand cmd_sqlite = new SQLiteCommand(con_sqlite))
                    {
                        PictureBox pictureBox = (PictureBox)sender;
                        if (pictureBox.Name == "login_program")
                        {
                            if (Class_Parameter.login_program)
                            {
                                cmd_sqlite.CommandText = "UPDATE Setting_Configure SET " +
                                    "status = 0, " +
                                    "updated_date = datetime('now', 'localtime'), " +
                                    "updated_by = '" + Class_Parameter.User_Login + "' " +
                                    "WHERE title = 'login_program'";
                                cmd_sqlite.ExecuteNonQuery();

                                Class_Parameter.login_program = false;

                                login_program.Image = Ppos.Properties.Resources.uncheck;
                            }
                            else
                            {
                                cmd_sqlite.CommandText = "UPDATE Setting_Configure SET " +
                                   "status = 1, " +
                                   "updated_date = datetime('now', 'localtime'), " +
                                   "updated_by = '" + Class_Parameter.User_Login + "' " +
                                   "WHERE title = 'login_program'";
                                cmd_sqlite.ExecuteNonQuery();

                                Class_Parameter.login_program = true;

                                login_program.Image = Ppos.Properties.Resources.check;
                            }
                        }
                       /* else if (pictureBox.Name == "hide_menu")
                        {
                            if (Class_Parameter.hide_menu)
                            {
                                cmd_sqlite.CommandText = "UPDATE Setting_Configure SET " +
                                  "status = 0, " +
                                  "updated_date = datetime('now', 'localtime'), " +
                                  "updated_by = '" + Class_Parameter.User_Login + "' " +
                                  "WHERE title = 'hide_menu'";
                                cmd_sqlite.ExecuteNonQuery();

                                //_main.SetButtonVisibility(false);

                                Class_Parameter.hide_menu = false;

                                hide_menu.Image = Ppos.Properties.Resources.uncheck;
                            }
                            else
                            {
                                cmd_sqlite.CommandText = "UPDATE Setting_Configure SET " +
                                  "status = 1, " +
                                  "updated_date = datetime('now', 'localtime'), " +
                                  "updated_by = '" + Class_Parameter.User_Login + "' " +
                                  "WHERE title = 'hide_menu'";
                                cmd_sqlite.ExecuteNonQuery();

                                // _main.SetButtonVisibility(true);

                                Class_Parameter.hide_menu = true;

                                hide_menu.Image = Ppos.Properties.Resources.check;
                            }

                        }*/
                        else if (pictureBox.Name == "use_item_medium_large")
                        {
                            if (Class_Parameter.use_item_medium_large)
                            {
                                cmd_sqlite.CommandText = "UPDATE Setting_Configure SET " +
                                  "status = 0, " +
                                  "updated_date = datetime('now', 'localtime'), " +
                                  "updated_by = '" + Class_Parameter.User_Login + "' " +
                                  "WHERE title = 'use_item_medium_large'";
                                cmd_sqlite.ExecuteNonQuery();

                                //_main.SetButtonVisibility(false);

                                Class_Parameter.use_item_medium_large = false;

                                use_item_medium_large.Image = Ppos.Properties.Resources.uncheck;
                            }
                            else
                            {
                                cmd_sqlite.CommandText = "UPDATE Setting_Configure SET " +
                                  "status = 1, " +
                                  "updated_date = datetime('now', 'localtime'), " +
                                  "updated_by = '" + Class_Parameter.User_Login + "' " +
                                  "WHERE title = 'use_item_medium_large'";
                                cmd_sqlite.ExecuteNonQuery();

                                // _main.SetButtonVisibility(true);

                                Class_Parameter.use_item_medium_large = true;

                                use_item_medium_large.Image = Ppos.Properties.Resources.check;
                            }

                        }
                        else if (pictureBox.Name == "custom_cost_adjust")
                        {
                            if (Class_Parameter.custom_cost_adjust)
                            {
                                cmd_sqlite.CommandText = "UPDATE Setting_Configure SET " +
                                  "status = 0, " +
                                  "updated_date = datetime('now', 'localtime'), " +
                                  "updated_by = '" + Class_Parameter.User_Login + "' " +
                                  "WHERE title = 'custom_cost_adjust'";
                                cmd_sqlite.ExecuteNonQuery();

                                Class_Parameter.custom_cost_adjust = false;

                                custom_cost_adjust.Image = Ppos.Properties.Resources.uncheck;
                            }
                            else
                            {
                                cmd_sqlite.CommandText = "UPDATE Setting_Configure SET " +
                                  "status = 1, " +
                                  "updated_date = datetime('now', 'localtime'), " +
                                  "updated_by = '" + Class_Parameter.User_Login + "' " +
                                  "WHERE title = 'custom_cost_adjust'";
                                cmd_sqlite.ExecuteNonQuery();

                                Class_Parameter.custom_cost_adjust = true;

                                custom_cost_adjust.Image = Ppos.Properties.Resources.check;
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Mouse_Enter(object sender, EventArgs e)
        {
            try
            {
                Label label = (Label)sender;
                label.Font = new Font("Segoe UI", 12F,FontStyle.Bold);
            }
            catch
            {

            }
        }

        private void Mouse_Leave(object sender, EventArgs e)
        {
            try
            {
                Label label = (Label)sender;
                label.Font = new Font("Segoe UI", 12F, FontStyle.Regular);
            }
            catch
            {

            }
        }
    }
}
