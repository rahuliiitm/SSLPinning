using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SSLPinningServer.Model
{
    public class PostDetails
    {
        [JsonPropertyName("PostId")]
        public int Id { get; set; }
        [JsonPropertyName("Description")]
        public string Text { get; set; }

        [JsonPropertyName("LikeCount")]
        public int LikeCount { get; set; }

        [JsonPropertyName("CommentsList")]
        public List<CommentDetails> Comments { get; set; }


    }
     public class CommentDetails
    {
        [JsonPropertyName("CommentId")]
        public int Id { get; set; }
        [JsonPropertyName("Comment")]
        public string Comment { get; set; }

    }
}
