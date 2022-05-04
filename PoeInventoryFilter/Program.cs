using EventHook;
using System;
using System.Threading;

namespace PoeInventoryFilter
{
    class Program
    {
        [MTAThread]
        static void Main(string[] args)
        {
            //Read Cfgs
            string ringpath = "Cfg\\Rings.cfg";
            FilterSet rings = new FilterSet(ringpath);
            Console.WriteLine("Hello World!");

            //Launch Overlay


            //Apply hooks
            using (var eventHookFactory = new EventHookFactory())
            {
                //Console.WriteLine("Hooked");
                var mouseWatcher = eventHookFactory.GetMouseWatcher();
                mouseWatcher.Start();
                mouseWatcher.OnMouseInput += MouseDownEvent;

                using (var overlay = new Overlay())
                {
                    overlay.Run();
                }


                Console.Read();
            }
        }

        static void MouseDownEvent(object sender, EventHook.MouseEventArgs e)
        {
            if (e.Message == EventHook.Hooks.MouseMessages.WM_LBUTTONDOWN)
            {
                
                //GetAsyncKeyState(VK_LCONTROL);
                Console.WriteLine(string.Format("Mouse event {0} at point {1},{2}", e.Message.ToString(), e.Point.x, e.Point.y));
               
                //if Shift+LMB
                if (KBInput.IsCtrlDown())
                    Console.WriteLine("Ctrl down");
                
                //if CTRL+LMB
                else if (KBInput.IsShiftDown())
                    Console.WriteLine("Shift down");


            }
        }
    }
}
