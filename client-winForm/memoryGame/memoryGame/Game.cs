using memoryGame.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memoryGame
{
    public partial class Game : Form
    {
        string currentTurn;
        Dictionary<string, string> CardsDictionary;
        string currentPlayer;
        string partnerPlayer;
        private static Random rng = new Random();
        private int counterClick = 0;
        private string firstCardValue;
        List<string> allCards = new List<string>();

        public Game(string player1, string player2)
        {
            InitializeComponent();
            currentPlayer = player1;
            partnerPlayer = player2;
            GlobalProp.CurrentUser.PartnerUserName = partnerPlayer;
            lbl_player_name.Text = player1;
            lbl_partner_name_2.Text = player2;
            lbl_my_sets.Text = "0";
            lbl_partner_sets.Text = "0";

            GetCardsAndCurrentTurn();

            allCards.AddRange(CardsDictionary.Keys);
            allCards.AddRange(CardsDictionary.Keys);
            MixList();
            showCards();

        }

        private void showCards()
        {
            lbl_my_sets.Text = CardsDictionary.Values.Count(p => p == GlobalProp.CurrentUser.UserName).ToString();
            lbl_partner_sets.Text = CardsDictionary.Values.Count(p => p == GlobalProp.CurrentUser.PartnerUserName).ToString();
            int indexForBtn = 1;
            foreach (string item in allCards)
            {


                Button btn = (tableLayoutPanel1.Controls["b" + indexForBtn++] as Button);
                if (CardsDictionary[item] != null)
                {
                    btn.Text = item;
                    if (CardsDictionary[item] == currentPlayer)
                    {
                        btn.BackColor = Color.Red;
               
                    }
                    else
                    {
                        btn.BackColor = Color.Green;
              
                    }
                }
                //======================
                else btn.Text = item;




            }
        }

        public void GetCardsAndCurrentTurn()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(@"http://localhost:57034/");
            // Add an Accept header for JSON format.  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // List all Names.  
            HttpResponseMessage response = client.GetAsync($"GetAllCards/{GlobalProp.CurrentUser.UserName}").Result;  // Blocking call!  
            if (response.IsSuccessStatusCode)
            {

                var CardsJson = response.Content.ReadAsStringAsync().Result;

                dynamic obj = JsonConvert.DeserializeObject(CardsJson);

                CardsDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(JsonConvert.SerializeObject(obj["cards"]));
                currentTurn = JsonConvert.SerializeObject(obj["currentTurn"]);
                currentTurn = currentTurn.Trim(new Char[] { '\"' });
                showCards();
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetCardsAndCurrentTurn();
            if (currentTurn == currentPlayer)
            {
                lbl_player_name.Text = currentPlayer;
                foreach (Control item in tableLayoutPanel1.Controls)
                {
                    item.Enabled = true;
                }
            }
            else
            {
                lbl_player_name.Text = partnerPlayer;
                foreach (Control item in tableLayoutPanel1.Controls)
                {
                    item.Enabled = false;
                }

            }

        }
        public void MixList()
        {

            int n = allCards.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = allCards[k];
                allCards[k] = allCards[n];
                allCards[n] = value;
            }
        }


        private void ClickCard(object sender, EventArgs e)
        {
            counterClick++;

            (sender as Button).Text = allCards[int.Parse((sender as Button).Name.Remove(0, 1)) - 1];
            if (counterClick == 2)
            {
                Thread.Sleep(2000);
                sendCards(firstCardValue, allCards[int.Parse((sender as Button).Name.Remove(0, 1)) - 1]);

                showCards();
                counterClick = 0;
            }
            else firstCardValue = allCards[int.Parse((sender as Button).Name.Remove(0, 1)) - 1];

        }

        private void sendCards(string firstCardValue, string secondCardValue)
        {
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($@"http://localhost:57034/ChooseTwoCards/{currentPlayer}");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {

                string[] cards = new string[] { firstCardValue, secondCardValue };
                dynamic cardsArray = cards;
                string credentialString = Newtonsoft.Json.JsonConvert.SerializeObject(cardsArray, Formatting.None);

                streamWriter.Write(credentialString);
                streamWriter.Flush();
                streamWriter.Close();


            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new System.IO.StreamReader(httpResponse.GetResponseStream(), ASCIIEncoding.ASCII))
            {
                string result = streamReader.ReadToEnd();
                if (!result.Contains("continue"))
                {
                    MessageBox.Show($"{result} won the game!!!");
                }
              

            }


        }
    }
}
