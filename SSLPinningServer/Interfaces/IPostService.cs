using SSLPinningServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSLPinningServer.Interfaces
{
    public interface IPostService
    {
        Task<PostDetails> Get(int id);
        Task<List<PostDetails>> All();
    }
}
