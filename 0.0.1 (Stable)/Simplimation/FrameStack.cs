using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Simplimation
{
    public partial class FrameStack : ObservableCollection<frame>
    {
       
        
        //add frames
        public void append(ref FrameStack working, frame ins)
        {
            working.Add(ins);
        }

        //rem frame
        public void remover(ref FrameStack working, int kill)
        {
            working.RemoveAt(kill);

        }

        //rem all
        public void clear(ref FrameStack working)
        {
            working.Clear();
        }

        //moving frames
        public void move(ref FrameStack working, int to, ref frame x)
        {
            frame copy = x;
            working.Remove(x);
            working.Insert(to, copy);


        }




    }
}
