using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AddCompletedActionSignal
{
    private string _nameAction;
    public AddCompletedActionSignal(string nameAction)
    {
        _nameAction = nameAction;
    }
    public string NameAction => _nameAction;
}