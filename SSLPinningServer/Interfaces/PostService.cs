using SSLPinningServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSLPinningServer.Interfaces
{
    public class PostService : IPostService
    {
        Dictionary<int, PostDetails> postRepository = new Dictionary<int, PostDetails>();
        public PostService()
        {
            postRepository.Add(1, new PostDetails
            {
                Text = "Hello all !! This is my First Post",
                Id = 1,
                LikeCount = 3
            });
            postRepository.Add(2, new PostDetails
            {
                Text = "Hello all !! This is my second Post",
                Id = 2,
                LikeCount = 3
            });
            postRepository.Add(3, new PostDetails
            {
                Text = "Hello all !! This is my third Post",
                Id = 3,
                LikeCount = 3
            });

        }
        public Task<PostDetails> Get(int id)
        {
            TaskCompletionSource<PostDetails> tcs = new TaskCompletionSource<PostDetails>();
            if(postRepository.ContainsKey(id))
            {
                tcs.SetResult(postRepository[id]);
            }
            else
            {
                tcs.SetException(new Exception("Key not Found"));
            }
            return tcs.Task;
        }

        public Task<List<PostDetails>> All()
        {
            TaskCompletionSource< List<PostDetails>> tcs = new TaskCompletionSource<List<PostDetails>>();
            List<PostDetails> posts = new List<PostDetails>();
            if (postRepository.Count > 0 )
            {
                foreach(PostDetails post in postRepository.Values)
                {
                    posts.Add(post);
                }
                tcs.SetResult(posts);
            }
            else
            {
                tcs.SetException(new Exception("Key not Found"));
            }
            return tcs.Task;
        }
    }
}
