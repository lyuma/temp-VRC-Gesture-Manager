﻿using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace GestureManager.Scripts.Core.Editor
{
    /**
     * Hi, you're a curious one!
     * 
     * What you're looking at are some of the methods of my Unity Libraries.
     * They do not contains all the methods otherwise the UnityPackage would have been so much bigger.
     * 
     * P.S: Gmg stands for GestureManager~
     */
    public static class GmgVisualElementExtensions
    {
        public static T MyAdd<T>(this VisualElement visualElement, T child) where T : VisualElement
        {
            visualElement.Add(child);
            return child;
        }

        public static T With<T>(this T visualElement, VisualElement child) where T : VisualElement
        {
            visualElement.Add(child);
            return visualElement;
        }

        public static T MyBorder<T>(this T visualElement, float width, float radius, Color color) where T : VisualElement
        {
            visualElement.style.borderBottomRightRadius = radius;
            visualElement.style.borderBottomLeftRadius = radius;
            visualElement.style.borderTopRightRadius = radius;
            visualElement.style.borderTopLeftRadius = radius;
            visualElement.style.borderBottomWidth = width;
            visualElement.style.borderRightWidth = width;
            visualElement.style.borderLeftWidth = width;
            visualElement.style.borderTopWidth = width;
            visualElement.style.borderBottomColor = color;
            visualElement.style.borderRightColor = color;
            visualElement.style.borderLeftColor = color;
            visualElement.style.borderTopColor = color;
            return visualElement;
        }

        public static void MySetAntiAliasing(this EditorWindow window, int antiAliasing)
        {
            if (!window || window.GetAntiAliasing() == antiAliasing) return;

            window.SetAntiAliasing(antiAliasing);
            // Dumb workaround method to trigger the internal MakeParentsSettingsMatchMe() method on the EditorWindow.
            window.minSize = window.minSize;
        }
    }
}