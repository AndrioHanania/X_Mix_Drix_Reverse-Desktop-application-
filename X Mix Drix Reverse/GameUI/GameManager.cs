using System.Windows.Forms;

namespace GameUI
{
    public class GameManager
    {
        private string m_NamePlayer1;
        private string m_NamePlayer2;
        private int m_BoardSize;
        private bool m_IsPlayer2Human;
        private bool m_IsUserClosed;


        public void Show()
        {
            FormGameSettings gameSettingsForm = new FormGameSettings();

            gameSettingsForm.NamePlayer1Chosen += OnNamePlayer1Chosen;
            gameSettingsForm.NamePlayer2Chosen += OnNamePlayer2Chosen;
            gameSettingsForm.BoardSizeChosen += OnBoardSizeChosen;
            gameSettingsForm.IsPlayer2HumanChosen += OnIsPlayer2HumanChosen;
            gameSettingsForm.FormClosed += OnGameSettingsFormClosed;
            gameSettingsForm.ShowDialog();
            if (!m_IsUserClosed)
            {
                FormTicTacToeMisere ticTacToeMisereForm = new FormTicTacToeMisere(
                m_NamePlayer1, m_NamePlayer2, m_BoardSize, m_IsPlayer2Human);
           
                ticTacToeMisereForm.ShowDialog();
            }
        }

        public void OnGameSettingsFormClosed(object sender, FormClosedEventArgs e)
        {
            FormGameSettings formGameSettings = (FormGameSettings)sender;

            if (e.CloseReason == CloseReason.UserClosing &&
                formGameSettings.ActiveControl.Name != "StartButton")
            {
                m_IsUserClosed = true;
            }
        }

        public void OnNamePlayer1Chosen(string i_NamePlayer1Chosen)
        { m_NamePlayer1 = i_NamePlayer1Chosen; }

        public void OnNamePlayer2Chosen(string i_NamePlayer2Chosen) 
        { m_NamePlayer2 = i_NamePlayer2Chosen; }

        public void OnBoardSizeChosen(int i_BoardSize)
        { m_BoardSize = i_BoardSize; }

        public void OnIsPlayer2HumanChosen(bool i_IsPlayer2Human) 
        { m_IsPlayer2Human = i_IsPlayer2Human; }
    }
}