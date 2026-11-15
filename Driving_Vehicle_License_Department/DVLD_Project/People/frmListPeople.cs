using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusinessLayer;

namespace DVLD_Project.People
{
    public partial class frmListPeople : Form
    {
        private static DataTable _dtAllPeople = clsPerson.GetAllPeople();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                                        "FirstName", "SecondName", "ThirdName",
                                                                        "LastName", "Gender", "DateOfBirth", "CountryName",
                                                                        "Phone", "Email");
        public frmListPeople()
        {
            InitializeComponent();
        }
        private void frmListPeople_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            _RefreshPeopleList();
            _SetManagePeopleDesign();
            _ReadNumberOfPeople();
            pFilterBy.Visible = false;
            this.Width = 1265;
            this.Height = 620;
            this.CenterToScreen();
        }
        private void _RefreshPeopleList()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                                        "FirstName", "SecondName", "ThirdName",
                                                                        "LastName", "Gender", "DateOfBirth", "CountryName",
                                                                        "Phone", "Email");
            dgvPeople.DataSource = _dtPeople;
        }


        private void _SetManagePeopleDesign()
        {
            this.BackColor = Color.FromArgb(10, 20, 38);

            dgvPeople.BackgroundColor = Color.FromArgb(15, 29, 54);
            dgvPeople.BorderStyle = BorderStyle.None;
            dgvPeople.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPeople.GridColor = Color.FromArgb(35, 52, 78);

            dgvPeople.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPeople.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            dgvPeople.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPeople.MultiSelect = false;
            dgvPeople.ReadOnly = true;
            dgvPeople.RowHeadersVisible = false;
            dgvPeople.AllowUserToAddRows = false;
            dgvPeople.AllowUserToResizeRows = false;

            dgvPeople.EnableHeadersVisualStyles = false;
            dgvPeople.ColumnHeadersHeight = 42;
            dgvPeople.RowTemplate.Height = 38;

            dgvPeople.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(25, 45, 75);

            dgvPeople.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            dgvPeople.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI Semibold", 10, FontStyle.Bold);

            dgvPeople.ColumnHeadersDefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleCenter;

            dgvPeople.ColumnHeadersDefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            dgvPeople.ColumnHeadersDefaultCellStyle.Padding =
                new Padding(5, 0, 5, 0);

            dgvPeople.DefaultCellStyle.BackColor =
                Color.FromArgb(15, 29, 54);

            dgvPeople.DefaultCellStyle.ForeColor =
                Color.FromArgb(225, 233, 245);

            dgvPeople.DefaultCellStyle.Font =
                new Font("Segoe UI", 9.5f, FontStyle.Regular);

            dgvPeople.DefaultCellStyle.SelectionBackColor =
                Color.FromArgb(45, 90, 135);

            dgvPeople.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvPeople.DefaultCellStyle.Alignment =
                DataGridViewContentAlignment.MiddleLeft;

            dgvPeople.DefaultCellStyle.Padding =
                new Padding(7, 0, 7, 0);

            dgvPeople.DefaultCellStyle.WrapMode =
                DataGridViewTriState.False;

            dgvPeople.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(19, 36, 62);

            dgvPeople.AlternatingRowsDefaultCellStyle.ForeColor =
                Color.FromArgb(225, 233, 245);

            if (dgvPeople.Columns.Count == 11)
            {
                dgvPeople.Columns["PersonID"].HeaderText = "ID";
                dgvPeople.Columns["NationalNo"].HeaderText = "National ID";
                dgvPeople.Columns["FirstName"].HeaderText = "First Name";
                dgvPeople.Columns["SecondName"].HeaderText = "Second Name";
                dgvPeople.Columns["ThirdName"].HeaderText = "Third Name";
                dgvPeople.Columns["LastName"].HeaderText = "Last Name";
                dgvPeople.Columns["Gender"].HeaderText = "Gender";
                dgvPeople.Columns["DateOfBirth"].HeaderText = "Birth Date";
                dgvPeople.Columns["CountryName"].HeaderText = "Nationality";
                dgvPeople.Columns["Phone"].HeaderText = "Phone";
                dgvPeople.Columns["Email"].HeaderText = "Email";

                dgvPeople.Columns["PersonID"].FillWeight = 45;
                dgvPeople.Columns["NationalNo"].FillWeight = 85;
                dgvPeople.Columns["FirstName"].FillWeight = 85;
                dgvPeople.Columns["SecondName"].FillWeight = 85;
                dgvPeople.Columns["ThirdName"].FillWeight = 85;
                dgvPeople.Columns["LastName"].FillWeight = 85;
                dgvPeople.Columns["Gender"].FillWeight = 60;
                dgvPeople.Columns["DateOfBirth"].FillWeight = 90;
                dgvPeople.Columns["CountryName"].FillWeight = 85;
                dgvPeople.Columns["Phone"].FillWeight = 90;
                dgvPeople.Columns["Email"].FillWeight = 130;

                dgvPeople.Columns["PersonID"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvPeople.Columns["Gender"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvPeople.Columns["DateOfBirth"].DefaultCellStyle.Alignment =
                    DataGridViewContentAlignment.MiddleCenter;

                dgvPeople.Columns["DateOfBirth"].DefaultCellStyle.Format =
                    "dd/MM/yyyy";

                foreach (DataGridViewColumn column in dgvPeople.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _ReadNumberOfPeople()
        {
            lblRecords.Text = dgvPeople.Rows.Count.ToString(); 
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
            {
                pFilterBy.Visible = false;
                _RefreshPeopleList();
            }
            else
            {
                pFilterBy.Visible = true;
                
                switch (cbFilterBy.SelectedIndex)
                {
                    case 1:
                        txtSearchFilterBy.Text = "Search By Person ID....";
                        break;
                    case 2:
                        txtSearchFilterBy.Text = "Search By National No....";
                        break;
                    case 3:
                        txtSearchFilterBy.Text = "Search By First Name....";
                        break;
                    case 4:
                        txtSearchFilterBy.Text = "Search By Second Name....";
                        break;
                    case 5:
                        txtSearchFilterBy.Text = "Search By Third Name....";
                        break;
                    case 6:
                        txtSearchFilterBy.Text = "Search By Last Name....";
                        break;
                    case 7:
                        txtSearchFilterBy.Text = "Search By Nationality....";
                        break;
                    case 8:
                        txtSearchFilterBy.Text = "Search By Gender....";
                        break;
                    case 9:
                        txtSearchFilterBy.Text = "Search By Email....";
                        break;
                    case 10:
                        txtSearchFilterBy.Text = "Search By Phone....";
                        break;

                }
            }
        }

        private void txtSearchFilterBy_TextChanged(object sender, EventArgs e)
        {
            string filterColumn = "";

            switch (cbFilterBy.SelectedIndex)
            {
                case 1:
                    filterColumn = "PersonID";
                    break;
                case 2:
                    filterColumn = "NationalNo";
                    break;
                case 3:
                    filterColumn = "FirstName";
                    break;
                case 4:
                    filterColumn = "SecondName"; 
                    break;
                case 5:
                    filterColumn = "ThirdName"; 
                    break;
                case 6:
                    filterColumn = "LastName";
                    break;
                case 7:
                    filterColumn = "CountryName";
                    break;
                case 8:
                    filterColumn = "Gender";
                    break;
                case 9:
                    filterColumn = "Email";
                    break;
                case 10:
                    filterColumn = "Phone";
                    break;
                default:
                    filterColumn = "";
                    break;
            }
            if (string.IsNullOrEmpty(txtSearchFilterBy.Text.Trim()))
            {
                _dtPeople.DefaultView.RowFilter = "";
                _ReadNumberOfPeople();
                return;
            }
            if (filterColumn == "PersonID")
            {
                if (int.TryParse(txtSearchFilterBy.Text.Trim(), out int id))
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, id);
                else
                    _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = 0", filterColumn);
            }
            else
            {
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, txtSearchFilterBy.Text.Trim());
            }
            _ReadNumberOfPeople();
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
            _RefreshPeopleList();
            _ReadNumberOfPeople();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frmAddUpdatePerson.ShowDialog();

            _RefreshPeopleList();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete Person[" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshPeopleList();
                }
                else
                {
                    MessageBox.Show("Person was not deleted because it has data linked to it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
            frmShowPersonInfo frm = new frmShowPersonInfo(PersonID);
            frm.ShowDialog();
            _RefreshPeopleList();
        }

        private void addNewPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frmAddUpdatePerson = new frmAddUpdatePerson();
            frmAddUpdatePerson.ShowDialog();
            _RefreshPeopleList();
            _ReadNumberOfPeople();
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow != null)
            {
                string phone = dgvPeople.CurrentRow.Cells["Phone"].Value.ToString();

                if (!string.IsNullOrEmpty(phone))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = $"tel:{phone}",
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("This person does not have a phone number.", "No Phone", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow != null)
            {
                string email = dgvPeople.CurrentRow.Cells["Email"].Value.ToString();

                if (!string.IsNullOrEmpty(email))
                {
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = $"mailto:{email}",
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("This person does not have an email address.", "No Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtSearchFilterBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
