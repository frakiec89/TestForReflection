using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReflectionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            goRefBt.IsEnabled = false;
            goBt.IsEnabled = false;
        }

        private void goBt_Click(object sender, RoutedEventArgs e)
        {
            Assembly asm = Assembly.LoadFrom(pathTb.Text);
            List<Type> types = asm.GetTypes().ToList();

            Type pr = types[0];

            // создаем экземпляр класса Program
            object programObj = Activator.CreateInstance(pr);

            ConsoleHelper.AllocConsole();
            this.Close();
            MethodInfo method = pr.GetMethod("Main", BindingFlags.DeclaredOnly
            | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
             method.Invoke(programObj, new object[] { new string[] { } });
        }

        private void selectBt_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter= "dll|*dll";
            if ( openFileDialog.ShowDialog()==true)
            {
                pathTb.Text = openFileDialog.FileName;
                if (string.IsNullOrWhiteSpace(pathTb.Text))
                {
                    MessageBox.Show("Error");
                    return;
                }

                goRefBt.IsEnabled = true;
                goBt.IsEnabled = true;

                Assembly asm = Assembly.LoadFrom(pathTb.Text);
                
                List<Type> types = asm.GetTypes().ToList();

                string info = $"В библиотеке {asm.FullName} следующие классы:" + "\n";

                int x = 1;
                foreach (Type t in types)
                {
                    info += x +". " +  t.Name + "\n";
                    x++;
                }
                infoLb.Content = info;
            }
        }

        private void goRefBt_Click(object sender, RoutedEventArgs e)
        {
            Assembly asm = Assembly.LoadFrom(pathTb.Text);
            List<Type> types = asm.GetTypes().ToList();
            Type pr = types[0];

            // создаем экземпляр класса Program
            object programObj = Activator.CreateInstance(pr);

            ConsoleHelper.AllocConsole();
            this.Close();
            MethodInfo method = pr.GetMethod("GetStart", BindingFlags.DeclaredOnly |
                BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Static);
            method.Invoke(programObj, null);
        }
    }
}
