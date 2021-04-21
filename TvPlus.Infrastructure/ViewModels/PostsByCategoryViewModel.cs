using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlus.Infrastructure.ViewModels
{
    public class PostsByCategoryViewModel
    {
        public string CategoryTitle { get; set; }

        private List<PostViewModel> _postList;
        public List<PostViewModel> PostList
        {
            get { return _postList ?? (_postList = new List<PostViewModel>()); }
            set { _postList = value; }
        }

        private List<PostViewModel> _bestPosts;
        public List<PostViewModel> BestPosts
        {
            get { return _bestPosts ?? (_bestPosts = new List<PostViewModel>()); }
            set { _bestPosts = value; }
        }
    }
}
