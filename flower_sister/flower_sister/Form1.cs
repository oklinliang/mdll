using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text;

namespace flower_sister
{
    public partial class flower_sister : Form
    {
        public flower_sister()
        {
            InitializeComponent();
        }
        public void output(string log)
        {
            textBox1.AppendText(log + "\r\n");
        }
        //输出利率
        public void output_lilv(string log)
        {
            textBox4.AppendText(log + "\r\n");
        }
        public void output_zijin(string log)
        {
            textBox2.AppendText(log + "\r\n");
        }
        public void output_zhekou(string log)
        {
            textBox3.AppendText(log + "\r\n");
        }
        public void output_name(string log)
        {
            textBox5.AppendText(log + "\r\n");
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
            dayDiff += 1;
            if (dayDiff == end_month_date)
            {
                dayDiff = 0;
                monthDiff += 1;
            }

            
            string op_lilv = string.Empty;
            string op_zijin = string.Empty;
            string op_zhekou = string.Empty;
            string op_name = string.Empty;
            List<string> lines = new List<string>();
            using (StreamReader reader_lilv = new StreamReader(@"G:\nlilv.txt"))
            using (StreamReader reader_name = new StreamReader(@"G:\nname.txt"))
            using (StreamReader reader_zhekou = new StreamReader(@"G:\nzhekou.txt"))
            using (StreamReader reader_zijin = new StreamReader(@"G:\nzijin.txt"))
            {
                op_lilv = reader_lilv.ReadLine();
                op_name = reader_name.ReadLine();
                op_zhekou = reader_zhekou.ReadLine();
                op_zijin = reader_zijin.ReadLine();
                while (op_lilv != "" && op_lilv != null)
                {
                    output_lilv(op_lilv.ToString());
                    output_zijin(op_zijin.ToString());
                    output_zhekou(op_zhekou.ToString());
                    output_name(op_name.ToString());
                    if (MessageBox.Show("继续？", "caption", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {

                        double dazhe = Convert.ToDouble(this.textBox3.Text.ToString());
                        double new_dazhe = dazhe / 10;
                        double my_money = Convert.ToDouble(this.textBox2.Text.ToString());
                        double lilv = Convert.ToDouble(this.textBox4.Text.ToString());
                        string name = textBox5.Text;
                        double exit_rate = 0.02;
                        double dazhe_out;
                        double dazhe_qian;
                        double cha;
                        double gross_interest;
                        double day_money;
                        double overall_money;
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


                        dazhe_out = my_money * exit_rate * new_dazhe;
                        dazhe_qian = my_money * exit_rate;
                        cha = dazhe_qian - dazhe_out;
                        overall_money -= dazhe_out;


                        output("用户名：" + name.ToString());
                        output("共持有" + monthDiff.ToString() + "个月" + dayDiff.ToString() + "天");
                        output("折扣：" + dazhe.ToString());
                        output("利率" + lilv.ToString() + "%");
                        output("总利息" + gross_interest.ToString() + "元");
                        output("总成交额" + overall_money.ToString() + "元");
                        output("打折前应收手续费：" + dazhe_qian.ToString());
                        output("打折后应收手续费：" + dazhe_out.ToString());
                        output("为您节省了：" + cha.ToString());
                        output("-------------------------------------");
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";
                        textBox5.Text = "";

                        lines.Add(op_lilv);
                        Console.WriteLine(op_lilv);
                        op_lilv = reader_lilv.ReadLine();

                        lines.Add(op_zijin);
                        Console.WriteLine(op_zijin);
                        op_zijin = reader_zijin.ReadLine();

                        lines.Add(op_zhekou);
                        Console.WriteLine(op_zhekou);
                        op_zhekou = reader_zhekou.ReadLine();

                        lines.Add(op_name);
                        Console.WriteLine(op_name);
                        op_name = reader_name.ReadLine();
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
