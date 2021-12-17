﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Threading;
using OpenTK;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;

namespace HeadshotEngine
{
    public abstract class EngineStart
    {
        private Vector ScreenSize = new Vector(0, 0);
        private string? Title = null;
        private Thread? GameLoopThread = null;
        public Color? BackgroundColor = null;
        public static List<GameObject> AllObjects = new List<GameObject>();
        public Vector CameraPosition = Vector.Zero();
        public float CameraAngle = 0f;
        private GameWindow window;
        public EngineStart(Vector size, string title)
        {
            window = new GameWindow(GameWindowSettings.Default, NativeWindowSettings.Default);
            window.Title = title;
            window.Size = new Vector2i((int)size.x, (int)size.y);
            window.VSync = VSyncMode.On;
            window.KeyUp += KeyUnpressed;
            window.KeyDown += KeyPressed;
            window.MouseDown += MouseClick;
            window.Run();
            Console.OutputEncoding = Encoding.UTF8;
            Console.Title = "Console";
        }
        public abstract void OnLoad();
        public abstract void OnUpdate();
        public abstract void OnDraw();
        public abstract void OnClose();
        public abstract void KeyPressed(KeyboardKeyEventArgs args);
        public abstract void KeyUnpressed(KeyboardKeyEventArgs args);
        public abstract void MouseClick(MouseButtonEventArgs args);
        internal static void Register(GameObject obj)
        {
            AllObjects.Add(obj);
        }
        internal static void UnRegister(GameObject obj)
        {
            AllObjects.Remove(obj);
        }
    }
    public class GameObject 
    {
        internal Type? _type;
        public Type? type
        {
            get
            {
                return _type;
            }
        }
    }
}