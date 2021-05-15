using System;
using System.ComponentModel.DataAnnotations;

namespace WhiteBlog.Models
{
    public class Blog
    {
        /* 用户账户的数据模型 */
        public string Id { get; set; }
        [Required] public string Title { get; set; } // 文章标题
        [Required] public string Body { get; set; } // 文章主体
        [Required] public string[] Tags { get; set; } // 文章标签
        public DateTime CreatedDate { get; set; } // 创建时间
        public DateTime LastEditedDate { get; set; } // 最后一次修改时间
    }
}