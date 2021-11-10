// GENERATED AUTOMATICALLY FROM 'Assets/Alon/Management/MainMenu/MenuNavi.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @MenuNavi : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @MenuNavi()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuNavi"",
    ""maps"": [
        {
            ""name"": ""MenuNav"",
            ""id"": ""a62a0154-24a9-4be1-bd1b-46e629fe7b5f"",
            ""actions"": [
                {
                    ""name"": ""NextItem"",
                    ""type"": ""Button"",
                    ""id"": ""96957a72-f40f-4c8d-b4d6-75847b60aafb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PrevItem"",
                    ""type"": ""Button"",
                    ""id"": ""07fdd8e4-dd29-4032-accc-1004b9c28729"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""8908d053-ae2d-47bd-aa33-32d793698dd1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8c3b4ff3-85b7-4a63-b379-31c4c46eeebc"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc184e78-e662-4681-80b0-aa406d144b6f"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57cda3bd-dd93-4a1c-ae24-d4719762e326"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""99c8be21-d548-42b3-b10b-4a39f4cfac09"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a6d644b3-d13b-431c-9557-a5340691b81c"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a9d39fc-4490-4cfc-ac33-32a399bd1a6a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PrevItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""323ca7e5-f006-47b9-b06c-0172bde109d9"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d377ca2c-dc90-4a91-9f7e-72d960b03d94"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""721f7760-0df9-4afe-9cc3-7ad68611d290"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard&Mouse"",
            ""bindingGroup"": ""Keyboard&Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // MenuNav
        m_MenuNav = asset.FindActionMap("MenuNav", throwIfNotFound: true);
        m_MenuNav_NextItem = m_MenuNav.FindAction("NextItem", throwIfNotFound: true);
        m_MenuNav_PrevItem = m_MenuNav.FindAction("PrevItem", throwIfNotFound: true);
        m_MenuNav_Select = m_MenuNav.FindAction("Select", throwIfNotFound: true);
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

    // MenuNav
    private readonly InputActionMap m_MenuNav;
    private IMenuNavActions m_MenuNavActionsCallbackInterface;
    private readonly InputAction m_MenuNav_NextItem;
    private readonly InputAction m_MenuNav_PrevItem;
    private readonly InputAction m_MenuNav_Select;
    public struct MenuNavActions
    {
        private @MenuNavi m_Wrapper;
        public MenuNavActions(@MenuNavi wrapper) { m_Wrapper = wrapper; }
        public InputAction @NextItem => m_Wrapper.m_MenuNav_NextItem;
        public InputAction @PrevItem => m_Wrapper.m_MenuNav_PrevItem;
        public InputAction @Select => m_Wrapper.m_MenuNav_Select;
        public InputActionMap Get() { return m_Wrapper.m_MenuNav; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuNavActions set) { return set.Get(); }
        public void SetCallbacks(IMenuNavActions instance)
        {
            if (m_Wrapper.m_MenuNavActionsCallbackInterface != null)
            {
                @NextItem.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnNextItem;
                @NextItem.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnNextItem;
                @NextItem.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnNextItem;
                @PrevItem.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnPrevItem;
                @PrevItem.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnPrevItem;
                @PrevItem.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnPrevItem;
                @Select.started -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuNavActionsCallbackInterface.OnSelect;
            }
            m_Wrapper.m_MenuNavActionsCallbackInterface = instance;
            if (instance != null)
            {
                @NextItem.started += instance.OnNextItem;
                @NextItem.performed += instance.OnNextItem;
                @NextItem.canceled += instance.OnNextItem;
                @PrevItem.started += instance.OnPrevItem;
                @PrevItem.performed += instance.OnPrevItem;
                @PrevItem.canceled += instance.OnPrevItem;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
            }
        }
    }
    public MenuNavActions @MenuNav => new MenuNavActions(this);
    private int m_GamepadSchemeIndex = -1;
    public InputControlScheme GamepadScheme
    {
        get
        {
            if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
            return asset.controlSchemes[m_GamepadSchemeIndex];
        }
    }
    private int m_KeyboardMouseSchemeIndex = -1;
    public InputControlScheme KeyboardMouseScheme
    {
        get
        {
            if (m_KeyboardMouseSchemeIndex == -1) m_KeyboardMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard&Mouse");
            return asset.controlSchemes[m_KeyboardMouseSchemeIndex];
        }
    }
    public interface IMenuNavActions
    {
        void OnNextItem(InputAction.CallbackContext context);
        void OnPrevItem(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
    }
}
