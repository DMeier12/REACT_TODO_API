// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDo_Data
{
    [Table("UserId")]
    public partial class UserId
    {
        [Key]
        [Column("UserID")]
        public int UserId1 { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Username { get; set; }

        [StringLength(50)]
        [Unicode(false)]
        public string Password { get; set; }
    }
}