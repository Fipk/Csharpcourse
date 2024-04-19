namespace Pokemon_like
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Battle = new System.Windows.Forms.Button();
            this.btn_MeetAtrainer = new System.Windows.Forms.Button();
            this.btn_PokemonCenter = new System.Windows.Forms.Button();
            this.btn_ShowItems = new System.Windows.Forms.Button();
            this.btn_ShowAllPokemons = new System.Windows.Forms.Button();
            this.lbl_Enemy = new System.Windows.Forms.Label();
            this.lbl_Player = new System.Windows.Forms.Label();
            this.btn_Exchange = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Battle
            // 
            this.btn_Battle.Location = new System.Drawing.Point(0, 49);
            this.btn_Battle.Name = "btn_Battle";
            this.btn_Battle.Size = new System.Drawing.Size(128, 35);
            this.btn_Battle.TabIndex = 0;
            this.btn_Battle.Text = "button1";
            this.btn_Battle.UseVisualStyleBackColor = true;
            this.btn_Battle.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_MeetAtrainer
            // 
            this.btn_MeetAtrainer.Location = new System.Drawing.Point(134, 49);
            this.btn_MeetAtrainer.Name = "btn_MeetAtrainer";
            this.btn_MeetAtrainer.Size = new System.Drawing.Size(132, 36);
            this.btn_MeetAtrainer.TabIndex = 1;
            this.btn_MeetAtrainer.Text = "button2";
            this.btn_MeetAtrainer.UseVisualStyleBackColor = true;
            this.btn_MeetAtrainer.Click += new System.EventHandler(this.btn_MeetAtrainer_Click);
            // 
            // btn_PokemonCenter
            // 
            this.btn_PokemonCenter.Location = new System.Drawing.Point(272, 53);
            this.btn_PokemonCenter.Name = "btn_PokemonCenter";
            this.btn_PokemonCenter.Size = new System.Drawing.Size(130, 33);
            this.btn_PokemonCenter.TabIndex = 2;
            this.btn_PokemonCenter.Text = "button3";
            this.btn_PokemonCenter.UseVisualStyleBackColor = true;
            // 
            // btn_ShowItems
            // 
            this.btn_ShowItems.Location = new System.Drawing.Point(408, 51);
            this.btn_ShowItems.Name = "btn_ShowItems";
            this.btn_ShowItems.Size = new System.Drawing.Size(129, 35);
            this.btn_ShowItems.TabIndex = 3;
            this.btn_ShowItems.Text = "button4";
            this.btn_ShowItems.UseVisualStyleBackColor = true;
            // 
            // btn_ShowAllPokemons
            // 
            this.btn_ShowAllPokemons.Location = new System.Drawing.Point(543, 50);
            this.btn_ShowAllPokemons.Name = "btn_ShowAllPokemons";
            this.btn_ShowAllPokemons.Size = new System.Drawing.Size(137, 35);
            this.btn_ShowAllPokemons.TabIndex = 4;
            this.btn_ShowAllPokemons.Text = "button5";
            this.btn_ShowAllPokemons.UseVisualStyleBackColor = true;
            // 
            // lbl_Enemy
            // 
            this.lbl_Enemy.AutoSize = true;
            this.lbl_Enemy.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Enemy.Location = new System.Drawing.Point(53, 133);
            this.lbl_Enemy.Name = "lbl_Enemy";
            this.lbl_Enemy.Size = new System.Drawing.Size(64, 25);
            this.lbl_Enemy.TabIndex = 5;
            this.lbl_Enemy.Text = "label1";
            // 
            // lbl_Player
            // 
            this.lbl_Player.AutoSize = true;
            this.lbl_Player.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Player.Location = new System.Drawing.Point(53, 172);
            this.lbl_Player.Name = "lbl_Player";
            this.lbl_Player.Size = new System.Drawing.Size(64, 25);
            this.lbl_Player.TabIndex = 6;
            this.lbl_Player.Text = "label2";
            // 
            // btn_Exchange
            // 
            this.btn_Exchange.Location = new System.Drawing.Point(685, 51);
            this.btn_Exchange.Name = "btn_Exchange";
            this.btn_Exchange.Size = new System.Drawing.Size(103, 35);
            this.btn_Exchange.TabIndex = 7;
            this.btn_Exchange.Text = "button5";
            this.btn_Exchange.UseVisualStyleBackColor = true;
            this.btn_Exchange.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Exchange);
            this.Controls.Add(this.lbl_Player);
            this.Controls.Add(this.lbl_Enemy);
            this.Controls.Add(this.btn_ShowAllPokemons);
            this.Controls.Add(this.btn_ShowItems);
            this.Controls.Add(this.btn_PokemonCenter);
            this.Controls.Add(this.btn_MeetAtrainer);
            this.Controls.Add(this.btn_Battle);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Battle;
        private System.Windows.Forms.Button btn_MeetAtrainer;
        private System.Windows.Forms.Button btn_PokemonCenter;
        private System.Windows.Forms.Button btn_ShowItems;
        private System.Windows.Forms.Button btn_ShowAllPokemons;
        private System.Windows.Forms.Label lbl_Enemy;
        private System.Windows.Forms.Label lbl_Player;
        private System.Windows.Forms.Button btn_Exchange;
    }
}