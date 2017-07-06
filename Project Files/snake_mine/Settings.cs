using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake_mine
{
    public enum directions { up, down, left, right };
    class Settings
    {
        public static int score { get; set; }
        public static int points { get; set; }
        public static bool gameover { get; set; }
        public static directions direction { get; set; }

        public Settings()
        {
            score = 0;
            points = 100;
            gameover = false;
            direction = directions.right;
        }
    }
}
