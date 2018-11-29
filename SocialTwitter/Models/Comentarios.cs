using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialTwitter.Models
{
    public class Comentarios
    {
        [Key]
        public int ComentarioID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Comentario { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<SubComentario> SubComentarios { get; set; }
    }
}