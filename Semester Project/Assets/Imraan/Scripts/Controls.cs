// GENERATED AUTOMATICALLY FROM 'Assets/Imraan/Scripts/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""BasicControls"",
            ""id"": ""58c334e7-27ac-486e-8134-1e6b09fed727"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""22a2cca4-541c-4911-8651-16a00f11e0da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""9ed03b9e-aa5c-4e81-80fe-ce2a491091d8"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""4e63c836-24b9-4d98-8020-78f7299fb519"",
                    ""path"": ""<HID::ZEROPLUS P4 Wired Gamepad>/button2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2106f4c4-d65b-423a-943f-f7308e5337c4"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // BasicControls
        m_BasicControls = asset.FindActionMap("BasicControls", throwIfNotFound: true);
        m_BasicControls_Jump = m_BasicControls.FindAction("Jump", throwIfNotFound: true);
        m_BasicControls_Move = m_BasicControls.FindAction("Move", throwIfNotFound: true);
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

    // BasicControls
    private readonly InputActionMap m_BasicControls;
    private IBasicControlsActions m_BasicControlsActionsCallbackInterface;
    private readonly InputAction m_BasicControls_Jump;
    private readonly InputAction m_BasicControls_Move;
    public struct BasicControlsActions
    {
        private @Controls m_Wrapper;
        public BasicControlsActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_BasicControls_Jump;
        public InputAction @Move => m_Wrapper.m_BasicControls_Move;
        public InputActionMap Get() { return m_Wrapper.m_BasicControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(BasicControlsActions set) { return set.Get(); }
        public void SetCallbacks(IBasicControlsActions instance)
        {
            if (m_Wrapper.m_BasicControlsActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnJump;
                @Move.started -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_BasicControlsActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_BasicControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public BasicControlsActions @BasicControls => new BasicControlsActions(this);
    public interface IBasicControlsActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMove(InputAction.CallbackContext context);
    }
}
