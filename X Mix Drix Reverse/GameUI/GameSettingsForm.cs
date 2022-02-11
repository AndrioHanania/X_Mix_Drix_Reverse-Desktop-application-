using System;
using System.Windows.Forms;
using Application = GameLogic.Application;

namespace GameUI
{
    public delegate void NamePlayer1Chosen(string i_NamePlayer1Chosen);
    public delegate void NamePlayer2Chosen(string i_NamePlayer2Chosen);
    public delegate void BoardSizeChosen(int i_BoardSize);
    public delegate void IsPlayer2Human(bool i_IsPlayer2Human);

    public class FormGameSettings : Form
    {
        private readonly string r_MyTitle = "Game Settings";

        private Label m_LabelPlayers;
        private Label m_LabelPlayer1;
        private Label m_LabelPlayer2;
        private Label m_LabelRows;
        private Label m_LabelCols;
        private Label m_LabelBoardSize;
        private Button m_ButtonStart;
        private NumericUpDown m_NumericUpDownRows;
        private NumericUpDown m_NumericUpDownCols;
        private CheckBox m_CheckBoxPlayer2Status;
        private TextBox m_TextBoxNamePlayer1;
        private TextBox m_TextBoxNamePlayer2;

        public event NamePlayer1Chosen NamePlayer1Chosen;
        public event NamePlayer2Chosen NamePlayer2Chosen;
        public event BoardSizeChosen BoardSizeChosen;
        public event IsPlayer2Human IsPlayer2HumanChosen;

        public FormGameSettings()
        {
            initializeComponent();
        }


        private void initializeComponent()
        {
            this.m_LabelPlayers = new Label();
            this.m_LabelPlayer1 = new Label();
            this.m_LabelPlayer2 = new Label();
            this.m_CheckBoxPlayer2Status = new CheckBox();
            this.m_TextBoxNamePlayer1 = new TextBox();
            this.m_TextBoxNamePlayer2 = new TextBox();
            this.m_LabelBoardSize = new Label();
            this.m_LabelRows = new Label();
            this.m_LabelCols = new Label();
            this.m_NumericUpDownRows = new NumericUpDown();
            this.m_NumericUpDownCols = new NumericUpDown();
            this.m_ButtonStart = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownCols)).BeginInit();
            this.SuspendLayout();
            // 
            // m_LabelPlayers
            // 
            this.m_LabelPlayers.AutoSize = true;
            this.m_LabelPlayers.Location = new System.Drawing.Point(28, 32);
            this.m_LabelPlayers.Name = "PlayersLabel";
            this.m_LabelPlayers.Size = new System.Drawing.Size(59, 17);
            this.m_LabelPlayers.TabIndex = 0;
            this.m_LabelPlayers.Text = "Players:";
            // 
            // m_LabelPlayer1
            // 
            this.m_LabelPlayer1.AutoSize = true;
            this.m_LabelPlayer1.Location = new System.Drawing.Point(31, 74);
            this.m_LabelPlayer1.Name = "Player1Label";
            this.m_LabelPlayer1.Size = new System.Drawing.Size(60, 17);
            this.m_LabelPlayer1.TabIndex = 1;
            this.m_LabelPlayer1.Text = "Player1:";
            // 
            // m_Player2Label
            // 
            this.m_LabelPlayer2.AutoSize = true;
            this.m_LabelPlayer2.Location = new System.Drawing.Point(34, 124);
            this.m_LabelPlayer2.Name = "Player2Label";
            this.m_LabelPlayer2.Size = new System.Drawing.Size(60, 17);
            this.m_LabelPlayer2.TabIndex = 2;
            this.m_LabelPlayer2.Text = "Player2:";
            // 
            // m_Player2StatusCheckBox
            // 
            this.m_CheckBoxPlayer2Status.AutoSize = true;
            this.m_CheckBoxPlayer2Status.Location = new System.Drawing.Point(10, 124);
            this.m_CheckBoxPlayer2Status.Name = "Player2StatusCheckBox";
            this.m_CheckBoxPlayer2Status.Size = new System.Drawing.Size(18, 17);
            this.m_CheckBoxPlayer2Status.TabIndex = 3;
            this.m_CheckBoxPlayer2Status.UseVisualStyleBackColor = true;
            this.m_CheckBoxPlayer2Status.CheckedChanged += new EventHandler(this.player2StatusCheckBox_CheckedChanged);
            // 
            // m_NamePlayer1TextBox
            // 
            this.m_TextBoxNamePlayer1.Location = new System.Drawing.Point(135, 74);
            this.m_TextBoxNamePlayer1.Name = "NamePlayer1TextBox";
            this.m_TextBoxNamePlayer1.Size = new System.Drawing.Size(100, 22);
            this.m_TextBoxNamePlayer1.TabIndex = 4;
            // 
            // m_NamePlayer2TextBox
            // 
            this.m_TextBoxNamePlayer2.Enabled = false;
            this.m_TextBoxNamePlayer2.Location = new System.Drawing.Point(135, 118);
            this.m_TextBoxNamePlayer2.Name = "NamePlayer2TextBox";
            this.m_TextBoxNamePlayer2.Size = new System.Drawing.Size(100, 22);
            this.m_TextBoxNamePlayer2.TabIndex = 5;
            this.m_TextBoxNamePlayer2.Text = "[Computer]";
            // 
            // m_BoardSizeLabel
            // 
            this.m_LabelBoardSize.AutoSize = true;
            this.m_LabelBoardSize.Location = new System.Drawing.Point(12, 200);
            this.m_LabelBoardSize.Name = "BoardSizeLabel";
            this.m_LabelBoardSize.Size = new System.Drawing.Size(77, 17);
            this.m_LabelBoardSize.TabIndex = 6;
            this.m_LabelBoardSize.Text = "BoardSize:";
            // 
            // m_RowsLabel
            // 
            this.m_LabelRows.AutoSize = true;
            this.m_LabelRows.Location = new System.Drawing.Point(22, 243);
            this.m_LabelRows.Name = "RowsLabel";
            this.m_LabelRows.Size = new System.Drawing.Size(46, 17);
            this.m_LabelRows.TabIndex = 7;
            this.m_LabelRows.Text = "Rows:";
            // 
            // m_ColsLabel
            // 
            this.m_LabelCols.AutoSize = true;
            this.m_LabelCols.Location = new System.Drawing.Point(171, 243);
            this.m_LabelCols.Name = "ColsLabel";
            this.m_LabelCols.Size = new System.Drawing.Size(39, 17);
            this.m_LabelCols.TabIndex = 8;
            this.m_LabelCols.Text = "Cols:";
            // 
            // m_NumericRows
            // 
            this.m_NumericUpDownRows.Location = new System.Drawing.Point(92, 243);
            this.m_NumericUpDownRows.Maximum = Application.MaxSizeBoardGame;
            this.m_NumericUpDownRows.Minimum = Application.MinSizeBoardGame;
            this.m_NumericUpDownRows.Name = "NumericRows";
            this.m_NumericUpDownRows.Size = new System.Drawing.Size(46, 22);
            this.m_NumericUpDownRows.TabIndex = 9;
            this.m_NumericUpDownRows.Value = Application.MinSizeBoardGame;
            this.m_NumericUpDownRows.ValueChanged += new EventHandler(this.numericRows_ValueChanged);
            // 
            // m_NumericCols
            // 
            
