using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractWork : MonoBehaviour
{
    public abstract void Run(GameEventArgs args);
}
