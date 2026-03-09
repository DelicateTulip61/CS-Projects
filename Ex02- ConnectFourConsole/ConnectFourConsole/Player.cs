using System;

namespace Ex02
{
    internal class Player
    {
        private string m_Nickname;
        private int m_Points;
        private char m_Piece;
        private bool m_IsHuman;

        public Player(string i_Nickname, char i_Piece, bool i_IsHuman)
        {
            m_Nickname = i_Nickname;
            m_Piece = i_Piece;
            m_IsHuman = i_IsHuman;
            m_Points = 0;
        }
        public string Nickname
        {
            get 
            { 
                return m_Nickname; 
            }
            private set
            {
                m_Nickname = value;
            }
        }

        public int Points
        {
            get
            {
                return m_Points;
            }

            set
            {
                m_Points = value;
            }
        }

        public char Piece
        {
            get
            {
                return m_Piece;
            }
            private set
            {
                m_Piece = value;
            }
        }

        public bool IsHuman
        {
            get
            {
                return m_IsHuman;
            }
            private set
            {
                m_IsHuman = value;
            }
        }
    }
}
