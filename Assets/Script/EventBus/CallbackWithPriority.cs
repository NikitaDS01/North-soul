using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CallbackWithPriority
{
    private int _priority;
    private object _callback;
    public CallbackWithPriority(object callbackIn, int priorityIn)
    {
        _callback = callbackIn;
        _priority = priorityIn;
    }
    public int Priority => _priority;
    public object Callback => _callback;
}
