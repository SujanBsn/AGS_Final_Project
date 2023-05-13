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
            ""name"": ""String"",
            ""id"": ""8dcb8c24-0964-4c5a-82fc-dfc80e29fce8"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Value"",
                    ""id"": ""d6598174-5547-4c66-a220-653c825e03a7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""f9e1afff-e7a1-4cc0-9e2f-7fba73a969d5"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""SingleNote"",
            ""id"": ""3ca655ef-0660-44dc-8a89-1c0612e19fa6"",
            ""actions"": [
                {
                    ""name"": ""StrumGuitar"",
                    ""type"": ""Button"",
                    ""id"": ""b42fa0ea-ac40-4e11-9b56-d3284643558a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""HammerNote"",
                    ""type"": ""Button"",
                    ""id"": ""1d7d495d-494a-482a-85a2-6c3950c1dd06"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Mute"",
                    ""type"": ""Button"",
                    ""id"": ""48a20042-8d58-4846-b157-bc5393775f9c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ae4901e6-0928-4f2c-b792-270622a5d45e"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StrumGuitar"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f8ab976-2dae-482d-a515-b3d18d879876"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HammerNote"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f372347-4078-4705-8030-33698c48982c"",
                    ""path"": ""<Mouse>/middleButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mute"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // String
        m_String = asset.FindActionMap("String", throwIfNotFound: true);
        m_String_MouseClick = m_String.FindAction("MouseClick", throwIfNotFound: true);
        // SingleNote
        m_SingleNote = asset.FindActionMap("SingleNote", throwIfNotFound: true);
        m_SingleNote_StrumGuitar = m_SingleNote.FindAction("StrumGuitar", throwIfNotFound: true);
        m_SingleNote_HammerNote = m_SingleNote.FindAction("HammerNote", throwIfNotFound: true);
        m_SingleNote_Mute = m_SingleNote.FindAction("Mute", throwIfNotFound: true);
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

    // String
    private readonly InputActionMap m_String;
    private List<IStringActions> m_StringActionsCallbackInterfaces = new List<IStringActions>();
    private readonly InputAction m_String_MouseClick;
    public struct StringActions
    {
        private @StringController m_Wrapper;
        public StringActions(@StringController wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_String_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_String; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(StringActions set) { return set.Get(); }
        public void AddCallbacks(IStringActions instance)
        {
            if (instance == null || m_Wrapper.m_StringActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_StringActionsCallbackInterfaces.Add(instance);
            @MouseClick.started += instance.OnMouseClick;
            @MouseClick.performed += instance.OnMouseClick;
            @MouseClick.canceled += instance.OnMouseClick;
        }

        private void UnregisterCallbacks(IStringActions instance)
        {
            @MouseClick.started -= instance.OnMouseClick;
            @MouseClick.performed -= instance.OnMouseClick;
            @MouseClick.canceled -= instance.OnMouseClick;
        }

        public void RemoveCallbacks(IStringActions instance)
        {
            if (m_Wrapper.m_StringActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IStringActions instance)
        {
            foreach (var item in m_Wrapper.m_StringActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_StringActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public StringActions @String => new StringActions(this);

    // SingleNote
    private readonly InputActionMap m_SingleNote;
    private List<ISingleNoteActions> m_SingleNoteActionsCallbackInterfaces = new List<ISingleNoteActions>();
    private readonly InputAction m_SingleNote_StrumGuitar;
    private readonly InputAction m_SingleNote_HammerNote;
    private readonly InputAction m_SingleNote_Mute;
    public struct SingleNoteActions
    {
        private @StringController m_Wrapper;
        public SingleNoteActions(@StringController wrapper) { m_Wrapper = wrapper; }
        public InputAction @StrumGuitar => m_Wrapper.m_SingleNote_StrumGuitar;
        public InputAction @HammerNote => m_Wrapper.m_SingleNote_HammerNote;
        public InputAction @Mute => m_Wrapper.m_SingleNote_Mute;
        public InputActionMap Get() { return m_Wrapper.m_SingleNote; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SingleNoteActions set) { return set.Get(); }
        public void AddCallbacks(ISingleNoteActions instance)
        {
            if (instance == null || m_Wrapper.m_SingleNoteActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SingleNoteActionsCallbackInterfaces.Add(instance);
            @StrumGuitar.started += instance.OnStrumGuitar;
            @StrumGuitar.performed += instance.OnStrumGuitar;
            @StrumGuitar.canceled += instance.OnStrumGuitar;
            @HammerNote.started += instance.OnHammerNote;
            @HammerNote.performed += instance.OnHammerNote;
            @HammerNote.canceled += instance.OnHammerNote;
            @Mute.started += instance.OnMute;
            @Mute.performed += instance.OnMute;
            @Mute.canceled += instance.OnMute;
        }

        private void UnregisterCallbacks(ISingleNoteActions instance)
        {
            @StrumGuitar.started -= instance.OnStrumGuitar;
            @StrumGuitar.performed -= instance.OnStrumGuitar;
            @StrumGuitar.canceled -= instance.OnStrumGuitar;
            @HammerNote.started -= instance.OnHammerNote;
            @HammerNote.performed -= instance.OnHammerNote;
            @HammerNote.canceled -= instance.OnHammerNote;
            @Mute.started -= instance.OnMute;
            @Mute.performed -= instance.OnMute;
            @Mute.canceled -= instance.OnMute;
        }

        public void RemoveCallbacks(ISingleNoteActions instance)
        {
            if (m_Wrapper.m_SingleNoteActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISingleNoteActions instance)
        {
            foreach (var item in m_Wrapper.m_SingleNoteActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SingleNoteActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SingleNoteActions @SingleNote => new SingleNoteActions(this);
    public interface IStringActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
    }
    public interface ISingleNoteActions
    {
        void OnStrumGuitar(InputAction.CallbackContext context);
        void OnHammerNote(InputAction.CallbackContext context);
        void OnMute(InputAction.CallbackContext context);
    }
}
