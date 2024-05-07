using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adonet_db_videogame
{

    public class Videogioco
    {
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Overview { get; set; }
        public DateTime CreatedAt {  get; set; }
        public DateTime UpdatedAt { get; set; }
        public int SoftwareHouseID { get; set; }

        public Videogioco(string nome, DateTime dataDiRilascio, string overview, DateTime createdAt, DateTime updatedAt, int softwareHouseID)
        {
            Name = nome;
            ReleaseDate = dataDiRilascio;
            Overview = overview;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            SoftwareHouseID = softwareHouseID;
        }
    }
}
