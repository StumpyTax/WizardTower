//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Player.inputactions
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

public partial class @casterInput: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @casterInput()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9afff60f-433b-4959-a763-8d367e6e05e0"",
            ""actions"": [
                {
                    ""name"": ""cast_spell_1"",
                    ""type"": ""Button"",
                    ""id"": ""aa6bb5eb-a5b0-49ba-9e2f-7d851b43ced5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""cast_spell_2"",
                    ""type"": ""Button"",
                    ""id"": ""09d4afa6-c06e-4964-8746-3ca01b062020"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""416267f0-9a9e-4e5a-aee4-9fc5e1f1a1ac"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""cast_spell_1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""364808df-5a94-4611-9497-fc76ec4cf4ba"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""cast_spell_2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_cast_spell_1 = m_Player.FindAction("cast_spell_1", throwIfNotFound: true);
        m_Player_cast_spell_2 = m_Player.FindAction("cast_spell_2", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private List<IPlayerActions> m_PlayerActionsCallbackInterfaces = new List<IPlayerActions>();
    private readonly InputAction m_Player_cast_spell_1;
    private readonly InputAction m_Player_cast_spell_2;
    public struct PlayerActions
    {
        private @casterInput m_Wrapper;
        public PlayerActions(@casterInput wrapper) { m_Wrapper = wrapper; }
        public InputAction @cast_spell_1 => m_Wrapper.m_Player_cast_spell_1;
        public InputAction @cast_spell_2 => m_Wrapper.m_Player_cast_spell_2;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void AddCallbacks(IPlayerActions instance)
        {
            if (instance == null || m_Wrapper.m_PlayerActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Add(instance);
            @cast_spell_1.started += instance.OnCast_spell_1;
            @cast_spell_1.performed += instance.OnCast_spell_1;
            @cast_spell_1.canceled += instance.OnCast_spell_1;
            @cast_spell_2.started += instance.OnCast_spell_2;
            @cast_spell_2.performed += instance.OnCast_spell_2;
            @cast_spell_2.canceled += instance.OnCast_spell_2;
        }

        private void UnregisterCallbacks(IPlayerActions instance)
        {
            @cast_spell_1.started -= instance.OnCast_spell_1;
            @cast_spell_1.performed -= instance.OnCast_spell_1;
            @cast_spell_1.canceled -= instance.OnCast_spell_1;
            @cast_spell_2.started -= instance.OnCast_spell_2;
            @cast_spell_2.performed -= instance.OnCast_spell_2;
            @cast_spell_2.canceled -= instance.OnCast_spell_2;
        }

        public void RemoveCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlayerActions instance)
        {
            foreach (var item in m_Wrapper.m_PlayerActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PlayerActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    public interface IPlayerActions
    {
        void OnCast_spell_1(InputAction.CallbackContext context);
        void OnCast_spell_2(InputAction.CallbackContext context);
    }
}
