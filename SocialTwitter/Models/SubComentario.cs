using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialTwitter.Models
{
    public class SubComentario
    {
        [Key]
        public int subComentarioID { get; set; }

        [DataType(DataType.Text)]
        public string subcomentario { get; set; }

        public int ComentarioID { get; set; }

        public virtual Comentarios Comentarios { get; set; }
    }
}