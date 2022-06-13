using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public sealed class GenericSingleton<T>
    {
        private static readonly GenericSingleton<T> instance = new GenericSingleton<T>();
        T data = (T)default;
        public T Data {
            get { return data; }

            set {
                if (data.Equals((T)default))
                    data = value;    
            } 
        }

        static GenericSingleton()
        {

        }
        private GenericSingleton()
        {

        }

        public static GenericSingleton<T> Instance
        {
            get
            {
                return instance;
            }
                
        }
        

    }
}
