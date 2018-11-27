using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_WinForm.Manager
{
    public partial class WorkerReport : Form
    {
        public WorkerReport()
        {
            InitializeComponent();
            this.radGridView1.Relations.AddSelfReference(this.radGridView1.MasterTemplate, "Id", "ParentId");
            this.radGridView1.DataSource = Requests.ReportsRequests.CreateWorkerReport();
            this.radGridView1.Columns["Id"].IsVisible = false;
            this.radGridView1.Columns["ParentId"].IsVisible = false;
        }
    }
}
