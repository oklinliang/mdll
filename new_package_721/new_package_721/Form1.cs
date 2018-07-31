using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace new_package_721
{
    public partial class new_package : Form
    {
        public new_package()
        {
            InitializeComponent();
        }
        public void output(string log)
        {
            textBox1.AppendText(log + "\r\n");
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
            //dayDiff += 1;
            //if (dayDiff == end_month_date)
            //{
            //    dayDiff = 0;
            //    monthDiff += 1;
            //}
            double my_money = Convert.ToDouble(this.textBox3.Text.ToString());//本金
            double old_money = Convert.ToDouble(this.textBox4.Text.ToString());//债权金额
            double zhekou = Convert.ToDouble(this.textBox2.Text.ToString());//折扣
            double lilv = Convert.ToDouble(this.textBox9.Text.ToString());//利率
            double vip = Convert.ToDouble(this.textBox10.Text.ToString());//利率
            double day_money;
            double overall_money;
            double dazhe_my_money;
            double dazhe_my_zhaiquan;
            double over_lilv = lilv / 100;

            if (this.radioButton1.Checked == true)
            {
                double gross_interest;
                double tuichu = 0;
                if (monthDiff == 0)
                {
                    if (start_date < end_date)
                    {
                        day_money = my_money * over_lilv * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        day_money = my_money * over_lilv * dayDiff / 12 / list_end_month_date;
                    }
                }
                else
                {
                    if (start_date < end_date)
                    {
                        day_money = my_money * over_lilv * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        day_money = my_money * over_lilv * dayDiff / 12 / list_end_month_date;
                    }
                }
                gross_interest = my_money * over_lilv / 12 * monthDiff;
                gross_interest += day_money;
                gross_interest = Math.Round(gross_interest, 5, MidpointRounding.AwayFromZero);
                dazhe_my_money = my_money * zhekou / 10;
                dazhe_my_zhaiquan = old_money * zhekou / 10;
                if (this.checkBox1.Checked == true)
                {
                    tuichu = my_money * 0.02;
                    tuichu = vip * tuichu / 10;
                    if (tuichu < 2)
                    {
                        tuichu = 2;
                    }
                }
                overall_money = dazhe_my_money + gross_interest - tuichu;

                output("转让人计算方式：");
                output("紧急退出费用：" + tuichu.ToString());
                output("转让原金额：" + my_money.ToString());
                output("转让折扣：" + zhekou.ToString() + "折");
                output("打折后转让金额：" + dazhe_my_zhaiquan.ToString());
                output("转让时利息：" + gross_interest.ToString());
                output("转让人最后拿到：" + overall_money.ToString());
                output("------------------------------");
            }
            if (this.radioButton2.Checked == true)
            {
                double tuichu = 0;
                if (monthDiff == 0)
                {
                    if (start_date < end_date)
                    {
                        day_money = my_money * over_lilv * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        day_money = my_money * over_lilv * dayDiff / 12 / list_end_month_date;
                    }
                }
                else
                {
                    if (start_date < end_date)
                    {
                        day_money = my_money * over_lilv * dayDiff / 12 / end_month_date;
                    }
                    else
                    {
                        day_money = my_money * over_lilv * dayDiff / 12 / list_end_month_date;
                    }
                }
                day_money = Math.Round(day_money, 5, MidpointRounding.AwayFromZero);
                dazhe_my_money = my_money * zhekou / 10;
                dazhe_my_zhaiquan = old_money * zhekou / 10;
                if (this.checkBox1.Checked == true)
                {
                    tuichu = my_money * 0.02;
                    tuichu = vip * tuichu / 10;
                    if (tuichu < 2)
                    {
                        tuichu = 2;
                    }
                }
                overall_money = dazhe_my_money + day_money - tuichu;

                output("转让人计算方式：");
                output("紧急退出费用：" + tuichu.ToString());
                output("转让原金额：" + my_money.ToString());
                output("转让折扣：" + zhekou.ToString() + "折");
                output("打折后转让金额：" + dazhe_my_zhaiquan.ToString());
                output("转让时利息：" + day_money.ToString());
                output("转让人最后拿到：" + overall_money.ToString());
                output("------------------------------");
            }
            if (this.radioButton3.Checked == true)
            {
                double[] p_box = new double[38];
                p_box[0] = 0;
                double tby01 = 5; p_box[1] = tby01 / 100;
                double tby02 = 5.5; p_box[2] = tby02 / 100;
                double tby03 = 6; p_box[3] = tby03 / 100;
                double tby04 = 6.3; p_box[4] = tby04 / 100;
                double tby05 = 6.6; p_box[5] = tby05 / 100;
                double tby06 = 6.9; p_box[6] = tby06 / 100;
                double tby07 = 7.3; p_box[7] = tby07 / 100;
                double tby08 = 7.7; p_box[8] = tby08 / 100;
                double tby09 = 8.1; p_box[9] = tby09 / 100;
                double tby10 = 8.6; p_box[10] = tby10 / 100;
                double tby11 = 9.1; p_box[11] = tby11 / 100;
                double tby12 = 9.6; p_box[12] = tby12 / 100;
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
                

                double[] month_money = new double[100];
                double gross_interest = 0;
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
                dazhe_my_money = my_money * zhekou / 10;
                overall_money = gross_interest + my_money;

                output("转让人计算方式：");
                output("转让原金额：" + my_money.ToString());
                output("转让折扣：" + zhekou.ToString() + "折");
                output("打折后转让金额：" + dazhe_my_money.ToString());
                output("转让时利息：" + gross_interest.ToString());
                output("转让人最后拿到：" + overall_money.ToString());
                output("------------------------------");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double my_money = Convert.ToDouble(this.textBox6.Text.ToString());//承接金额
            double old_money = Convert.ToDouble(this.textBox5.Text.ToString());//债权金额
            double lilv = Convert.ToDouble(this.textBox7.Text.ToString());//利率
            double my_time = Convert.ToDouble(this.textBox8.Text.ToString());//持有时间
            double lixi;

            lixi = old_money * lilv / 12 * my_time / 100;

            output("承接人计算方式：");
            output("承接时金额：" + my_money.ToString());
            output("总承接债权金额：" + old_money.ToString());
            output("预期利息：" + lixi.ToString());
            output("------------------------------");
        }
    }
}
