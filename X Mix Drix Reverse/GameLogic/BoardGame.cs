namespace GameLogic
{
    public class BoardGame
    {
        private char[,] m_BoardGame;
        private int m_Width;
        private const char k_InitSymbol = ' ';

        public BoardGame()
        {
            m_BoardGame = null;
            m_Width = 0;
        }

        public BoardGame(int i_Length)
        {
            InitializedLengthOfBoardGame(i_Length);
        }

        public void InitializedLengthOfBoardGame(int i_Length)
        {
            m_BoardGame = new char[i_Length, i_Length];
            m_Width = (int)System.Math.Sqrt(m_BoardGame.Length);
            for (int i = 0; i < m_Width; i++)
            {
                for (int j = 0; j < m_Width; j++)
                {
                    m_BoardGame[i, j] = k_InitSymbol;
                }
            }
        }

        public void InitializedBoardGame()
        {
            for (int i = 0; i < m_Width; i++)
            {
                for (int j = 0; j < m_Width; j++)
                {
                    m_BoardGame[i, j] = k_InitSymbol;
                }
            }
        }

        public int Width
        {
            get
            {
                return m_Width;
            }
        }

        public char[,] Board
        {
            get
            {
                return m_BoardGame;
            }
        }

        public char InitSymbol
        {
            get
            {
                return k_InitSymbol;
            }
        }
    }
}