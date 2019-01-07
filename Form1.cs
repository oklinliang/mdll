using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hxd_ZT_calc
{
    public partial class hxd_ZT_calc : Form
    {
        public hxd_ZT_calc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*天数计算方法------------------------------------------------------------------------------------------------------*/
            DateTime start = Convert.ToDateTime(this.dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            DateTime end = Convert.ToDateTime(this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));
            DateTime end_end = Convert.ToDateTime(this.dateTimePicker3.Value.ToString("yyyy-MM-dd"));
            TimeSpan ts1 = end - start;
            TimeSpan ts2 = end_end - start;
            int days1 = ts1.Days;
            int days2 = ts2.Days;

            string year1 = (start.Year.ToString());//起始年
            int start_year = 0;
            int.TryParse(year1, out start_year);

            string year2 = (end.Year.ToString());//结束年
            int end_year = 0;
            int.TryParse(year2, out end_year);

            string month1 = (start.Month.ToString());//起始月
            int start_month = 0;
            int.TryParse(month1, out start_month);

            string month2 = (end.Month.ToString());//结束月
            int end_month = 0;
            int.TryParse(month2, out end_month);

            string date1 = (start.Day.ToString());//起始日
            int start_date = 0;
            int.TryParse(date1, out start_date);

            string date2 = (end.Day.ToString());//结束日
            int end_date = 0;
            int.TryParse(date2, out end_date);
            if (start > end)
            {
                MessageBox.Show("转投日期不对，请调整~~~");
                return;
            }
            int start_month_date = 0;
            start_month_date = System.DateTime.DaysInMonth(start_year, start_month);

            int end_month_date = 0;
            end_month_date = System.DateTime.DaysInMonth(end_year, end_month);
            int list_end_month_date = 0;
            if (end_month != 1)
            {
                list_end_month_date = System.DateTime.DaysInMonth(end_year, end_month - 1);
            }
            else
            {
                list_end_month_date = System.DateTime.DaysInMonth(end_year, 12);
            }


            int monthDiff = 0;
            int dayDiff = 0;
            int end_last_month = 0;
            int differ_year = 0;
            int differ_year_month = 0;

            differ_year = end_year - start_year;
            differ_year_month = differ_year * 12;


            if (end_month - start_month == 1)
            {
                if (((end_year % 4 == 0 && end_year % 100 != 0) || (end_year % 100 == 0 && end_year % 400 == 0)) && ((start_date == 29 || start_date == 30 || start_date == 31) && end_date == 28))
                {
                    monthDiff = differ_year_month;
                    dayDiff = 28;
                }
                else if (((end_year % 4 == 0 && end_year % 100 != 0) || (end_year % 100 == 0 && end_year % 400 == 0)) && ((end_date - start_date == 0) || (end_month == 2 && (start_date == 29 || start_date == 30 || start_date == 31) && end_date == 29)))
                {
                    monthDiff = 1 + differ_year_month;
                    dayDiff = 0;
                }
                else if ((end_date - start_date == 0) || (end_month == 2 && (start_date == 28 || start_date == 29 || start_date == 30 || start_date == 31) && end_date == 28))
                {
                    monthDiff = 1 + differ_year_month;
                    dayDiff = 0;
                }
                else if (start_month_date == 31)
                {
                    dayDiff = 31 - start_date;
                    dayDiff = dayDiff + end_date;
                    if (dayDiff > start_month_date)
                    {
                        dayDiff -= start_month_date;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                    else if (dayDiff == end_month_date && start_date == 31)
                    {
                        dayDiff = 0;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                    else if (dayDiff < start_month_date)
                    {
                        monthDiff = differ_year_month - 1;
                    }
                }
                else if (start_month_date == 30)
                {
                    dayDiff = 30 - start_date;
                    dayDiff = dayDiff + end_date;
                    if (dayDiff > start_month_date)
                    {
                        dayDiff -= start_month_date;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                }
                else if (start_month_date == 28)
                {
                    dayDiff = 28 - start_date;
                    dayDiff = dayDiff + end_date;
                    if (dayDiff > start_month_date)
                    {
                        dayDiff -= start_month_date;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                }
                else if (start_month_date == 29)
                {
                    dayDiff = 29 - start_date;
                    dayDiff = dayDiff + end_date;
                    if (dayDiff > start_month_date)
                    {
                        dayDiff -= start_month_date;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                }

            }
            else if (end_month - start_month != 1)
            {
                end_last_month = end_month - 1;
                if (end_last_month == 0)
                {
                    end_last_month = 12;
                }
                start_month_date = System.DateTime.DaysInMonth(start_year, end_last_month);
                monthDiff = end_month - start_month - 1;
                if (((end_year % 4 == 0 && end_year % 100 != 0) || (end_year % 100 == 0 && end_year % 400 == 0)) && ((start_date == 29 || start_date == 30 || start_date == 31) && end_date == 28))
                {
                    monthDiff += differ_year_month;
                    dayDiff = 28;
                }
                else if (((end_year % 4 == 0 && end_year % 100 != 0) || (end_year % 100 == 0 && end_year % 400 == 0)) && ((end_date - start_date == 0) || (end_month == 2 && (start_date == 29 || start_date == 30 || start_date == 31) && end_date == 29)))
                {
                    monthDiff += 1;
                    monthDiff += differ_year_month;
                    dayDiff = 0;
                }
                else if ((end_date - start_date == 0) || (end_month == 2 && (start_date == 28 || start_date == 29 || start_date == 30 || start_date == 31) && end_date == 28))
                {
                    monthDiff += 1;
                    monthDiff += differ_year_month;
                    dayDiff = 0;
                }
                else if (start_month_date == 31)
                {
                    dayDiff = 31 - start_date;
                    dayDiff = dayDiff + end_date;
                    if (dayDiff > start_month_date)
                    {
                        dayDiff -= start_month_date;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                    else if (dayDiff == end_month_date && start_date == 31)
                    {
                        dayDiff = 0;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                    else
                    {
                        monthDiff += differ_year_month;
                    }
                }
                else if (start_month_date == 30)
                {
                    dayDiff = 30 - start_date;
                    if (dayDiff < 0)
                    {
                        dayDiff = 0;
                    }
                    dayDiff = dayDiff + end_date;
                    if (dayDiff > start_month_date)
                    {
                        dayDiff -= start_month_date;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                    else
                    {
                        monthDiff += differ_year_month;
                    }
                }
                else if (start_month_date == 28)
                {
                    dayDiff = 28 - start_date;
                    if (dayDiff < 0)
                    {
                        dayDiff = 0;
                    }
                    dayDiff = dayDiff + end_date;
                    if (dayDiff > start_month_date)
                    {
                        dayDiff -= start_month_date;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                    else
                    {
                        monthDiff += differ_year_month;
                    }
                }
                else if (start_month_date == 29)
                {
                    dayDiff = 29 - start_date;
                    if (dayDiff < 0)
                    {
                        dayDiff = 0;
                    }
                    dayDiff = dayDiff + end_date;
                    if (dayDiff > start_month_date)
                    {
                        dayDiff -= start_month_date;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
                    }
                    else
                    {
                        monthDiff += differ_year_month;
                    }
                }
            }
            this.textBox4.Text = monthDiff.ToString();
            this.textBox5.Text = dayDiff.ToString();
            /*------------------------------------------------------------------------------------------------------------------*/
            /*取利率--------------------------------------------------------------------------------------------------------*/
            double tbp01 = Convert.ToDouble(this.tbp01.Text.ToString());
            double lilv = tbp01 / 100;
            /*------------------------------------------------------------------------------------------------------------------*/
            /*页面元素----------------------------------------------------------------------------------------------------------*/
            double my_money = Convert.ToDouble(this.textBox6.Text.ToString());//本金
            double xssyll = Convert.ToDouble(this.textBox9.Text.ToString());//新手用首月利率
            /*------------------------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------------------------*/
            int end_day = days2 - days1;
            if (end_day < 0)
            {
                end_day = 0;
            }
            double gross_interest = 0;
            double day_money;
            double overall_money = 0;
            double lockup_period_money = 0;
            double monthDiff_list = monthDiff - 1;
            double sdqw_money;
            xssyll = xssyll / 100;
            
            if (this.radioButton1.Checked == true)
            {
                if (monthDiff >= 1)
                {

                    gross_interest = my_money * lilv / 12 * monthDiff;
                    if (start_date < end_date)
                    {
                        day_money = my_money * lilv * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        if (start_date == 31)
                        {
                            day_money = my_money * lilv * dayDiff / 12 / end_month_date;
                        }
                        else
                        {
                            day_money = my_money * lilv * dayDiff / 12 / list_end_month_date;
                        }
                    }
                    gross_interest += day_money;
                    gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
                    overall_money = my_money + gross_interest;
                }
                else
                {
                    if (monthDiff == 0)
                    {
                        if (start_date < end_date)
                        {
                            day_money = my_money * lilv * dayDiff / 12 / end_month_date;
                        }
                        else
                        {
                            day_money = my_money * lilv * dayDiff / 12 / list_end_month_date;
                        }
                    }
                    else
                    {
                        if (start_date < end_date)
                        {
                            day_money = my_money * lilv * dayDiff / 12 / end_month_date;
                        }
                        else
                        {
                            day_money = my_money * lilv * dayDiff / 12 / list_end_month_date;
                        }
                    }
                    gross_interest = my_money * lilv / 12 * monthDiff;
                    gross_interest += day_money;
                    gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
                    overall_money = my_money + gross_interest;
                }
                this.textBox53.Text = overall_money.ToString();
                this.textBox1.Text = end_day.ToString();//剩余天数
                this.textBox2.Text = end_day.ToString();
            }
            if (this.radioButton2.Checked == true)
            {
                gross_interest = my_money * xssyll / 12;
                if (monthDiff_list < 0)
                {
                    monthDiff_list = 0;
                }
                sdqw_money = my_money * lilv / 12 * monthDiff_list;
                if (start_date < end_date)
                {
                    day_money = my_money * lilv * dayDiff / 12 / end_month_date;
                }
                else
                {
                    day_money = my_money * lilv * dayDiff / 12 / list_end_month_date;
                }
                overall_money = day_money + gross_interest + sdqw_money + my_money;
                this.textBox53.Text = overall_money.ToString();
                this.textBox1.Text = end_day.ToString();//剩余天数
                this.textBox2.Text = end_day.ToString();
            }
            if (this.radioButton3.Checked == true)
            {
                monthDiff = 0;
                if (monthDiff == 0)
                    {
                        if (start_date < end_date)
                        {
                            day_money = my_money * lilv * dayDiff / 12 / end_month_date;
                        }
                        else
                        {
                            day_money = my_money * lilv * dayDiff / 12 / list_end_month_date;
                        }
                    }
                 else
                    {
                        if (start_date < end_date)
                        {
                            day_money = my_money * lilv * dayDiff / 12 / end_month_date;
                        }
                        else
                        {
                            day_money = my_money * lilv * dayDiff / 12 / list_end_month_date;
                        }
                    }
                gross_interest = my_money * lilv / 12 * monthDiff;
                gross_interest += day_money;
                gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
                overall_money = my_money + gross_interest;
                this.textBox53.Text = overall_money.ToString();
                this.textBox1.Text = end_day.ToString();//剩余天数
                this.textBox2.Text = end_day.ToString();
            }
            if (this.radioButton4.Checked == true)
            {
                /*梯度利率----------------------------------------------------------------------------------------------------------*/
                double[] p_box = new double[38];
                p_box[0] = 0;
                double tby01 = Convert.ToDouble(this.tby01.Text.ToString()); p_box[1] = tby01 / 100;
                double tby02 = Convert.ToDouble(this.tby02.Text.ToString()); p_box[2] = tby02 / 100;
                double tby03 = Convert.ToDouble(this.tby03.Text.ToString()); p_box[3] = tby03 / 100;
                double tby04 = Convert.ToDouble(this.tby04.Text.ToString()); p_box[4] = tby04 / 100;
                double tby05 = Convert.ToDouble(this.tby05.Text.ToString()); p_box[5] = tby05 / 100;
                double tby06 = Convert.ToDouble(this.tby06.Text.ToString()); p_box[6] = tby06 / 100;
                double tby07 = Convert.ToDouble(this.tby07.Text.ToString()); p_box[7] = tby07 / 100;
                double tby08 = Convert.ToDouble(this.tby08.Text.ToString()); p_box[8] = tby08 / 100;
                double tby09 = Convert.ToDouble(this.tby09.Text.ToString()); p_box[9] = tby09 / 100;
                double tby10 = Convert.ToDouble(this.tby10.Text.ToString()); p_box[10] = tby10 / 100;
                double tby11 = Convert.ToDouble(this.tby11.Text.ToString()); p_box[11] = tby11 / 100;
                double tby12 = Convert.ToDouble(this.tby12.Text.ToString()); p_box[12] = tby12 / 100;
                p_box[13] = tby12 / 100;
                p_box[14] = tby12 / 100;
                p_box[15] = tby12 / 100;
                p_box[16] = tby12 / 100;
                p_box[17] = tby12 / 100;
                p_box[18] = tby12 / 100;
                p_box[19] = tby12 / 100;
                p_box[20] = tby12 / 100;
                p_box[21] = tby12 / 100;
                p_box[22] = tby12 / 100;
                p_box[23] = tby12 / 100;
                p_box[24] = tby12 / 100;
                p_box[25] = tby12 / 100;
                p_box[26] = tby12 / 100;
                p_box[27] = tby12 / 100;
                p_box[28] = tby12 / 100;
                p_box[29] = tby12 / 100;
                p_box[30] = tby12 / 100;
                p_box[31] = tby12 / 100;
                p_box[32] = tby12 / 100;
                p_box[33] = tby12 / 100;
                p_box[34] = tby12 / 100;
                p_box[35] = tby12 / 100;
                p_box[36] = tby12 / 100;
                p_box[37] = 0;
                /*------------------------------------------------------------------------------------------------------------------*/
                /*------------------------------------------------------------------------------------------------------------------*/
                double[] month_money = new double[100];
                for (int i = 0; i <= monthDiff; i++)
                {
                    month_money[i] = my_money * p_box[i] / 12;
                    gross_interest += month_money[i];
                }
                if (start_date <= end_date)
                {
                    day_money = my_money * p_box[monthDiff + 1] * dayDiff / 12 / end_month_date;
                }
                else
                {
                    day_money = my_money * p_box[monthDiff + 1] * dayDiff / 12 / list_end_month_date;
                }
                gross_interest += day_money;
                gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
                overall_money = gross_interest + my_money;
                this.textBox53.Text = overall_money.ToString();
                this.textBox1.Text = end_day.ToString();//剩余天数
                this.textBox2.Text = end_day.ToString();
                
            }
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            double zt_money = Convert.ToDouble(this.textBox53.Text.ToString());
            double zt_lilv_a = Convert.ToDouble(this.textBox3.Text.ToString());
            double zt_day = Convert.ToDouble(this.textBox2.Text.ToString());
            double zt_lilv = zt_lilv_a / 100;
            double zt_over_money;
            zt_over_money = zt_money * zt_lilv / 365 * zt_day;
            zt_over_money = Math.Round(zt_over_money, 5, MidpointRounding.AwayFromZero);
            double zt_zong_over_money;
            zt_zong_over_money = zt_over_money + zt_money;
            zt_zong_over_money = Math.Round(zt_zong_over_money, 5, MidpointRounding.AwayFromZero);
            this.textBox7.Text = zt_over_money.ToString();
            this.textBox8.Text = zt_zong_over_money.ToString();
        }
    }
}
