// GENERATED AUTOMATICALLY FROM 'Assets/Code/Input/Actions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Actions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Actions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Actions"",
    ""maps"": [
        {
            ""name"": ""inGame"",
            ""id"": ""2d826437-ebf3-4020-8bd7-97891217e6e8"",
            ""actions"": [
                {
                    ""name"": ""shoot"",
                    ""type"": ""Button"",
                    ""id"": ""c009996c-6af4-41e6-b855-18ae556cf658"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""move"",
                    ""type"": ""Value"",
                    ""id"": ""9a464dd2-e5c0-422a-b803-2941cb43efba"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""6843f9cd-1d4c-49da-ae8e-131b1ef35445"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e84773f-a79b-44d8-bb76-9b2ecb5c3d07"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bd216edb-7ddf-4397-9fd7-1c2f41152f56"",
                    ""path"": ""<HID::Twin USB Gamepad      >/trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5c9f2a4a-e4c5-4d41-84cc-4ae0a7adbe4e"",
                    ""path"": ""<Linux::PersonalCommunicationSystemsInc::GSA5120DDVDRW>/Trigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ebb1677-01e8-4e37-9a9a-6f5ff16d38f1"",
                    ""path"": ""<HID::Twin USB Gamepad      >/stick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""503208d8-a98d-41ea-8c6b-3b7e45deac71"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2a9d099d-bfd4-4d92-b453-18d1bac9c347"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""a90919ad-5dce-42cf-a59b-157113d5408d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c925141f-667c-4cb1-8f86-24922d236874"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bbec0ef7-cc17-4cad-9b37-5ab29cb0f394"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3fba8bcd-51b1-43d1-8fbf-4f2a257b1ac3"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // inGame
        m_inGame = asset.FindActionMap("inGame", throwIfNotFound: true);
        m_inGame_shoot = m_inGame.FindAction("shoot", throwIfNotFound: true);
        m_inGame_move = m_inGame.FindAction("move", throwIfNotFound: true);
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

    // inGame
    private readonly InputActionMap m_inGame;
    private IInGameActions m_InGameActionsCallbackInterface;
    private readonly InputAction m_inGame_shoot;
    private readonly InputAction m_inGame_move;
    public struct InGameActions
    {
        private @Actions m_Wrapper;
        public InGameActions(@Actions wrapper) { m_Wrapper = wrapper; }
        public InputAction @shoot => m_Wrapper.m_inGame_shoot;
        public InputAction @move => m_Wrapper.m_inGame_move;
        public InputActionMap Get() { return m_Wrapper.m_inGame; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InGameActions set) { return set.Get(); }
        public void SetCallbacks(IInGameActions instance)
        {
            if (m_Wrapper.m_InGameActionsCallbackInterface != null)
            {
                @shoot.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnShoot;
                @shoot.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnShoot;
                @shoot.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnShoot;
                @move.started -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @move.performed -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
                @move.canceled -= m_Wrapper.m_InGameActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_InGameActionsCallbackInterface = instance;
            if (instance != null)
            {
                @shoot.started += instance.OnShoot;
                @shoot.performed += instance.OnShoot;
                @shoot.canceled += instance.OnShoot;
                @move.started += instance.OnMove;
                @move.performed += instance.OnMove;
                @move.canceled += instance.OnMove;
            }
        }
    }
    public InGameActions @inGame => new InGameActions(this);
    public interface IInGameActions
    {
        void OnShoot(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
