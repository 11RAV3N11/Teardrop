using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Experia.Framework.Controls
{
    public enum GamePadButton { A, B, Y, X, BigButton, LeftShoulder, RightShoulder, Back, Start }
    /// <summary>Holder of all of the Information for the GamePad</summary>
    public class GamePadExtension
    {
        /*### Controller Information ###*/
        public PlayerIndex MainPlayerGamePad { get { return this.m_MainGamepadIndex; } }
        protected Dictionary<PlayerIndex, GamePadState> m_CurrentState, m_PreviousState;
        protected Dictionary<PlayerIndex, Vector2> m_LeftStickVector, m_RightStickVector;
        protected PlayerIndex m_MainGamepadIndex;

        public void Initialize()
        {
            m_CurrentState = new Dictionary<PlayerIndex, GamePadState>(4);
            m_CurrentState.Add(PlayerIndex.One, GamePad.GetState(PlayerIndex.One));
            m_CurrentState.Add(PlayerIndex.Two, GamePad.GetState(PlayerIndex.Two));
            m_CurrentState.Add(PlayerIndex.Three, GamePad.GetState(PlayerIndex.Three));
            m_CurrentState.Add(PlayerIndex.Four, GamePad.GetState(PlayerIndex.Four));

            m_PreviousState = new Dictionary<PlayerIndex, GamePadState>(4);
            m_PreviousState.Add(PlayerIndex.One, GamePad.GetState(PlayerIndex.One));
            m_PreviousState.Add(PlayerIndex.Two, GamePad.GetState(PlayerIndex.Two));
            m_PreviousState.Add(PlayerIndex.Three, GamePad.GetState(PlayerIndex.Three));
            m_PreviousState.Add(PlayerIndex.Four, GamePad.GetState(PlayerIndex.Four));

            m_LeftStickVector = new Dictionary<PlayerIndex, Vector2>(4);

            m_RightStickVector = new Dictionary<PlayerIndex, Vector2>(4);
        }

        public void Update()
        {
            /*Update the Previous States*/
            m_PreviousState[PlayerIndex.One] = m_CurrentState[PlayerIndex.One];
            m_PreviousState[PlayerIndex.Two] = m_CurrentState[PlayerIndex.Two];
            m_PreviousState[PlayerIndex.Three] = m_CurrentState[PlayerIndex.Three];
            m_PreviousState[PlayerIndex.Four] = m_CurrentState[PlayerIndex.Four];

            /*Get the Current States*/
            m_CurrentState[PlayerIndex.One] = GamePad.GetState(PlayerIndex.One);
            m_CurrentState[PlayerIndex.Two] = GamePad.GetState(PlayerIndex.Two);
            m_CurrentState[PlayerIndex.Three] = GamePad.GetState(PlayerIndex.Three);
            m_CurrentState[PlayerIndex.Four] = GamePad.GetState(PlayerIndex.Four);

        }
        public void CheckForMainController(GamePadButton ButtonToProbeWith)
        {
            if (CheckButtonDown(ButtonToProbeWith, PlayerIndex.One))
                m_MainGamepadIndex = PlayerIndex.One;
            else if (CheckButtonDown(ButtonToProbeWith, PlayerIndex.Two))
                m_MainGamepadIndex = PlayerIndex.Two;
            else if (CheckButtonDown(ButtonToProbeWith, PlayerIndex.Three))
                m_MainGamepadIndex = PlayerIndex.Three;
            else if (CheckButtonDown(ButtonToProbeWith, PlayerIndex.Four))
                m_MainGamepadIndex = PlayerIndex.Four;
        }
        public bool CheckButtonDown(GamePadButton Button, PlayerIndex Index)
        {
            switch (Button)
            {
                case GamePadButton.A:
                    if (m_CurrentState[Index].Buttons.A == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.B:
                    if (m_CurrentState[Index].Buttons.B == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.X:
                    if (m_CurrentState[Index].Buttons.X == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.Y:
                    if (m_CurrentState[Index].Buttons.Y == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.BigButton:
                    if (m_CurrentState[Index].Buttons.BigButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.LeftShoulder:
                    if (m_CurrentState[Index].Buttons.LeftShoulder == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.RightShoulder:
                    if (m_CurrentState[Index].Buttons.RightShoulder == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.Start:
                    if (m_CurrentState[Index].Buttons.Start == ButtonState.Pressed)
                        return true;
                    else return false;
            }
            return false;
        }
        public bool CheckButtonPress(GamePadButton Button, PlayerIndex Index)
        {
            switch (Button)
            {
                case GamePadButton.A:
                    if (m_CurrentState[Index].Buttons.A == ButtonState.Pressed && m_PreviousState[Index].Buttons.A == ButtonState.Released)
                        return true;
                    else return false;
                case GamePadButton.B:
                    if (m_CurrentState[Index].Buttons.B == ButtonState.Pressed && m_PreviousState[Index].Buttons.B == ButtonState.Released)
                        return true;
                    else return false;
                case GamePadButton.X:
                    if (m_CurrentState[Index].Buttons.X == ButtonState.Pressed && m_PreviousState[Index].Buttons.X == ButtonState.Released)
                        return true;
                    else return false;
                case GamePadButton.Y:
                    if (m_CurrentState[Index].Buttons.Y == ButtonState.Pressed && m_PreviousState[Index].Buttons.Y == ButtonState.Released)
                        return true;
                    else return false;
                case GamePadButton.BigButton:
                    if (m_CurrentState[Index].Buttons.BigButton == ButtonState.Pressed && m_PreviousState[Index].Buttons.BigButton == ButtonState.Released)
                        return true;
                    else return false;
                case GamePadButton.LeftShoulder:
                    if (m_CurrentState[Index].Buttons.LeftShoulder == ButtonState.Pressed && m_PreviousState[Index].Buttons.LeftShoulder == ButtonState.Released)
                        return true;
                    else return false;
                case GamePadButton.RightShoulder:
                    if (m_CurrentState[Index].Buttons.RightShoulder == ButtonState.Pressed && m_PreviousState[Index].Buttons.RightShoulder == ButtonState.Released)
                        return true;
                    else return false;
                case GamePadButton.Start:
                    if (m_CurrentState[Index].Buttons.Start == ButtonState.Pressed && m_PreviousState[Index].Buttons.Start == ButtonState.Released)
                        return true;
                    else return false;
            }
            return false;
        }
        public bool CheckButtonRelease(GamePadButton Button, PlayerIndex Index)
        {
            switch (Button)
            {
                case GamePadButton.A:
                    if (m_CurrentState[Index].Buttons.A == ButtonState.Released && m_PreviousState[Index].Buttons.A == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.B:
                    if (m_CurrentState[Index].Buttons.B == ButtonState.Released && m_PreviousState[Index].Buttons.B == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.X:
                    if (m_CurrentState[Index].Buttons.X == ButtonState.Released && m_PreviousState[Index].Buttons.X == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.Y:
                    if (m_CurrentState[Index].Buttons.Y == ButtonState.Released && m_PreviousState[Index].Buttons.Y == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.BigButton:
                    if (m_CurrentState[Index].Buttons.BigButton == ButtonState.Released && m_PreviousState[Index].Buttons.BigButton == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.LeftShoulder:
                    if (m_CurrentState[Index].Buttons.LeftShoulder == ButtonState.Released && m_PreviousState[Index].Buttons.LeftShoulder == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.RightShoulder:
                    if (m_CurrentState[Index].Buttons.RightShoulder == ButtonState.Released && m_PreviousState[Index].Buttons.RightShoulder == ButtonState.Pressed)
                        return true;
                    else return false;
                case GamePadButton.Start:
                    if (m_CurrentState[Index].Buttons.Start == ButtonState.Released && m_PreviousState[Index].Buttons.Start == ButtonState.Pressed)
                        return true;
                    else return false;
            }
            return false;
        }
        public Vector2 GetLeftStick(PlayerIndex Index)
        {
            return m_CurrentState[Index].ThumbSticks.Left;
        }
        public Vector2 GetRightStick(PlayerIndex Index)
        {
            return m_CurrentState[Index].ThumbSticks.Right;
        }
        public Vector2 GetPreviousLeftStick(PlayerIndex Index)
        {
            return m_PreviousState[Index].ThumbSticks.Left;
        }
        public Vector2 GetPreviousRightStick(PlayerIndex Index)
        {
            return m_PreviousState[Index].ThumbSticks.Right;
        }
    }
}
