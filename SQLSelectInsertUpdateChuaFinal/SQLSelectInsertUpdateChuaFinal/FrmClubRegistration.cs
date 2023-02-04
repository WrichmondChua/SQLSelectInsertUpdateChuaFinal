using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SQLSelectInsertUpdateChuaFinal
{
    public partial class FrmClubRegistration : Form
    {
        public FrmClubRegistration()
        {
            InitializeComponent();
            comboBoxGender.Items.Add("Male");
            comboBoxGender.Items.Add("Female");
            comboBoxProgram.Items.Add("BS in Information Management");
        }

        private void FrmClubRegistration_Load(object sender, EventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\ADMIN\\source\\repos\\SQLSelectInsertUpdateChuaFinal\\SQLSelectInsertUpdateChuaFinal\\Database1.mdf; Integrated Security = True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("Select * from ClubMembers", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            dataGridViewListOfClubMembers.DataSource = dataTable;
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\ADMIN\\source\\repos\\SQLSelectInsertUpdateChuaFinal\\SQLSelectInsertUpdateChuaFinal\\Database1.mdf; Integrated Security = True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into ClubMembers values (@ID, @StudentId, @FirstName,@MiddleName, @LastName, " +
                "@Age, @Gender, @Program where ID= @ID)", sqlConnection);

            sqlCommand = new SqlCommand("INSERT INTO ClubMembers VALUES (@ID, @StudentID, @FirstName, " +
                "@MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnection);

            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(textBoxID.Text);
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.Int).Value = int.Parse(textBoxStudentID.Text);
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = textBoxFirstName.Text;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value= textBoxMiddleName.Text;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = textBoxLastName.Text;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = int.Parse(textBoxAge.Text);
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = comboBoxGender.Text;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = comboBoxProgram.Text;

            if (sqlCommand.Connection.State==ConnectionState.Open)
            {
                sqlCommand.Connection.Close();
            }
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            MessageBox.Show("Successfully Registered.");

        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection("Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\ADMIN\\source\\repos\\SQLSelectInsertUpdateChuaFinal\\SQLSelectInsertUpdateChuaFinal\\Database1.mdf; Integrated Security = True");
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand("insert into ClubMembers values (@ID, @StudentId, @FirstName,@MiddleName, @LastName, " +
                "@Age, @Gender, @Program where ID= @ID)", sqlConnection);

            sqlCommand = new SqlCommand("INSERT INTO ClubMembers VALUES (@ID, @StudentID, @FirstName, " +
                "@MiddleName, @LastName, @Age, @Gender, @Program)", sqlConnection);

            sqlCommand.Parameters.Add("@ID", SqlDbType.Int).Value = int.Parse(textBoxID.Text);
            sqlCommand.Parameters.Add("@StudentID", SqlDbType.Int).Value = int.Parse(textBoxStudentID.Text);
            sqlCommand.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = textBoxFirstName.Text;
            sqlCommand.Parameters.Add("@MiddleName", SqlDbType.VarChar).Value = textBoxMiddleName.Text;
            sqlCommand.Parameters.Add("@LastName", SqlDbType.VarChar).Value = textBoxLastName.Text;
            sqlCommand.Parameters.Add("@Age", SqlDbType.Int).Value = int.Parse(textBoxAge.Text);
            sqlCommand.Parameters.Add("@Gender", SqlDbType.VarChar).Value = comboBoxGender.Text;
            sqlCommand.Parameters.Add("@Program", SqlDbType.VarChar).Value = comboBoxProgram.Text;

            if (sqlCommand.Connection.State == ConnectionState.Open)
            {
                sqlCommand.Connection.Close();
            }
            sqlConnection.Open();
            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            MessageBox.Show("Successfully Updated.");

        }
    }
    }

