//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Scripts/StringControl.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @StringController: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @StringController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""StringControl"",
    ""maps"": [
        {
            ""name"": ""String1"",
            ""id"": ""8dcb8c24-0964-4c5a-82fc-dfc80e29fce8"",
            ""actions"": [
                {
                    ""name"": ""MouseSlide"",
                    ""type"": ""Value"",
                    ""id"": ""d6598174-5547-4c66-a220-653c825e03a7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Button"",
                    ""id"": ""a3e8d998-a947-432c-847c-d6e7f51b8b5a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MousePosition"",
                    ""type"": ""Value"",
                    ""id"": ""1eafb6f8-dd3f-4182-9dfd-3a59fb1083dd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""55236b10-dffb-48f0-8883-5a934e6df37d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseSlide"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d00bfd25-3430-462a-a7c3-0652c45dd86f"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""194afc26-0333-45fc-a2c3-09e4125b3671"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MousePosition"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // String1
        m_String1 = asset.FindActionMap("String1", throwIfNotFound: true);
        m_String1_MouseSlide = m_String1.FindAction("MouseSlide", throwIfNotFound: true);
        m_String1_MouseClick = m_String1.FindAction("MouseClick", throwIfNotFound: true);
        m_String1_MousePosition = m_String1.FindAction("MousePosition", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // String1
    private readonly InputActionMap m_String1;
    private List<IString1Actions> m_String1ActionsCallbackInterfaces = new List<IString1Actions>();
    private readonly InputAction m_String1_MouseSlide;
    private readonly InputAction m_String1_MouseClick;
    private readonly InputAction m_String1_MousePosition;
    public struct String1Actions
    {
        private @StringController m_Wrapper;
        public String1Actions(@StringController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseSlide => m_Wrapper.m_String1_MouseSlide;
        public InputAction @MouseClick => m_Wrapper.m_String1_MouseClick;
        public InputAction @MousePosition => m_Wrapper.m_String1_MousePosition;
        public InputActionMap Get() { return m_Wrapper.m_String1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(String1Actions set) { return set.Get(); }
        public void AddCallbacks(IString1Actions instance)
        {
            if (instance == null || m_Wrapper.m_String1ActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_String1ActionsCallbackInterfaces.Add(instance);
            @MouseSlide.started += instance.OnMouseSlide;
            @MouseSlide.performed += instance.OnMouseSlide;
            @MouseSlide.canceled += instance.OnMouseSlide;
            @MouseClick.started += instance.OnMouseClick;
            @MouseClick.performed += instance.OnMouseClick;
            @MouseClick.canceled += instance.OnMouseClick;
            @MousePosition.started += instance.OnMousePosition;
            @MousePosition.performed += instance.OnMousePosition;
            @MousePosition.canceled += instance.OnMousePosition;
        }

        private void UnregisterCallbacks(IString1Actions instance)
        {
            @MouseSlide.started -= instance.OnMouseSlide;
            @MouseSlide.performed -= instance.OnMouseSlide;
            @MouseSlide.canceled -= instance.OnMouseSlide;
            @MouseClick.started -= instance.OnMouseClick;
            @MouseClick.performed -= instance.OnMouseClick;
            @MouseClick.canceled -= instance.OnMouseClick;
            @MousePosition.started -= instance.OnMousePosition;
            @MousePosition.performed -= instance.OnMousePosition;
            @MousePosition.canceled -= instance.OnMousePosition;
        }

        public void RemoveCallbacks(IString1Actions instance)
        {
            if (m_Wrapper.m_String1ActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IString1Actions instance)
        {
            foreach (var item in m_Wrapper.m_String1ActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_String1ActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public String1Actions @String1 => new String1Actions(this);
    public interface IString1Actions
    {
        void OnMouseSlide(InputAction.CallbackContext context);
        void OnMouseClick(InputAction.CallbackContext context);
        void OnMousePosition(InputAction.CallbackContext context);
    }
}