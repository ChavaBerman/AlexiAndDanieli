using memoryGame.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memoryGame
{
    public partial class StartGame : Form
    {
        User partner;
        public StartGame(User partner)
        {
            InitializeComponent();
            this.partner = partner;
            lbl_name.Text = partner.UserName;
            lbl_age.Text = partner.Age.ToString();
        }

        private void btn_startGame_Click(object sender, EventArgs e)
        {
            Game game = new Game(GlobalProp.CurrentUser.UserName,partner.UserName);
            game.Show();
            Close();
        }

        private void StartGame_Load(object sender, EventArgs e)
        {

        }
    }
}
