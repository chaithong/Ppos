using Ppos.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ppos
{
    public partial class Form_Calendar : Form
    {
        int set_month, set_year;
        public bool cancel = true;
        Label L_select_day = new Label();
        public Form_Calendar()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            button_back.Image = Class_Image.resizeImage(Ppos.Properties.Resources.back, new Size(50, 50));

            button_next.Image = Class_Image.resizeImage(Ppos.Properties.Resources.next, new Size(50, 50));

            button_confirm.Image = Class_Image.resizeImage(Ppos.Properties.Resources.confirms, new Size(40, 40));

           

            label_title.Text = Class_Parameter.calendar_title;
            set_month = Convert.ToInt16(Class_Parameter.calendar_month);
            set_year = Convert.ToInt16(Class_Parameter.calendar_year);
            getDate(set_month, set_year);
            label_set_days.Text = "--";

            getDateOfMonth_From(Convert.ToInt16(Class_Parameter.calendar_month).ToString(), Convert.ToInt16(Class_Parameter.calendar_year).ToString());

            // กดวันที่เข้ามา
            foreach (Control label in tableLayoutPanel_calendar.Controls)
            {
                if (label is Label)
                {
                    if (label.Text == Convert.ToInt16(Class_Parameter.calendar_day).ToString())
                    {

                        label_click(label, EventArgs.Empty);
                        break;
                    }
                }
            }
        }

     
        public void getDate(int month, int year)
        {
            try
            {


                if (month == 1)
                {
                    label_month_year.Text = "มกราคม " + year;
                }
                else if (month == 2)
                {
                    label_month_year.Text = "กุมภาพันธ์ " + year;
                }
                else if (month == 3)
                {
                    label_month_year.Text = "มีนาคม " + year;
                }
                else if (month == 4)
                {
                    label_month_year.Text = "เมษายน " + year;
                }
                else if (month == 5)
                {
                    label_month_year.Text = "พฤษภาคม " + year;
                }
                else if (month == 6)
                {
                    label_month_year.Text = "มิถุนายน " + year;
                }
                else if (month == 7)
                {
                    label_month_year.Text = "กรกฎาคม " + year;
                }
                else if (month == 8)
                {
                    label_month_year.Text = "สิงหาคม " + year;
                }
                else if (month == 9)
                {
                    label_month_year.Text = "กันยายน " + year;
                }
                else if (month == 10)
                {
                    label_month_year.Text = "ตุลาคม " + year;
                }
                else if (month == 11)
                {
                    label_month_year.Text = "พฤศจิกายน " + year;
                }
                else
                {
                    label_month_year.Text = "ธันวาคม " + year;
                }
            }
            catch { }
        }
        public void getDateOfMonth_From(string month, string year)
        {
            try
            {
                DayOfWeek dayOfWeek = new DateTime(Convert.ToInt16(year), Convert.ToInt16(month), 1).DayOfWeek;
                int dayNumber = (int)dayOfWeek + 1;
                int daysInMonth = DateTime.DaysInMonth(Convert.ToInt16(year), Convert.ToInt16(month));

                int days = 1;

                if (dayNumber == 1)
                {
                    label_1.Text = days.ToString();
                    label_1.BackColor = Color.White;
                    days += 1;
                    label_2.Text = days.ToString();
                    label_2.BackColor = Color.White;
                    days += 1;
                    label_3.Text = days.ToString();
                    label_3.BackColor = Color.White;
                    days += 1;
                    label_4.Text = days.ToString();
                    label_4.BackColor = Color.White;
                    days += 1;
                    label_5.Text = days.ToString();
                    label_5.BackColor = Color.White;
                    days += 1;
                    label_6.Text = days.ToString();
                    label_6.BackColor = Color.White;
                    days += 1;
                    label_7.Text = days.ToString();
                    label_7.BackColor = Color.White;
                    days += 1;
                }
                else if (dayNumber == 2)
                {
                    label_1.Text = "";
                    label_1.BackColor = Color.Transparent;

                    label_2.Text = days.ToString();
                    label_2.BackColor = Color.White;
                    days += 1;
                    label_3.Text = days.ToString();
                    label_3.BackColor = Color.White;
                    days += 1;
                    label_4.Text = days.ToString();
                    label_4.BackColor = Color.White;
                    days += 1;
                    label_5.Text = days.ToString();
                    label_5.BackColor = Color.White;
                    days += 1;
                    label_6.Text = days.ToString();
                    label_6.BackColor = Color.White;
                    days += 1;
                    label_7.Text = days.ToString();
                    label_7.BackColor = Color.White;
                    days += 1;
                }
                else if (dayNumber == 3)
                {
                    label_1.Text = "";
                    label_1.BackColor = Color.Transparent;

                    label_2.Text = "";
                    label_2.BackColor = Color.Transparent;

                    label_3.Text = days.ToString();
                    label_3.BackColor = Color.White;
                    days += 1;
                    label_4.Text = days.ToString();
                    label_4.BackColor = Color.White;
                    days += 1;
                    label_5.Text = days.ToString();
                    label_5.BackColor = Color.White;
                    days += 1;
                    label_6.Text = days.ToString();
                    label_6.BackColor = Color.White;
                    days += 1;
                    label_7.Text = days.ToString();
                    label_7.BackColor = Color.White;
                    days += 1;
                }
                else if (dayNumber == 4)
                {
                    label_1.Text = "";
                    label_1.BackColor = Color.Transparent;

                    label_2.Text = "";
                    label_2.BackColor = Color.Transparent;

                    label_3.Text = "";
                    label_3.BackColor = Color.Transparent;

                    label_4.Text = days.ToString();
                    label_4.BackColor = Color.White;
                    days += 1;
                    label_5.Text = days.ToString();
                    label_5.BackColor = Color.White;
                    days += 1;
                    label_6.Text = days.ToString();
                    label_6.BackColor = Color.White;
                    days += 1;
                    label_7.Text = days.ToString();
                    label_7.BackColor = Color.White;
                    days += 1;
                }
                else if (dayNumber == 5)
                {
                    label_1.Text = "";
                    label_1.BackColor = Color.Transparent;

                    label_2.Text = "";
                    label_2.BackColor = Color.Transparent;

                    label_3.Text = "";
                    label_3.BackColor = Color.Transparent;

                    label_4.Text = "";
                    label_4.BackColor = Color.Transparent;

                    label_5.Text = days.ToString();
                    label_5.BackColor = Color.White;
                    days += 1;
                    label_6.Text = days.ToString();
                    label_6.BackColor = Color.White;
                    days += 1;
                    label_7.Text = days.ToString();
                    label_7.BackColor = Color.White;
                    days += 1;
                }
                else if (dayNumber == 6)
                {
                    label_1.Text = "";
                    label_1.BackColor = Color.Transparent;

                    label_2.Text = "";
                    label_2.BackColor = Color.Transparent;

                    label_3.Text = "";
                    label_3.BackColor = Color.Transparent;

                    label_4.Text = "";
                    label_4.BackColor = Color.Transparent;

                    label_5.Text = "";
                    label_5.BackColor = Color.Transparent;

                    label_6.Text = days.ToString();
                    label_6.BackColor = Color.White;
                    days += 1;
                    label_7.Text = days.ToString();
                    label_7.BackColor = Color.White;
                    days += 1;
                }
                else // 7
                {
                    label_1.Text = "";
                    label_1.BackColor = Color.Transparent;

                    label_2.Text = "";
                    label_2.BackColor = Color.Transparent;

                    label_3.Text = "";
                    label_3.BackColor = Color.Transparent;

                    label_4.Text = "";
                    label_4.BackColor = Color.Transparent;

                    label_5.Text = "";
                    label_5.BackColor = Color.Transparent;

                    label_6.Text = "";
                    label_6.BackColor = Color.Transparent;

                    label_7.Text = days.ToString();
                    label_7.BackColor = Color.White;
                    days += 1;
                }
                label_8.Text = days.ToString();
                label_8.BackColor = Color.White;
                days += 1;
                label_9.Text = days.ToString();
                label_9.BackColor = Color.White;
                days += 1;
                label_10.Text = days.ToString();
                label_10.BackColor = Color.White;
                days += 1;
                label_11.Text = days.ToString();
                label_11.BackColor = Color.White;
                days += 1;
                label_12.Text = days.ToString();
                label_12.BackColor = Color.White;
                days += 1;
                label_13.Text = days.ToString();
                label_13.BackColor = Color.White;
                days += 1;
                label_14.Text = days.ToString();
                label_14.BackColor = Color.White;
                days += 1;

                label_15.Text = days.ToString();
                label_15.BackColor = Color.White;
                days += 1;
                label_16.Text = days.ToString();
                label_16.BackColor = Color.White;
                days += 1;
                label_17.Text = days.ToString();
                label_17.BackColor = Color.White;
                days += 1;
                label_18.Text = days.ToString();
                label_18.BackColor = Color.White;
                days += 1;
                label_19.Text = days.ToString();
                label_19.BackColor = Color.White;
                days += 1;
                label_20.Text = days.ToString();
                label_20.BackColor = Color.White;
                days += 1;
                label_21.Text = days.ToString();
                label_21.BackColor = Color.White;
                days += 1;

                label_22.Text = days.ToString();
                label_22.BackColor = Color.White;
                days += 1;
                label_23.Text = days.ToString();
                label_23.BackColor = Color.White;
                days += 1;
                label_24.Text = days.ToString();
                label_24.BackColor = Color.White;
                days += 1;
                label_25.Text = days.ToString();
                label_25.BackColor = Color.White;
                days += 1;
                label_26.Text = days.ToString();
                label_26.BackColor = Color.White;
                days += 1;
                label_27.Text = days.ToString();
                label_27.BackColor = Color.White;
                days += 1;
                label_28.Text = days.ToString();
                label_28.BackColor = Color.White;
                days += 1;

                if (days <= daysInMonth)
                {
                    label_29.Text = days.ToString();
                    label_29.BackColor = Color.White;
                    days += 1;

                    if (days <= daysInMonth)
                    {
                        label_30.Text = days.ToString();
                        label_30.BackColor = Color.White;
                        days += 1;
                        if (days <= daysInMonth)
                        {
                            label_31.Text = days.ToString();
                            label_31.BackColor = Color.White;
                            days += 1;
                            if (days <= daysInMonth)
                            {
                                label_32.Text = days.ToString();
                                label_32.BackColor = Color.White;
                                days += 1;
                                if (days <= daysInMonth)
                                {
                                    label_33.Text = days.ToString();
                                    label_33.BackColor = Color.White;
                                    days += 1;
                                    if (days <= daysInMonth)
                                    {
                                        label_34.Text = days.ToString();
                                        label_34.BackColor = Color.White;
                                        days += 1;
                                        if (days <= daysInMonth)
                                        {
                                            label_35.Text = days.ToString();
                                            label_35.BackColor = Color.White;
                                            days += 1;
                                            if (days <= daysInMonth)
                                            {
                                                label_36.Text = days.ToString();
                                                label_36.BackColor = Color.White;
                                                days += 1;

                                                if (days <= daysInMonth)
                                                {
                                                    label_37.Text = days.ToString();
                                                    label_37.BackColor = Color.White;
                                                    days += 1;
                                                    if (days <= daysInMonth)
                                                    {
                                                        label_38.Text = days.ToString();
                                                        label_38.BackColor = Color.White;
                                                        days += 1;
                                                        if (days <= daysInMonth)
                                                        {
                                                            label_39.Text = days.ToString();
                                                            label_39.BackColor = Color.White;
                                                            days += 1;
                                                            if (days <= daysInMonth)
                                                            {
                                                                label_40.Text = days.ToString();
                                                                label_40.BackColor = Color.White;
                                                                days += 1;
                                                                if (days <= daysInMonth)
                                                                {
                                                                    label_41.Text = days.ToString();
                                                                    label_41.BackColor = Color.White;
                                                                    days += 1;
                                                                    if (days <= daysInMonth)
                                                                    {
                                                                        label_42.Text = days.ToString();
                                                                        label_42.BackColor = Color.White;
                                                                    }
                                                                    else
                                                                    {

                                                                        label_42.Text = "";
                                                                        label_42.BackColor = Color.Transparent;
                                                                    }
                                                                }
                                                                else
                                                                {

                                                                    label_41.Text = "";
                                                                    label_41.BackColor = Color.Transparent;
                                                                    label_42.Text = "";
                                                                    label_42.BackColor = Color.Transparent;
                                                                }
                                                            }
                                                            else
                                                            {

                                                                label_40.Text = "";
                                                                label_40.BackColor = Color.Transparent;
                                                                label_41.Text = "";
                                                                label_41.BackColor = Color.Transparent;
                                                                label_42.Text = "";
                                                                label_42.BackColor = Color.Transparent;
                                                            }
                                                        }
                                                        else
                                                        {

                                                            label_39.Text = "";
                                                            label_39.BackColor = Color.Transparent;
                                                            label_40.Text = "";
                                                            label_40.BackColor = Color.Transparent;
                                                            label_41.Text = "";
                                                            label_41.BackColor = Color.Transparent;
                                                            label_42.Text = "";
                                                            label_42.BackColor = Color.Transparent;
                                                        }
                                                    }
                                                    else
                                                    {

                                                        label_38.Text = "";
                                                        label_38.BackColor = Color.Transparent;
                                                        label_39.Text = "";
                                                        label_39.BackColor = Color.Transparent;
                                                        label_40.Text = "";
                                                        label_40.BackColor = Color.Transparent;
                                                        label_41.Text = "";
                                                        label_41.BackColor = Color.Transparent;
                                                        label_42.Text = "";
                                                        label_42.BackColor = Color.Transparent;
                                                    }

                                                }
                                                else
                                                {

                                                    label_37.Text = "";
                                                    label_37.BackColor = Color.Transparent;
                                                    label_38.Text = "";
                                                    label_38.BackColor = Color.Transparent;
                                                    label_39.Text = "";
                                                    label_39.BackColor = Color.Transparent;
                                                    label_40.Text = "";
                                                    label_40.BackColor = Color.Transparent;
                                                    label_41.Text = "";
                                                    label_41.BackColor = Color.Transparent;
                                                    label_42.Text = "";
                                                    label_42.BackColor = Color.Transparent;
                                                }
                                            }
                                            else
                                            {
                                                label_36.Text = "";
                                                label_36.BackColor = Color.Transparent;
                                                label_37.Text = "";
                                                label_37.BackColor = Color.Transparent;
                                                label_38.Text = "";
                                                label_38.BackColor = Color.Transparent;
                                                label_39.Text = "";
                                                label_39.BackColor = Color.Transparent;
                                                label_40.Text = "";
                                                label_40.BackColor = Color.Transparent;
                                                label_41.Text = "";
                                                label_41.BackColor = Color.Transparent;
                                                label_42.Text = "";
                                                label_42.BackColor = Color.Transparent;
                                            }
                                        }
                                        else
                                        {

                                            label_35.Text = "";
                                            label_35.BackColor = Color.Transparent;
                                            label_36.Text = "";
                                            label_36.BackColor = Color.Transparent;
                                            label_37.Text = "";
                                            label_37.BackColor = Color.Transparent;
                                            label_38.Text = "";
                                            label_38.BackColor = Color.Transparent;
                                            label_39.Text = "";
                                            label_39.BackColor = Color.Transparent;
                                            label_40.Text = "";
                                            label_40.BackColor = Color.Transparent;
                                            label_41.Text = "";
                                            label_41.BackColor = Color.Transparent;
                                            label_42.Text = "";
                                            label_42.BackColor = Color.Transparent;
                                        }
                                    }
                                    else
                                    {

                                        label_34.Text = "";
                                        label_34.BackColor = Color.Transparent;
                                        label_35.Text = "";
                                        label_35.BackColor = Color.Transparent;
                                        label_36.Text = "";
                                        label_36.BackColor = Color.Transparent;
                                        label_37.Text = "";
                                        label_37.BackColor = Color.Transparent;
                                        label_38.Text = "";
                                        label_38.BackColor = Color.Transparent;
                                        label_39.Text = "";
                                        label_39.BackColor = Color.Transparent;
                                        label_40.Text = "";
                                        label_40.BackColor = Color.Transparent;
                                        label_41.Text = "";
                                        label_41.BackColor = Color.Transparent;
                                        label_42.Text = "";
                                        label_42.BackColor = Color.Transparent;
                                    }
                                }
                                else
                                {

                                    label_33.Text = "";
                                    label_33.BackColor = Color.Transparent;
                                    label_34.Text = "";
                                    label_34.BackColor = Color.Transparent;
                                    label_35.Text = "";
                                    label_35.BackColor = Color.Transparent;
                                    label_36.Text = "";
                                    label_36.BackColor = Color.Transparent;
                                    label_37.Text = "";
                                    label_37.BackColor = Color.Transparent;
                                    label_38.Text = "";
                                    label_38.BackColor = Color.Transparent;
                                    label_39.Text = "";
                                    label_39.BackColor = Color.Transparent;
                                    label_40.Text = "";
                                    label_40.BackColor = Color.Transparent;
                                    label_41.Text = "";
                                    label_41.BackColor = Color.Transparent;
                                    label_42.Text = "";
                                    label_42.BackColor = Color.Transparent;
                                }
                            }
                            else
                            {

                                label_32.Text = "";
                                label_32.BackColor = Color.Transparent;
                                label_33.Text = "";
                                label_33.BackColor = Color.Transparent;
                                label_34.Text = "";
                                label_34.BackColor = Color.Transparent;
                                label_35.Text = "";
                                label_35.BackColor = Color.Transparent;
                                label_36.Text = "";
                                label_36.BackColor = Color.Transparent;
                                label_37.Text = "";
                                label_37.BackColor = Color.Transparent;
                                label_38.Text = "";
                                label_38.BackColor = Color.Transparent;
                                label_39.Text = "";
                                label_39.BackColor = Color.Transparent;
                                label_40.Text = "";
                                label_40.BackColor = Color.Transparent;
                                label_41.Text = "";
                                label_41.BackColor = Color.Transparent;
                                label_42.Text = "";
                                label_42.BackColor = Color.Transparent;
                            }
                        }
                        else
                        {

                            label_31.Text = "";
                            label_31.BackColor = Color.Transparent;
                            label_32.Text = "";
                            label_32.BackColor = Color.Transparent;
                            label_33.Text = "";
                            label_33.BackColor = Color.Transparent;
                            label_34.Text = "";
                            label_34.BackColor = Color.Transparent;
                            label_35.Text = "";
                            label_35.BackColor = Color.Transparent;
                            label_36.Text = "";
                            label_36.BackColor = Color.Transparent;
                            label_37.Text = "";
                            label_37.BackColor = Color.Transparent;
                            label_38.Text = "";
                            label_38.BackColor = Color.Transparent;
                            label_39.Text = "";
                            label_39.BackColor = Color.Transparent;
                            label_40.Text = "";
                            label_40.BackColor = Color.Transparent;
                            label_41.Text = "";
                            label_41.BackColor = Color.Transparent;
                            label_42.Text = "";
                            label_42.BackColor = Color.Transparent;
                        }

                    }
                    else
                    {

                        label_30.Text = "";
                        label_30.BackColor = Color.Transparent;
                        label_31.Text = "";
                        label_31.BackColor = Color.Transparent;
                        label_32.Text = "";
                        label_32.BackColor = Color.Transparent;
                        label_33.Text = "";
                        label_33.BackColor = Color.Transparent;
                        label_34.Text = "";
                        label_34.BackColor = Color.Transparent;
                        label_35.Text = "";
                        label_35.BackColor = Color.Transparent;
                        label_36.Text = "";
                        label_36.BackColor = Color.Transparent;
                        label_37.Text = "";
                        label_37.BackColor = Color.Transparent;
                        label_38.Text = "";
                        label_38.BackColor = Color.Transparent;
                        label_39.Text = "";
                        label_39.BackColor = Color.Transparent;
                        label_40.Text = "";
                        label_40.BackColor = Color.Transparent;
                        label_41.Text = "";
                        label_41.BackColor = Color.Transparent;
                        label_42.Text = "";
                        label_42.BackColor = Color.Transparent;
                    }
                }
                else
                {
                    label_29.Text = "";
                    label_29.BackColor = Color.Transparent;
                    label_30.Text = "";
                    label_30.BackColor = Color.Transparent;
                    label_31.Text = "";
                    label_31.BackColor = Color.Transparent;
                    label_32.Text = "";
                    label_32.BackColor = Color.Transparent;
                    label_33.Text = "";
                    label_33.BackColor = Color.Transparent;
                    label_34.Text = "";
                    label_34.BackColor = Color.Transparent;
                    label_35.Text = "";
                    label_35.BackColor = Color.Transparent;
                    label_36.Text = "";
                    label_36.BackColor = Color.Transparent;
                    label_37.Text = "";
                    label_37.BackColor = Color.Transparent;
                    label_38.Text = "";
                    label_38.BackColor = Color.Transparent;
                    label_39.Text = "";
                    label_39.BackColor = Color.Transparent;
                    label_40.Text = "";
                    label_40.BackColor = Color.Transparent;
                    label_41.Text = "";
                    label_41.BackColor = Color.Transparent;
                    label_42.Text = "";
                    label_42.BackColor = Color.Transparent;
                }

            }
            catch
            {

            }
        }



        private void button_back_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateTime = new DateTime(set_year, set_month, 1).AddMonths(-1);

                set_month = Convert.ToInt16(dateTime.Month.ToString());
                set_year = Convert.ToInt16(dateTime.Year.ToString());
                getDate(set_month, set_year);

                getDateOfMonth_From(dateTime.Month.ToString(), dateTime.Year.ToString());

                if (label_set_days.Text != "--")
                {
                    if (Convert.ToInt16(label_set_days.Text.Split("-")[1]) == set_month &&
                        Convert.ToInt16(label_set_days.Text.Split("-")[2]) == set_year)
                    {
                        L_select_day.BackColor = Color.Lime;
                    }

                }
            }
            catch
            {

            }
        }

        private void button_next_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime dateTime = new DateTime(set_year, set_month, 1).AddMonths(1);

                set_month = Convert.ToInt16(dateTime.Month.ToString());
                set_year = Convert.ToInt16(dateTime.Year.ToString());
                getDate(set_month, set_year);

                getDateOfMonth_From(dateTime.Month.ToString(), dateTime.Year.ToString());

                if (label_set_days.Text != "--")
                {
                    if (Convert.ToInt16(label_set_days.Text.Split("-")[1]) == set_month &&
                        Convert.ToInt16(label_set_days.Text.Split("-")[2]) == set_year)
                    {
                        L_select_day.BackColor = Color.Lime;
                    }

                }
            }
            catch
            {

            }
        }

        private void button_confirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (label_set_days.Text != "--")
                {
                    cancel = false;
                    this.Close();
                }
            }
            catch
            {

            }
        }
        private void label_click(object sender, EventArgs e)
        {
            try
            {
                Label L = (Label)sender;

                if (L.Text != "")
                {
                    if (L_select_day is not null)
                    {
                        if (L_select_day.BackColor == Color.Lime)
                        {
                            L_select_day.BackColor = Color.White;
                        }
                    }
                    L_select_day = L;
                    L_select_day.BackColor = Color.Lime;

                    label_set_days.Text = Convert.ToInt16(L_select_day.Text).ToString("00") + "-" + set_month.ToString("00") + "-" + set_year;
                }
            }
            catch
            {

            }
        }
        private void label_doubleclick(object sender, EventArgs e)
        {
            try
            {
                Label L = (Label)sender;

                if (L.Text != "")
                {
                    cancel = false;
                    label_set_days.Text = Convert.ToInt16(L.Text).ToString("00") + "-" + set_month.ToString("00") + "-" + set_year;
                    this.Close();
                }
            }
            catch { }
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                if (((Label)sender).Text != "")
                {
                  //  ((Label)sender).BackColor = Color.Transparent;
                    ((Label)sender).Font = new System.Drawing.Font(((Label)sender).Font.FontFamily, ((Label)sender).Font.Size + 4, ((Label)sender).Font.Style);
                }
            }
            catch
            {

            }
        }

        private void label_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                if (((Label)sender).Text != "")
                {
                   // ((Label)sender).BackColor = Color.White;
                    ((Label)sender).Font = new System.Drawing.Font(((Label)sender).Font.FontFamily, ((Label)sender).Font.Size - 4, ((Label)sender).Font.Style);
                }
            }
            catch
            {

            }
        }

        private void label_month_year_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                set_month = Convert.ToInt16(DateTime.Now.Month.ToString());
                set_year = Convert.ToInt16(DateTime.Now.Year.ToString());
                getDate(DateTime.Now.Month, DateTime.Now.Year);
                getDateOfMonth_From(DateTime.Now.Month.ToString(), DateTime.Now.Year.ToString());
                if (label_set_days.Text != "--")
                {
                    if (Convert.ToInt16(label_set_days.Text.Split("-")[1]) == set_month &&
                        Convert.ToInt16(label_set_days.Text.Split("-")[2]) == set_year)
                    {
                        L_select_day.BackColor = Color.Lime;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font(button.Font.FontFamily, button.Font.Size + 4, button.Font.Style);
               
                if(button.Name == "button_back")
                {
                    button.Image = Class_Image.resizeImage(Ppos.Properties.Resources.back, new Size(40, 40));
                }
                else if (button.Name == "button_next")
                {
                    button.Image = Class_Image.resizeImage(Ppos.Properties.Resources.next, new Size(40, 40));
                }

            }
            catch
            {

            }
        }

        private void button_MouseLeave(object sender, EventArgs e)
        {
            try
            {
                System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
                button.Font = new System.Drawing.Font(button.Font.FontFamily, button.Font.Size - 4, button.Font.Style);

                if (button.Name == "button_back")
                {
                    button.Image = Class_Image.resizeImage(Ppos.Properties.Resources.back, new Size(50, 50));
                }
                else if (button.Name == "button_next")
                {
                    button.Image = Class_Image.resizeImage(Ppos.Properties.Resources.next, new Size(50, 50));
                }
            }
            catch
            {

            }
        }
    }
}
