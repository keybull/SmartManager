using System;
using System.Collections.Generic;
using System.Linq;
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

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SmartManager
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int i = 0;
        public MainWindow()
        {
            InitializeComponent();
            FillDataGrid();
           
        }

        private void FillDataGrid()
        {
 
            
            //string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            //string CmdString = string.Empty;
            //using (SqlConnection con = new SqlConnection(ConString))
           // {
           //     CmdString = "SELECT Id, Stage, Task, Week FROM Tasks";
           //     SqlCommand cmd = new SqlCommand(CmdString, con);
            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
           //     DataTable dt = new DataTable("Tasks");
           //     sda.Fill(dt);
           //     grdEmployee.ItemsSource = dt.DefaultView;
           // }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

            SqlConnection sc = new SqlConnection(SmartManager.Properties.Settings.Default.TasksConnectionString);
            try
            {
                i++;
                string sql = "INSERT INTO Tasks (Id, Stage, Task, Week) VALUES ( '"+i+"', 'Stage"+ (i) +"', 'Task"+(i)+"', 'Week')";
                SqlCommand exeSql = new SqlCommand(sql, sc);
                sc.Open();
                exeSql.ExecuteNonQuery();
            }
            catch (Exception ex) { }
            finally { sc.Close(); }
        }

        private void Load_table_txt_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sc = new SqlConnection(SmartManager.Properties.Settings.Default.TasksConnectionString);

            try
            {
                sc.Open();
                string Query = "SELECT Id, Stage, Task, Week FROM Tasks";
                SqlCommand createCommand = new SqlCommand(Query, sc);
                createCommand.ExecuteNonQuery();

                SqlDataAdapter dataAdp = new SqlDataAdapter(createCommand);
                DataTable dt = new DataTable("Tasks");
                dataAdp.Fill(dt);
                grdTask.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);
            }
            catch (Exception ex) { }
            finally { sc.Close(); }
        }
    }
}
