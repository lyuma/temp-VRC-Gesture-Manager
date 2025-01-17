﻿#if VRC_SDK_VRCSDK3
using System.Collections.Generic;
using GestureManager.Scripts.Core;
using UnityEditor.Animations;
using UnityEngine;
using VRC.SDK3.Avatars.Components;
using ValueType = VRC.SDK3.Avatars.ScriptableObjects.VRCExpressionParameters.ValueType;
using AnimLayerType = VRC.SDK3.Avatars.Components.VRCAvatarDescriptor.AnimLayerType;
using BlendablePlayableLayer = VRC.SDKBase.VRC_PlayableLayerControl.BlendableLayer;
using BlendableAnimatorLayer = VRC.SDKBase.VRC_AnimatorLayerControl.BlendableLayer;
using TrackingType = VRC.SDKBase.VRC_AnimatorTrackingControl.TrackingType;

namespace GestureManager.Scripts.Editor.Modules.Vrc3
{
    public static class ModuleVrc3Styles
    {
        private static GUIStyle _url;
        private static GUIStyle _urlPro;

        private static Texture2D _emojis;
        private static Texture2D _option;
        private static Texture2D _expressions;
        private static Texture2D _noExpressions;
        private static Texture2D _back;
        private static Texture2D _backHome;
        private static Texture2D _default;
        private static Texture2D _reset;
        private static Texture2D _twoAxis;
        private static Texture2D _fourAxis;
        private static Texture2D _radial;
        private static Texture2D _toggle;
        private static Texture2D _runningParam;
        private static Texture2D _axisUp;
        private static Texture2D _axisRight;
        private static Texture2D _axisDown;
        private static Texture2D _axisLeft;
        private static Texture2D _supportLike;
        private static Texture2D _supportHeart;

        internal static GUIStyle Url => _url ?? (_url = new GUIStyle(GUI.skin.label) { padding = new RectOffset(-3, -3, 1, 0), normal = { textColor = Color.blue } });
        internal static GUIStyle UrlPro => _urlPro ?? (_urlPro = new GUIStyle(GUI.skin.label) { padding = new RectOffset(-3, -3, 1, 0), normal = { textColor = Color.cyan } });

        internal static Texture2D Emojis => _emojis ? _emojis : _emojis = Resources.Load<Texture2D>("Vrc3/BSX_GM_Emojis");
        internal static Texture2D Option => _option ? _option : _option = Resources.Load<Texture2D>("Vrc3/BSX_GM_Option");
        internal static Texture2D Expressions => _expressions ? _expressions : _expressions = Resources.Load<Texture2D>("Vrc3/BSX_GM_Expressions");
        internal static Texture2D NoExpressions => _noExpressions ? _noExpressions : _noExpressions = Resources.Load<Texture2D>("Vrc3/BSX_GM_No_Expressions");
        internal static Texture2D Back => _back ? _back : _back = Resources.Load<Texture2D>("Vrc3/BSX_GM_Back");
        internal static Texture2D BackHome => _backHome ? _backHome : _backHome = Resources.Load<Texture2D>("Vrc3/BSX_GM_BackHome");
        internal static Texture2D Default => _default ? _default : _default = Resources.Load<Texture2D>("Vrc3/BSX_GM_Default");
        internal static Texture2D Reset => _reset ? _reset : _reset = Resources.Load<Texture2D>("Vrc3/BSX_GM_Reset");
        internal static Texture2D TwoAxis => _twoAxis ? _twoAxis : _twoAxis = Resources.Load<Texture2D>("Vrc3/BSX_GM_2_Axis");
        internal static Texture2D FourAxis => _fourAxis ? _fourAxis : _fourAxis = Resources.Load<Texture2D>("Vrc3/BSX_GM_4_Axis");
        internal static Texture2D Radial => _radial ? _radial : _radial = Resources.Load<Texture2D>("Vrc3/BSX_GM_Radial");
        internal static Texture2D Toggle => _toggle ? _toggle : _toggle = Resources.Load<Texture2D>("Vrc3/BSX_GM_Toggle");
        internal static Texture2D RunningParam => _runningParam ? _runningParam : _runningParam = Resources.Load<Texture2D>("Vrc3/BSX_GM_Running_Param");
        internal static Texture2D AxisUp => _axisUp ? _axisUp : _axisUp = Resources.Load<Texture2D>("Vrc3/BSX_GM_Axis_Up");
        internal static Texture2D AxisRight => _axisRight ? _axisRight : _axisRight = Resources.Load<Texture2D>("Vrc3/BSX_GM_Axis_Right");
        internal static Texture2D AxisDown => _axisDown ? _axisDown : _axisDown = Resources.Load<Texture2D>("Vrc3/BSX_GM_Axis_Down");
        internal static Texture2D AxisLeft => _axisLeft ? _axisLeft : _axisLeft = Resources.Load<Texture2D>("Vrc3/BSX_GM_Axis_Left");
        internal static Texture2D SupportLike => _supportLike ? _supportLike : _supportLike = Resources.Load<Texture2D>("Vrc3/BSX_GM_Support_Like");
        internal static Texture2D SupportHeart => _supportHeart ? _supportHeart : _supportHeart = Resources.Load<Texture2D>("Vrc3/BSX_GM_Support_Heart");

        public static class Data
        {
            private const string VrcSdk3ControllerPath = "Vrc3/Controllers/";
            private const string VrcSdk3RestorePath = "Vrc3/Controllers/Restore/";

            private static AnimatorController ControllerOfPath(string path) => Resources.Load<AnimatorController>(VrcSdk3ControllerPath + path);

            private static TextAsset RestoreOfPath(string path) => Resources.Load<TextAsset>(VrcSdk3RestorePath + path);

