using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        //private object item;
        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {





            // Save the config file.
            //Setting.Default.Save();
            dataGridView1.Rows.Clear();
            dataGridView1.ShowCellToolTips = true;
            string year = comboBox1.Text;


            foreach (var c in Directory.GetDirectories(textBoxData2.Text))


         //foreach (var c in Directory.GetDirectories(@"\\ifw-dresden.de\Archiv\Projects\Elektrotechnik\_____BFT_Projekte"))
            {
                var dir = new DirectoryInfo(c);
                if (dir.Exists)
                {
                    var dirname = dir.Name;
                    string d = @"^[a-zA-Z ]*$";
                    if (dirname.Substring(0, 2) == year)

                    //|| dirname.Substring(0, 2) == year && year.Contains(d) || year.Contains(d))
                    {




                        if (Directory.Exists(dir + @"\___Projekt_Abschluss"))
                        {
                            var index = dataGridView1.Rows.Add();
                            //dataGridView1.Rows[index].Cells[0].Value = dirname;
                        
                                dataGridView1.Rows[index].Cells[0].Value = dirname;

                                
                               
                            dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                           
                            string[] files = Directory.GetFiles(dir + @"\___Projekt_Abschluss");


                            List<string> result = new List<string>();
                            foreach (string file in files)
                            {

                                var dd = new DirectoryInfo(file);
                                var dname = dd.Name;

                                result.Add(dname);

                            }
                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                List<string> rst = result.FindAll(delegate(string s)
                                {
                                    return s.StartsWith(dataGridView1.Columns[j].HeaderText);
                                });
                                DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                cell.ToolTipText = string.Join(Environment.NewLine, rst);
                                if (rst.Count > 0)
                                {
                                    List<string> pdf = rst.FindAll(delegate(string s)
                                    {
                                        return s.EndsWith(".pdf");
                                    });
                                    List<string> jpg = rst.FindAll(delegate(string s)
                                    {
                                        return s.EndsWith(".jpg");
                                    });
                                    if (pdf.Count > 0 || jpg.Count > 0)
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                        // cell.ToolTipText = "rst";


                                    }


                                    else
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                    }



                                }


                            }

                        }
                        else
                        {
                            var index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells[0].Value = dirname;
                            
                           
                            dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                            string[] files = Directory.GetFiles(dir.ToString());
                            List<string> result = new List<string>();
                            foreach (string file in files)
                            {

                                var dd = new DirectoryInfo(file);
                                var dname = dd.Name;

                                result.Add(dname);
                            }
                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                List<string> rst = result.FindAll(delegate(string s)
                                {
                                    return s.StartsWith(dataGridView1.Columns[j].HeaderText);
                                });
                                DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                cell.ToolTipText = string.Join(Environment.NewLine, rst);
                                if (rst.Count > 0)
                                {
                                    List<string> pdf = rst.FindAll(delegate(string s)
                                    {
                                        return s.EndsWith(".pdf");
                                    });
                                    List<string> jpg = rst.FindAll(delegate(string s)
                                    {
                                        return s.EndsWith(".jpg");
                                    });
                                    if (pdf.Count > 0 || jpg.Count > 0)
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                        // cell.ToolTipText = "rst";


                                    }


                                    else
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                    }



                                }

                            }

                        }
                        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                    }
                    else
                    {
                        if (c.Substring(0, 2) == year)
                        {
                            var index = dataGridView1.Rows.Add();
                            //dataGridView1.Rows[index].Cells[0].Value = c;
                           
                            dataGridView1.Rows[index].Cells[0].Value = c;
                            dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                            string[] fi = Directory.GetFiles(c);
                            List<string> res = new List<string>();
                            foreach (string f in fi)
                            {
                                var ll = new DirectoryInfo(f);
                                var lname = ll.Name;
                                res.Add(lname);
                            }

                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                List<string> re = res.FindAll(delegate(string k)
                                {

                                    return k.StartsWith(dataGridView1.Columns[j].HeaderText);
                                }); DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                cell.ToolTipText = string.Join(Environment.NewLine, re);
                                if (re.Count > 0)
                                {
                                    List<string> pdf = re.FindAll(delegate(string k)
                                    {
                                        return k.EndsWith(".pdf");
                                    });
                                    List<string> jpg = re.FindAll(delegate(string k)
                                    {
                                        return k.EndsWith(".jpg");
                                    });
                                    if (pdf.Count > 0 || jpg.Count > 0)
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                        // cell.ToolTipText = "rst";


                                    }


                                    else
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                    }



                                }

                            }
                        }
                        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                    }



                    dataGridView1.ClearSelection();


                }
            }

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult dr = fbd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBoxData2.Text = fbd.SelectedPath;
                //textBoxData2.Text = fbd.SelectedPath;
                textBoxData1.Enabled = true;
                //comboBox3.Enabled = true;
                button1.Enabled = true;
                List<string> yer = new List<string>();
                foreach (var c in Directory.GetDirectories(textBoxData2.Text))


                //foreach (var c in Directory.GetDirectories(@"\\ifw-dresden.de\Archiv\Projects\Elektrotechnik\_____BFT_Projekte"))
                {
                    var dir = new DirectoryInfo(c);
                    if (dir.Exists)
                    {
                        yer.Add(dir.Name.Substring(0, 2));
                    }
                }


                var year_d = yer.Distinct().ToList();
                comboBox1.DataSource = year_d;
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxData1.Text = Properties.Settings.Default.Data1;
            textBoxData2.Text = Properties.Settings.Default.Data2;
            textBox1.Text = Properties.Settings.Default.Data4;
            if (File.Exists("data.xml"))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Information));
                FileStream read = new FileStream("data.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
                Information info = (Information)xs.Deserialize(read);
                textBoxData1.Text = info.Data1;
                textBoxData2.Text = info.Data2;
                textBox1.Text = info.Data4;
            }
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Data1 = textBoxData1.Text;
            Properties.Settings.Default.Data2 = textBoxData2.Text;
            Properties.Settings.Default.Data3 = comboBox1.Text;
            Properties.Settings.Default.Data4 = textBox1.Text;
            //Properties.Settings.Default.Data5 = comboBox3.Items.ToString();
            Properties.Settings.Default.Save();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ShowCellToolTips = true;
            string Pname = textBoxData1.Text;


            foreach (var c in Directory.GetDirectories(textBoxData2.Text))


            //foreach (var c in Directory.GetDirectories(@"\\ifw-dresden.de\Archiv\Projects\Elektrotechnik\_____BFT_Projekte"))
            {
                var dir = new DirectoryInfo(c);
                if (dir.Exists)
                {
                    var dirname = dir.Name;
                    string d = @"^[a-zA-Z ]*$";
                    //if (dirname.Contains(Pname))
                    if (Regex.IsMatch(dirname, Pname, RegexOptions.IgnoreCase))

                    //|| dirname.Substring(7, 12) == Pname && Pname.Contains(d) || Pname.Contains(d))
                    {




                        if (Directory.Exists(dir + @"\___Projekt_Abschluss"))
                        {
                            var index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells[0].Value = dirname;
                            dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                            string[] files = Directory.GetFiles(dir + @"\___Projekt_Abschluss");


                            List<string> result = new List<string>();
                            foreach (string file in files)
                            {

                                var dd = new DirectoryInfo(file);
                                var dname = dd.Name;

                                result.Add(dname);

                            }
                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                List<string> rst = result.FindAll(delegate(string s)
                                {
                                    return s.StartsWith(dataGridView1.Columns[j].HeaderText);
                                });
                                DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                cell.ToolTipText = string.Join(Environment.NewLine, rst);
                                if (rst.Count > 0)
                                {
                                    List<string> pdf = rst.FindAll(delegate(string s)
                                    {
                                        return s.EndsWith(".pdf");
                                    });
                                    List<string> jpg = rst.FindAll(delegate(string s)
                                    {
                                        return s.EndsWith(".jpg");
                                    });
                                    if (pdf.Count > 0 || jpg.Count > 0)
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                        // cell.ToolTipText = "rst";


                                    }


                                    else
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                    }



                                }


                            }

                        }
                        else
                        {
                            var index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells[0].Value = dirname;
                            dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                            string[] files = Directory.GetFiles(dir.ToString());
                            List<string> result = new List<string>();
                            foreach (string file in files)
                            {

                                var dd = new DirectoryInfo(file);
                                var dname = dd.Name;

                                result.Add(dname);
                            }
                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                List<string> rst = result.FindAll(delegate(string s)
                                {
                                    return s.StartsWith(dataGridView1.Columns[j].HeaderText);
                                });
                                DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                cell.ToolTipText = string.Join(Environment.NewLine, rst);
                                if (rst.Count > 0)
                                {
                                    List<string> pdf = rst.FindAll(delegate(string s)
                                    {
                                        return s.EndsWith(".pdf");
                                    });
                                    List<string> jpg = rst.FindAll(delegate(string s)
                                    {
                                        return s.EndsWith(".jpg");
                                    });
                                    if (pdf.Count > 0 || jpg.Count > 0)
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                        // cell.ToolTipText = "rst";


                                    }


                                    else
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                    }



                                }

                            }

                        }
                        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending); 
                    }
                    else
                    {
                        if (Regex.IsMatch(c, Pname, RegexOptions.IgnoreCase))
                        //if (c.Substring(0, 12) == Pname)
                        {
                            var index = dataGridView1.Rows.Add();
                            dataGridView1.Rows[index].Cells[0].Value = c;
                            dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                            dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                            string[] fi = Directory.GetFiles(c);
                            List<string> res = new List<string>();
                            foreach (string f in fi)
                            {
                                var ll = new DirectoryInfo(f);
                                var lname = ll.Name;
                                res.Add(lname);
                            }

                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                List<string> re = res.FindAll(delegate(string k)
                                {

                                    return k.StartsWith(dataGridView1.Columns[j].HeaderText);
                                }); DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                cell.ToolTipText = string.Join(Environment.NewLine, re);
                                if (re.Count > 0)
                                {
                                    List<string> pdf = re.FindAll(delegate(string k)
                                    {
                                        return k.EndsWith(".pdf");
                                    });
                                    List<string> jpg = re.FindAll(delegate(string k)
                                    {
                                        return k.EndsWith(".jpg");
                                    });
                                    if (pdf.Count > 0 || jpg.Count > 0)
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                        // cell.ToolTipText = "rst";


                                    }


                                    else
                                    {
                                        dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                    }



                                }

                            }
                        }
                        dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                    }



                    dataGridView1.ClearSelection();


                }
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            textBox1.Enabled = true;
            button1.Enabled = true;
            comboBox2.Enabled = true;
          
            

            openFileDialog1.InitialDirectory = @"C:\";

            openFileDialog1.Title = "Browse Text Files";



            openFileDialog1.CheckFileExists = true;

            openFileDialog1.CheckPathExists = true;



            openFileDialog1.DefaultExt = "txt";

            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            openFileDialog1.FilterIndex = 2;

            openFileDialog1.RestoreDirectory = true;



            openFileDialog1.ReadOnlyChecked = true;

            openFileDialog1.ShowReadOnly = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                textBox1.Text = openFileDialog1.FileName;

            }


            StreamReader sr = new
                               StreamReader(textBox1.Text, System.Text.Encoding.Default, true);
            //string f = sr.ReadToEnd();

            comboBox2.Text = sr.ReadToEnd();


            string f = comboBox2.Text;



            //for (int i = 0; i < f.Length; i++)
            //{
            var n = f.Split('\n').ToList();
            //    var n = f.Split('\n').Select(Int32.Parse).ToList();

            //string n = f.Substring(0, 6);
            //comboBox2.Items.Add(n);
            //comboBox2.DataSource = n;

            comboBox2.DataSource = n;
        }
         

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.ShowCellToolTips = true;
            //string year = comboBox2.Text;




            foreach (var c in Directory.GetDirectories(textBoxData2.Text))


            //foreach (var c in Directory.GetDirectories(@"\\ifw-dresden.de\Archiv\Projects\Elektrotechnik\_____BFT_Projekte"))
            {
                var dir = new DirectoryInfo(c);
                if (dir.Exists)
                {
                    var dirname = dir.Name;
                    //string d = @"^[a-zA-Z ]*$";

                    foreach (object n in this.comboBox2.Items
                        )
                    {
                        if (n.ToString().Contains(dirname.Substring(0,6)))




                        ////|| dirname.Substring(0, 6) == year )
                        ////&& year.Contains(d) || year.Contains(d))
                        //{
                        {



                            if (Directory.Exists(dir + @"\___Projekt_Abschluss"))
                            {
                                var index = dataGridView1.Rows.Add();
                                dataGridView1.Rows[index].Cells[0].Value = dirname;
                              
                                dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                                string[] files = Directory.GetFiles(dir + @"\___Projekt_Abschluss");


                                List<string> result = new List<string>();
                                foreach (string file in files)
                                {

                                    var dd = new DirectoryInfo(file);
                                    var dname = dd.Name;

                                    result.Add(dname);

                                }
                                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                                {
                                    List<string> rst = result.FindAll(delegate(string s)
                                    {
                                        return s.StartsWith(dataGridView1.Columns[j].HeaderText);
                                    });
                                    DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                    cell.ToolTipText = string.Join(Environment.NewLine, rst);
                                    if (rst.Count > 0)
                                    {
                                        List<string> pdf = rst.FindAll(delegate(string s)
                                        {
                                            return s.EndsWith(".pdf");
                                        });
                                        List<string> jpg = rst.FindAll(delegate(string s)
                                        {
                                            return s.EndsWith(".jpg");
                                        });
                                        if (pdf.Count > 0 || jpg.Count > 0)
                                        {
                                            dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                            // cell.ToolTipText = "rst";


                                        }


                                        else
                                        {
                                            dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                        }



                                    }


                                }

                            }
                            else
                            {
                                var index = dataGridView1.Rows.Add();
                                dataGridView1.Rows[index].Cells[0].Value = dirname;
                                dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                                string[] files = Directory.GetFiles(dir.ToString());
                                List<string> result = new List<string>();
                                foreach (string file in files)
                                {

                                    var dd = new DirectoryInfo(file);
                                    var dname = dd.Name;

                                    result.Add(dname);
                                }
                                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                                {
                                    List<string> rst = result.FindAll(delegate(string s)
                                    {
                                        return s.StartsWith(dataGridView1.Columns[j].HeaderText);
                                    });
                                    DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                    cell.ToolTipText = string.Join(Environment.NewLine, rst);
                                    if (rst.Count > 0)
                                    {
                                        List<string> pdf = rst.FindAll(delegate(string s)
                                        {
                                            return s.EndsWith(".pdf");
                                        });
                                        List<string> jpg = rst.FindAll(delegate(string s)
                                        {
                                            return s.EndsWith(".jpg");
                                        });
                                        if (pdf.Count > 0 || jpg.Count > 0)
                                        {
                                            dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                            // cell.ToolTipText = "rst";


                                        }


                                        else
                                        {
                                            dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                        }



                                    }

                                }

                            }
                            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                        }
                        else
                        {
                            //if (c.Substring(0, year.Length) == year)
                            if (n.ToString().Contains(c.Substring(0,6)))
                            {
                                var index = dataGridView1.Rows.Add();
                                dataGridView1.Rows[index].Cells[0].Value = c;
                                dataGridView1.Rows[index].Cells[0].Style.BackColor = Color.White;
                                dataGridView1.Rows[index].DefaultCellStyle.BackColor = Color.Red;
                                string[] fi = Directory.GetFiles(c);
                                List<string> res = new List<string>();
                                foreach (string f in fi)
                                {
                                    var ll = new DirectoryInfo(f);
                                    var lname = ll.Name;
                                    res.Add(lname);
                                }

                                for (int j = 1; j < dataGridView1.Columns.Count; j++)
                                {
                                    List<string> re = res.FindAll(delegate(string k)
                                    {

                                        return k.StartsWith(dataGridView1.Columns[j].HeaderText);
                                    }); DataGridViewCell cell = this.dataGridView1.Rows[index].Cells[j];

                                    cell.ToolTipText = string.Join(Environment.NewLine, re);
                                    if (re.Count > 0)
                                    {
                                        List<string> pdf = re.FindAll(delegate(string k)
                                        {
                                            return k.EndsWith(".pdf");
                                        });
                                        List<string> jpg = re.FindAll(delegate(string k)
                                        {
                                            return k.EndsWith(".jpg");
                                        });
                                        if (pdf.Count > 0 || jpg.Count > 0)
                                        {
                                            dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Green;

                                            // cell.ToolTipText = "rst";


                                        }


                                        else
                                        {
                                            dataGridView1.Rows[index].Cells[j].Style.BackColor = Color.Yellow;
                                        }



                                    }

                                }
                            }
                            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
                        }



                        dataGridView1.ClearSelection();


                    }
                }

            }
        }

        private void textBoxData2_TextChanged(object sender, EventArgs e)
        {

        }
    }


}