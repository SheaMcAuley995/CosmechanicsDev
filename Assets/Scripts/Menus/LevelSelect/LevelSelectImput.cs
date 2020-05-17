// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Menus/LevelSelect/LevelSelectImput.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @LevelSelectImput : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @LevelSelectImput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""LevelSelectImput"",
    ""maps"": [
        {
            ""name"": ""Menu Controls"",
            ""id"": ""b12c3c1f-61c2-4b24-93e7-e329b90e71f8"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""464c7b72-8664-4554-825c-5685bf88459d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""58e7e183-5304-46b1-a747-8889e94e78e0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                },
                {
                    ""name"": ""Back"",
                    ""type"": ""Button"",
                    ""id"": ""25076557-5029-44e9-ba10-44e877111f5c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""D-Pad"",
                    ""id"": ""f4aece4a-a6ac-47b3-9f63-0334483a590f"",
                    ""path"": ""2DVector"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""265bf1a9-2cac-489a-9d43-7b2ecb11407a"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""81f34781-e08e-4f95-a978-1a289eaa174a"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1270ba13-8e74-481a-baea-6fe5b38b7a98"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""f697e9cc-82b8-46eb-87b5-e02e0f2b7858"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""818874a1-f1ad-41cd-a789-585c0dfe145d"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": ""Hold(duration=0.2,pressPoint=0.5)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef338f38-3a90-4fe1-a70e-b3873f583666"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8c6870b0-9867-467a-bc62-bdf211d7a23a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Back"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu Controls
        m_MenuControls = asset.FindActionMap("Menu Controls", throwIfNotFound: true);
        m_MenuControls_Move = m_MenuControls.FindAction("Move", throwIfNotFound: true);
        m_MenuControls_Select = m_MenuControls.FindAction("Select", throwIfNotFound: true);
        m_MenuControls_Back = m_MenuControls.FindAction("Back", throwIfNotFound: true);
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

    // Menu Controls
    private readonly InputActionMap m_MenuControls;
    private IMenuControlsActions m_MenuControlsActionsCallbackInterface;
    private readonly InputAction m_MenuControls_Move;
    private readonly InputAction m_MenuControls_Select;
    private readonly InputAction m_MenuControls_Back;
    public struct MenuControlsActions
    {
        private @LevelSelectImput m_Wrapper;
        public MenuControlsActions(@LevelSelectImput wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_MenuControls_Move;
        public InputAction @Select => m_Wrapper.m_MenuControls_Select;
        public InputAction @Back => m_Wrapper.m_MenuControls_Back;
        public InputActionMap Get() { return m_Wrapper.m_MenuControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMenuControlsActions instance)
        {
            if (m_Wrapper.m_MenuControlsActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnMove;
                @Select.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnSelect;
                @Back.started -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnBack;
                @Back.performed -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnBack;
                @Back.canceled -= m_Wrapper.m_MenuControlsActionsCallbackInterface.OnBack;
            }
            m_Wrapper.m_MenuControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Back.started += instance.OnBack;
                @Back.performed += instance.OnBack;
                @Back.canceled += instance.OnBack;
            }
        }
    }
    public MenuControlsActions @MenuControls => new MenuControlsActions(this);
    public interface IMenuControlsActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnBack(InputAction.CallbackContext context);
    }
}
