using Client_WinForm.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client_WinForm.Worker
{
    public partial class ApplyToManager : Form
    {
        Models.Worker worker;
        public ApplyToManager(Models.Worker worker)
        {
            this.worker = worker;
            InitializeComponent();
        }

        private void btn_sendApply_Click(object sender, EventArgs e)
        {
           if( Requests.WorkerRequests.sendMessageToManager(worker.WorkerId, txt_message.Text,txt_subject.Text!="" ? txt_subject.Text : "No Subject"))
                MessageBox.Show("Sent successfuly");
            else MessageBox.Show("Did not succeed to send your message, try again.");
        }
    }
}
