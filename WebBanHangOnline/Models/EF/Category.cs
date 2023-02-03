﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBanHangOnline.Models.EF
{
    [Table("tb_Category")]   
    public class Category: CommonAbstract
    {
        public Category()
        {
            this.News = new HashSet<News>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tên danh mục không thể để trống")]
        [StringLength(150)]
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Descreption { get; set; }
        [StringLength(150)]
        public string SeoKeywords { get; set; }
        [StringLength(250)]
        public string SeoDesception { get; set; }
        [StringLength(150)]
        public string SeoTitle { get; set; }
        public int Position { get; set; }
        public bool IsActive { get; set; }
        public ICollection<News> News { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}