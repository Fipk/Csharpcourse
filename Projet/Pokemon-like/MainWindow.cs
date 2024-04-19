using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Pokemon_like
{
    public partial class MainWindow : Form
    {
        public GameInstance gameInstance;
        public MainWindow()
        {
            InitializeComponent();
            SetBtnBattle("Battle with a random pokemon");
            SetBtnMeetATrainer("Meet a trainer.");
            SetBtnPokemonCenter("Go to the Pokemon center");
            SetBtnShowItems("Show my items");
            SetBtnShowAllPokemons("Show all my pokemon");
            lbl_Enemy.Text = "What do you want to do ?";
            
            gameInstance = GameInstance.GetInstance();
            lbl_Player.Text = "You have " + gameInstance.GetPlayer().GetMoney() + " money";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gameInstance.isInCombat)
            {
                Pokemon pokemonPlayer = gameInstance.GetPlayer().GetTeam()[0];
                gameInstance.isInCombat = gameInstance.Attack(ref pokemonPlayer, ref gameInstance.encounteredPokemon, 10);
                lbl_Enemy.Text = "The pokemon encountered is " + gameInstance.encounteredPokemon.GetName() + " and it has " + gameInstance.encounteredPokemon.GetCurrentHealth() + " health left.";
                lbl_Player.Text = "My pokemon is " + gameInstance.GetPlayer().GetTeam()[0].GetName() + " and it has " + gameInstance.GetPlayer().GetTeam()[0].GetCurrentHealth() + " health left.";
                
            } else {
                gameInstance.encounteredPokemon = gameInstance.GenerateRandomPokemon();
                gameInstance.Battle();
                lbl_Enemy.Text = "The pokemon encountered is " + gameInstance.encounteredPokemon.GetName() + " and it has " + gameInstance.encounteredPokemon.GetCurrentHealth() + " health left.";
                lbl_Player.Text = "My pokemon is " + gameInstance.GetPlayer().GetTeam()[0].GetName() + " and it has " + gameInstance.GetPlayer().GetTeam()[0].GetCurrentHealth() + " health left.";
                
                SetButtonBattle();
            }

            if(!gameInstance.isInCombat)
            {
                SetButtonMenu();
                lbl_Enemy.Text = "What do you want to do ?";
                lbl_Player.Text = "You have " + gameInstance.GetPlayer().GetMoney()+ " money";
            }
            
        }
        private void btn_MeetAtrainer_Click(object sender, EventArgs e)
        {
            if (gameInstance.isInCombat)
            {
                gameInstance.isInCombat = gameInstance.GetPlayer().TryToFlee();
            } else
            {
                lbl_Enemy.Text = "You met a trainer";
            }

            if (!gameInstance.isInCombat)
            {
                SetButtonMenu();
                lbl_Enemy.Text = "What do you want to do ?";
                lbl_Player.Text = "You have " + gameInstance.GetPlayer().GetMoney() + " money";
            }
        }

        public void SetButtonMenu()
        {
            SetBtnBattle("Battle with a random pokemon");
            SetBtnMeetATrainer("Meet a trainer.");
            SetBtnPokemonCenter("Go to the Pokemon center");
            SetBtnShowItems("Show my items");
            SetBtnShowAllPokemons("Show all my pokemon");
            btn_Exchange.Visible = false;
        }

        public void SetButtonBattle()
        {
            SetBtnBattle("Attack");
            SetBtnMeetATrainer("Flee");
            SetBtnPokemonCenter("Catch");
            SetBtnShowItems("use 1 potion of healing");
            SetBtnShowAllPokemons("use 1 potion of damage");
            btn_Exchange.Visible = true;
            SetBtnExchange("Exchange your pokemon");
        }

        private void SetBtnExchange(string text)
        {
            btn_Exchange.Text = text;
        }

        public void TestFunction()
        {

        }

        public void SetBtnBattle(string text)
        {
            btn_Battle.Text = text;
        }
        public void SetBtnPokemonCenter(string text)
        {
            btn_PokemonCenter.Text = text;
        }
        public void SetBtnMeetATrainer(string text)
        {
            btn_MeetAtrainer.Text = text;
            
        }
        public void SetBtnShowAllPokemons(string text)
        {
            btn_ShowAllPokemons.Text = text;
        }
        public void SetBtnShowItems(string text)
        {
            btn_ShowItems.Text = text;
        }

    }
}
