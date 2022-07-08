public class EventSystem
{
    public delegate void EventHandler();

    public static event EventHandler OnWindowsCloseNeeded;
    public static void CallOnWindowsCloseNeeded() { if (OnWindowsCloseNeeded != null) OnWindowsCloseNeeded(); }

}