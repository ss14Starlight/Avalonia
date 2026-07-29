using System;

namespace Avalonia.X11
{
    internal static class XEmbedHelper
    {
        public static void Send(
            IntPtr display,
            IntPtr window,
            XEmbedMessage message,
            IntPtr detail = default,
            IntPtr data1 = default,
            IntPtr data2 = default)
        {
            var xEmbedAtom = XLib.XInternAtom(display, "_XEMBED", false);

            var ev = default(XEvent);
            ev.ClientMessageEvent.type = XEventName.ClientMessage;
            ev.ClientMessageEvent.window = window;
            ev.ClientMessageEvent.message_type = xEmbedAtom;
            ev.ClientMessageEvent.format = 32;
            ev.ClientMessageEvent.ptr1 = IntPtr.Zero;
            ev.ClientMessageEvent.ptr2 = (IntPtr)(long)message;
            ev.ClientMessageEvent.ptr3 = detail;
            ev.ClientMessageEvent.ptr4 = data1;
            ev.ClientMessageEvent.ptr5 = data2;

            XLib.XSendEvent(display, window, false, IntPtr.Zero, ref ev);
        }
    }
}
