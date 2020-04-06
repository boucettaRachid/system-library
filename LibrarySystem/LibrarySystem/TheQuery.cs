using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace LibrarySystem
{
    class TheQuery
    {
        Access a = new Access();

        public DataTable AllProduct(DataGridView DG, string where)
        {
            try
            {
                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select * from Product " + where;
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                DG.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
                return a.dt;
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
                return a.dt;
            }
        }


        public void Allorders(DataGridView DG, string where)
        {
            try
            {
                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select * from Orders " + where;
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                DG.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

        public void Admins(DataGridView dg)
        {
            try
            {
                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select * from Admins ";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                dg.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

      


        public void Orders(DataGridView DG,Label l)
        {
            try
            {
                a.dt.Clear();
                a.connection();
                a.cmd.CommandText = "select Orders.ID,Product.Name,Orders.Quntity,Orders.price from Orders inner join Product on Product.ID = Orders.product where Orders.ID_cmd='" + l.Text + "'";
                a.cmd.Connection = a.con;
                a.dr = a.cmd.ExecuteReader();
                a.dt.Load(a.dr);
                DG.DataSource = a.dt;
                a.dr.Close();
                a.Deconnection();
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

            public int SumProducts()
            {
                 try{
                    a.connection();
                    a.cmd.CommandText = "select count(*) from Product";
                    a.cmd.Connection = a.con;

                        if (a.cmd.ExecuteScalar().ToString() != null)
                        {
                            return int.Parse(a.cmd.ExecuteScalar().ToString());
                        }
                        else
                        {
                            return 0;
                        }

                    a.Deconnection();
                    }
                    catch (Exception x)
                    {
                        MessageBox.Show(x.Message);
                        return 0;
                    }
            }

            public int SumOrders()
            {
                try
                {
                    a.connection();
                    a.cmd.CommandText = "select count(*) from Orders";
                    a.cmd.Connection = a.con;

                    if (a.cmd.ExecuteScalar().ToString() != null)
                    {
                        return int.Parse(a.cmd.ExecuteScalar().ToString());
                    }
                    else
                    {
                        return 0;
                    }
                    a.Deconnection();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                    return 0;
                }
            }

            public int SumFinProducts()
            {
                try
                {
                    a.connection();
                    a.cmd.CommandText = "select count(*) from Product where Quntity <= 0";
                    a.cmd.Connection = a.con;

                    if (a.cmd.ExecuteScalar().ToString() != null)
                    {
                        return int.Parse(a.cmd.ExecuteScalar().ToString());
                    }
                    else
                    {
                        return 0;
                    }
                    a.Deconnection();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                    return 0;
                }
            }


            public Double SumMoney()
            {
                try
                {
                    a.connection();
                    a.cmd.CommandText = "select sum(price) from Orders";
                    a.cmd.Connection = a.con;

                    if (a.cmd.ExecuteScalar().ToString() != "")
                    {
                        return Double.Parse(a.cmd.ExecuteScalar().ToString());
                    }
                    else
                    {
                        return 0;
                    }

                    a.Deconnection();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                    return 0;
                }

            }

            public Double SumCapital()
            {
                try
                {
                    a.connection();
                    a.cmd.CommandText = "select sum(capital) from Product";
                    a.cmd.Connection = a.con;

                    if (a.cmd.ExecuteScalar().ToString() != "")
                    {
                        return Double.Parse(a.cmd.ExecuteScalar().ToString());
                    }
                    else
                    {
                        return 0;
                    }

                    a.Deconnection();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                    return 0;
                }

            }



            public string CountOrder(string ID)
            {
                try
                {
                    a.connection();
                    a.cmd.CommandText = "select count(product) from Orders where product = "+ ID ;
                    a.cmd.Connection = a.con;
                    return a.cmd.ExecuteScalar().ToString();
                    a.Deconnection();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                    return "0";
                }
            }


            public string Stock(string ID)
            {
                try
                {
                    a.connection();
                    a.cmd.CommandText = "select Quntity from Product where ID = " + ID;
                    a.cmd.Connection = a.con;
                    return a.cmd.ExecuteScalar().ToString();
                    a.Deconnection();
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                    return "0";
                }
            }


        }
    }

