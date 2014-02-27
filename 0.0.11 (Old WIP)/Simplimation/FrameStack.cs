using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Simplimation
{
    public partial class FrameStack
    {
        public List<frame> working = new List<frame>();
        
        //add frames
        public void append(frame ins)
        {
            working.Add(ins);
        }

        //rem frame
        public void remover(int kill)
        {
            working.RemoveAt(kill);

        }

        //rem all
        public void clear()
        {
            working.Clear();
        }

        //moving frames
        public void move(int to, ref frame x)
        {
            frame copy = x;
            working.Remove(x);
            working.Insert(to, copy);


        }




    }
}
