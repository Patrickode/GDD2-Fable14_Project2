// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Movement"",
            ""id"": ""2a7e8d43-52ea-4e91-938b-a62152386ff1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""d5ff2e6d-8ecd-4822-ad16-5bcaaec1a79d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability 0"",
                    ""type"": ""Button"",
                    ""id"": ""ed216ae2-80df-4131-8084-889144df5463"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability 1"",
                    ""type"": ""Button"",
                    ""id"": ""837c489a-26e0-4ca9-8c5e-3165e2143bf9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability 2"",
                    ""type"": ""Button"",
                    ""id"": ""19d06d74-486c-40a7-a430-d203be8e3c8d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability 3"",
                    ""type"": ""Button"",
                    ""id"": ""15872d4d-0ab2-4fcd-be0a-14a9164fad57"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability 4"",
                    ""type"": ""Button"",
                    ""id"": ""87c3a20a-d82a-4506-b628-52cb5ecc75fd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability 5"",
                    ""type"": ""Button"",
                    ""id"": ""220c2d76-ec3b-4b16-a459-3dfc6ced7cd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Ability 6"",
                    ""type"": ""Button"",
                    ""id"": ""3158bd98-64cd-4faf-97c3-a8679e44ea0a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""819cc73f-d772-4a12-9399-31981d38c91b"",
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
                    ""id"": ""fd5b188d-0cff-4b55-97c1-a47aeac32ce4"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0b1a9ef7-e2c5-4615-9121-01451037fd1d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""af490963-a2e6-4aa2-b409-d47a70eb476c"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c9e112a7-e4e6-440d-8313-74fb9717e1df"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""9ac8e203-4b7e-4664-a5e8-7e3d73359d95"",
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
                    ""id"": ""a2119d5b-c813-4f72-a225-db1fa5071bc6"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""08f5d553-7e56-459d-a4cf-224d1a0d3c02"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""d7aec1cd-8dcf-4386-8118-4dc606722ae4"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a9ebfd6d-fb62-463e-82c2-db589ec9f106"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e954cdef-86c6-473b-8ef9-73ae468a6018"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability 0"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""93f67b69-bfde-4971-b158-0e9ceec3a82a"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability 1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""68b48bac-4f2f-402d-88a0-349034187800"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability 2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0df99199-0033-4558-a4c1-cdd5355a29c3"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability 3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20f84c53-8f3f-48aa-8b59-1895cc7e7d3c"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability 4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e448d350-f24a-49a2-9055-d76bb1e77851"",
                    ""path"": ""<Keyboard>/n"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability 5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f01ebf4f-4324-4a12-8b01-0e5232c8bf39"",
                    ""path"": ""<Keyboard>/m"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Ability 6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
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
        // Movement
        m_Movement = asset.FindActionMap("Movement", throwIfNotFound: true);
        m_Movement_Move = m_Movement.FindAction("Move", throwIfNotFound: true);
        m_Movement_Ability0 = m_Movement.FindAction("Ability 0", throwIfNotFound: true);
        m_Movement_Ability1 = m_Movement.FindAction("Ability 1", throwIfNotFound: true);
        m_Movement_Ability2 = m_Movement.FindAction("Ability 2", throwIfNotFound: true);
        m_Movement_Ability3 = m_Movement.FindAction("Ability 3", throwIfNotFound: true);
        m_Movement_Ability4 = m_Movement.FindAction("Ability 4", throwIfNotFound: true);
        m_Movement_Ability5 = m_Movement.FindAction("Ability 5", throwIfNotFound: true);
        m_Movement_Ability6 = m_Movement.FindAction("Ability 6", throwIfNotFound: true);
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

    // Movement
    private readonly InputActionMap m_Movement;
    private IMovementActions m_MovementActionsCallbackInterface;
    private readonly InputAction m_Movement_Move;
    private readonly InputAction m_Movement_Ability0;
    private readonly InputAction m_Movement_Ability1;
    private readonly InputAction m_Movement_Ability2;
    private readonly InputAction m_Movement_Ability3;
    private readonly InputAction m_Movement_Ability4;
    private readonly InputAction m_Movement_Ability5;
    private readonly InputAction m_Movement_Ability6;
    public struct MovementActions
    {
        private @PlayerControls m_Wrapper;
        public MovementActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Movement_Move;
        public InputAction @Ability0 => m_Wrapper.m_Movement_Ability0;
        public InputAction @Ability1 => m_Wrapper.m_Movement_Ability1;
        public InputAction @Ability2 => m_Wrapper.m_Movement_Ability2;
        public InputAction @Ability3 => m_Wrapper.m_Movement_Ability3;
        public InputAction @Ability4 => m_Wrapper.m_Movement_Ability4;
        public InputAction @Ability5 => m_Wrapper.m_Movement_Ability5;
        public InputAction @Ability6 => m_Wrapper.m_Movement_Ability6;
        public InputActionMap Get() { return m_Wrapper.m_Movement; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MovementActions set) { return set.Get(); }
        public void SetCallbacks(IMovementActions instance)
        {
            if (m_Wrapper.m_MovementActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnMove;
                @Ability0.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility0;
                @Ability0.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility0;
                @Ability0.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility0;
                @Ability1.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility1;
                @Ability1.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility1;
                @Ability1.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility1;
                @Ability2.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility2;
                @Ability2.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility2;
                @Ability2.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility2;
                @Ability3.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility3;
                @Ability3.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility3;
                @Ability3.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility3;
                @Ability4.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility4;
                @Ability4.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility4;
                @Ability4.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility4;
                @Ability5.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility5;
                @Ability5.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility5;
                @Ability5.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility5;
                @Ability6.started -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility6;
                @Ability6.performed -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility6;
                @Ability6.canceled -= m_Wrapper.m_MovementActionsCallbackInterface.OnAbility6;
            }
            m_Wrapper.m_MovementActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Ability0.started += instance.OnAbility0;
                @Ability0.performed += instance.OnAbility0;
                @Ability0.canceled += instance.OnAbility0;
                @Ability1.started += instance.OnAbility1;
                @Ability1.performed += instance.OnAbility1;
                @Ability1.canceled += instance.OnAbility1;
                @Ability2.started += instance.OnAbility2;
                @Ability2.performed += instance.OnAbility2;
                @Ability2.canceled += instance.OnAbility2;
                @Ability3.started += instance.OnAbility3;
                @Ability3.performed += instance.OnAbility3;
                @Ability3.canceled += instance.OnAbility3;
                @Ability4.started += instance.OnAbility4;
                @Ability4.performed += instance.OnAbility4;
                @Ability4.canceled += instance.OnAbility4;
                @Ability5.started += instance.OnAbility5;
                @Ability5.performed += instance.OnAbility5;
                @Ability5.canceled += instance.OnAbility5;
                @Ability6.started += instance.OnAbility6;
                @Ability6.performed += instance.OnAbility6;
                @Ability6.canceled += instance.OnAbility6;
            }
        }
    }
    public MovementActions @Movement => new MovementActions(this);
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.FindControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IMovementActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAbility0(InputAction.CallbackContext context);
        void OnAbility1(InputAction.CallbackContext context);
        void OnAbility2(InputAction.CallbackContext context);
        void OnAbility3(InputAction.CallbackContext context);
        void OnAbility4(InputAction.CallbackContext context);
        void OnAbility5(InputAction.CallbackContext context);
        void OnAbility6(InputAction.CallbackContext context);
    }
}
