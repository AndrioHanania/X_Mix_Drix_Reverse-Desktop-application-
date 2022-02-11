using System;
using System.Drawing;

namespace GameLogic
{
    public delegate void BoardGameChange(int row, int column, char symbol, bool isEnable);
    public delegate void GameEnd();
    public delegate void ScorePlayersChange();

    public class Application
    {
        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private readonly BoardGame r_BoardGame;
        private readonly Random r_Random;

        private bool m_IsFinish;
        private const char k_SymbolPlayer1 = 'x';
        private const char k_SymbolPlayer2 = 'o';
        private int m_NumberOfRounds;
        private int m_WinnerRoundPlayer;
        private const int k_MinSizeBoardGame = 3;
        private const int k_MaxSizeBoardGame = 9;
        private bool m_CurrentPlayer;
        private Point m_CurrentCoordinate;

        public event BoardGameChange BoardGameChange;
        public event GameEnd GameEnd;
        public event ScorePlayersChange ScorePlayersChange;
        public Application(int i_BoardSize)
        {
            r_Player1 = new Player();
            r_Player2 = new Player();
            r_BoardGame = new BoardGame(i_BoardSize);
            r_Random = new Random();
            m_IsFinish = false;
            m_NumberOfRounds = 0;
            m_WinnerRoundPlayer = 0;
        }

        public void OnCoordinateToBoardGameForHumanPlayerChosen(Point i_Coordinate)
        {
            m_CurrentCoordinate = i_Coordinate;
        }

        public void RunGame()
        {
            while(!isFinishAndUpdateScore())
            {
                RunMove();
            }
        }

        public void RunMove()
        { 
            if(!isFinishAndUpdateScore())
            {
                m_CurrentPlayer = (m_NumberOfRounds + 1) % 2 != 0;
                int row, column;

                if (m_CurrentPlayer ? r_Player1.IsHuman : r_Player2.IsHuman)
                {
                    row = m_CurrentCoordinate.X;
                    column = m_CurrentCoordinate.Y;
                }
                else
                {
                    getCoordinateToBoardGameForComputerPlayer(out row,
                        out column);
                }

                r_BoardGame.Board[--row, --column] = m_CurrentPlayer ?
                                                         k_SymbolPlayer1 : k_SymbolPlayer2;
                OnBoardGameChange(row, column, m_CurrentPlayer ?
                                                   k_SymbolPlayer1 : k_SymbolPlayer2, false);
                m_NumberOfRounds++;
                m_CurrentPlayer = (m_NumberOfRounds + 1) % 2 != 0;
                isFinishAndUpdateScore();
            }
        }

        protected virtual void OnBoardGameChange(int i_Row, int i_Column, char symbol, bool i_IsEnable)
        {
            BoardGameChange?.Invoke(i_Row, i_Column, symbol, i_IsEnable);
        }

        private void checkForRowWinning(ref bool io_IsFinish,
                                        ref char io_SymbolPlayer)
        {
            if (io_IsFinish)
            {
                return;
            }

            for (int i = 0; i < r_BoardGame.Width; i++)
            {
                for (int j = 0; j < r_BoardGame.Width; j++)
                {
                    if (r_BoardGame.Board[i, j] == r_BoardGame.InitSymbol)
                    {
                        break;
                    }

                    io_SymbolPlayer = j == 0 ?
                             r_BoardGame.Board[i, j] : io_SymbolPlayer;

                    if (j != 0 && r_BoardGame.Board[i, j] !=
                       io_SymbolPlayer)
                    {
                        break;
                    }

                    if (j == r_BoardGame.Width - 1)
                    {
                        io_IsFinish = !io_IsFinish;
                        if (io_IsFinish)
                        {
                            i = r_BoardGame.Width;
                            break;
                        }
                    }
                }
            }
        }

        private void checkForColumnWinning(ref bool io_IsFinish,
                                           ref char io_SymbolPlayer)
        {
            if (io_IsFinish)
            {
                return;
            }

            for (int i = 0; i < r_BoardGame.Width; i++)
            {
                for (int j = 0; j < r_BoardGame.Width; j++)
                {
                    if (r_BoardGame.Board[j, i] == r_BoardGame.InitSymbol)
                    {
                        break;
                    }

                    io_SymbolPlayer = j == 0 ?
                              r_BoardGame.Board[j, i] : io_SymbolPlayer;

                    if (j != 0 && r_BoardGame.Board[j, i] !=
                       io_SymbolPlayer)
                    {
                        break;
                    }

                    if (j == r_BoardGame.Width - 1)
                    {
                        io_IsFinish = !io_IsFinish;
                        if (io_IsFinish)
                        {
                            i = r_BoardGame.Width;
                            break;
                        }
                    }
                }
            }
        }

        private void checkForPrimaryDiagonalWinning(ref bool io_IsFinish,
                                 ref char io_SymbolPlayer)
        {
            if (io_IsFinish)
            {
                return;
            }

            io_SymbolPlayer = r_BoardGame.Board[0, 0];
            if (io_SymbolPlayer != r_BoardGame.InitSymbol)
            {
                for (int i = 1; i < r_BoardGame.Width; i++)
                {
                    if (r_BoardGame.Board[i, i] == r_BoardGame.InitSymbol)
                    {
                        break;
                    }

                    if (r_BoardGame.Board[i, i] != io_SymbolPlayer)
                    {
                        break;
                    }

                    io_IsFinish = i == r_BoardGame.Width - 1 ?
                                      !io_IsFinish : io_IsFinish;
                }
            }
        }

