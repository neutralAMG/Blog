﻿

using Blog.Infraestructure.Identity.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Entities
{
	public class CommentLike : BaseEntity, IBaseSoftDeleteEntity
	{
		public string UserId { get; set; }
		public int CommentId { get; set; }
		[ForeignKey("CommentId")]
		public Comment Comment { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }
        public DateTime DeleteTime { get; set; }
    }
}
