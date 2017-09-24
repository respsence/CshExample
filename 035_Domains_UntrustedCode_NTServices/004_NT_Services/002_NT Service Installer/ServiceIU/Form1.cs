using System;
using System.Windows.Forms;
using System.ServiceProcess;
using System.Configuration.Install;

namespace ServiceIU
{
    public partial class Form1 : Form
    {
        ServiceController controller;

        public Form1()
        {
            InitializeComponent();
        }
        // Выбор файла-службы
        private void Button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.SafeFileName;
            }
        }

        // Устанавка службы.
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Выберите файл с NT-службой.");
            }
            else
            {
                try
                {
                    ManagedInstallerClass.InstallHelper(new[]
                                                            {
                                                                openFileDialog1.FileName
                                                            });
                    MessageBox.Show("Сервис " + openFileDialog1.SafeFileName + " установлен!");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        }

        // Деинсталяция службы.
        private void Button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                MessageBox.Show("Выберите файл с NT-службой.");
            }
            else
            {
                try
                {
                    ManagedInstallerClass.InstallHelper(new[] { @"/u", openFileDialog1.FileName });
                    MessageBox.Show("Сервис " + openFileDialog1.SafeFileName + " деинсталирован!");
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.ToString());
                }
            }
        }

        // Start service
        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                controller = new ServiceController
                                 {
                                     ServiceName = "===== TEST SERVICE ====="
                                 };
                controller.Start();
                MessageBox.Show("Service Started");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        // Stop service
        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                controller = new ServiceController
                                 {
                                     ServiceName = "===== TEST SERVICE ====="
                                 };
                controller.Stop();
                MessageBox.Show("Service Stopped");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }
    }
}
