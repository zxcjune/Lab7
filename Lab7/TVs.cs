using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    public class TV : IComparable
    {
        public string Model { get; set; }
        public string Display { get; set; }
        public int Cores { get; set; }
        public string Resolution { get; set; }
        public string Platform { get; set; }
        public bool HasTuner { get; set; }
        public bool HasAI { get; set; }

        public string TV4k
        {
            get
            {
                return Is4k() ? "TV has 4k" : "TV doesn't have 4k";
            }
        }

        public bool Is4k()
        {

            if (!string.IsNullOrEmpty(Display) && Display[0] == '4')
            {
                return true;
            }
            return false;
        }

        public TV()
        {

        }

        public TV(string model, string display, int cores, string resolution, string platform, bool hasTuner, bool hasAI)
        {
            Model = model;
            Display = display;
            Cores = cores;
            Resolution = resolution;
            Platform = platform;
            HasTuner = hasTuner;
            HasAI = hasAI;
        }

        public string Info()
        {
                return Model + ", " + Display + ", " + Resolution;
        }

        public int CompareTo(object obj)
        {
            TV tv = obj as TV;
            return string.Compare(this.Model, tv.Model);
        }
    }
}
