namespace GameLogic
{
    public class Player
    {
        private int m_Score;
        private bool m_IsHuman;

        public Player()
        {
            m_Score = 0;
            m_IsHuman = true;
        }

        public Player(int i_Score, bool i_IsHuman)
        {
            m_Score = i_Score;
            m_IsHuman = i_IsHuman;
        }

        public int Score
        {
            get
            {
                return m_Score;
            }

            set
            {
                m_Score = value;
            }
        }

        public bool IsHuman
        {
            get
            {
                return m_IsHuman;
            }

            set
            {
                m_IsHuman = value;
            }
        }
    }
}