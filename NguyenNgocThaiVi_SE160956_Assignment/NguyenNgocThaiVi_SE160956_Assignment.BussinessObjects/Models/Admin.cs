﻿using NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace NguyenNgocThaiVi_SE160956_Assignment.BussinessObjects.Models
{
    public class Admin : BaseAuditableEntity
    {
        [ForeignKey("ApplicationUser")]
        public Guid ApplicationUserId { get; set; }


        public virtual ApplicationUser? ApplicationUser { get; set; }
    }
}