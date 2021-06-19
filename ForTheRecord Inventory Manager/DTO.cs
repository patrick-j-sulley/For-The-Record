using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTheRecord_Inventory_Manager
{
    /// <summary>
    /// The Class Object for the Artist
    /// </summary>
    public class clsArtist
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public List<clsAlbum> AlbumsList { get; set; }
    }

    /// <summary>
    /// The Class Object for the Album
    /// </summary>
    public class clsAlbum
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string ArtistName { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public DateTime LastModified { get; set; }
        public float Tracks { get; set; }
        public float Stock { get; set; }
        public float? Discs { get; set; } //CD
        public Boolean? Single { get; set; } //CD
        public float? Sides { get; set; } //Vinyl
        public Boolean? Limited { get; set; } //Vinyl
        public Boolean? BoxSet { get; set; } //Vinyl

        /// <summary>
        /// ToString Method for the Album Details
        /// </summary>
        /// <returns>Formatted Album Details</returns>
        public override string ToString()
        {
            return Name + "\t" + Type + "\t" + Stock + "\t" + LastModified.ToShortDateString();
        }

        /// <summary>
        /// A method that instanstiates a new ClsAlbum, which then returns the Album Type
        /// </summary>
        /// <param name="prChoice">The choice of album type that the user has seleted</param>
        /// <returns>Returns the new instanstiation of a ClsAlbum alongside the type of album that the user selected</returns>
        public static clsAlbum NewAlbum(string prChoice)
        {
            return new clsAlbum() { Type = prChoice };
        }

        public static readonly string FACTORY_PROMPT = "Select Album Type";


    }

    /// <summary>
    /// The Class Object for the Order
    /// </summary>
    public class clsOrder
    {
        public float ID { get; set; }
        public string AlbumName { get; set; }
        public string AlbumType { get; set; }
        public string Status { get; set; }
        public float Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime DateTime { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }

    }
}