        private void checkForSecondaryDiagonalWinning(ref bool io_IsFinish,
                                     ref char io_SymbolPlayer)
        {
            if (io_IsFinish)
            {
                return;
            }

            io_SymbolPlayer = r_BoardGame.Board[0, r_BoardGame.Width - 1];
            if (io_SymbolPlayer != r_BoardGame.InitSymbol)
            {
                for (int i = 1; i < r_BoardGame.Width; i++)
                {
                    if (r_BoardGame.Board[i, r_BoardGame.Width - 1 - i] ==
                       r_BoardGame.InitSymbol)
                    {
                        break;
                    }

                    if (r_BoardGame.Board[i, r_BoardGame.Width - 1 - i] !=
                       io_SymbolPlayer)
                    {
                        break;
                    }

                    io_IsFinish = i == r_BoardGame.Width - 1 ?
                                      !io_IsFinish : io_IsFinish;
                }
            }
        }

        private void checkForDraw(ref bool io_IsFinish,
                                  ref char io_SymbolPlayer)
        {
            if (io_IsFinish)
            {
                return;
            }

            if (m_NumberOfRounds == r_BoardGame.Board.Length)
            {
                io_IsFinish = !io_IsFinish;
                io_SymbolPlayer = new char();
            }
        }

        private void isFinish(ref bool io_IsFinish,
                              ref char io_SymbolPlayer)
        {
            if (m_NumberOfRounds >= r_BoardGame.Width * 2 - 1)
            {
                checkForRowWinning(ref io_IsFinish, ref io_SymbolPlayer);
                checkForColumnWinning(ref io_IsFinish, ref io_SymbolPlayer);
                checkForPrimaryDiagonalWinning(ref io_IsFinish,
                    ref io_SymbolPlayer);
                checkForSecondaryDiagonalWinning(ref io_IsFinish,
                    ref io_SymbolPlayer);
                checkForDraw(ref io_IsFinish, ref io_SymbolPlayer);

            }
        }

        private bool isFinishAndUpdateScore()
        {
            bool isFinishFlag = false;
            char symbolPlayer = new char();

            isFinish(ref isFinishFlag, ref symbolPlayer);
            if (isFinishFlag)
            {
                updateScore(symbolPlayer);
                OnGameEnd();
            }

            m_IsFinish = isFinishFlag;

            return isFinishFlag;
        }

        protected virtual void OnGameEnd()
        {
            GameEnd?.Invoke();
        }

        protected virtual void OnScorePlayersChange()
        {
            ScorePlayersChange?.Invoke();
        }

        private void updateScore(char i_SymbolWinner)
        {
            if (i_SymbolWinner == k_SymbolPlayer1)
            {
                r_Player2.Score++;
                OnScorePlayersChange();
                m_WinnerRoundPlayer = 2;
            }
            else if (i_SymbolWinner == k_SymbolPlayer2)
            {
                r_Player1.Score++;
                OnScorePlayersChange();
                m_WinnerRoundPlayer = 1;
            }
            else
            {
                m_WinnerRoundPlayer = 0;
            }
        }

        public void RunNewGame()
        {
            int sizeBoardGame = r_BoardGame.Width;

            r_BoardGame.InitializedBoardGame();
            for (int i = 0; i < sizeBoardGame; i++)
            {
                for(int j = 0; j < sizeBoardGame; j++)
                {
                    OnBoardGameChange(i, j, r_BoardGame.InitSymbol, true);
                }
            }

            m_IsFinish = !m_IsFinish;
            m_NumberOfRounds = 0;
            m_WinnerRoundPlayer = 0;
        }

        private void getCoordinateToBoardGameForComputerPlayer(
            out int o_Row, out int o_Column)
        {
            o_Row = 0;
            o_Column = 0;
            do
            {
                o_Row = r_Random.Next(1, r_BoardGame.Width + 1);
                o_Column = r_Random.Next(1, r_BoardGame.Width + 1);
            }
            while (o_Row < 1 || o_Row > r_BoardGame.Width || o_Column < 1 ||
                  o_Column > r_BoardGame.Width ||
                  r_BoardGame.Board[o_Row - 1, o_Column - 1] !=
                  r_BoardGame.InitSymbol);
        }

        public void QuitMove(bool i_CurrentPlayer)
        {
            m_WinnerRoundPlayer = i_CurrentPlayer ? 2 : 1;
            Player1.Score = i_CurrentPlayer ?
                                Player1.Score : ++Player1.Score;
            Player2.Score = i_CurrentPlayer ?
                                ++Player2.Score : Player2.Score;
        }

        public Player Player1
        {
            get
            {
                return r_Player1;
            }
        }

        public Player Player2
        {
            get
            {
                return r_Player2;
            }
        }

        public int WinnerRoundPlayer
        {
            get
            {
                return m_WinnerRoundPlayer;
            }
        }

        public BoardGame BoardGame
        {
            get
            {
                return r_BoardGame;
            }
        }

        public static int MinSizeBoardGame
        {
            get
            {
                return k_MinSizeBoardGame;
            }
        }

        public static int MaxSizeBoardGame
        {
            get
            {
                return k_MaxSizeBoardGame;
            }
        }

        public bool IsFinish
        {
            get
            {
                return m_IsFinish;
            }
        }

        public int CurrentPlayer
        {
            get
            {
                if(m_CurrentPlayer)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }
    }
}