            this.m_NumericUpDownCols.Location = new System.Drawing.Point(216, 243);
            this.m_NumericUpDownCols.Maximum = Application.MaxSizeBoardGame;
            this.m_NumericUpDownCols.Minimum = Application.MinSizeBoardGame;
            this.m_NumericUpDownCols.Name = "NumericCols";
            this.m_NumericUpDownCols.Size = new System.Drawing.Size(46, 22);
            this.m_NumericUpDownCols.TabIndex = 10;
            this.m_NumericUpDownCols.Value = Application.MinSizeBoardGame;
            this.m_NumericUpDownCols.ValueChanged += new EventHandler(this.numericCols_ValueChanged);
            // 
            // m_StartButton
            // 
            this.m_ButtonStart.Location = new System.Drawing.Point(25, 302);
            this.m_ButtonStart.Name = "StartButton";
            this.m_ButtonStart.Size = new System.Drawing.Size(237, 32);
            this.m_ButtonStart.TabIndex = 11;
            this.m_ButtonStart.Text = "Start!";
            this.m_ButtonStart.UseVisualStyleBackColor = true;
            this.m_ButtonStart.Click += new EventHandler(this.startButton_Click);
            // 
            // GameSettingsForm
            // 
            this.ShowIcon = false;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = SizeGripStyle.Hide;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ClientSize = new System.Drawing.Size(287, 351);
            this.Controls.Add(this.m_ButtonStart);
            this.Controls.Add(this.m_NumericUpDownCols);
            this.Controls.Add(this.m_NumericUpDownRows);
            this.Controls.Add(this.m_LabelCols);
            this.Controls.Add(this.m_LabelRows);
            this.Controls.Add(this.m_LabelBoardSize);
            this.Controls.Add(this.m_TextBoxNamePlayer2);
            this.Controls.Add(this.m_TextBoxNamePlayer1);
            this.Controls.Add(this.m_CheckBoxPlayer2Status);
            this.Controls.Add(this.m_LabelPlayer2);
            this.Controls.Add(this.m_LabelPlayer1);
            this.Controls.Add(this.m_LabelPlayers);
            this.Name = r_MyTitle;
            this.Text = r_MyTitle;
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_NumericUpDownCols)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void player2StatusCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;

            if(checkBox.Checked)
            {
                m_TextBoxNamePlayer2.Enabled = true;
                m_TextBoxNamePlayer2.Text = string.Empty;
            }
            else
            {
                m_TextBoxNamePlayer2.Enabled = false;
                m_TextBoxNamePlayer2.Text = "[Computer]";
            }
        }

        private void numericRows_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            m_NumericUpDownCols.Value = numericUpDown.Value;
        }

        private void numericCols_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;

            m_NumericUpDownRows.Value = numericUpDown.Value;
        }

        protected virtual void startButton_Click(object sender, EventArgs e)
        {
            this.Close();
            NamePlayer1Chosen?.Invoke(m_TextBoxNamePlayer1.Text);
            NamePlayer2Chosen?.Invoke(m_TextBoxNamePlayer2.Text);
            BoardSizeChosen?.Invoke((int)m_NumericUpDownRows.Value);
            IsPlayer2HumanChosen?.Invoke(m_CheckBoxPlayer2Status.Checked);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormGameSettings
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "FormGameSettings";
            this.Load += new System.EventHandler(this.FormGameSettings_Load);
            this.ResumeLayout(false);

        }

        private void FormGameSettings_Load(object sender, EventArgs e)
        {

        }
    }
}