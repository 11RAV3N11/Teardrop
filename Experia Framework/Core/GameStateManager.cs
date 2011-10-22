using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Experia.Framework;
using Experia.Framework.UI;

namespace Experia.Framework
{
    public class GameStateManager
    {
        public static GameStateManager Instance { get { return Experia.Framework.Generics.Singleton<GameStateManager>.Instance; } }
        protected GameState m_GameState;
        public GameState CurrentState
        {
            get
            {
                return m_GameState;
            }
        }
        protected GameStateManager()
        {
            m_GameState = GameState.InFullScreenMenu;
        }
        public void ChangeState(GameState state)
        {
            m_GameState = state;
        }
        public void ExitGame()
        {
            m_GameState = GameState.CallingExit;
        }
        public void Update(Game game)
        {
            switch (m_GameState)
            {
                case GameState.InFullScreenMenu:
                    MenuManager.Instance.Update();
                    break;
                case GameState.PlayingGame:
                    EntityManager.Instance.Update();
                    break;
                case GameState.CallingExit:
                    //Add in an Event for hooks [AP]
                    game.Exit();
                    break;
            }
        }
        public void Draw(GraphicsManager graphics)
        {
            switch (m_GameState)
            {
                case GameState.InFullScreenMenu:
                    MenuManager.Instance.Draw(graphics);
                    break;
                case GameState.PlayingGame:
                    EntityManager.Instance.Draw(graphics);
                    break;
            }
        }
    }
}
