using System.Collections;

namespace Zadanie_03
{
    //Zadanie 3.2
    class Queue : ArrayList
    {
        public void Enqueue(Object value) 
        {
            Add(value);
        }

        public Object Dequeue() 
        {
            Object result = null;

            if (base.Count > 0)
            {
                result = base[0];
                RemoveAt(0);
            }

            return result;
        }

    }

    class Queue2
    {
        private ArrayList al;

        public Queue2() 
        {
            al = new ArrayList();
        }

        public void Enqueue(Object value) 
        {
            al.Add(value);
        }
        public Object Dequeue() 
        {
            Object result = null;
            if ( al.Count > 0 )
            {
                result = al[0];
                al.RemoveAt(0);
            }

            return result;
        }

    }
}
