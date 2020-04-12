// GENERATED AUTOMATICALLY FROM 'Assets/zExperimental/PlayerControls.inputactions'

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
            ""name"": ""Gameplay"",
            ""id"": ""08f8c73b-c487-42cd-aacd-71e8a1c09aea"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""a928f16d-a592-4d9a-92a5-4f60702e3c2b"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickUp"",
                    ""type"": ""Button"",
                    ""id"": ""b27b6bde-db2d-4edd-9695-8ab4faaa237e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""ccc21c8f-89dc-4c8c-b3e3-fd727313907d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold""
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""e4bdd73f-440b-488f-9f5c-3ffb5b3e37c3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""9573f97f-c6c0-4793-b239-ab411daa4e48"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""da016762-2156-4bb8-8f1e-8bd58f5e4f78"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""a7b5b350-97b9-4fdc-a87f-2c31e88c6625"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e57a55c2-759c-4c6d-a93e-4a0dea859210"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""de018312-0d36-421c-9019-a0063eb50827"",
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
                    ""id"": ""86180c41-a819-4794-a6aa-132408534de1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c0ceb9b4-bbf2-4ac1-9223-2596ed1b3236"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""25e6eea6-7937-40be-bd74-57bd84115158"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""37b75f78-fdb9-4a4c-a79f-bc2c01fdc5d1"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""28ac879f-d8f3-40b1-989c-2f2dbefa128d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickUp"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eb347a57-f32a-4a0a-8001-e4cd3ceb73c7"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2e141b00-fb35-4a76-8888-e940f0d27fb1"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e0c404fa-4a60-4328-88d3-1f68be5f979f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ed49e9fa-f03f-409d-97ef-39bb43d3face"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""44d819ff-8b44-4b54-84cd-108e6197e6c5"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""MainMenu"",
            ""id"": ""3a5ba496-4a5b-496e-9c56-22c551764086"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""5257692f-8f79-4b4c-ba4a-c80018bb800a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Selection"",
                    ""type"": ""Button"",
                    ""id"": ""60c99ef4-9eca-484d-b4ef-ba2919e69500"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""286d6094-db83-4a8f-90c1-c05752ee9a0a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""5fd77662-c9b4-425c-9359-979033a47772"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""ac813e27-a2d8-48c0-8f58-b9a48f1c5e12"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Alt_Selection"",
                    ""type"": ""Value"",
                    ""id"": ""ef0c6a6a-0205-4437-8458-1b9181f8df58"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""L-Selection"",
                    ""type"": ""Button"",
                    ""id"": ""e07f0af4-424f-4636-afcd-d032f90b0235"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""R-Selection"",
                    ""type"": ""Button"",
                    ""id"": ""6e80f2b9-e9d4-4133-b7e9-f7904138b4fb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e773ceb5-30e9-4aff-bf7e-5225b2272c96"",
                    ""path"": ""<XInputController>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7852c419-0c1c-47e8-b256-62526fe0889f"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""1ad0e830-2208-45e3-a4fa-5509ec09e750"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""63cbb706-b36c-4a52-9dd8-087b16d1954c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""0c6b6453-0789-4a89-a61f-edb1c32b8a80"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8e517423-330c-4e61-8531-f754f16266f1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c8ee205d-e747-4ecc-a9f4-c9dfd8659d31"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""d4433b67-65f9-4cc3-8438-15cdcbd74de2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""30da017d-9bfb-411f-a8cd-a4cf751bb877"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bc0e9101-4b8a-407c-8ede-839197275066"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ac8f665e-68c6-4b13-85cf-336e0569257b"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""62f053c9-68c8-4564-a270-c63348e3d048"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""39c3de4e-5690-4c2a-9d05-26520958c715"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Gamepad Axis"",
                    ""id"": ""903e4fc8-8efb-4c16-989a-3c23a264ebdd"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alt_Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""88102746-9235-41fa-8da4-3beb825b33de"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alt_Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""76ff2acc-7066-401a-b823-fef64183214c"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alt_Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard Axis"",
                    ""id"": ""a46dde40-9ebd-45d4-b481-98c6db89f083"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alt_Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b3664332-a243-430c-ad89-9e9d8913ecc2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alt_Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4581a808-a916-4d6d-bb54-e12ec8c51c45"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Alt_Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e61cc717-14f1-4e5f-8663-21993aa02583"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L-Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82da18fb-aa5b-42a4-b911-a4de27b2e539"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""L-Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0d816c4f-9a42-48f8-943e-2aed187d41df"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R-Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""94039430-6cca-4ef3-a2a1-02c9117ef1f8"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""R-Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""CharSelect"",
            ""id"": ""7570d613-9316-41c7-9853-d65364955d96"",
            ""actions"": [
                {
                    ""name"": ""MovementRight"",
                    ""type"": ""Button"",
                    ""id"": ""74055047-8b89-437d-8154-e4605b0790ea"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                },
                {
                    ""name"": ""MovementLeft"",
                    ""type"": ""Button"",
                    ""id"": ""52471491-7611-471c-9d53-be6a11dc57b3"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(pressPoint=1)""
                },
                {
                    ""name"": ""AltMovementRight"",
                    ""type"": ""Button"",
                    ""id"": ""86696338-53a6-47a7-a847-c83c0a3f866f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""AltMovementLeft"",
                    ""type"": ""Button"",
                    ""id"": ""5785aae7-a1e2-42a9-9d73-016ecbe1f1de"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""9628192f-be27-4b04-9d9c-ec377c2ba79c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": ""Press(behavior=1)""
                },
                {
                    ""name"": ""Confirm"",
                    ""type"": ""Button"",
                    ""id"": ""2dd7f641-81f7-4032-8f58-7dfb81f0d56f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Hold(duration=1)""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""046d0b68-9a3a-4903-984f-676c639225ce"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2f7e549d-f9eb-4d34-84f1-073197600742"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4366b92-24d5-4469-848d-e8c97322be28"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2073e6db-bbc9-48d0-88ad-6287a4323ac3"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""47599478-9d08-4ab7-84d6-65589e815713"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""425fd42c-2cf3-4a56-a4cf-b37e5f201b9e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MovementLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6ab0f8a7-2e52-40c4-bd2e-0b15a96b7e05"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltMovementRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fee74269-c96e-4d38-a170-c35702ea30cf"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltMovementRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""551c38ea-27bd-42e9-9a60-0b3bd5c86b4f"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltMovementLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e18b4fe8-bc74-4538-b282-aa3c85bbe0ad"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""AltMovementLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""43438189-2557-45b2-8de1-60352ef79ed7"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a84422d5-c218-4f22-9ed6-fb6badb00f77"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc2edaf2-08b9-46d1-a61c-995b8f3b15ae"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afe6480d-3f07-41e2-a1ec-eb59bf7ad65c"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Confirm"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_PickUp = m_Gameplay.FindAction("PickUp", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        m_Gameplay_Up = m_Gameplay.FindAction("Up", throwIfNotFound: true);
        m_Gameplay_Down = m_Gameplay.FindAction("Down", throwIfNotFound: true);
        m_Gameplay_Left = m_Gameplay.FindAction("Left", throwIfNotFound: true);
        m_Gameplay_Right = m_Gameplay.FindAction("Right", throwIfNotFound: true);
        // MainMenu
        m_MainMenu = asset.FindActionMap("MainMenu", throwIfNotFound: true);
        m_MainMenu_Movement = m_MainMenu.FindAction("Movement", throwIfNotFound: true);
        m_MainMenu_Selection = m_MainMenu.FindAction("Selection", throwIfNotFound: true);
        m_MainMenu_Cancel = m_MainMenu.FindAction("Cancel", throwIfNotFound: true);
        m_MainMenu_Up = m_MainMenu.FindAction("Up", throwIfNotFound: true);
        m_MainMenu_Down = m_MainMenu.FindAction("Down", throwIfNotFound: true);
        m_MainMenu_Alt_Selection = m_MainMenu.FindAction("Alt_Selection", throwIfNotFound: true);
        m_MainMenu_LSelection = m_MainMenu.FindAction("L-Selection", throwIfNotFound: true);
        m_MainMenu_RSelection = m_MainMenu.FindAction("R-Selection", throwIfNotFound: true);
        // CharSelect
        m_CharSelect = asset.FindActionMap("CharSelect", throwIfNotFound: true);
        m_CharSelect_MovementRight = m_CharSelect.FindAction("MovementRight", throwIfNotFound: true);
        m_CharSelect_MovementLeft = m_CharSelect.FindAction("MovementLeft", throwIfNotFound: true);
        m_CharSelect_AltMovementRight = m_CharSelect.FindAction("AltMovementRight", throwIfNotFound: true);
        m_CharSelect_AltMovementLeft = m_CharSelect.FindAction("AltMovementLeft", throwIfNotFound: true);
        m_CharSelect_Cancel = m_CharSelect.FindAction("Cancel", throwIfNotFound: true);
        m_CharSelect_Confirm = m_CharSelect.FindAction("Confirm", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_PickUp;
    private readonly InputAction m_Gameplay_Interact;
    private readonly InputAction m_Gameplay_Up;
    private readonly InputAction m_Gameplay_Down;
    private readonly InputAction m_Gameplay_Left;
    private readonly InputAction m_Gameplay_Right;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @PickUp => m_Wrapper.m_Gameplay_PickUp;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Up => m_Wrapper.m_Gameplay_Up;
        public InputAction @Down => m_Wrapper.m_Gameplay_Down;
        public InputAction @Left => m_Wrapper.m_Gameplay_Left;
        public InputAction @Right => m_Wrapper.m_Gameplay_Right;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @PickUp.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @PickUp.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @PickUp.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnPickUp;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Up.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnDown;
                @Left.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLeft;
                @Right.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnRight;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @PickUp.started += instance.OnPickUp;
                @PickUp.performed += instance.OnPickUp;
                @PickUp.canceled += instance.OnPickUp;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // MainMenu
    private readonly InputActionMap m_MainMenu;
    private IMainMenuActions m_MainMenuActionsCallbackInterface;
    private readonly InputAction m_MainMenu_Movement;
    private readonly InputAction m_MainMenu_Selection;
    private readonly InputAction m_MainMenu_Cancel;
    private readonly InputAction m_MainMenu_Up;
    private readonly InputAction m_MainMenu_Down;
    private readonly InputAction m_MainMenu_Alt_Selection;
    private readonly InputAction m_MainMenu_LSelection;
    private readonly InputAction m_MainMenu_RSelection;
    public struct MainMenuActions
    {
        private @PlayerControls m_Wrapper;
        public MainMenuActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_MainMenu_Movement;
        public InputAction @Selection => m_Wrapper.m_MainMenu_Selection;
        public InputAction @Cancel => m_Wrapper.m_MainMenu_Cancel;
        public InputAction @Up => m_Wrapper.m_MainMenu_Up;
        public InputAction @Down => m_Wrapper.m_MainMenu_Down;
        public InputAction @Alt_Selection => m_Wrapper.m_MainMenu_Alt_Selection;
        public InputAction @LSelection => m_Wrapper.m_MainMenu_LSelection;
        public InputAction @RSelection => m_Wrapper.m_MainMenu_RSelection;
        public InputActionMap Get() { return m_Wrapper.m_MainMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainMenuActions set) { return set.Get(); }
        public void SetCallbacks(IMainMenuActions instance)
        {
            if (m_Wrapper.m_MainMenuActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnMovement;
                @Selection.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelection;
                @Selection.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelection;
                @Selection.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnSelection;
                @Cancel.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnCancel;
                @Up.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnDown;
                @Alt_Selection.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAlt_Selection;
                @Alt_Selection.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAlt_Selection;
                @Alt_Selection.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnAlt_Selection;
                @LSelection.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnLSelection;
                @LSelection.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnLSelection;
                @LSelection.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnLSelection;
                @RSelection.started -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnRSelection;
                @RSelection.performed -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnRSelection;
                @RSelection.canceled -= m_Wrapper.m_MainMenuActionsCallbackInterface.OnRSelection;
            }
            m_Wrapper.m_MainMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Selection.started += instance.OnSelection;
                @Selection.performed += instance.OnSelection;
                @Selection.canceled += instance.OnSelection;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Alt_Selection.started += instance.OnAlt_Selection;
                @Alt_Selection.performed += instance.OnAlt_Selection;
                @Alt_Selection.canceled += instance.OnAlt_Selection;
                @LSelection.started += instance.OnLSelection;
                @LSelection.performed += instance.OnLSelection;
                @LSelection.canceled += instance.OnLSelection;
                @RSelection.started += instance.OnRSelection;
                @RSelection.performed += instance.OnRSelection;
                @RSelection.canceled += instance.OnRSelection;
            }
        }
    }
    public MainMenuActions @MainMenu => new MainMenuActions(this);

    // CharSelect
    private readonly InputActionMap m_CharSelect;
    private ICharSelectActions m_CharSelectActionsCallbackInterface;
    private readonly InputAction m_CharSelect_MovementRight;
    private readonly InputAction m_CharSelect_MovementLeft;
    private readonly InputAction m_CharSelect_AltMovementRight;
    private readonly InputAction m_CharSelect_AltMovementLeft;
    private readonly InputAction m_CharSelect_Cancel;
    private readonly InputAction m_CharSelect_Confirm;
    public struct CharSelectActions
    {
        private @PlayerControls m_Wrapper;
        public CharSelectActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MovementRight => m_Wrapper.m_CharSelect_MovementRight;
        public InputAction @MovementLeft => m_Wrapper.m_CharSelect_MovementLeft;
        public InputAction @AltMovementRight => m_Wrapper.m_CharSelect_AltMovementRight;
        public InputAction @AltMovementLeft => m_Wrapper.m_CharSelect_AltMovementLeft;
        public InputAction @Cancel => m_Wrapper.m_CharSelect_Cancel;
        public InputAction @Confirm => m_Wrapper.m_CharSelect_Confirm;
        public InputActionMap Get() { return m_Wrapper.m_CharSelect; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharSelectActions set) { return set.Get(); }
        public void SetCallbacks(ICharSelectActions instance)
        {
            if (m_Wrapper.m_CharSelectActionsCallbackInterface != null)
            {
                @MovementRight.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovementRight;
                @MovementRight.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovementRight;
                @MovementRight.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovementRight;
                @MovementLeft.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovementLeft;
                @MovementLeft.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovementLeft;
                @MovementLeft.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnMovementLeft;
                @AltMovementRight.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnAltMovementRight;
                @AltMovementRight.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnAltMovementRight;
                @AltMovementRight.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnAltMovementRight;
                @AltMovementLeft.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnAltMovementLeft;
                @AltMovementLeft.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnAltMovementLeft;
                @AltMovementLeft.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnAltMovementLeft;
                @Cancel.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnCancel;
                @Confirm.started -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnConfirm;
                @Confirm.performed -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnConfirm;
                @Confirm.canceled -= m_Wrapper.m_CharSelectActionsCallbackInterface.OnConfirm;
            }
            m_Wrapper.m_CharSelectActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MovementRight.started += instance.OnMovementRight;
                @MovementRight.performed += instance.OnMovementRight;
                @MovementRight.canceled += instance.OnMovementRight;
                @MovementLeft.started += instance.OnMovementLeft;
                @MovementLeft.performed += instance.OnMovementLeft;
                @MovementLeft.canceled += instance.OnMovementLeft;
                @AltMovementRight.started += instance.OnAltMovementRight;
                @AltMovementRight.performed += instance.OnAltMovementRight;
                @AltMovementRight.canceled += instance.OnAltMovementRight;
                @AltMovementLeft.started += instance.OnAltMovementLeft;
                @AltMovementLeft.performed += instance.OnAltMovementLeft;
                @AltMovementLeft.canceled += instance.OnAltMovementLeft;
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @Confirm.started += instance.OnConfirm;
                @Confirm.performed += instance.OnConfirm;
                @Confirm.canceled += instance.OnConfirm;
            }
        }
    }
    public CharSelectActions @CharSelect => new CharSelectActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnPickUp(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
    }
    public interface IMainMenuActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnSelection(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnAlt_Selection(InputAction.CallbackContext context);
        void OnLSelection(InputAction.CallbackContext context);
        void OnRSelection(InputAction.CallbackContext context);
    }
    public interface ICharSelectActions
    {
        void OnMovementRight(InputAction.CallbackContext context);
        void OnMovementLeft(InputAction.CallbackContext context);
        void OnAltMovementRight(InputAction.CallbackContext context);
        void OnAltMovementLeft(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnConfirm(InputAction.CallbackContext context);
    }
}