            internal static TextAsset RestoreOf(AnimLayerType type) => RestoreOfPath(NameOf[type]);

            internal static AnimatorController ControllerOf(AnimLayerType type) => ControllerOfPath(NameOf[type]);

            public static int LayerSort(VRCAvatarDescriptor.CustomAnimLayer x, VRCAvatarDescriptor.CustomAnimLayer y) => SortValue[x.type] - SortValue[y.type];

            private static readonly Dictionary<AnimLayerType, string> NameOf = new Dictionary<AnimLayerType, string>
            {
                { AnimLayerType.FX, "GmgFxLayer" },
                { AnimLayerType.Base, "GmgBaseLayer" },
                { AnimLayerType.TPose, "GmgUtilityTPose" },
                { AnimLayerType.Action, "GmgActionLayer" },
                { AnimLayerType.IKPose, "GmgUtilityIKPose" },
                { AnimLayerType.Gesture, "GmgGestureLayer" },
                { AnimLayerType.Sitting, "GmgSittingLayer" },
                { AnimLayerType.Additive, "GmgAdditiveLayer" }
            };

            internal static readonly Dictionary<BlendableAnimatorLayer, AnimLayerType> AnimatorToLayer = new Dictionary<BlendableAnimatorLayer, AnimLayerType>
            {
                { BlendableAnimatorLayer.FX, AnimLayerType.FX },
                { BlendableAnimatorLayer.Action, AnimLayerType.Action },
                { BlendableAnimatorLayer.Gesture, AnimLayerType.Gesture },
                { BlendableAnimatorLayer.Additive, AnimLayerType.Additive }
            };

            internal static readonly Dictionary<BlendablePlayableLayer, AnimLayerType> PlayableToLayer = new Dictionary<BlendablePlayableLayer, AnimLayerType>
            {
                { BlendablePlayableLayer.FX, AnimLayerType.FX },
                { BlendablePlayableLayer.Action, AnimLayerType.Action },
                { BlendablePlayableLayer.Gesture, AnimLayerType.Gesture },
                { BlendablePlayableLayer.Additive, AnimLayerType.Additive }
            };

            internal static readonly Dictionary<AnimLayerType, int> SortValue = new Dictionary<AnimLayerType, int>
            {
                { AnimLayerType.Base, 0 },
                { AnimLayerType.Additive, 1 },
                { AnimLayerType.Sitting, 2 },
                { AnimLayerType.TPose, 3 },
                { AnimLayerType.IKPose, 4 },
                { AnimLayerType.Gesture, 5 },
                { AnimLayerType.Action, 6 },
                { AnimLayerType.FX, 7 }
            };

            internal static readonly Dictionary<AnimLayerType, AvatarMask> MaskOf = new Dictionary<AnimLayerType, AvatarMask>
            {
                { AnimLayerType.Base, null },
                { AnimLayerType.Action, null },
                { AnimLayerType.Sitting, null },
                { AnimLayerType.Additive, null },
                { AnimLayerType.FX, Masks.Empty },
                { AnimLayerType.TPose, Masks.MuscleOnly },
                { AnimLayerType.IKPose, Masks.MuscleOnly },
                { AnimLayerType.Gesture, Masks.HandsOnly }
            };

            internal static readonly Dictionary<ValueType, AnimatorControllerParameterType> TypeOf = new Dictionary<ValueType, AnimatorControllerParameterType>
            {
                { ValueType.Int, AnimatorControllerParameterType.Int },
                { ValueType.Bool, AnimatorControllerParameterType.Bool },
                { ValueType.Float, AnimatorControllerParameterType.Float }
            };

            public static readonly AnimationClip[] GestureClips =
            {
                new AnimationClip { name = GestureManagerStyles.Data.GestureNames[0] },
                new AnimationClip { name = GestureManagerStyles.Data.GestureNames[1] },
                new AnimationClip { name = GestureManagerStyles.Data.GestureNames[2] },
                new AnimationClip { name = GestureManagerStyles.Data.GestureNames[3] },
                new AnimationClip { name = GestureManagerStyles.Data.GestureNames[4] },
                new AnimationClip { name = GestureManagerStyles.Data.GestureNames[5] },
                new AnimationClip { name = GestureManagerStyles.Data.GestureNames[6] },
                new AnimationClip { name = GestureManagerStyles.Data.GestureNames[7] }
            };

            public static Dictionary<string, TrackingType> DefaultTrackingState => new Dictionary<string, TrackingType>
            {
                { "Head", TrackingType.Tracking },
                { "Left Hand", TrackingType.Tracking },
                { "Right Hand", TrackingType.Tracking },
                { "Hip", TrackingType.Tracking },
                { "Left Foot", TrackingType.Tracking },
                { "Right Foot", TrackingType.Tracking },
                { "Left Fingers", TrackingType.Tracking },
                { "Right Fingers", TrackingType.Tracking },
                { "Eye & Eyelid", TrackingType.Tracking },
                { "Mouth & Jaw", TrackingType.Tracking }
            };
        }

        private static class Masks
        {
            internal static AvatarMask Empty => GmgAvatarMaskHelper.CreateEmptyMask("Empty");

            internal static AvatarMask MuscleOnly => GmgAvatarMaskHelper.CreateMaskWithout("MuscleOnly", new[]
            {
                AvatarMaskBodyPart.LeftFootIK,
                AvatarMaskBodyPart.LeftHandIK,
                AvatarMaskBodyPart.RightFootIK,
                AvatarMaskBodyPart.RightHandIK
            });

            internal static AvatarMask HandsOnly => GmgAvatarMaskHelper.CreateMaskWith("HandsOnly", new[]
            {
                AvatarMaskBodyPart.LeftFingers,
                AvatarMaskBodyPart.RightFingers
            });
        }
    }
}
#endif