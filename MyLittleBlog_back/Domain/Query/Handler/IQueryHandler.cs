using MyLittleBlog_back.Domain.Query.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleBlog_back.Domain.Query.Handler
{
    /// <summary>
    /// in keyword indicate contravariant parameter, allowing less typed assinment.
    /// out keyword indicate covariant parametere allowing more typed assinment than the original object only.
    /// TResponse is used as return statment. 
    /// </summary>
    /// <typeparam name="TQuery"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IQueryHandler<in TQuery, out TResponse> where TQuery : IQuery<TResponse>
    {
        TResponse Get();
    }
}
