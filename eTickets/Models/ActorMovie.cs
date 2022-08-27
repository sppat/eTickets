using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models
{
    public class ActorMovie
    {
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public Movie Movie { get; set; }

        public int ActorId { get; set; }
        [ForeignKey("ActorId")]
        public Actor Actor { get; set; }
    }
}
