// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/PlayerInputs.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputs : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""16863d5b-4361-4377-92c6-576bf97a0f5a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""45f220a6-1c47-4e75-b14c-af778d9fad75"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""XPunch"",
                    ""type"": ""Button"",
                    ""id"": ""3e554dae-d3af-4b89-96da-1edbe73dd3a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""YPunch"",
                    ""type"": ""Button"",
                    ""id"": ""b56f7a01-c0fd-4639-ae4e-a0840ac1bc54"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BPunch"",
                    ""type"": ""Button"",
                    ""id"": ""b829c1ce-f0df-4f32-9c19-455376c33a14"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JumpKick"",
                    ""type"": ""Button"",
                    ""id"": ""ea59e7d3-3023-477c-8868-5c5f1ced2932"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Gamepad Left Stick"",
                    ""id"": ""1b1a694f-8b46-4063-8456-51d894977269"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2394ec29-1433-49af-92fb-4efbdc98d3df"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d8bc2f9b-295a-404e-b59c-25c67fe9523a"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""66495205-288c-45ff-8706-795f0b2c4d2c"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""fef17640-524f-411c-8572-60b027ac5651"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""acf8998b-a782-4ecb-b237-118c7280aed9"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""XPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0b79224f-50e0-4e8d-aea8-aa51da7f8475"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""YPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""370920fd-af8b-486d-a82f-2e0c4dc271ba"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""BPunch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aedce30b-890a-4f5d-8b3e-3fbbdd968a7e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""JumpKick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        },
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_XPunch = m_Player.FindAction("XPunch", throwIfNotFound: true);
        m_Player_YPunch = m_Player.FindAction("YPunch", throwIfNotFound: true);
        m_Player_BPunch = m_Player.FindAction("BPunch", throwIfNotFound: true);
        m_Player_JumpKick = m_Player.FindAction("JumpKick", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_XPunch;
    private readonly InputAction m_Player_YPunch;
    private readonly InputAction m_Player_BPunch;
    private readonly InputAction m_Player_JumpKick;
    public struct PlayerActions
    {
        private @PlayerInputs m_Wrapper;
        public PlayerActions(@PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @XPunch => m_Wrapper.m_Player_XPunch;
        public InputAction @YPunch => m_Wrapper.m_Player_YPunch;
        public InputAction @BPunch => m_Wrapper.m_Player_BPunch;
        public InputAction @JumpKick => m_Wrapper.m_Player_JumpKick;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                @XPunch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXPunch;
                @XPunch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXPunch;
                @XPunch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnXPunch;
                @YPunch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYPunch;
                @YPunch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYPunch;
                @YPunch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnYPunch;
                @BPunch.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBPunch;
                @BPunch.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBPunch;
                @BPunch.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBPunch;
                @JumpKick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpKick;
                @JumpKick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpKick;
                @JumpKick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJumpKick;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @XPunch.started += instance.OnXPunch;
                @XPunch.performed += instance.OnXPunch;
                @XPunch.canceled += instance.OnXPunch;
                @YPunch.started += instance.OnYPunch;
                @YPunch.performed += instance.OnYPunch;
                @YPunch.canceled += instance.OnYPunch;
                @BPunch.started += instance.OnBPunch;
                @BPunch.performed += instance.OnBPunch;
                @BPunch.canceled += instance.OnBPunch;
                @JumpKick.started += instance.OnJumpKick;
                @JumpKick.performed += instance.OnJumpKick;
                @JumpKick.canceled += instance.OnJumpKick;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.FindControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnXPunch(InputAction.CallbackContext context);
        void OnYPunch(InputAction.CallbackContext context);
        void OnBPunch(InputAction.CallbackContext context);
        void OnJumpKick(InputAction.CallbackContext context);
    }
}
