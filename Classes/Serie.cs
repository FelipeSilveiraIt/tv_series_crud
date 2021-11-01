using System;

namespace cadastro_series
{
    public class Serie : BaseEntity
    {
        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false; 

        }
        private Genre Genre { get; set; }

        private string Title { get; set; }

        private string Description { get; set; }

        private int Year { get; set; }

        private bool Deleted {get; set;}

        public override string ToString()
        {
            string output = "";
            output += "Genre: " + this.Genre + Environment.NewLine; 
            output += "Title: " + this.Title + Environment.NewLine; 
            output += "Description: " + this.Description + Environment.NewLine; 
            output += "Publication year: " + this.Year + Environment.NewLine; 
            output += "Deleted " + this.Deleted + Environment.NewLine; 

            return output;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }

        public bool returnDeleted()
        {
            return this.Deleted;
        }

        public void Delete()
        {
            this.Deleted = true;
        }
    }



}