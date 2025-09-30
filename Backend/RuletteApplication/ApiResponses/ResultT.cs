using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RuletteApplication.ApiResponses;


public class ResultT<T> : Result
{
    public T? Data { get; set; }

    public ResultT(string message, bool success, HttpStatusCode statusCode, T data)
        : base(message, success, statusCode) => this.Data = data;
}