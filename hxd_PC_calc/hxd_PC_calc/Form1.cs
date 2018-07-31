using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hxd_PC_calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            /*天数计算方法------------------------------------------------------------------------------------------------------*/
            DateTime start = Convert.ToDateTime(this.dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            DateTime end = Convert.ToDateTime(this.dateTimePicker2.Value.ToString("yyyy-MM-dd"));



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
                MessageBox.Show("开始时间应晚于结束时间");
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
                    if (dayDiff == end_month_date && start_date == 31)
                    {
                        dayDiff = 0;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
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
            if (this.checkBox1.Checked == true)
            {
                dayDiff += 1;
                if (dayDiff == end_month_date)
                {
                    dayDiff = 0;
                    monthDiff += 1;
                }
            }
            this.textBox4.Text = monthDiff.ToString();
            this.textBox5.Text = dayDiff.ToString();
            /*------------------------------------------------------------------------------------------------------------------*/
            /*取梯度利率--------------------------------------------------------------------------------------------------------*/
            double[] p_box = new Double[37];
            p_box[0] = 0;
            double tbp01 = Convert.ToDouble(this.tbp01.Text.ToString()); p_box[1] = tbp01 / 100;
            p_box[2] = tbp01 / 100;
            double tbp03 = Convert.ToDouble(this.tbp03.Text.ToString()); p_box[3] = tbp03 / 100;
            p_box[4] = tbp03 / 100;
            p_box[5] = tbp03 / 100;
            double tbp06 = Convert.ToDouble(this.tbp06.Text.ToString()); p_box[6] = tbp06 / 100;
            p_box[7] = tbp06 / 100;
            p_box[8] = tbp06 / 100;
            double tbp09 = Convert.ToDouble(this.tbp09.Text.ToString()); p_box[9] = tbp09 / 100;
            p_box[10] = tbp09 / 100;
            p_box[11] = tbp09 / 100;
            double tbp12 = Convert.ToDouble(this.tbp12.Text.ToString()); p_box[12] = tbp12 / 100;
            p_box[13] = tbp12 / 100;
            p_box[14] = tbp12 / 100;
            p_box[15] = tbp12 / 100;
            p_box[16] = tbp12 / 100;
            p_box[17] = tbp12 / 100;
            double tbp18 = Convert.ToDouble(this.tbp18.Text.ToString()); p_box[18] = tbp18 / 100;
            p_box[19] = tbp18 / 100;
            p_box[20] = tbp18 / 100;
            p_box[21] = tbp18 / 100;
            p_box[22] = tbp18 / 100;
            p_box[23] = tbp18 / 100;
            p_box[24] = tbp18 / 100;
            p_box[25] = tbp18 / 100;
            p_box[26] = tbp18 / 100;
            p_box[27] = tbp18 / 100;
            p_box[28] = tbp18 / 100;
            p_box[29] = tbp18 / 100;
            p_box[30] = tbp18 / 100;
            p_box[31] = tbp18 / 100;
            p_box[32] = tbp18 / 100;
            p_box[33] = tbp18 / 100;
            p_box[34] = tbp18 / 100;
            p_box[35] = tbp18 / 100;
            p_box[36] = tbp18 / 100;
            /*------------------------------------------------------------------------------------------------------------------*/
            /*页面元素----------------------------------------------------------------------------------------------------------*/
            double my_money = Convert.ToDouble(this.textBox6.Text.ToString());//本金
            double lockup_period = Convert.ToDouble(this.textBox1.Text.ToString());//锁定期
            double lockup_period_rate = Convert.ToDouble(this.textBox2.Text.ToString());//锁定期利率
            double Emergency_exit_rate = Convert.ToDouble(this.textBox3.Text.ToString());//紧急退出利率
            double dazhe = Convert.ToDouble(this.textBox11.Text.ToString());//紧急退出打折
            /*------------------------------------------------------------------------------------------------------------------*/
            /*------------------------------------------------------------------------------------------------------------------*/
            double gross_interest;
            double overall_money;
            double day_money;
            double lockup_period_money = 0;
            dazhe = dazhe / 10;
            double old_lockup_period_money = 0;
            double money_sub = 0;

            if (monthDiff >= lockup_period)
            {
                
                gross_interest = my_money * p_box[monthDiff] / 12 * monthDiff;
                if (start_date < end_date)
                {
                    day_money = my_money * p_box[monthDiff] * dayDiff / 12 / end_month_date;
                }
                else
                {
                    day_money = my_money * p_box[monthDiff] * dayDiff / 12 / list_end_month_date;
                }
                gross_interest += day_money;
                gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
                overall_money = my_money + gross_interest;
                overall_money -= lockup_period_money;
            }
            else
            {
                if (monthDiff == 0)
                {
                    if (start_date < end_date)
                    {
                        day_money = my_money * p_box[monthDiff + 1] * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        day_money = my_money * p_box[monthDiff + 1] * dayDiff / 12 / list_end_month_date;
                    }
                }
                else
                {
                    if (start_date < end_date)
                    {
                        day_money = my_money * p_box[monthDiff] * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        day_money = my_money * p_box[monthDiff] * dayDiff / 12 / list_end_month_date;
                    }
                }
                gross_interest = my_money * p_box[monthDiff] / 12 * monthDiff;
                gross_interest += day_money;
                gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
             
                overall_money = my_money + gross_interest;
                lockup_period_money = my_money * Emergency_exit_rate / 100 * dazhe;
                old_lockup_period_money = my_money * Emergency_exit_rate / 100;
                money_sub = old_lockup_period_money - lockup_period_money;
                overall_money -= lockup_period_money;
            }




            this.textBox7.Text = lockup_period_money.ToString();//退出手续费
            this.textBox8.Text = gross_interest.ToString();//总利息
            this.textBox53.Text = overall_money.ToString();//总成交额
            this.textBox13.Text = old_lockup_period_money.ToString();
            this.textBox14.Text = money_sub.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*活动和新手荷包*/
            /*天数计算方法------------------------------------------------------------------------------------------------------*/
            DateTime start = Convert.ToDateTime(this.dateTimePicker6.Value.ToString("yyyy-MM-dd"));
            DateTime end = Convert.ToDateTime(this.dateTimePicker5.Value.ToString("yyyy-MM-dd"));



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
                MessageBox.Show("开始时间应晚于结束时间");
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
                    if (dayDiff == end_month_date && start_date == 31)
                    {
                        dayDiff = 0;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
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
            if (this.checkBox2.Checked == true)
            {
                dayDiff += 1;
                if (dayDiff == end_month_date)
                {
                    dayDiff = 0;
                    monthDiff += 1;
                }
            }
            this.textBox59.Text = monthDiff.ToString();
            this.textBox58.Text = dayDiff.ToString();
            /*------------------------------------------------------------------------------------------------------------------*/
            /*取梯度利率--------------------------------------------------------------------------------------------------------*/
            double[] p_box = new Double[37];
            p_box[0] = 0;
            double tbh01 = Convert.ToDouble(this.tbh01.Text.ToString()); p_box[1] = tbh01 / 100;
            p_box[2] = tbh01 / 100;
            double tbh03 = Convert.ToDouble(this.tbh03.Text.ToString()); p_box[3] = tbh03 / 100;
            p_box[4] = tbh03 / 100;
            p_box[5] = tbh03 / 100;
            double tbh06 = Convert.ToDouble(this.tbh06.Text.ToString()); p_box[6] = tbh06 / 100;
            p_box[7] = tbh06 / 100;
            p_box[8] = tbh06 / 100;
            double tbh09 = Convert.ToDouble(this.tbh09.Text.ToString()); p_box[9] = tbh09 / 100;
            p_box[10] = tbh09 / 100;
            p_box[11] = tbh09 / 100;
            double tbh12 = Convert.ToDouble(this.tbh12.Text.ToString()); p_box[12] = tbh12 / 100;
            p_box[13] = tbh12 / 100;
            p_box[14] = tbh12 / 100;
            p_box[15] = tbh12 / 100;
            p_box[16] = tbh12 / 100;
            p_box[17] = tbh12 / 100;
            double tbh18 = Convert.ToDouble(this.tbh18.Text.ToString()); p_box[18] = tbh18 / 100;
            p_box[19] = tbh18 / 100;
            p_box[20] = tbh18 / 100;
            p_box[21] = tbh18 / 100;
            p_box[22] = tbh18 / 100;
            p_box[23] = tbh18 / 100;
            p_box[24] = tbh18 / 100;
            p_box[25] = tbh18 / 100;
            p_box[26] = tbh18 / 100;
            p_box[27] = tbh18 / 100;
            p_box[28] = tbh18 / 100;
            p_box[29] = tbh18 / 100;
            p_box[30] = tbh18 / 100;
            p_box[31] = tbh18 / 100;
            p_box[32] = tbh18 / 100;
            p_box[33] = tbh18 / 100;
            p_box[34] = tbh18 / 100;
            p_box[35] = tbh18 / 100;
            p_box[36] = tbh18 / 100;
            /*------------------------------------------------------------------------------------------------------------------*/
            /*页面元素----------------------------------------------------------------------------------------------------------*/
            double my_money = Convert.ToDouble(this.textBox57.Text.ToString());//本金
            double lockup_period = Convert.ToDouble(this.textBox62.Text.ToString());//锁定期
            double lockup_period_rate = Convert.ToDouble(this.textBox61.Text.ToString());//锁定期利率
            double Emergency_exit_rate = Convert.ToDouble(this.textBox60.Text.ToString());//紧急退出利率
            double dazhe = Convert.ToDouble(this.textBox12.Text.ToString());//紧急退出手续费打折
            /*------------------------------------------------------------------------------------------------------------------*/
            double gross_interest_inner;
            double gross_interest_outer;
            double gross_interest;
            double overall_money;
            double day_money;
            double lockup_period_money = 0;
            dazhe = dazhe / 10;
            int new_monthDiff = monthDiff - (int)lockup_period;
            if (new_monthDiff >= 0)
            {
                new_monthDiff = new_monthDiff;
            }
            else
            {
                new_monthDiff = 0;
            }
            if (monthDiff >= lockup_period)
            {
                gross_interest_inner = my_money * lockup_period_rate / 12 / 100 * lockup_period;//锁定期内
                gross_interest_inner = Math.Round(gross_interest_inner, 5, MidpointRounding.AwayFromZero);
                gross_interest_outer = my_money * p_box[monthDiff] / 12 * new_monthDiff;//锁定期外
                if (start_date < end_date)
                {
                    day_money = my_money * p_box[monthDiff] * dayDiff / 12 / end_month_date;
                }
                else
                {
                    day_money = my_money * p_box[monthDiff] * dayDiff / 12 / list_end_month_date;
                }
                gross_interest_outer += day_money;
                gross_interest_outer = Math.Round(gross_interest_outer, 5, MidpointRounding.AwayFromZero);
                gross_interest = gross_interest_inner + gross_interest_outer;//总利息
                gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
                overall_money = my_money + gross_interest;
            }
            else
            {
                if (monthDiff == 0)
                {
                    if (start_date < end_date)
                    {
                        day_money = my_money * p_box[monthDiff + 1] * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        day_money = my_money * p_box[monthDiff + 1] * dayDiff / 12 / list_end_month_date;
                    }
                }
                else
                {
                    if (start_date < end_date)
                    {
                        day_money = my_money * p_box[monthDiff] * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        day_money = my_money * p_box[monthDiff] * dayDiff / 12 / list_end_month_date;
                    }
                }
                gross_interest_inner = my_money * lockup_period_rate / 12 / 100 * lockup_period;//锁定期内
                gross_interest_inner += day_money;
                gross_interest_inner = Math.Round(gross_interest_inner, 5, MidpointRounding.AwayFromZero);
                gross_interest_outer = my_money * p_box[monthDiff] / 12 * new_monthDiff;//锁定期外
                gross_interest_outer = Math.Round(gross_interest_outer, 5, MidpointRounding.AwayFromZero);
                gross_interest = gross_interest_inner + gross_interest_outer;
                gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
                lockup_period_money = my_money * Emergency_exit_rate / 100 * dazhe;
                overall_money = my_money + gross_interest - lockup_period_money;
            }


            this.textBox9.Text = gross_interest_inner.ToString();//锁定期内
            this.textBox10.Text = gross_interest_outer.ToString();//锁定期外
            this.textBox56.Text = lockup_period_money.ToString();//退出手续费
            this.textBox55.Text = gross_interest.ToString();//总利息
            this.textBox54.Text = overall_money.ToString();//总成交额
        }

        private void button4_Click(object sender, EventArgs e)
        {
            /*月月升息*/
            /*天数计算方法------------------------------------------------------------------------------------------------------*/
            DateTime start = Convert.ToDateTime(this.dateTimePicker8.Value.ToString("yyyy-MM-dd"));
            DateTime end = Convert.ToDateTime(this.dateTimePicker7.Value.ToString("yyyy-MM-dd"));



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
                MessageBox.Show("开始时间应晚于结束时间");
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
                    if (dayDiff == end_month_date && start_date == 31)
                    {
                        dayDiff = 0;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
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
            if (this.checkBox3.Checked == true)
            {
                dayDiff += 1;
                if (dayDiff == end_month_date)
                {
                    dayDiff = 0;
                    monthDiff += 1;
                }
            }
            this.textBox68.Text = monthDiff.ToString();
            this.textBox67.Text = dayDiff.ToString();
            /*------------------------------------------------------------------------------------------------------------------*/
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
            /*页面元素----------------------------------------------------------------------------------------------------------*/
            double my_money = Convert.ToDouble(this.textBox66.Text.ToString());//本金
            /*------------------------------------------------------------------------------------------------------------------*/
            double[] month_money = new double[100];
            double gross_interest = 0;
            double overall_money = 0;
            double day_money = 0;
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
            
            this.textBox64.Text = gross_interest.ToString();//总利息
            this.textBox63.Text = overall_money.ToString();//总成交额
        }

        private void button5_Click(object sender, EventArgs e)
        {
             double principal = Convert.ToDouble(this.textBox24.Text.ToString());//本金
            double nlx = Convert.ToDouble(this.textBox23.Text.ToString());//年利息
            double qx = Convert.ToDouble(this.textBox22.Text.ToString());//期限
            double jsqq = Convert.ToDouble(this.comboBox2.Text.ToString());
            double jsqx = Math.Floor(jsqq);
            double nll = nlx / 100;
            double yll = nll / 12;//月利息
            double i = 1 + yll;
            double j = Math.Pow(i, qx);
            double zzzhk = (principal * yll * j) / (j - 1);
            Math.Round(zzzhk, 2, MidpointRounding.AwayFromZero);
            double[] a = new Double[100];//剩余本金数组
            int b = 0;
            double[] c = new Double[100];//利息数组
            double d = 0;
            double[] aa = new Double[100];//本金数组
            double aaa = 0;
            double aab = 0;
            double aac = 0;
            double aad = 0;
            for (b = 0; b < qx; b++)
            {
                a[b] = Math.Round(principal, 5, MidpointRounding.AwayFromZero);
                d = yll * principal;
                c[b] = Math.Round(d, 5, MidpointRounding.AwayFromZero);
                zzzhk = Math.Round(zzzhk, 5, MidpointRounding.AwayFromZero);
                aaa = zzzhk - c[b];
                aa[b] = Math.Round(aaa, 5, MidpointRounding.AwayFromZero);
                principal = principal - zzzhk + c[b];
            }
            if (jsqx == 1)
            {
                aab = aa[0] + c[0];//当期总额
                aac = aa[0];
                aad = c[0];
            }
            else if (jsqx == 2)
            {
                aab = aa[1] + c[1];//当期总额
                aac = aa[1];
                aad = c[1];
            }
            else if (jsqx == 3)
            {
                aab = aa[2] + c[2];//当期总额
                aac = aa[2];
                aad = c[2];
            }
            else if (jsqx == 4)
            {
                aab = aa[3] + c[3];//当期总额
                aac = aa[3];
                aad = c[3];
            }
            else if (jsqx == 5)
            {
                aab = aa[4] + c[4];//当期总额
                aac = aa[4];
                aad = c[4];
            }
            else if (jsqx == 6)
            {
                aab = aa[5] + c[5];//当期总额
                aac = aa[5];
                aad = c[5];
            }
            else if (jsqx == 7)
            {
                aab = aa[6] + c[6];//当期总额
                aac = aa[6];
                aad = c[6];
            }
            else if (jsqx == 8)
            {
                aab = aa[7] + c[7];//当期总额
                aac = aa[7];
                aad = c[7];
            }
            else if (jsqx == 9)
            {
                aab = aa[8] + c[8];//当期总额
                aac = aa[8];
                aad = c[8];
            }
            else if (jsqx == 10)
            {
                aab = aa[9] + c[9];//当期总额
                aac = aa[9];
                aad = c[9];
            }
            if (jsqx == 11)
            {
                aab = aa[10] + c[10];//当期总额
                aac = aa[10];
                aad = c[10];
            }
            else if (jsqx == 12)
            {
                aab = aa[11] + c[11];//当期总额
                aac = aa[11];
                aad = c[11];
            }
            else if (jsqx == 13)
            {
                aab = aa[12] + c[12];//当期总额
                aac = aa[12];
                aad = c[12];
            }
            else if (jsqx == 14)
            {
                aab = aa[13] + c[13];//当期总额
                aac = aa[13];
                aad = c[13];
            }
            else if (jsqx == 15)
            {
                aab = aa[14] + c[14];//当期总额
                aac = aa[14];
                aad = c[14];
            }
            else if (jsqx == 16)
            {
                aab = aa[15] + c[15];//当期总额
                aac = aa[15];
                aad = c[15];
            }
            else if (jsqx == 17)
            {
                aab = aa[16] + c[16];//当期总额
                aac = aa[16];
                aad = c[16];
            }
            else if (jsqx == 18)
            {
                aab = aa[17] + c[17];//当期总额
                aac = aa[17];
                aad = c[17];
            }
            else if (jsqx == 19)
            {
                aab = aa[18] + c[18];//当期总额
                aac = aa[18];
                aad = c[18];
            }
            else if (jsqx == 20)
            {
                aab = aa[19] + c[19];//当期总额
                aac = aa[19];
                aad = c[19];
            }
            if (jsqx == 21)
            {
                aab = aa[20] + c[20];//当期总额
                aac = aa[20];
                aad = c[20];
            }
            else if (jsqx == 22)
            {
                aab = aa[21] + c[21];//当期总额
                aac = aa[21];
                aad = c[21];
            }
            else if (jsqx == 23)
            {
                aab = aa[22] + c[22];//当期总额
                aac = aa[22];
                aad = c[22];
            }
            else if (jsqx == 24)
            {
                aab = aa[23] + c[23];//当期总额
                aac = aa[23];
                aad = c[23];
            }
            else if (jsqx == 25)
            {
                aab = aa[24] + c[24];//当期总额
                aac = aa[24];
                aad = c[24];
            }
            else if (jsqx == 26)
            {
                aab = aa[25] + c[25];//当期总额
                aac = aa[25];
                aad = c[25];
            }
            else if (jsqx == 27)
            {
                aab = aa[26] + c[26];//当期总额
                aac = aa[26];
                aad = c[26];
            }
            else if (jsqx == 28)
            {
                aab = aa[27] + c[27];//当期总额
                aac = aa[27];
                aad = c[27];
            }
            else if (jsqx == 29)
            {
                aab = aa[28] + c[28];//当期总额
                aac = aa[28];
                aad = c[28];
            }
            else if (jsqx == 30)
            {
                aab = aa[29] + c[29];//当期总额
                aac = aa[29];
                aad = c[29];
            }
            if (jsqx == 31)
            {
                aab = aa[30] + c[30];//当期总额
                aac = aa[30];
                aad = c[30];
            }
            else if (jsqx == 32)
            {
                aab = aa[31] + c[31];//当期总额
                aac = aa[31];
                aad = c[31];
            }
            else if (jsqx == 33)
            {
                aab = aa[32] + c[32];//当期总额
                aac = aa[32];
                aad = c[32];
            }
            else if (jsqx == 34)
            {
                aab = aa[33] + c[33];//当期总额
                aac = aa[33];
                aad = c[33];
            }
            else if (jsqx == 35)
            {
                aab = aa[34] + c[34];//当期总额
                aac = aa[34];
                aad = c[34];
            }
            else if (jsqx == 36)
            {
                aab = aa[35] + c[35];//当期总额
                aac = aa[35];
                aad = c[35];
            }
            this.textBox25.Text = aab.ToString();
            this.textBox26.Text = aac.ToString();
            this.textBox27.Text = aad.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double principal = Convert.ToDouble(this.textBox21.Text.ToString());//本金
            double nlx = Convert.ToDouble(this.textBox20.Text.ToString());//年利息
            double qx = Convert.ToDouble(this.textBox19.Text.ToString());//期限
            double jsqx = Convert.ToDouble(this.comboBox1.Text.ToString());
            double nll = nlx / 100;
            double ylx = nll / 12;
            double yhbj = principal / qx;
            double[] a = new Double[38];//剩余本金
            int b = 0;
            double[] c = new Double[38];
            double aa = 0;
            double[] d = new Double[38];
            double qq = 0;
            double ww = 0;
            yhbj = Math.Round(yhbj, 5, MidpointRounding.AwayFromZero);
            for (b = 0; b <= qx; b++)
            {
                a[b] = principal;
                aa = principal * ylx;
                aa = Math.Round(aa, 5, MidpointRounding.AwayFromZero);
                c[b] = aa;
                d[b] = c[b] + yhbj;
                principal = principal - yhbj;
                principal = Math.Round(principal, 5, MidpointRounding.AwayFromZero);
            }
            if (jsqx == 1)
            {
                qq = d[0];//当期总额
                ww = c[0];
            }
            else if (jsqx == 2)
            {
                qq = d[1];//当期总额
                ww = c[1];
            }
            else if (jsqx == 3)
            {
                qq = d[2];//当期总额
                ww = c[2];
            }
            else if (jsqx == 4)
            {
                qq = d[3];//当期总额
                ww = c[3];
            }
            else if (jsqx == 5)
            {
                qq = d[4];//当期总额
                ww = c[4];
            }
            else if (jsqx == 6)
            {
                qq = d[5];//当期总额
                ww = c[5];
            }
            else if (jsqx == 7)
            {
                qq = d[6];//当期总额
                ww = c[6];
            }
            else if (jsqx == 8)
            {
                qq = d[7];//当期总额
                ww = c[7];
            }
            else if (jsqx == 9)
            {
                qq = d[8];//当期总额
                ww = c[8];
            }
            else if (jsqx == 10)
            {
                qq = d[9];//当期总额
                ww = c[9];
            }
            if (jsqx == 11)
            {
                qq = d[10];//当期总额
                ww = c[10];
            }
            else if (jsqx == 12)
            {
                qq = d[11];//当期总额
                ww = c[11];
            }
            else if (jsqx == 13)
            {
                qq = d[12];//当期总额
                ww = c[12];
            }
            else if (jsqx == 14)
            {
                qq = d[13];//当期总额
                ww = c[13];
            }
            else if (jsqx == 15)
            {
                qq = d[14];//当期总额
                ww = c[14];
            }
            else if (jsqx == 16)
            {
                qq = d[15];//当期总额
                ww = c[15];
            }
            else if (jsqx == 17)
            {
                qq = d[16];//当期总额
                ww = c[16];
            }
            else if (jsqx == 18)
            {
                qq = d[17];//当期总额
                ww = c[17];
            }
            else if (jsqx == 19)
            {
                qq = d[18];//当期总额
                ww = c[18];
            }
            else if (jsqx == 20)
            {
                qq = d[19];//当期总额
                ww = c[19];
            }
            if (jsqx == 21)
            {
                qq = d[20];//当期总额
                ww = c[20];
            }
            else if (jsqx == 22)
            {
                qq = d[21];//当期总额
                ww = c[21];
            }
            else if (jsqx == 23)
            {
                qq = d[22];//当期总额
                ww = c[22];
            }
            else if (jsqx == 24)
            {
                qq = d[23];//当期总额
                ww = c[23];
            }
            else if (jsqx == 25)
            {
                qq = d[24];//当期总额
                ww = c[24];
            }
            else if (jsqx == 26)
            {
                qq = d[25];//当期总额
                ww = c[25];
            }
            else if (jsqx == 27)
            {
                qq = d[26];//当期总额
                ww = c[26];
            }
            else if (jsqx == 28)
            {
                qq = d[27];//当期总额
                ww = c[27];
            }
            else if (jsqx == 29)
            {
                qq = d[28];//当期总额
                ww = c[28];
            }
            else if (jsqx == 30)
            {
                qq = d[29];//当期总额
                ww = c[29];
            }
            if (jsqx == 31)
            {
                qq = d[30];//当期总额
                ww = c[30];
            }
            else if (jsqx == 32)
            {
                qq = d[31];//当期总额
                ww = c[31];
            }
            else if (jsqx == 33)
            {
                qq = d[32];//当期总额
                ww = c[32];
            }
            else if (jsqx == 34)
            {
                qq = d[33];//当期总额
                ww = c[33];
            }
            else if (jsqx == 35)
            {
                qq = d[34];//当期总额
                ww = c[34];
            }
            else if (jsqx == 36)
            {
                qq = d[35];//当期总额
                ww = c[35];
            }

            this.textBox28.Text = qq.ToString();
            this.textBox29.Text = yhbj.ToString();
            this.textBox30.Text = ww.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*天数计算方法------------------------------------------------------------------------------------------------------*/
            DateTime start = Convert.ToDateTime(this.dateTimePicker4.Value.ToString("yyyy-MM-dd"));
            DateTime end = Convert.ToDateTime(this.dateTimePicker3.Value.ToString("yyyy-MM-dd"));



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
                MessageBox.Show("开始时间应晚于结束时间");
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
                    if (dayDiff == end_month_date && start_date == 31)
                    {
                        dayDiff = 0;
                        monthDiff += 1;
                        monthDiff += differ_year_month;
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
            /*------------------------------------------------------------------------------------------------------------------*/
            
            double principal = Convert.ToDouble(this.textBox33.Text.ToString());//本金
            double jxlx = Convert.ToDouble(this.textBox31.Text.ToString());//加息利息
            double jxsc = Convert.ToDouble(this.textBox32.Text.ToString());//加息时长
            double gjl;
            double yhbj;
            double yhlx;
            yhlx = principal * jxlx / 100 / 12; 
            yhlx = Math.Round(yhlx, 2, MidpointRounding.AwayFromZero);
            if (this.checkBox5.Checked == true)
            {
                yhbj = yhlx * dayDiff / list_end_month_date;
                gjl = monthDiff * yhlx;
                gjl += yhbj; 
            }
            else
            {
                yhbj = 0;
                gjl = yhlx * jxsc;
            }
            gjl = Math.Round(gjl, 2, MidpointRounding.AwayFromZero);
            yhbj = Math.Round(yhbj, 5, MidpointRounding.AwayFromZero);
            this.textBox34.Text = gjl.ToString();//共奖励
            this.textBox35.Text = yhbj.ToString();//按日计息奖励
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double principal = Convert.ToDouble(this.textBox36.Text.ToString());//本金
            double jxlx = Convert.ToDouble(this.textBox38.Text.ToString());//加息利息
            double jxsc = Convert.ToDouble(this.textBox37.Text.ToString());//加息时长
            double sjts = jxsc;
            double sjlx = jxlx / 100;
            double gjl = 0;
            DateTime start = Convert.ToDateTime(this.dateTimePicker10.Value.ToString("yyyy-MM-dd"));
            DateTime end = Convert.ToDateTime(this.dateTimePicker9.Value.ToString("yyyy-MM-dd"));
            string year1 = (start.Year.ToString());
            int intA = 0;
            int.TryParse(year1, out intA);
            string year2 = (end.Year.ToString());
            int intB = 0;
            int.TryParse(year2, out intB);
            //月
            string month1 = (start.Month.ToString());
            int intC = 0;
            int.TryParse(month1, out intC);
            string month2 = (end.Month.ToString());
            int intD = 0;
            int.TryParse(month2, out intD);
            //日
            string date1 = (start.Day.ToString());
            int intE = 0;
            int.TryParse(date1, out intE);
            string date2 = (start.Day.ToString());
            int intF = 0;
            int.TryParse(date1, out intF);

            DateTime dt1 = start;
            DateTime dt2 = end;
            TimeSpan span = dt2.Subtract(dt1);
            int dayDiff = span.Days;
            if (this.checkBox4.Checked == true)
            {
                sjts = dayDiff;
                gjl = principal * dayDiff * sjlx / 365;
            }
            else
            {
                gjl = principal * sjlx * sjts / 365;
            }

            gjl = Math.Round(gjl, 5, MidpointRounding.AwayFromZero);
            sjts = Math.Round(sjts, 5, MidpointRounding.AwayFromZero);
            this.textBox39.Text = gjl.ToString();//共奖励
            this.textBox40.Text = sjts.ToString();//实际持有天数
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void rb01_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb01.Checked == true)
            {
                richTextBox1.Text = "预期收益=出借金额×预期年化收益率÷12×持有期限\n数据处理：保留小数点后两位，四舍五入";
            }
        }

        private void rb02_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb02.Checked == true)
            {
                richTextBox1.Text = "预期收益=出借金额×(新手首月年化收益率÷12)+出借金额×预期年化收益率÷12×(持有期限-1)\n数据处理：保留小数点后两位，四舍五入";    
            }
        }

        private void rb03_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb03.Checked == true)
            {
                richTextBox1.Text = "预期收益=出借金额×(锁定期年化收益率÷12×锁定期限)+出借金额×预期年化收益率÷12×(持有期限-锁定期限)\n数据处理：保留小数点后两位，四舍五入";
            }
        }

        private void rb04_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb04.Checked == true)
            {
                richTextBox1.Text = "预期收益=出借金额×（第1个月预期年化收益率÷12）+出借金额×（第2个月预期年化收益率÷12）+……+出借金额×（第n个月预期年化收益率÷12）\n数据处理：每一期小数点后16位，最后加和保留小数点后两位，四舍五入";
            }
        }

        private void rb05_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb05.Checked == true)
            {
                richTextBox1.Text = "--散标一次性还本付息--\n预期收益=出借金额*（预期年化收益率÷12）*持有期限\n--散标按月付息到期还本--\n每月收益=出借金额*（预期年化收益率÷12）\n预期收益=每月收益*持有期限\n数据处理：保留小数点后两位，四舍五入";
            }
        }

        private void rb06_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rb06.Checked == true)
            {
                richTextBox1.Text = "--按月加息--\n每期的加息奖励=投标金额*（加息利率/12）\n总加息奖励=每期加息奖励（四舍五入后）*总加息时长\n--按日加息--\n总加息劵预期收益=投资金额*加息利率*(加息天数/365)\n四舍五入";
            }
        }
    }
}
