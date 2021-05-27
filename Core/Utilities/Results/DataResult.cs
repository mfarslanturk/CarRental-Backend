using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T>:Result,IDataResult<T>
    { 
        public DataResult(T data,bool sucsess, string message) : base(sucsess, message)
        {
            Data = data;
        }

        public DataResult(T data, bool sucsess) : base(sucsess)
        {
            Data = data;
        }

        public T Data { get; }

        
    }
}
