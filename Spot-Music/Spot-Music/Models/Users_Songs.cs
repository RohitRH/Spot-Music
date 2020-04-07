using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spot_Music.Models
{
    public class Users_Songs
    {
        [Key]
        [Column(Order =0)]
        [ForeignKey("Songs")]
        public int SongId { get; set; }
        [Key]
        [Column(Order =1)]
        [ForeignKey("Users")]
        public int UserId { get; set; }

        public virtual Song Song { get; set; }
        public virtual Users Users  { get; set; }
        
    }
}
