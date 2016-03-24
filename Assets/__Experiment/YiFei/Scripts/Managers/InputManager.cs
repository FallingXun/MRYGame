using UnityEngine;
using System.Collections;

namespace MRYGame
{
    /// <summary>
    /// 实现各种输入输出控制器
    /// </summary>
    public class InputManager : Manager<InputManager>
    {
        public enum EInputType
        {
            None,
            Keyboard,
            Joystick,
            Touch
        }

        class InputState
        {
            public virtual void Move(float deltaTime) { }
            public virtual void Rotate(float deltaTime) { }
            public virtual void Skill() { }
            public virtual void SwitchItem() { }
            public virtual void UseItem() { }
            public virtual void Chat() { }
        }

        private static Hero character;
        private InputState currentInputState;
        private EInputType currentInputType = EInputType.None;
        private bool isLock;

        public override void Init()
        {
            Debug.Log("Initialize InputManager");
        }

        public override void Release()
        {
            Debug.Log("Release InputManager");
        }

        void Update()
        {
            float delta = Time.deltaTime;
            if (character != null && currentInputState != null)
            {
                if (!isLock)
                {
                    currentInputState.Move(delta);
                    currentInputState.Rotate(delta);
                    currentInputState.Skill();
                    currentInputState.SwitchItem();
                    currentInputState.UseItem();
                }
                // 聊天属于特殊操作
                currentInputState.Chat();
            }
        }

        public void SetInputState(Hero hero, EInputType type)
        {
            character = hero;
            if (currentInputType != type)
            {
                currentInputType = type;
                currentInputState = InputStateFactory.CreateInputState(type);
            }
        }

        public void LockInput()
        {
            isLock = true;
        }

        public void UnlockInput()
        {
            isLock = false;
        }

        class InputStateFactory
        {
            static public InputState CreateInputState(EInputType type)
            {
                switch (type)
                {
                    case EInputType.Keyboard:
                        return new KeyboardInputState();
                    case EInputType.Joystick:
                        return new JoystickInputState();
                    case EInputType.Touch:
                        return new TouchInputState();
                    default:
                        return new NullInputState();
                }
            }
        }

        #region 控制器组
        class NullInputState : InputState
        {
        }

        class KeyboardInputState : InputState
        {
            public override void Move(float deltaTime)
            {
                if (Input.GetKey(KeyCode.W))
                    character.transform.position += Vector3.up * character.walkSpeed * deltaTime;
                if (Input.GetKey(KeyCode.S))
                    character.transform.position += Vector3.down * character.walkSpeed * deltaTime;
                if (Input.GetKey(KeyCode.A))
                    character.transform.position += Vector3.left * character.walkSpeed * deltaTime;
                if (Input.GetKey(KeyCode.D))
                    character.transform.position += Vector3.right * character.walkSpeed * deltaTime;
            }

            public override void Rotate(float deltaTime)
            {
                if (Input.GetKey(KeyCode.L))
                {
                    character.transform.RotateAround(character.transform.position,
                        Vector3.back, character.spinSpeed * deltaTime);
                }
                if (Input.GetKey(KeyCode.J))
                {
                    character.transform.RotateAround(character.transform.position,
                        Vector3.forward, character.spinSpeed * deltaTime);
                }
            }

            public override void Skill()
            {
                if (Input.GetKeyDown(KeyCode.K))
                {
                    Debug.Log("Active some skill");
                }
            }

            public override void SwitchItem()
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Debug.Log("Switch left item");
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Switch right item");
                }
            }

            public override void UseItem()
            {
                if (Input.GetKeyDown(KeyCode.R))
                {
                    Debug.Log("Use some item");
                }
            }

            public override void Chat()
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    if (DialogManager.Instance.IsInitStory())
                    {
                        DialogManager.Instance.GotoNextSection();
                    }
                }
            }
        }

        class JoystickInputState : InputState
        {
        }

        class TouchInputState : InputState
        {
        }
        #endregion
    }
}
